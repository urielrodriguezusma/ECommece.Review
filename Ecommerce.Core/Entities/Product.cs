﻿using Ecommerce.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Core
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType  ProductType { get; set; }
        public int ProductTypeId { get; set; }

        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}
