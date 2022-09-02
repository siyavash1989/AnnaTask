using API.Dtos;
using AutoMapper;
using Core.Entities.Store;
using Core.Entities.Store.Invoice;
using Core.Entities.UserBasket;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.Brand.Title))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

            CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<Basket, CustomerBasketDto>().ReverseMap();
            CreateMap<BasketItem, CustomerBasketItemDto>().ReverseMap();
            CreateMap<AddressDto, Core.Entities.Store.Invoice.Address>();

            CreateMap<Invoice, InvoiceToReturnDto>()
                .ForMember(d => d.DeliveryMethod,
                    o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice,
                    o => o.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<InvoiceItem, InvoiceItemDto>()
                .ForMember(d => d.ProductId,
                    o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName,
                    o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl,
                    o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
                .ForMember(d=>d.PictureUrl, o=>o.MapFrom<OrderItemValueResolver>());

        }
    }
}