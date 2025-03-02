using EComShop.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComShop.Infrastructure.Data.Confiq
{
    public class ProductConfiq : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
           builder.Property(x => x.Description).IsRequired();
           builder.Property(x => x.Price).HasColumnType("decimal( 18, 2)");
            builder.HasData(
                    new Product { Id = 1, Name = "Laptop", Description = "Dell Laptop", Price = 50000, CategoryId = 1 },
                    new Product { Id = 2, Name = "Mobile", Description = "Samsung Mobile", Price = 20000, CategoryId = 1 },
                    new Product { Id = 3, Name = "Shirt", Description = "Peter England Shirt", Price = 2000, CategoryId = 2 },
                    new Product { Id = 4, Name = "T-Shirt", Description = "Polo T-Shirt", Price = 1000, CategoryId = 2 },
                    new Product { Id = 5, Name = "Rice", Description = "Basmati Rice", Price = 50, CategoryId = 3 },
                    new Product { Id = 6, Name = "Wheat", Description = "Wheat Flour", Price = 30, CategoryId = 3 }
                );
        }
    }
}
