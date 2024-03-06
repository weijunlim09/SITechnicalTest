using Microsoft.AspNetCore.Mvc;

namespace SITechnicalTest_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotationController : ControllerBase
    {
        private readonly ILogger<QuotationController> _logger;

        public QuotationController(ILogger<QuotationController> logger)
        {
            _logger = logger;
        }
    }
}
