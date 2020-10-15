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
    [RoutePrefix("api/OperacionCajaTipo")]
    public class OperacionCajaTipoController : ApiController
    {
        private readonly OperacionCajaTipoServicios _servicio;
        private static readonly ILog log = LogManager.GetLogger(System.Environment.MachineName);

        public OperacionCajaTipoController()
        {
            _servicio = new OperacionCajaTipoServicios();
        }

        [HttpPost]
        [Route("Crear")]
        public IHttpActionResult Crear(Tbl_OperacionCajaTipo modelo)
        {
            log.Info("Inicia el metodo Crear - OperacionCajaTipoController");
            try
            {
                _servicio.Crear(modelo);
                log.Info("Finaliza el metodo Crear - OperacionCajaTipoController");
                return Ok(modelo);
            }
            catch (Exception ex)
            {
                log.Error($"Ha ocurrido un error: {ex}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerTodos")]
        public IHttpActionResult ObtenerTodos()
        {
            log.Info("Inicia el metodo ObtenerTodos - OperacionCajaTipoController");
            try
            {
                var list = _servicio.ObtenerTodos();
                log.Info("Finaliza el metodo ObtenerTodos - OperacionCajaTipoController");
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
            log.Info("Inicia el metodo Obtener - OperacionCajaTipoController");
            try
            {
                var item = _servicio.Obtener(id);
                log.Info("Finaliza el metodo Obtener - OperacionCajaTipoController");
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
        public IHttpActionResult Editar(Tbl_OperacionCajaTipo modelo)
        {
            log.Info("Inicia el metodo Editar - OperacionCajaTipoController");
            try
            {
                _servicio.Editar(modelo);
                log.Info("Finaliza el metodo Editar - OperacionCajaTipoController");
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
