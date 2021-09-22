using ApplicationSOSPet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositorySOSPet.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<Usuario>> GetAll([FromQuery] int? IdUsuario = null)
        {
            Expression<Func<Usuario, bool>> filter = null;

            if (IdUsuario.HasValue) filter = f => f.IdUsuario == IdUsuario.Value;
            return await _app.GetAll(filter);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add(Usuario usuario)
        {
            await _app.Add(usuario);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update(Usuario usuario)
        {
            await _app.Update(usuario);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(Usuario usuario)
        {
            await _app.Delete(usuario);
        }
    }
}
