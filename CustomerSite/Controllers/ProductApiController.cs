using EnsureThat;
using General.DataAccess.Business.Constants;
using General.DataAccess.Business.Interfaces;
using General.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
namespace CustomerSite.Controllers
{
    [Route("api/product")]
    public class ProductApiController : Controller
    {
         private readonly IProductService _productService;
        public ProductApiController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var _categories = await _productService.GetAllAsync();
            return Ok(_categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var _categories = await _productService.GetByIdAsync(id);
            return Ok(_categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductDto productDto)
        {
            Ensure.Any.IsNotNull(productDto, nameof(productDto));
            await _productService.AddAsync(productDto);
            return Created(Endpoints.Category, productDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ProductDto productDto)
        {
            Ensure.Any.IsNotNull(productDto, nameof(productDto));
            await _productService.UpdateAsync(productDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var categoryDto = await _productService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(categoryDto, nameof(categoryDto));
            await _productService.RemoveAsync(id);
            return NoContent();
        }
    }
}