using EnsureThat;
using General.DataAccess.Business.Constants;
using General.DataAccess.Business.Interfaces;
using General.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSite.Controllers
{
    [Route("api/category")]
    public class CategoryApiController : Controller
    {
        private readonly IProductCategoryService _productCategoryService;
        public CategoryApiController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var _categories = await _productCategoryService.GetAllAsync();
            return Ok(_categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var _categories = await _productCategoryService.GetByIdAsync(id);
            return Ok(_categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductCategoryDto productCategoryDto)
        {
            Ensure.Any.IsNotNull(productCategoryDto, nameof(productCategoryDto));
            await _productCategoryService.AddAsync(productCategoryDto);
            return Created(Endpoints.Category, productCategoryDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ProductCategoryDto productCategoryDto)
        {
            Ensure.Any.IsNotNull(productCategoryDto, nameof(productCategoryDto));
            await _productCategoryService.UpdateAsync(productCategoryDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var categoryDto = await _productCategoryService.GetByIdAsync(id);
            Ensure.Any.IsNotNull(categoryDto, nameof(categoryDto));
            await _productCategoryService.RemoveAsync(categoryDto);
            return NoContent();
        }
    }
}
