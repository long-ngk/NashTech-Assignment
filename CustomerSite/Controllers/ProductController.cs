using General.DataAccess;
using General.Models;
using General.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            //IEnumerable<Product> products = from p in _db.Products
            //                                join c in _db.ProductCategories
            //                                on p.ProductCategory.CategoryID equals c.CategoryID
            //                                select p;
            VM_Product? vm_Product = (from p in _db.Products.ToList()
                                      join img in _db.ProductImages.ToList()
                                      on p.ProductID equals img.Product.ProductID
                                      into ProductImageList
                                      join c in _db.ProductCategories.ToList()
                                      on p.ProductCategory.CategoryID equals c.CategoryID
                                      where p.ProductID.Equals(id)
                                      select new VM_Product
                                      {
                                          Product = p,
                                          ProductImages = ProductImageList.ToList(),
                                      }).FirstOrDefault();
            if (vm_Product == null)
            {
                return NotFound();
            }

            return View(vm_Product);
        }
    }
}
