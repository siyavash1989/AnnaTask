using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class InvoiceDto
    {
        public AddressDto ShippingAddress { get; set; }
        public int DeliveryMethodId { get; set; }
        public string BasketId { get; set; }
    }
}