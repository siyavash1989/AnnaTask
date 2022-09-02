using System.Security.Claims;
using API.Dtos;
using API.Error;
using AutoMapper;
using Core.Entities.Store.Invoice;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InvoiceController : ApiBaseController
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(ILogger<InvoiceController> logger,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IInvoiceService invoiceService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<InvoiceDto>> CreateOrder(InvoiceDto invoiceDto)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
           
            var address = _mapper.Map<AddressDto, Address>(invoiceDto.ShippingAddress);
            
            var order = await _invoiceService.CreateInvoiceAsync(email, invoiceDto.DeliveryMethodId, invoiceDto.BasketId, address);
            
            if (order == null) return BadRequest(new ApiResponse(400, "Bad Request"));
            return Ok(_mapper.Map<Invoice,InvoiceToReturnDto>(order));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<InvoiceDto>>> GetUserOrders()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var orders = await _invoiceService.GetUserInvoicesAsync(email);
            return Ok(_mapper.Map<IReadOnlyList<Invoice>,IReadOnlyList<InvoiceToReturnDto>>(orders));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceToReturnDto>> GetOrderById(int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var invoice = await _invoiceService.GetInvoiceByIdAsync(id, email);
            if (invoice == null)
            {
                return NotFound(new ApiResponse(404, "Not Found"));
            }
            return _mapper.Map<Invoice,InvoiceToReturnDto>(invoice);
        }

        [HttpGet("deliveryMethod")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethod()
        {
            return Ok(await _invoiceService.GetDeliveryMethodsAsync());
        }
    }
}