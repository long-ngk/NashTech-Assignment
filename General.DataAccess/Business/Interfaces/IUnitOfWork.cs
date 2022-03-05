using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.DataAccess.Business.Interfaces
{
    public interface IUnitOfWork
    {
        IProductCategoryService ProductCategory { get; }
        IProductService Product { get; }
        void Save();
    }
}
