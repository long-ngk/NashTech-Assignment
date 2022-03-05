using General.DataAccess.Business.Interfaces;
using General.DataAccess.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.DataAccess.Business
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IProductCategoryService ProductCategory { get; private set; }
        public IProductService Product { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ProductCategory = new ProductCategoryService(_db);
            Product = new ProductService(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
