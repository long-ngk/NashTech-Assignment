using AutoMapper;
using EnsureThat;
using General.DataAccess.Business.Interfaces;
using General.Models;
using General.Models.Dtos;

namespace General.DataAccess.Business.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IRepository<ProductCategory> _repository;
        private readonly IMapper _mapper;
        public ProductCategoryService(IRepository<ProductCategory> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductCategoryDto productCategoryDto)
        {
            Ensure.Any.IsNotNull(productCategoryDto, nameof(productCategoryDto));
            var category = _mapper.Map<ProductCategory>(productCategoryDto);
            await _repository.AddAsync(category);
        }

        public async Task<ProductCategoryDto> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductCategoryDto>(category);
        }

        public async Task RemoveAsync(int id)
        {
            await _repository.RemoveAsync(id);
        }

        public async Task UpdateAsync(ProductCategoryDto productCategoryDto)
        {
            var category = _mapper.Map<ProductCategory>(productCategoryDto);
            await _repository.UpdateAsync(category);
        }

        public async Task<IEnumerable<ProductCategoryDto>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductCategoryDto>>(categories);
        }
    }
}
