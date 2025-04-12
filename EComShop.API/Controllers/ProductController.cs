using AutoMapper;
using EComShop.API.Helper;
using EComShop.Core.Dtos;
using EComShop.Core.Entities.Product;
using EComShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace EComShop.API.Controllers
{
 
    public class ProductController(IUnitOfWork unitOfWork, IMapper mapper) : BaseController(unitOfWork, mapper)
    {
        [HttpGet("Get All")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await unitOfWork.ProductRepository
                    .GetAllAsync(x=>x.Category,x=>x.Photos);
                var productDtos = mapper.Map<List<ProductDTO>>(products);
                return Ok(new ApiResponse<List<ProductDTO>>("Success", productDtos));
            }
            catch (Exception ex)
            {
                return ErrorResponse<List<ProductDTO>>(500, "Failed to retrieve products");
            }
        }
        [HttpGet("Get By Id")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await unitOfWork.ProductRepository
                    .GetByIdAsync(id,x=>x.Category,x=>x.Photos);
                var productDto = mapper.Map<ProductDTO>(product);
                if (product == null)
                    return NotFound("Product not found");
                return Ok(new ApiResponse<ProductDTO>("Success", productDto));
            }
            catch (Exception ex)
            {
                return ErrorResponse<ProductDTO>(500, $"Failed to retrieve product with id {id}");
            }
        }
    
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductDTO addProductDto)
        {
            try
            {
                await unitOfWork.ProductRepository.AddAsync(addProductDto);
                return Ok(new ApiResponse<AddProductDTO>("Success", addProductDto));
            }
            catch (Exception ex)
            {
                return ErrorResponse<ProductDTO>(500, "Failed to add product");
            }
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDto)
        {
            try
            {
                await unitOfWork.ProductRepository.UpdateAsync(updateProductDto);

                return Ok(new ApiResponse<UpdateProductDTO>("Success", updateProductDto));
            }
            catch (Exception ex)
            {
                return ErrorResponse<ProductDTO>(500, "Failed to update product");
            }
        }
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await unitOfWork.ProductRepository
                    .GetByIdAsync(id,p=>p.Photos,p=>p.Category);
                await unitOfWork.ProductRepository.DeleteAsync(product);
                return Ok(new ApiResponse<Product>("Success", product));
            }
            catch (Exception ex)
            {
                return ErrorResponse<ProductDTO>(500, "Failed to delete product");
            }
        }
    }
}
