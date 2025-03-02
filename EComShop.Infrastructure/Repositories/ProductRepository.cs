using EComShop.Core.Entities.Product;
using EComShop.Core.Interfaces;
using EComShop.Infrastructure.Data;

namespace EComShop.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
    }
}
