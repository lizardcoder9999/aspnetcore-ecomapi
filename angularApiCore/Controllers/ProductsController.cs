using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using angularApiCore.Dtos;
using angularApiCore.Helpers;
using AutoMapper;
using Core.interfaces;
using Core.Models;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace angularApiCore.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {

        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productsBrandRepo;
        private readonly IGenericRepository<ProductType> _productsTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo,IMapper mapper)
        {
            _productsRepo = productsRepo;
            _productsBrandRepo = productBrandRepo;
            _productsTypeRepo = productTypeRepo;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturn>>> GetProducts([FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);

            var countSpec = new ProductsWithFiltersCountSpecification(productParams);

            var totalItems = await _productsRepo.CountAsync(countSpec);

            var products = await _productsRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturn>>(products);

            return Ok(new Pagination<ProductToReturn>(productParams.PageIndex,productParams.PageSize,totalItems,data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturn>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToReturn>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productsBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productsTypeRepo.ListAllAsync());
        }


    }
}
