using AutoMapper;
using EnsureThat;
using General.DataAccess.Business.Interfaces;
using General.Models;
using General.Models.Dtos;

namespace General.DataAccess.Business.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IRepository<ProductImage> _repository;
        private readonly IMapper _mapper;
        public ProductImageService(IRepository<ProductImage> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddAsync(ProductImageDto productImageDto)
        {
            Ensure.Any.IsNotNull(productImageDto, nameof(productImageDto));
            var productImage = _mapper.Map<ProductImage>(productImageDto);
            await _repository.AddAsync(productImage);
        }

        public async Task<IEnumerable<ProductImageDto>> GetAllAsync()
        {
            var productImages = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductImageDto>>(productImages);
        }

        public async Task<ProductImageDto> GetByIdAsync(int id)
        {
            var productImages = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductImageDto>(productImages);
        }

        public async Task RemoveAsync(ProductImageDto productImageDto)
        {
            var productImage = _mapper.Map<ProductImage>(productImageDto);
            await _repository.RemoveAsync(productImage);
        }

        public async Task UpdateAsync(ProductImageDto productImageDto)
        {
            var productImage = _mapper.Map<ProductImage>(productImageDto);
            await _repository.UpdateAsync(productImage);
        }
    }
}
