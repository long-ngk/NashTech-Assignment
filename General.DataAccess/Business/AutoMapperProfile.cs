using General.Models;
using General.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
