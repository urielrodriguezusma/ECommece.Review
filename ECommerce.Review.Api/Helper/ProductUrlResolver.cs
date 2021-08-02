using AutoMapper;
using Ecommerce.Core;
using ECommerce.Review.Api.Dtos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Review.Api.Helper
{
    // Clase para que en el automapper la propiedad PictureUrl que es de tipo string( Ultimo parametro que se le configura
    // al IValueResolver. Quiero que se le concatene algo. Esta clase la usamos en el profile
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_config["ApiUrl"]}/images/{source.Name.ToLower()}.png";
            }

            return source.PictureUrl;
        }
    }
}
