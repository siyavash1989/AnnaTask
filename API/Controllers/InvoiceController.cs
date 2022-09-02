using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InvoiceController : ApiBaseController
    {
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(ILogger<InvoiceController> logger)
        {
            _logger = logger;
        }
    }
}