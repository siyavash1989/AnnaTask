namespace Core.Entities.Store.Invoice
{
    public class Invoice : BaseEntity
    {
        public Invoice()
        {
        }

        public Invoice(string buyerEmail, Address shippingAddress, DeliveryMethod deliveryMethod, IReadOnlyList<InvoiceItem> invoiceItems, decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = shippingAddress;
            DeliveryMethod = deliveryMethod;
            InvoiceItems = invoiceItems;
            Subtotal = subtotal;
        }

        public string BuyerEmail { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
         public Address ShippingAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<InvoiceItem> InvoiceItems { get; set; }
        public decimal Subtotal { get; set; }
        public InvoiceStatus Status { get; set; } = InvoiceStatus.Pending;
        public string PaymentIntentId { get; set; }
        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }
    }
}