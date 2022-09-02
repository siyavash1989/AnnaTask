using Core.Entities.Store.Invoice;

namespace Core.Interfaces
{
    public interface IInvoiceService
    {
        Task<Invoice> CreateInvoiceAsync(string userEmail, int deliveryMethodId, int basketId, Address address);
        Task<IReadOnlyList<Invoice>> GetUserInvoicesAsync(string userEmail);
        Task<Invoice> GetInvoiceByIdAsync(int id, string userEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync(); 
    }
}