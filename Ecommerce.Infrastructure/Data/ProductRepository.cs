using Ecommerce.Core;
using Ecommerce.Core.Interfaces;
using ECommerce.Infrasctrucure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetProducsAsync()
        {
            var lstProducts = await _context.Products.Include(p => p.ProductBrand)
                                                     .Include(p => p.ProductType)
                                                     .ToListAsync();
            return lstProducts;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.Include(p => p.ProductBrand)
                                                 .Include(p => p.ProductType)
                                                 .FirstOrDefaultAsync(d => d.Id == id);
            return product;
        }

        public async Task<IReadOnlyList<ProductType>> GetProducTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProducBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }
    }
}
