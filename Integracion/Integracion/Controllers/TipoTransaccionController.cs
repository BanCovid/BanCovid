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
    [RoutePrefix("api/TipoTransaccion")]
    public class TipoTransaccionController : ApiController
    {
        private readonly TipoTransaccionServicio _servicio;
        private static readonly ILog log = LogManager.GetLogger(System.Environment.MachineName);
        public TipoTransaccionController()
        {
            _servicio = new TipoTransaccionServicio();
        }

        [HttpGet]
        [Route("ObtenerTodos")]
        public IHttpActionResult ObtenerTodos()
        {
            log.Info("Inicia el metodo ObtenerTodos - TipoTransaccionController");
            try
            {
                var list = _servicio.ObtenerTodos();
                log.Info("Finaliza el metodo ObtenerTodos - TipoTransaccionController");
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
            log.Info("Inicia el metodo Obtener - TipoTransaccionController");
            try
            {
                var item = _servicio.Obtener(id);
                log.Info("Finaliza el metodo Obtener - TipoTransaccionController");
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
        public IHttpActionResult Editar(Tbl_TipoTransaccion modelo)
        {
            log.Info("Inicia el metodo Editar - TipoTransaccionController");
            try
            {
                _servicio.Editar(modelo);
                log.Info("Finaliza el metodo Editar - TipoTransaccionController");
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
