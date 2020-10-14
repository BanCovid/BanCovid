using Core.ModeloData;
using Core.Modelos;
using Core.Servicios;
using Integracion.Models;
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

        public UsuariosController()
        {
            _servicio = new UsuariosServicio();
        }

        [HttpPost]
        [Route("Crear")]
        public IHttpActionResult Crear(Tbl_Usuario modelo)
        {
            try
            {
                _servicio.Crear(modelo);

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
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public IHttpActionResult IniciarSesion(UsuarioModelo modelo)
        {
            try
            {
                var usuario = _servicio.InicioSesion(modelo);

                return Ok(new
                {
                    UsuarioId = usuario.Id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerTodos")]
        public IHttpActionResult ObtenerTodos()
        {
            try
            {
                var list = _servicio.ObtenerTodos();

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
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Obtener/{id}")]
        public IHttpActionResult Obtener(int id)
        {
            try
            {
                var item = _servicio.Obtener(id);

                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IHttpActionResult Editar(Tbl_Usuario modelo)
        {
            try
            {
                _servicio.Editar(modelo);

                return Ok(modelo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
