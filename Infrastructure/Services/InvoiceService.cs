using Core.Entities.Store;
using Core.Entities.Store.Invoice;
using Core.Entities.UserBasket;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Services
{
    public class InvoiceService:IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Invoice> CreateInvoiceAsync(string userEmail, int deliveryMethodId, int basketId, Address address)
        {
            throw new NotImplementedException();
        }

        public async Task<Invoice> CreateOrderAsync(string buyerEmail, int deliveryMethodId, int basketId, Address shippingAddress)
        {
            var basket = await _unitOfWork.Repository<Basket>().GetByIdAsync(basketId);
            var items = new List<InvoiceItem>();
            foreach (var item in basket.Items)
            {
                var product = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(product.Id,
                    product.Title, product.PictureUrl);
                var orderItem = new InvoiceItem(itemOrdered, product.Price, item.Quantity);
                items.Add(orderItem);
            }

            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);
            var subtotal = items.Sum(p => p.Price * p.Quantity) + deliveryMethod.Price;
            var invoice = new Invoice(buyerEmail, shippingAddress, deliveryMethod, items, subtotal);
            //to do save db
            _unitOfWork.Repository<Invoice>().Add(invoice);
            var result = await _unitOfWork.Complete();
            if(result <= 0) return null;
            
            return invoice;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _unitOfWork.Repository<DeliveryMethod>().GetAllAsync();
        }

        public Task<Invoice> GetInvoiceByIdAsync(int id, string userEmail)
        {
            throw new NotImplementedException();
        }

        public async Task<Invoice> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new InvoiceWithItemsAndOrderingSpecification(buyerEmail,id);
            return await _unitOfWork.Repository<Invoice>().GetEntityWithSpecAsync(spec);
        }

        public Task<IReadOnlyList<Invoice>> GetUserInvoicesAsync(string userEmail)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Invoice>> GetUserOrdersAsync(string buyerEmail)
        {
            var spec = new InvoiceWithItemsAndOrderingSpecification(buyerEmail);
            return await _unitOfWork.Repository<Invoice>().GetListWithSpecAsync(spec);
        }
    }
}