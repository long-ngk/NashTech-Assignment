using General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.DataAccess.Business.Interfaces
{
    public interface IProductCategoryService : IRepository<ProductCategory>
    {
        void Update(ProductCategory obj);
    }
}
