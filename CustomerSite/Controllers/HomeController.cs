using General.DataAccess;
using General.DataAccess.Business.Interfaces;
using General.Models;
using General.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        public HomeController(IProductService productService,
            IProductImageService productImageService)
        {
            _productService = productService;
            _productImageService = productImageService;
        }

        public async Task<IActionResult> Home()
        {
            var productList = await _productService.GetAllAsync();
            var productImageList = await _productImageService.GetAllAsync();
            IEnumerable<VM_Product> products = productList.GroupJoin
                (productImageList,
               p => p.ProductID,
               img => img.Product.ProductID,
               (p, img) => new VM_Product { ProductDto = p, ProductImageDto = img.ToList() })
               .OrderByDescending(p => p.ProductDto.Views)
               .Take(6).ToList();

            return View(products);
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