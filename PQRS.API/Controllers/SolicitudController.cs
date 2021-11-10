using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PQRS.API.Controllers
{
    using Models;
    using helpers;

    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        // GET: api/<SolicitudController>
        [HttpGet("tipoSolicitud")]
        public IEnumerable<Solicitud> Get(string tipoSolicitud)
        {
            switch (tipoSolicitud)
            {
                case SolicitudType.PETICION:
                    Peticion item = new Peticion();
                    return item.GetAll();
                case SolicitudType.QUEJA:
                    break;
                case SolicitudType.RECLAMO:
                    break;
                case SolicitudType.SUGERENCIA:
                    break;
                case SolicitudType.FELICITACION:
                    break;
                default:
                    break;
            }
            return null;
        }

        // GET api/<SolicitudController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SolicitudController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SolicitudController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SolicitudController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
