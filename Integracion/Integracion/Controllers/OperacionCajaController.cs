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
    [RoutePrefix("api/OperacionCaja")]
    public class OperacionCajaController : ApiController
    {
        private readonly OperacionCajaServicios _servicio;
        private static readonly ILog log = LogManager.GetLogger(System.Environment.MachineName);

        public OperacionCajaController()
        {
            _servicio = new OperacionCajaServicios();
        }

        [HttpPost]
        [Route("Crear")]
        public IHttpActionResult Crear(Tbl_OperacionCaja modelo)
        {
            log.Info("Inicia el metodo Crear - OperacionCajaController");
            try
            {
                _servicio.Crear(modelo);
                log.Info("Finaliza el metodo Crear - OperacionCajaController");
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
            log.Info("Inicia el metodo ObtenerTodos - OperacionCajaController");
            try
            {
                var list = _servicio.ObtenerTodos();
                log.Info("Finaliza el metodo ObtenerTodos - OperacionCajaController");
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
            log.Info("Inicia el metodo Obtener - OperacionCajaController");
            try
            {
                var item = _servicio.Obtener(id);
                log.Info("Finaliza el metodo Obtener - OperacionCajaController");
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
        public IHttpActionResult Editar(Tbl_OperacionCaja modelo)
        {
            log.Info("Inicia el metodo Editar - OperacionCajaController");
            try
            {
                _servicio.Editar(modelo);
                log.Info("Finaliza el metodo Editar - OperacionCajaController");
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
