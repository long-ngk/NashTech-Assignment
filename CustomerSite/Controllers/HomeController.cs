using General.DataAccess;
using General.Models;
using General.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Home()
        {
            List<VM_Product> products = _db.Products.ToList()
               .GroupJoin(_db.ProductImages.ToList(),
               p => p.ProductID,
               img => img.Product.ProductID,
               (p, img) => new VM_Product { Product = p, ProductImages = img.ToList() })
               .OrderByDescending(p => p.Product.Views)
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