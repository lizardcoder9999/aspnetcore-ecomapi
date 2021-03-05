using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;

namespace Core.Specifications
{
    public class ProductsWithFiltersCountSpecification : BaseSpecification<Product>
    {

        public ProductsWithFiltersCountSpecification(ProductSpecParams productParams) : base
        
            (x => (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                  (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId && (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        )
        {
            
        }

    }
}
