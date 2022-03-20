using AutoMapper;
using EnsureThat;
using General.DataAccess.Business.Interfaces;
using General.Models;
using General.Models.Dtos;

namespace General.DataAccess.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repositoryProduct;
        private readonly IRepository<ProductCategory> _repositoryProductCategory;
        private readonly IRepository<ProductImage> _repositoryProductImage;
        private readonly IMapper _mapper;
        public ProductService(IRepository<Product> repository,
            IMapper mapper,
            IRepository<ProductImage> repositoryProductImage,
            IRepository<ProductCategory> repositoryProductCategory)
        {
            _repositoryProduct = repository;
            _mapper = mapper;
            _repositoryProductImage = repositoryProductImage;
            _repositoryProductCategory = repositoryProductCategory;
        }

        public async Task AddAsync(ProductDto productDto)
        {
            Ensure.Any.IsNotNull(productDto, nameof(productDto));
            var product = _mapper.Map<Product>(productDto);
            await _repositoryProduct.AddAsync(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var productCategories = await _repositoryProductCategory.GetAllAsync();
            var productImages = await _repositoryProductImage.GetAllAsync();
            var products = await _repositoryProduct.GetAllAsync();
            return _mapper.Map<List<Product>, List<ProductDto>>(products.ToList());
        }

        public async Task<PagerModel<ProductDto>> GetAllPagedAsync(int pageNumber, int pageSize, string searchText, int categoryID)
        {
            var productCategories = await _repositoryProductCategory.GetAllAsync();
            var productImages = await _repositoryProductImage.GetAllAsync();
            var products = await _repositoryProduct.GetAllAsync();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                products = products.Where(p => p.ProdName.Contains(searchText, StringComparison.OrdinalIgnoreCase));
            }

            if (categoryID > 0)
            {
                products = products.Where(p => p.ProductCategory.CategoryID == categoryID);
            }

            int sourceCount = products.Count();
            var pager = new Pager(sourceCount, pageNumber, pageSize);

            var listProductDto = _mapper.Map<List<Product>, List<ProductDto>>(products.ToList());

            //example: when in page 2 skip the number of products already showed in page 1
            int sourceSkip = (pageNumber - 1) * pageSize;
            var productsPaged = listProductDto.Skip(sourceSkip).Take(pager.PageSize).ToList();

            PagerModel<ProductDto> pagerModel = new PagerModel<ProductDto>()
            {
                Pager = pager,
                DataList = productsPaged
            };

            return pagerModel;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _repositoryProduct.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task RemoveAsync(int id)
        {
            await _repositoryProduct.RemoveAsync(id);
        }
        public async Task UpdateAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _repositoryProduct.UpdateAsync(product);
        }
    }
}
