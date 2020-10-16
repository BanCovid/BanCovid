using Core.ModeloData;
using Core.Modelos;
using Core.Servicios;
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
        private readonly BeneficiarioServicio _servicio;

        public BeneficiariosController ()
        {
            _servicio = new BeneficiarioServicio();
        }

        [HttpPost]
        [Route("Crear")]
        public IHttpActionResult Crear(BeneficiarioModelo modelo)
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
        public IHttpActionResult ObtenerTodos(int clienteId)
        {
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

    }
}
