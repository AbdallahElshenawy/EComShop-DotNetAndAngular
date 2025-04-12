using AutoMapper;
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
                return Ok(productDtos ?? Enumerable.Empty<ProductDTO>());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductDTO addProductDto)
        {
            try
            {
                await unitOfWork.ProductRepository.AddAsync(addProductDto);
                return Ok(addProductDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDto)
        {
            try
            {
                await unitOfWork.ProductRepository.UpdateAsync(updateProductDto);

                return Ok(updateProductDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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
                return Ok(product);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
