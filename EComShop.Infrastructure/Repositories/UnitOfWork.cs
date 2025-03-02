using EComShop.Core.Interfaces;
using EComShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComShop.Infrastructure.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; } = new CategoryRepository(context);
        public IProductRepository ProductRepository { get; } = new ProductRepository(context);
        public IPhotoRepository PhotoRepository { get; } = new PhotoRepository(context);
    }
}