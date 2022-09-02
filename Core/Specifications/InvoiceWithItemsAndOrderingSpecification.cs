using Core.Entities.Store.Invoice;

namespace Core.Specifications
{
    public class InvoiceWithItemsAndOrderingSpecification:BaseSpecification<Invoice>
    {
        public InvoiceWithItemsAndOrderingSpecification(string email) : base(o => o.BuyerEmail == email)
        {
            AddIncludes(p => p.InvoiceItems);
            AddIncludes(p => p.DeliveryMethod);
            AddOrderByDesc(p => p.InvoiceDate);
        }

        public InvoiceWithItemsAndOrderingSpecification(string email, int id) : base(o => o.BuyerEmail == email && o.Id == id)
        {
            AddIncludes(p => p.InvoiceItems);
            AddIncludes(p => p.DeliveryMethod);
        }
    }
}