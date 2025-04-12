using AutoMapper;
using EComShop.Core.Interfaces;
using EComShop.Core.Services;
using EComShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComShop.Infrastructure.Repositories
{
    public class UnitOfWork(AppDbContext context, IMapper mapper,IImageManagementService imageManagementService) : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; } = new CategoryRepository(context);
        public IProductRepository ProductRepository { get; } = new ProductRepository(context,mapper,imageManagementService);
        public IPhotoRepository PhotoRepository { get; } = new PhotoRepository(context);
    }
}