using AutoMapper;
using Ecommerce.Core;
using ECommerce.Review.Api.Dtos;
using ECommerce.Review.Api.Helper;

namespace ECommerce.Review.Api.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<Product, ProductToReturnDto>().ForMember(d => d.ProductBrand, opt => opt.MapFrom(r => r.ProductBrand.Name))
                                                    .ForMember(d => d.ProductType, opt => opt.MapFrom(r => r.ProductType.Name))
                                                    .ForMember(d => d.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());
        }
    }
}
