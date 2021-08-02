using AutoMapper;
using Ecommerce.Core;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Specification;
using ECommerce.Review.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Review.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrand;
        private readonly IGenericRepository<ProductType> _productType;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository,
                                  IGenericRepository<ProductBrand> productBrand,
                                  IGenericRepository<ProductType> productType,
                                  IMapper mapper)
        {
            _productRepository = productRepository;
            _productBrand = productBrand;
            _productType = productType;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var spec = new ProductWithTypesAndBrandsSpecification();

            var listProducts = await _productRepository.ListAsync(spec);
            var listProductsToReturn = _mapper.Map<List<ProductToReturnDto>>(listProducts);
            return Ok(listProductsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(id);
            var product = await _productRepository.GetEntityWithSpec(spec);
            var productToReturn = _mapper.Map<ProductToReturnDto>(product);
            return Ok(productToReturn);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var brands = await _productBrand.ListAllAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductTypes()
        {
            var productTypes = await _productType.ListAllAsync();
            return Ok(productTypes);
        }

    }
}
