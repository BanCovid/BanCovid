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
    [RoutePrefix("api/Caja")]
    public class CajaController : ApiController
    {
        private readonly CajaServicio _servicio;
        private static readonly ILog log = LogManager.GetLogger(System.Environment.MachineName);
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
            log.Info("Inicia el metodo Crear - CajaController");
            try
            {
                _servicio.Crear(modelo);
                log.Info("Finaliza el metodo Crear - CajaController");
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
            log.Info("Inicia el metodo ObtenerTodos - CajaController");
            try
            {
                var list = _servicio.ObtenerTodos();
                log.Info("Finaliza el metodo ObtenerTodos - CajaController");
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
            log.Info("Inicia el metodo Obtener - CajaController");
            try
            {
                var item = _servicio.Obtener(id);
                log.Info("Finaliza el metodo Obtener - CajaController");
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
        public IHttpActionResult Editar(Tbl_Caja modelo)
        {
            log.Info("Inicia el metodo Editar - CajaController");
            try
            {
                _servicio.Editar(modelo);
                log.Info("Finaliza el metodo Editar - CajaController");
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
