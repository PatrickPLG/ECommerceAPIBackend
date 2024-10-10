using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Models;
using ECommerceAPI.Repositories;

namespace ECommerceAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public CategoryController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.GetCategories();
        }

        [HttpGet("{id}")]
        public async Task<Category> GetCategory(int id)
        {
            return await _categoryRepository.GetCategory(id);
        }

        [HttpPost]
        public async Task AddCategory(Category category)
        {
            await _categoryRepository.AddCategory(category);
        }

        [HttpPut]
        public async Task UpdateCategory(Category category)
        {
            await _categoryRepository.UpdateCategory(category);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);
        }

        [HttpGet("{id}/products")]
        public async Task<IActionResult> GetProductsByCategory(int id)
        {
            var category = await _categoryRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }

            var products = await _productRepository.GetProductsByCategory(id);
            return Ok(products);
        }
    }
}
