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
    [RoutePrefix("api/Cuenta")]
    public class CuentaController : ApiController
    {
        private readonly CuentaServicio _servicio;
        private static readonly ILog log = LogManager.GetLogger(System.Environment.MachineName);
        public CuentaController()
        {
            _servicio = new CuentaServicio();
        }

        [HttpGet]
        [Route("ObtenerTodos")]
        public IHttpActionResult ObtenerTodos()
        {
            log.Info("Inicia el metodo ObtenerTodos - CuentaController");
            try
            {
                var list = _servicio.ObtenerTodos();
                log.Info("Finaliza el metodo ObtenerTodos - CuentaController");
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
            log.Info("Inicia el metodo Obtener - CuentaController");
            try
            {
                var item = _servicio.Obtener(id);
                log.Info("Finaliza el metodo Obtener - CuentaController");
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
        public IHttpActionResult Editar(Tbl_Cuenta modelo)
        {
            log.Info("Inicia el metodo Editar -CuentaController");
            try
            {
                _servicio.Editar(modelo);
                log.Info("Finaliza el metodo Editar - CuentaController");
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
