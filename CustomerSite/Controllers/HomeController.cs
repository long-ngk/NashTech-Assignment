using General.DataAccess.Business;
using General.DataAccess.Business.Interfaces;
using General.Models;
using General.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        private readonly IProductCategoryService _productCategoryService;
        public HomeController(IProductService productService,
            IProductImageService productImageService,
            IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productImageService = productImageService;
            _productCategoryService = productCategoryService;
        }

        public async Task<IActionResult> Home()
        {
            var productList = await _productService.GetAllAsync();
            if (productList == null)
                return NotFound();
            IEnumerable<ProductDto> products = productList.OrderByDescending(p => p.Views).Take(6).ToList();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Category(string searchText = "", int pageNumber = 1, int categoryID = 0)
        {
            const int pageSize = 6;
            if (pageNumber < 1)
                pageNumber = 1;
            if (categoryID < 0)
                categoryID = 0;

            var _categories = await _productCategoryService.GetAllAsync();

            if (_categories == null)
                return NotFound();

            PagerModel<ProductDto> _productsPaged = await _productService.GetAllPagedAsync(pageNumber, pageSize, searchText, categoryID);

            ViewBag.Pager = _productsPaged.Pager;

            string categoryName = "All";
            if (categoryID > 0)
            {
                ProductCategoryDto category = await _productCategoryService.GetByIdAsync(categoryID);
                categoryName = category.CategoryName;
            }
            ViewData["CategoryName"] = categoryName;
            ViewData["CategoryID"] = categoryID;
            ViewData["Categories"] = _categories;
            ViewData["SearchText"] = searchText;

            return View(_productsPaged.DataList);
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var _categories = await _productCategoryService.GetAllAsync();
            return new OkObjectResult(_categories);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}