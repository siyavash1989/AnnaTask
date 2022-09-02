using Core.Entities.Store.Invoice;

namespace API.Dtos
{
    public class InvoiceToReturnDto
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Address ShippingAddress { get; set; }
        public string DeliveryMethod { get; set; }
        public long ShippingPrice { get; set; }
        public IReadOnlyList<InvoiceItemDto> InvoiceItems { get; set; }
        public long Subtotal { get; set; }
        public string Status { get; set; }
        public long Total { get; set; }
    }
}