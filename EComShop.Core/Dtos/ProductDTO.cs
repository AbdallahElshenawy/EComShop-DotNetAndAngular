﻿
using EComShop.Core.Entities.Product;
using Microsoft.AspNetCore.Http;

namespace EComShop.Core.Dtos
{
    public record ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public virtual List<PhotoDTO> Photos { get; set; }

        public string CategoryName { get; set; }
    
    }
    public record AddProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public int CategoryId { get; set; }
        public IFormFileCollection Photos { get; set; }
    }
    public record UpdateProductDTO : AddProductDTO
    {
        public int Id { get; set; }
    }

    public record PhotoDTO(string ImageName,int ProductId);
}
