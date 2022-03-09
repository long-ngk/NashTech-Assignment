using General.Models.Dtos;

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
