using Core.ModeloData;
using Core.Servicios;
using Integracion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Integracion.Controllers
{
    [RoutePrefix("api/Cuentas")]
    public class CuentasController : ApiController
    {
        private readonly CuentasServicio _servicio;
        public CuentasController()
        {
            _servicio = new CuentasServicio();
        }

        [HttpPost]
        [Route("Crear")]
        public IHttpActionResult Crear(Tbl_Cuenta modelo)
        {
            try
            {
                _servicio.Crear(modelo);

                return Ok(new CuentaDTO
                {
                    NoCuenta = modelo.NoCuenta,
                    ClienteId = modelo.ClienteId,
                    FechaCreacion = modelo.FechaCreacion,
                    Monto = modelo.Monto
                });
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

                return Ok(list.Select(x => new CuentaDTO
                {
                    NoCuenta = x.NoCuenta,
                    ClienteId = x.ClienteId,
                    FechaCreacion = x.FechaCreacion,
                    Monto = x.Monto
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Estadisticas/{noCuenta}")]
        public IHttpActionResult Estadisticas(string noCuenta)
        {
            try
            {
                var modelo = _servicio.Estadisticas(noCuenta);

                return Ok(modelo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Obtener/{noCuenta}")]
        public IHttpActionResult Obtener(string noCuenta)
        {
            try
            {
                var modelo = _servicio.Obtener(noCuenta);

                return Ok(new CuentaDTO
                {
                    NoCuenta = modelo.NoCuenta,
                    ClienteId = modelo.ClienteId,
                    FechaCreacion = modelo.FechaCreacion,
                    Monto = modelo.Monto,
                    Titular = modelo.Tbl_Cliente.Tbl_Usuario.Nombre + " " + modelo.Tbl_Cliente.Tbl_Usuario.Apellido
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public IHttpActionResult Editar(Tbl_Cuenta modelo)
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
