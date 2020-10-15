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
    [RoutePrefix("api/EstadosUsuario")]
    public class EstadosUsuarioController : ApiController
    {
        private readonly EstadosUsuariosServicios _servicio;
        private static readonly ILog log = LogManager.GetLogger(System.Environment.MachineName);

        public EstadosUsuarioController()
        {
            _servicio = new EstadosUsuariosServicios();
        }

        [HttpPost]
        [Route("Crear")]
        public IHttpActionResult Crear(Tbl_EstadoUsuario modelo)
        {
            log.Info("Inicia el metodo Crear - EstadosUsuarioController");
            try
            {
                _servicio.Crear(modelo);
                log.Info("Finaliza el metodo Crear - EstadosUsuarioController");
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
            log.Info("Inicia el metodo ObtenerTodos - EstadosUsuarioController");
            try
            {
                var list = _servicio.ObtenerTodos();
                log.Info("Finaliza el metodo ObtenerTodos - EstadosUsuarioController");
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
            log.Info("Inicia el metodo Obtener - EstadosUsuarioController");
            try
            {
                var item = _servicio.Obtener(id);
                log.Info("Finaliza el metodo Obtener -EstadosUsuarioController - EstadosUsuarioController");
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
        public IHttpActionResult Editar(Tbl_EstadoUsuario modelo)
        {
            log.Info("Inicia el metodo Editar - EstadosUsuarioController");
            try
            {
                _servicio.Editar(modelo); 
                log.Info("Finaliza el metodo Editar - EstadosUsuarioController");
                return Ok(modelo);
            }
            catch (Exception ex)
            {
                log.Error($"Ha ocurrido un error: {ex}");
                return BadRequest(ex.Message);
            }
        }

        /*
        Obtener -> GET
        Crear -> POST
        Actualizar -> PUT
        Eliminar -> DELETE
        */
    }
}
