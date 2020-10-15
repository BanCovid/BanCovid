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
    [RoutePrefix("api/Perfiles")]
    public class PerfilesController : ApiController
    {
        private readonly PerfilServicio _servicio;
        private static readonly ILog log = LogManager.GetLogger(System.Environment.MachineName);
        public PerfilesController()
        {
            _servicio = new PerfilServicio();
        }

        [HttpPost]
        [Route("Crear")]
        public IHttpActionResult Crear(Tbl_Perfil modelo)
        {
            log.Info("Inicia el metodo Crear - PerfilesController");
            try
            {
                _servicio.Crear(modelo);
                log.Info("Finaliza el metodo Crear - PerfilesController");
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
            log.Info("Inicia el metodo ObtenerTodos - PerfilesController");
            try
            {
                var list = _servicio.ObtenerTodos();
                log.Info("Finaliza el metodo ObtenerTodos - PerfilesController");
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
            log.Info("Inicia el metodo Obtener - PerfilesController");
            try
            {
                var item = _servicio.Obtener(id);
                log.Info("Finaliza el metodo Obtener - PerfilesController");
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
        public IHttpActionResult Editar(Tbl_Perfil modelo)
        {
            log.Info("Inicia el metodo Editar - PerfilesController");
            try
            {
                _servicio.Editar(modelo);
                log.Info("Finaliza el metodo Editar - PerfilesController");
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
