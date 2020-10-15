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
    [RoutePrefix("api/BeneficiariosEstado")]
    public class BeneficiariosEstadoController : ApiController
    {
        private readonly BeneficiariosEstadoServicios _servicio;
        private static readonly ILog log = LogManager.GetLogger(System.Environment.MachineName);
        public BeneficiariosEstadoController()
        {
            _servicio = new BeneficiariosEstadoServicios(); 
        }

        [HttpGet]
        [Route("ObtenerTodos")]
        public IHttpActionResult ObtenerTodos()
        {
            log.Info("Inicia el metodo ObtenerTodos - BeneficiariosEstadoController");
            try
            {
                var list = _servicio.ObtenerTodos();
                log.Info("Finaliza el metodo ObtenerTodos - BeneficiariosEstadoController");
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
            log.Info("Inicia el metodo Obtener - BeneficiariosEstadoController");
            try
            {
                var item = _servicio.Obtener(id);
                log.Info("Finaliza el metodo Obtener - BeneficiariosEstadoController");
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
        public IHttpActionResult Editar(Tbl_BeneficiarioEstado modelo)
        {
            log.Info("Inicia el metodo Editar - BeneficiariosEstadoController");
            try
            {
                _servicio.Editar(modelo); 
                log.Info("Finaliza el metodo Editar - BeneficiariosEstadoController");
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
