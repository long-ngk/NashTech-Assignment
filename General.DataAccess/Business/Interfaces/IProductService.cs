using General.Models.Dtos;

namespace General.DataAccess.Business.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<PagerModel<ProductDto>> GetAllPagedAsync(int pageNumber, int pageSize, string searchText, int categoryID);
        Task AddAsync(ProductDto productDto);
        Task UpdateAsync(ProductDto productDto);
        Task RemoveAsync(ProductDto productDto);
    }
}
