using AutoMapper;
using EComShop.Core.Dtos;
using EComShop.Core.Entities.Product;
using EComShop.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComShop.API.Controllers
{
    public class CategoriesController(IUnitOfWork unitOfWork , IMapper mapper) : BaseController(unitOfWork,mapper)
    {
        [HttpGet("Get All")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await unitOfWork.CategoryRepository.GetAllAsync();
                return Ok(categories ?? Enumerable.Empty<Category>());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("Get By Id")]
        public async Task<IActionResult> GetCategory(int id)
        {
            try
            {
                var category = await unitOfWork.CategoryRepository.GetByIdAsync(id);
                if (category == null)
                    return NotFound("Category not found");
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost("Add Category")]
        public async Task<IActionResult> AddCategory(CategoryDTO categoryDto)
        {
            try
            {
                var category = mapper.Map<Category>(categoryDto);
                await unitOfWork.CategoryRepository.AddAsync(category);
                return Ok("Category added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("Update Category")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDTO categoryDto)
        {
            try
            {
                var category = await unitOfWork.CategoryRepository.GetByIdAsync(id);
                if (category == null)
                    return NotFound("Category not found");
                mapper.Map(categoryDto, category);
                await unitOfWork.CategoryRepository.UpdateAsync(category);
                return Ok("Category updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("Delete Category")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await unitOfWork.CategoryRepository.GetByIdAsync(id);
                if (category == null)
                    return NotFound("Category not found");
                await unitOfWork.CategoryRepository.DeleteAsync(id);
                return Ok("Category deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
