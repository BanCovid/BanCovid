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
    [RoutePrefix("api/Transaccion")]
    public class TransaccionController : ApiController
    {
        private readonly TransaccionServicio _servicio;
        private static readonly ILog log = LogManager.GetLogger(System.Environment.MachineName);
        public TransaccionController()
        {
            _servicio = new TransaccionServicio();
        }

        [HttpPost]
        [Route("Interna")]
        public IHttpActionResult TransferenciaInterna(TransaccionModelo modelo)
        {
            log.Info("Inicia el metodo ObtenerTodos - TransaccionController");
            try
            {
                modelo.TipoTransaccion = TipoTransaccion.TransferenciaInterna;
                if (string.IsNullOrWhiteSpace(modelo.Concepto))
                    modelo.Concepto = "Transferencia interna a " + modelo.CuentaDestino;
                _servicio.Crear(modelo);

                return Ok(true);
            }
            catch (Exception ex)
            {
                log.Error($"Ha ocurrido un error: {ex}");
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Route("ObtenerTodos")]
        public IHttpActionResult ObtenerTodos(string noCuenta)
        {
            log.Info("Inicia el metodo Obtener - TransaccionController");
            try
            {
                var list = _servicio.ObtenerTodos(noCuenta);

                return Ok(list.Select(x => new TransaccionModelo 
                {
                    Cuenta = x.Tbl_Cuenta.NoCuenta,
                    CuentaDestino = x.Tbl_Cuenta1.NoCuenta,
                    Concepto = x.Concepto,
                    TipoTransaccion = (TipoTransaccion)x.TipoTransaccionId,
                    Monto = x.Monto,
                    Estado = x.Estado,
                    Titular = (noCuenta == x.Tbl_Cuenta.NoCuenta) ? 
                                x.Tbl_Cuenta1.Tbl_Cliente.Tbl_Usuario.Nombre + " " + 
                                x.Tbl_Cuenta1.Tbl_Cliente.Tbl_Usuario.Apellido :
                                x.Tbl_Cuenta.Tbl_Cliente.Tbl_Usuario.Nombre + " " +
                                x.Tbl_Cuenta.Tbl_Cliente.Tbl_Usuario.Apellido,
                    Fecha = x.Fecha
                }));
            }
            catch (Exception ex)
            {
                log.Error($"Ha ocurrido un error: {ex}");
                return BadRequest(ex.Message);
            }
        }


    }
}
