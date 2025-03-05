using BusinessLogicLayer.IServices;
using DTOs.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Asp.Net.Core.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategorySerivice _categoryService;

        public CategoryController(ICategorySerivice categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddCategoryDto addCategoryDto)
        {
            await _categoryService.AddCategoryAsync(addCategoryDto);
            return Ok();    
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Updated !");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DelertCategoryAsync(id);
            return Ok("Deleted successfully !");
        }

        [HttpGet("categorywithbook")]

        public async Task<IActionResult> GetCategoryWithProducts(int id)
        {
            var cateogry = await _categoryService.GetCategoryWithBooksAsync(id);
            return Ok(cateogry);
        }
    }
}
