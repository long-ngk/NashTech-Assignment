using General.DataAccess.Business.Interfaces;
using General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.DataAccess.Business.Services
{
    public class ProductCategoryService : Repository<ProductCategory>, IProductCategoryService
    {
        private ApplicationDbContext _db;
        public ProductCategoryService(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ProductCategory obj)
        {
            _db.ProductCategories.Update(obj);
        }
    }
}
