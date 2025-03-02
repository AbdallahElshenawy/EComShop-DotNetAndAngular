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
    public class CategoryConfiq : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
           builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
           builder.Property(x => x.Id).IsRequired();
            builder.HasData(
                 new Category { Id = 1, Name = "Electronics", Description = "Electronic Items" },
                 new Category { Id = 2, Name = "Clothes", Description = "Dresses" },
                 new Category { Id = 3, Name = "Grocery", Description = "Grocery Items" }
             );
        }
    }
}
