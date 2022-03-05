using General.DataAccess.Business;
using General.DataAccess.Business.Interfaces;
using General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.DataAccess.Business.Services
{
    public class ProductService : Repository<Product>, IProductService
    {
        private ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
