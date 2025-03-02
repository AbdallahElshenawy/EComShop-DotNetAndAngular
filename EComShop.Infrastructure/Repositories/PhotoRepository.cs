using EComShop.Core.Entities.Product;
using EComShop.Core.Interfaces;
using EComShop.Infrastructure.Data;

namespace EComShop.Infrastructure.Repositories
{
    internal class PhotoRepository(AppDbContext context) : GenericRepository<Photo>(context), IPhotoRepository
    {
    }
}
