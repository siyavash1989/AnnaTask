using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Store;

namespace Core.Specifications
{
    public class ProductsFilterCount:BaseSpecification<Product>
    {
         public ProductsFilterCount(ProductSpecParams productParams) :
            base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Title.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.BrandId == productParams.BrandId)
            )
        {

        }
    }
}