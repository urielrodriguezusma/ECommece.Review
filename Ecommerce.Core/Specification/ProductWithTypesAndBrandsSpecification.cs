using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Specification
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(int id) : base(d => d.Id == id)
        {
            AddInclude(d => d.ProductBrand);
            AddInclude(d => d.ProductType);
        }
        public ProductWithTypesAndBrandsSpecification()
        {
            AddInclude(d => d.ProductBrand);
            AddInclude(d => d.ProductType);
        }
    }
}
