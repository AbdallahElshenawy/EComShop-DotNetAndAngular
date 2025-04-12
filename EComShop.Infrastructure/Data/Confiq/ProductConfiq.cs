using EComShop.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EComShop.Infrastructure.Data.Confiq
{
    public class ProductConfiq : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .IsRequired();

            builder.Property(x => x.NewPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.OldPrice)
                .HasColumnType("decimal(18,2)");

            builder.HasData(
                new Product { Id = 1, Name = "Laptop", Description = "Dell Laptop", NewPrice = 50000, OldPrice = 0, CategoryId = 1 },
                new Product { Id = 2, Name = "Mobile", Description = "Samsung Mobile", NewPrice = 20000, OldPrice = 0, CategoryId = 1 },
                new Product { Id = 3, Name = "Shirt", Description = "Peter England Shirt", NewPrice = 2000, OldPrice = 0, CategoryId = 2 },
                new Product { Id = 4, Name = "T-Shirt", Description = "Polo T-Shirt", NewPrice = 1000, OldPrice = 0, CategoryId = 2 },
                new Product { Id = 5, Name = "Rice", Description = "Basmati Rice", NewPrice = 50, OldPrice = 0, CategoryId = 3 },
                new Product { Id = 6, Name = "Wheat", Description = "Wheat Flour", NewPrice = 30, OldPrice = 0, CategoryId = 3 }
            );
        }
    }
}