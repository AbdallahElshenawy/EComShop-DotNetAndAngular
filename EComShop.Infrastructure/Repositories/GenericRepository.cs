using EComShop.Core.Interfaces;
using EComShop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EComShop.Infrastructure.Repositories
{
    public class GenericRepository<T>(AppDbContext context) : IGenericRepository<T> where T : class
    {
        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var entity = await context.Set<T>().FindAsync(id) ?? throw new ArgumentNullException("entity not found");
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
           return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includs)
        {
            var quary = context.Set<T>().AsQueryable();
            foreach (var include in includs)
            {
                quary = quary.Include(include);
            }
            return await quary.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id) ?? throw new ArgumentNullException("entity not found");
            return entity;
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includs)
        {
            var query = context.Set<T>().AsQueryable();
            foreach (var include in includs)
            {
                query = query.Include(include);
            }
            return await query.FirstOrDefaultAsync(x => EF.Property<int>(x, "Id") == id);
        }


        public async Task UpdateAsync(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
