using System.Runtime.Serialization;

namespace Core.Entities.Store.Invoice
{
    public enum InvoiceStatus
    {
        [EnumMember(Value ="Pending")]
        Pending,
        [EnumMember(Value = "PaymentReceived")]
        PaymentReceived,
        [EnumMember(Value = "PaymentFailed")]
        PaymentFailed
    }
}