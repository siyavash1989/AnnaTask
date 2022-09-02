namespace API.Controllers
{
    public class CartController : ApiBaseController
    {
        private readonly ILogger<CartController> _logger;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }
    }
}