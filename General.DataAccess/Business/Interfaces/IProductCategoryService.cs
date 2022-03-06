using General.Models;
using General.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace General.DataAccess.Business.Interfaces
{
    public interface IProductCategoryService
    {
        Task<ProductCategoryDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductCategoryDto>> GetAllAsync();
        Task AddAsync(ProductCategoryDto productCategoryDto);
        Task UpdateAsync(ProductCategoryDto productCategoryDto);
        Task RemoveAsync(ProductCategoryDto productCategoryDto);
    }
}
