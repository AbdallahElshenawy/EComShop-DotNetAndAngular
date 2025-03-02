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
        public Task AddAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Category>> GetAllAsync(params Expression<Func<Category, object>>[] includs)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(int id, params Expression<Func<Category, object>>[] includs)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
