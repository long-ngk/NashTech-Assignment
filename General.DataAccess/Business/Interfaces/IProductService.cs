using General.Models;
using General.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.DataAccess.Business.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task AddAsync(ProductDto productDto);
        Task UpdateAsync(ProductDto productDto);
        Task RemoveAsync(ProductDto productDto);
    }
}
