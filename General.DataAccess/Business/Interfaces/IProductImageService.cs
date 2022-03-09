using General.Models.Dtos;

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
