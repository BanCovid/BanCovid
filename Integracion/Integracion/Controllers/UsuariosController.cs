using Core.ModeloData;
using Core.Modelos;
using Core.Servicios;
using Integracion.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Integracion.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        private readonly UsuariosServicio _servicio;
        private static readonly ILog log = LogManager.GetLogger(System.Environment.MachineName);

        public UsuariosController()
        {
            _servicio = new UsuariosServicio();
        }

        [HttpPost]
        [Route("Crear")]
        public IHttpActionResult Crear(Tbl_Usuario modelo)
        {
            log.Info("Inicia el metodo Crear - UsuariosController");
            try
            {
                _servicio.Crear(modelo);
                log.Info("Finaliza el metodo Crear - UsuariosController");
                return Ok(new UsuarioDTO
                {
                    Id = modelo.Id,
                    Nombre = modelo.Nombre,
                    Apellido = modelo.Apellido,
                    UserName = modelo.UserName,
                    FechaCreacion = modelo.FechaCreacion
                });
            }
            catch (Exception ex)
            {
                log.Error($"Ha ocurrido un error: {ex}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public IHttpActionResult IniciarSesion(UsuarioModelo modelo)
        {
            log.Info("Inicia el metodo IniciarSesion - UsuariosController");
            try
            {
                var usuario = _servicio.InicioSesion(modelo);
                log.Info("Finaliza el metodo IniciarSesion - UsuariosController");
                return Ok(new
                {
                    UsuarioId = usuario.Id
                });
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
            log.Info("Inicia el metodo ObtenerTodos - UsuariosController");
            try
            {
                var list = _servicio.ObtenerTodos();
                log.Info("Finaliza el metodo ObtenerTodos - UsuariosController");
                return Ok(list.Select(x => new UsuarioDTO 
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    Cedula = x.Cedula,
                    FechaCreacion = x.FechaCreacion,
                    Perfil_Id = x.Perfil_Id,
                    Telefono = x.Telefono,
                    UserName = x.UserName,
                    Estado = x.Estado
                }));
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
            log.Info("Inicia el metodo Obtener - UsuariosController");
            try
            {
                var item = _servicio.Obtener(id);
                log.Info("Finaliza el metodo Obtener - UsuariosController");
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
        public IHttpActionResult Editar(Tbl_Usuario modelo)
        {
            log.Info("Inicia el metodo Editar - UsuariosController");
            try
            {
                _servicio.Editar(modelo);
                log.Info("Finaliza el metodo Editar - UsuariosController");
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
