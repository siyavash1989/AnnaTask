using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Store;

namespace Core.Specifications
{
    public class ProductsWithBrandsSpecifications:BaseSpecification<Product>
    {
        public ProductsWithBrandsSpecifications(ProductSpecParams productParams) :
            base(x =>
                (string.IsNullOrEmpty(productParams.Search) || x.Title.ToLower().Contains(productParams.Search))&&
                (!productParams.BrandId.HasValue || x.BrandId == productParams.BrandId)
            )
        {
            AddIncludes(p => p.Brand);
            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    case "nameDesc":
                        AddOrderByDesc(p => p.Title);
                        break;
                    default:
                        AddOrderBy(p => p.Title);
                        break;
                }
            }

            ApplyPaging(productParams.PageSize*(productParams.PageIndex-1),productParams.PageSize);

        }

        public ProductsWithBrandsSpecifications(int id) : base(x => x.Id == id)
        {
            AddIncludes(p => p.Brand);
        }
    }
}