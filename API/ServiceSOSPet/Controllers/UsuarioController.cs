using ApplicationSOSPet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ServiceSOSPet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<OngController> _logger;
        private readonly AppUsuario _app;

        public UsuarioController(ILogger<OngController> logger, AppUsuario app)
        {
            _logger = logger;
            _app = app;
        }
        
    }
}
