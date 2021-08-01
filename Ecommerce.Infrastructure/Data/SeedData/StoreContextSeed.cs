using Ecommerce.Core;
using ECommerce.Infrasctrucure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Data.SeedData
{
    public static class StoreContextSeed
    {
        
        public static async Task SeedStoreDataAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (context.Products.Any())
                {
                    return;
                }

                var productBrand = new List<ProductBrand>
                {
                    new ProductBrand{Name="Rico"},
                    new ProductBrand{Name="CocaCola"},
                    new ProductBrand{Name="Linio"},
                };

                context.ProductBrands.AddRange(productBrand);
                await context.SaveChangesAsync();

                var productTypes = new List<ProductType>
                {
                    new ProductType{Name="Fruit"},
                    new ProductType{Name="Tech"},
                    new ProductType{Name="Milk"},
                    new ProductType{Name="Sodas"}
                };

                context.ProductTypes.AddRange(productTypes);
                await context.SaveChangesAsync();

                var Products = new List<Product>
                {
                    new Product{Name="Cheese",Price=2300,Description="Delicious Cheese",ProductBrandId=1,ProductTypeId=3},
                    new Product{Name="Computer",Price=460000,Description="Dell Core I7",ProductBrandId=3,ProductTypeId=2},
                    new Product{Name="Apple",Price=4600,Description="Green and red apple",ProductBrandId=1,ProductTypeId=1},
                    new Product{Name="Soda",Price=3500,Description="Coca-Cola",ProductBrandId=2,ProductTypeId=4},
                    new Product{Name="Quatro",Price=3200,Description="Quatro Toronja",ProductBrandId=2,ProductTypeId=4}
                };

                context.Products.AddRange(Products);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger(nameof(StoreContextSeed));
                logger.LogError(ex.Message);
            }
        }
    }
}
