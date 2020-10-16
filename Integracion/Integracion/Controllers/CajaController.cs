using Core.ModeloData;
using Core.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Integracion.Controllers
{
    [RoutePrefix("api/Caja")]
    public class CajaController : ApiController
    {
        private readonly CajaServicio _servicio;

        public CajaController()
        {
            _servicio = new CajaServicio();
        }

        //[HttpGet]
        //[Route("Estadisticas")]
        //public IHttpActionResult Estadisticas(string cuentaNo)
        //{
        //    try
        //    {
        //        //_servicio.Crear();

        //        return Ok(modelo);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost]
        [Route("Crear")]
        public IHttpActionResult Crear(Tbl_Caja modelo)
        {
            try
            {
                _servicio.Crear(modelo);

                return Ok(modelo);
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

                return Ok(list);
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
        public IHttpActionResult Editar(Tbl_Caja modelo)
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
