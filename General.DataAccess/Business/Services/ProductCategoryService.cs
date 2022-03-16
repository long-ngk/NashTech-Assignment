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

        public async Task<PagerModel<ProductCategoryDto>> GetAllPagedAsync(int page, int limit, string sortOrder, string sortColumn)
        {
            IEnumerable<ProductCategory> categories;
            if (sortColumn == "id")
            {
                categories = await _repository.GetAllWithSortedAsync(sortOrder, c => c.CategoryID);
            }
            else
            {
                categories = await _repository.GetAllWithSortedAsync(sortOrder, c => c.CategoryName);
            }

            int sourceCount = categories.Count();
            var pager = new Pager(sourceCount, page, limit);

            var listProductCategoryDto = _mapper.Map<List<ProductCategory>, List<ProductCategoryDto>>(categories.ToList());

            //example: when in page 2 skip the number of products already showed in page 1
            int sourceSkip = (page - 1) * limit;
            var categoriesPaged = listProductCategoryDto.Skip(sourceSkip).Take(pager.PageSize).ToList();

            PagerModel<ProductCategoryDto> pagerModel = new PagerModel<ProductCategoryDto>()
            {
                Pager = pager,
                DataList = categoriesPaged
            };

            return pagerModel;
        }
    }
}
