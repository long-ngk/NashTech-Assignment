using EnsureThat;
using General.DataAccess.Business;
using General.DataAccess.Business.Constants;
using General.DataAccess.Business.Interfaces;
using General.Models.Dtos;
using General.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSite.Controllers
{
    [ApiController]
    [Route("api/category")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryApiController : ControllerBase
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

        [HttpGet("pagination")]
        public async Task<IActionResult> GetPagedCategory(int page = 1, int limit = 5, string sortOrder = "Accsending", string sortColumn = "Id")
        {
            PagerModel<ProductCategoryDto> _categories = await _productCategoryService.GetAllPagedAsync(page, limit, sortOrder, sortColumn);
            return Ok(_categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var _categories = await _productCategoryService.GetByIdAsync(id);
            if (_categories == null)
                return NotFound();
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
            if (categoryDto == null)
                return NotFound();
            await _productCategoryService.RemoveAsync(id);
            return NoContent();
        }
    }
}
