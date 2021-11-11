using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PQRS.API.Controllers
{
    using Models;
    using helpers;
    using System.Net;
    using Microsoft.AspNetCore.Cors;

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class SolicitudController : ControllerBase
    {
        #region GET
        [HttpGet("Peticion/{id}")]
        public IActionResult Peticion(int id)
        {
            try
            {
                Peticion rule = new Peticion();
                rule.Idpeticion = id;
                if (!rule.Consultar())
                {
                    throw new Exception(rule.Error);
                }
                return Ok(new
                {
                    IdCliente = rule.IdCliente,
                    Servicio = rule.Servicio,
                    TipoSoli = rule.TipoSoli,
                    Fecha = rule.Fecha,
                    IdPeticion = rule.Idpeticion,
                    IdSupervisor = rule.IdSupervisor
                });
            }
            catch (Exception ex)
            {
                return GenerateException(500, ex.Message);
            }
        }

        [HttpGet("Queja/{id}")]
        public IActionResult Queja(int id)
        {
            try
            {
                Queja rule = new Queja();
                rule.IdQueja = id;
                if (!rule.Consultar())
                {
                    throw new Exception(rule.Error);
                }
                return Ok(new
                {
                    IdCliente = rule.IdCliente,
                    Servicio = rule.Servicio,
                    TipoSoli = rule.TipoSoli,
                    Fecha = rule.Fecha,
                    IdQueja = rule.IdQueja,
                    IdSupervisor = rule.IdSupervisor,
                    IdTipoRemuneracion = rule.IdTipoRemuneracion
                });
            }
            catch (Exception ex)
            {
                return GenerateException(500, ex.Message);
            }
        }

        [HttpGet("Reclamo/{id}")]
        public IActionResult Reclamo(int id)
        {
            try
            {
                Reclamo rule = new Reclamo();
                rule.IdReclamo = id;
                if (!rule.Consultar())
                {
                    throw new Exception(rule.Error);
                }
                return Ok(new
                {
                    IdCliente = rule.IdCliente,
                    Servicio = rule.Servicio,
                    TipoSoli = rule.TipoSoli,
                    Fecha = rule.Fecha,
                    IdReclamo = rule.IdReclamo,
                    IdTipoReclamo = rule.IdTipoReclamo,
                    IdSolucion = rule.IdSolucion,
                    Costo = rule.Costo
                });
            }
            catch (Exception ex)
            {
                return GenerateException(500, ex.Message);
            }
        }

        [HttpGet("Sugerencia/{id}")]
        public IActionResult Sugerencia(int id)
        {
            try
            {
                Sugerencia rule = new Sugerencia();
                rule.IdSugerencia = id;
                if (!rule.Consultar())
                {
                    throw new Exception(rule.Error);
                }
                return Ok(new
                {
                    IdCliente = rule.IdCliente,
                    Servicio = rule.Servicio,
                    TipoSoli = rule.TipoSoli,
                    Fecha = rule.Fecha,
                    IdSugerencia = rule.IdSugerencia,
                    IdTipoSugerencia = rule.IdTipoSugerencia,
                    Descripcion = rule.Descripcion,
                });
            }
            catch (Exception ex)
            {
                return GenerateException(500, ex.Message);
            }
        }

        [HttpGet("Felicitacion/{id}")]
        public IActionResult Felicitacion(int id)
        {
            try
            {
                Felicitacion rule = new Felicitacion();
                rule.IdFelicitacion = id;
                if (!rule.Consultar())
                {
                    throw new Exception(rule.Error);
                }
                return Ok(new
                {
                    IdCliente = rule.IdCliente,
                    Servicio = rule.Servicio,
                    TipoSoli = rule.TipoSoli,
                    Fecha = rule.Fecha,
                    IdFelicitacion = rule.IdFelicitacion,
                    Descripcion = rule.Descripcion,
                });
            }
            catch (Exception ex)
            {
                return GenerateException(500, ex.Message);
            }
        }
        #endregion

        #region POST

        [HttpPost("Peticion")]
        public IActionResult Peticion([FromBody] Peticion item)
        {
            try
            {
                Peticion rule = new Peticion()
                {
                    Area = item.Area,
                    IdCliente = item.IdCliente,
                    Servicio = item.Servicio,
                    TipoSoli = item.TipoSoli,
                    Fecha = item.Fecha,
                    Idpeticion = item.Idpeticion,
                    IdSupervisor = item.IdSupervisor
                };
                if (!rule.Registrar())
                {
                    throw new Exception(rule.Error);
                }
                return Ok(new { message = $"Registro almacenado correctamente/nCodigo de el Registro: {rule.Idpeticion}" });
            }
            catch (Exception ex)
            {
                return GenerateException(500, ex.Message);
            }
        }

        [HttpPost("Queja")]
        public IActionResult Queja([FromBody] Queja item)
        {
            try
            {
                Queja rule = new Queja()
                {
                    Area = item.Area,
                    IdCliente = item.IdCliente,
                    Servicio = item.Servicio,
                    TipoSoli = item.TipoSoli,
                    Fecha = item.Fecha,
                    IdQueja = item.IdQueja,
                    IdSupervisor = item.IdSupervisor,
                    IdTipoRemuneracion = item.IdTipoRemuneracion
                };
                if (!rule.Registrar())
                {
                    throw new Exception(rule.Error);
                }
                return Ok(new { message = $"Registro almacenado correctamente/nCodigo de el Registro: {rule.IdQueja}" });
            }
            catch (Exception ex)
            {
                return GenerateException(500, ex.Message);
            }
        }

        [HttpPost("Reclamo")]
        public IActionResult Reclamo([FromBody] Reclamo item)
        {
            try
            {
                Reclamo rule = new Reclamo()
                {
                    Area = item.Area,
                    IdCliente = item.IdCliente,
                    Servicio = item.Servicio,
                    TipoSoli = item.TipoSoli,
                    Fecha = item.Fecha,
                    IdReclamo = item.IdReclamo,
                    IdTipoReclamo = item.IdTipoReclamo,
                    IdSolucion = item.IdSolucion,
                    Costo = item.Costo
                };
                if (!rule.Registrar())
                {
                    throw new Exception(rule.Error);
                }
                return Ok(new { message = $"Registro almacenado correctamente/nCodigo de el Registro: {rule.IdReclamo}" });
            }
            catch (Exception ex)
            {
                return GenerateException(500, ex.Message);
            }
        }

        [HttpPost("Sugerencia")]
        public IActionResult Sugerencia([FromBody] Sugerencia item)
        {
            try
            {
                Sugerencia rule = new Sugerencia()
                {
                    Area = item.Area,
                    IdCliente = item.IdCliente,
                    Servicio = item.Servicio,
                    TipoSoli = item.TipoSoli,
                    Fecha = item.Fecha,
                    IdSugerencia = item.IdSugerencia,
                    IdTipoSugerencia = item.IdTipoSugerencia,
                    Descripcion = item.Descripcion
                };
                if (!rule.Registrar())
                {
                    throw new Exception(rule.Error);
                }
                return Ok(new { message = $"Registro almacenado correctamente/nCodigo de el Registro: {rule.IdSugerencia}" });
            }
            catch (Exception ex)
            {
                return GenerateException(500, ex.Message);
            }
        }

        [HttpPost("Felicitacion")]
        public IActionResult Felicitacion([FromBody] Felicitacion item)
        {
            try
            {
                Felicitacion rule = new Felicitacion()
                {
                    Area = item.Area,
                    IdCliente = item.IdCliente,
                    Servicio = item.Servicio,
                    TipoSoli = item.TipoSoli,
                    Fecha = item.Fecha,
                    IdFelicitacion = item.IdFelicitacion,
                    Descripcion = item.Descripcion,
                };
                if (!rule.Registrar())
                {
                    throw new Exception(rule.Error);
                }
                return Ok(new { message = $"Registro almacenado correctamente/nCodigo de el Registro: {rule.IdFelicitacion}" });
            }
            catch (Exception ex)
            {
                return GenerateException(500, ex.Message);
            }
        }
        #endregion



        #region Private Methods
        private IActionResult GenerateException(int errorCode, string message)
        {
            return StatusCode(errorCode, new { message });
        }
        private IActionResult GenerateException(Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = "Internal Server Error" });
        }
        #endregion
    }
}
