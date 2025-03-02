using BusinessLogicLayer.IServices;
using DTOs.ProductDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Asp.Net.Core.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;

        public ProductController(IProductService product)
        {
            _product = product;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _product.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductDto addProductDto)
        {
            try
            {
                await _product.AddProductAsync(addProductDto);
                return Ok("Product Added !");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest("Xatolik " + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internel server error: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _product.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductDto updateProductDto)
        {
            await _product.UpdateProductAsync(updateProductDto);
            return Ok("Updated Successfully !");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _product.DeleteProductAsync(id);
            return Ok("Product deleted !");
        }
    }
}
