using General.Models;
using General.Models.Dtos;

namespace General.DataAccess.Business
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            FromDataAccessorLayer();
            FromPresentationLayer();
        }

        private void FromPresentationLayer()
        {
            CreateMap<ProductCategoryDto, ProductCategory>();
            CreateMap<ProductDto, Product>();
            CreateMap<ProductImageDto, ProductImage>();
        }

        private void FromDataAccessorLayer()
        {
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductImage, ProductImageDto>();
        }
    }
}
