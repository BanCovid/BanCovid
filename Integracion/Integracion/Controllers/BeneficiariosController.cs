using Core.ModeloData;
using Core.Modelos;
using Core.Servicios;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Integracion.Controllers
{
    [RoutePrefix("api/Beneficiarios")]
    public class BeneficiariosController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Environment.MachineName);
        private readonly BeneficiarioServicio _servicio;

        public BeneficiariosController ()
        {
            _servicio = new BeneficiarioServicio();
        }

        [HttpPost]
        [Route("Crear")]
        public IHttpActionResult Crear(BeneficiarioModelo modelo)
        {
            log.Info("Inicia el metodo Crear - BeneficiariosController");
            try
            {
                _servicio.Crear(modelo);
                log.Info("Finaliza el metodo Crear - BeneficiariosController");
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
        public IHttpActionResult ObtenerTodos(int clienteId)
        {
            log.Info("Inicia el metodo ObtenerTodos - BeneficiariosController");
            try
            {
                var list = _servicio.ObtenerTodos(clienteId);

                return Ok(list.Select(x => new BeneficiarioModelo
                {
                    Alias = x.Alias,
                    CuentaDestino = x.Tbl_Cuenta.NoCuenta,
                    Estado = x.Estado,
                    FechaCreacion = x.FechaCreacion,
                    Titular =  x.Tbl_Cuenta.Tbl_Cliente.Tbl_Usuario.Nombre + " " + x.Tbl_Cuenta.Tbl_Cliente.Tbl_Usuario.Apellido
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
            log.Info("Inicia el metodo Obtener - BeneficiariosController");
            try
            {
                var item = _servicio.Obtener(id);
                log.Info("Finaliza el metodo Obtener - BeneficiariosController");
                return Ok(item);
            }
            catch (Exception ex)
            {
                log.Error($"Ha ocurrido un error: {ex}");
                return BadRequest(ex.Message);
            }
        }

    }
}
