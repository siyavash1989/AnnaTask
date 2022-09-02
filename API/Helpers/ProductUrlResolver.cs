using API.Dtos;
using AutoMapper;
using Core.Entities.Store;

namespace API.Helper
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;

        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            return _config["ApiUrl"] + source.PictureUrl;
        }
    }
}