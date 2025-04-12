using AutoMapper;
using EComShop.Core.Dtos;
using EComShop.Core.Entities.Product;
using EComShop.Core.Interfaces;
using EComShop.Core.Services;
using EComShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EComShop.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext context,IMapper mapper,IImageManagementService imageManagementService) : GenericRepository<Product>(context), IProductRepository
    {
        public async Task<bool> AddAsync(AddProductDTO productDTO)
        {
            if(productDTO is null)
                return false;
            var product = mapper.Map<Product>(productDTO);
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            var  imagePath = await imageManagementService.AddImageAsync(productDTO.Photos, productDTO.Name);
            var photo = imagePath.Select(path => new Photo { ImageName = path, ProductId = product.Id }).ToList();
            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;


        }

        public async Task<bool> UpdateAsync(UpdateProductDTO productDTO)
        {
            if (productDTO is null)
                return false;
            var product = await context.Products.Include(p=>p.Category)
                .Include(p => p.Photos).FirstOrDefaultAsync(p => p.Id == productDTO.Id);
            if (product is null)
                return false;
            mapper.Map(productDTO, product);

            var photo = await context.Photos.Where(p => p.ProductId == productDTO.Id).ToListAsync();
            foreach (var p in photo)
            {
                imageManagementService.DeleteImageAsync(p.ImageName);
            }
            context.Photos.RemoveRange(photo);
            var imagePath = await imageManagementService
                .AddImageAsync(productDTO.Photos, productDTO.Name);
            var newPhotos = imagePath.Select(path => new Photo {
                ImageName = path, ProductId = productDTO.Id }).ToList();
            await context.Photos.AddRangeAsync(newPhotos);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task DeleteAsync(Product product)
        {
            if (product is null)
                return;
            var photos = await context.Photos.Where(p => p.ProductId == product.Id).ToListAsync();
            foreach (var p in photos)
            {
                imageManagementService.DeleteImageAsync(p.ImageName);
            }
            context.Photos.RemoveRange(photos);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}
