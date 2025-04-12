using EComShop.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;


namespace EComShop.Infrastructure.Data.Confiq
{
    public class PhotoConfiq : IEntityTypeConfiguration<Photo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Photo> builder)
        {
            builder.HasData(new Photo
            {
                Id = 1,
                ImageName = "product-1.jpg",
                ProductId = 1
            },
                new Photo
                {
                    Id = 2,
                    ImageName = "product-2.jpg",
                    ProductId = 2
                },
                new Photo
                {
                    Id = 3,
                    ImageName = "product-3.jpg",
                    ProductId = 3
                },
                new Photo
                {
                    Id = 4,
                    ImageName = "product-4.jpg",
                    ProductId = 4
                },
                new Photo
                {
                    Id = 5,
                    ImageName = "product-5.jpg",
                    ProductId = 5
                },
                new Photo
                {
                    Id = 6,
                    ImageName = "product-6.jpg",
                    ProductId = 6
                },
                new Photo
                {
                    Id = 7,
                    ImageName = "product-7.jpg",
                    ProductId = 7
                },
                new Photo
                {
                    Id = 8,
                    ImageName = "product-8.jpg",
                    ProductId = 8
                },
                new Photo
                {
                    Id = 9,
                    ImageName = "product-9.jpg",
                    ProductId = 9
                },
                new Photo
                {
                    Id = 10,
                    ImageName = "product-10.jpg",
                    ProductId = 10
                }
            );
        }
    }
}
