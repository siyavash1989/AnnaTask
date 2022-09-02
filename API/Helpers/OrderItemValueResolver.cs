using API.Dtos;
using AutoMapper;
using Core.Entities.Store.Invoice;

namespace API.Helper
{
    public class OrderItemValueResolver : IValueResolver<InvoiceItem, InvoiceItemDto, string>
    {
        private readonly IConfiguration _config;
        public OrderItemValueResolver(IConfiguration config)
        {
            _config = config;

        }
        public string Resolve(InvoiceItem source, InvoiceItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ItemOrdered.PictureUrl))
            {
                return _config["ApiUrl"]+source.ItemOrdered.PictureUrl;
            }
            return null;
        }
    }
}