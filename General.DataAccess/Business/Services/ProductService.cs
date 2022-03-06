using AutoMapper;
using EnsureThat;
using General.DataAccess.Business;
using General.DataAccess.Business.Interfaces;
using General.Models;
using General.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.DataAccess.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        public ProductService(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductDto productDto)
        {
            Ensure.Any.IsNotNull(productDto, nameof(productDto));
            var product = _mapper.Map<Product>(productDto);
            await _repository.AddAsync(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<List<Product>, List<ProductDto>>(products.ToList());
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task RemoveAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _repository.RemoveAsync(product);
        }
        public async Task UpdateAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _repository.UpdateAsync(product);
        }
    }
}
