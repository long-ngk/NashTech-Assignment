using General.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.DataAccess.Business.Interfaces
{
    public interface IProductImageService
    {
        Task<ProductImageDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductImageDto>> GetAllAsync();
        Task AddAsync(ProductImageDto productImageDto);
        Task UpdateAsync(ProductImageDto productImageDto);
        Task RemoveAsync(ProductImageDto productImageDto);
    }
}
