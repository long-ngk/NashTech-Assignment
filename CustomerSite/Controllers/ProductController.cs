using AutoMapper;
using General.DataAccess;
using General.DataAccess.Business.Interfaces;
using General.Models;
using General.Models.Dtos;
using General.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerSite.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductImageService _productImageService;
        public ProductController(IProductService productService,
            IProductCategoryService productCategoryService,
            IProductImageService productImageService
           )
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _productImageService = productImageService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var productCategoryList = await _productCategoryService.GetAllAsync();
            var productImageList = await _productImageService.GetAllAsync();

            var product = await _productService.GetByIdAsync((int)id);
            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}
