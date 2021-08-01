using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProducsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProducBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProducTypesAsync();


    }
}
