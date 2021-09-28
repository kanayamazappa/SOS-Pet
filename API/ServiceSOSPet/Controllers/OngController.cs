using ApplicationSOSPet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ServiceSOSPet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OngController : ControllerBase
    {
        private readonly ILogger<OngController> _logger;
        private readonly AppOng _app;

        public OngController(ILogger<OngController> logger, AppOng app)
        {
            _logger = logger;
            _app = app;
        }
    }
}
