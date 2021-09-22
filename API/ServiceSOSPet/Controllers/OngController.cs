using ApplicationSOSPet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositorySOSPet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<Ong>> GetAll([FromQuery] int? IdUsuario = null)
        {
            Expression<Func<Ong, bool>> filter = null;

            if (IdUsuario.HasValue) filter = f => f.IdUsuario == IdUsuario.Value;
            return await _app.GetAll(filter);
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="ong"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Add(Ong ong)
        {
            await _app.Add(ong);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ong"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task Update(Ong ong)
        {
            await _app.Update(ong);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="ong"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(Ong ong)
        {
            await _app.Delete(ong);
        }
    }
}
