using Core.ModeloData;
using Core.Servicios;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Integracion.Controllers
{
    [RoutePrefix("api/Transaccion")]
    public class TransaccionController : ApiController
    {
        private readonly TransaccionServicio _servicio;
        private static readonly ILog log = LogManager.GetLogger(System.Environment.MachineName);
        public TransaccionController()
        {
            _servicio = new TransaccionServicio();
        }

        [HttpGet]
        [Route("ObtenerTodos")]
        public IHttpActionResult ObtenerTodos()
        {
            log.Info("Inicia el metodo ObtenerTodos - TransaccionController");
            try
            {
                var list = _servicio.ObtenerTodos();
                log.Info("Finaliza el metodo ObtenerTodos - TransaccionController");
                return Ok(list);
            }
            catch (Exception ex)
            {
                log.Error($"Ha ocurrido un error: {ex}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Obtener/{id}")]
        public IHttpActionResult Obtener(int id)
        {
            log.Info("Inicia el metodo Obtener - TransaccionController");
            try
            {
                var item = _servicio.Obtener(id);
                log.Info("Finaliza el metodo Obtener - TransaccionController");
                return Ok(item);
            }
            catch (Exception ex)
            {
                log.Error($"Ha ocurrido un error: {ex}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IHttpActionResult Editar(Tbl_Transaccion modelo)
        {
            log.Info("Inicia el metodo Editar - TransaccionController");
            try
            {
                _servicio.Editar(modelo);
                log.Info("Finaliza el metodo Editar - TransaccionController");
                return Ok(modelo);
            }
            catch (Exception ex)
            {
                log.Error($"Ha ocurrido un error: {ex}");
                return BadRequest(ex.Message);
            }
        }

    }
}
