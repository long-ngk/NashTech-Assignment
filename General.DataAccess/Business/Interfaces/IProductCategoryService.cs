using General.Models.Dtos;

namespace General.DataAccess.Business.Interfaces
{
    public interface IProductCategoryService
    {
        Task<ProductCategoryDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductCategoryDto>> GetAllAsync();
        Task<PagerModel<ProductCategoryDto>> GetAllPagedAsync(int page, int limit, string sortOrder, string sortColumn);
        Task AddAsync(ProductCategoryDto productCategoryDto);
        Task UpdateAsync(ProductCategoryDto productCategoryDto);
        Task RemoveAsync(int id);
    }
}
