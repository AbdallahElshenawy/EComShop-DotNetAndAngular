using EComShop.Core.Entities.Product;
using EComShop.Core.Interfaces;
using EComShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EComShop.Infrastructure.Repositories
{
    public class CategoryRepository(AppDbContext context) : GenericRepository<Category>(context) , ICategoryRepository
    {
        
    }
}
