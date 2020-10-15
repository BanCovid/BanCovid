﻿using Core.ModeloData;
using Core.Servicios;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Integracion.Controllers
{
    [RoutePrefix("api/Cliente")]
    public class ClienteController : ApiController
    {
        private readonly ClienteServicios _servicio;
        private static readonly ILog log = LogManager.GetLogger(System.Environment.MachineName);
        public ClienteController()
        {
            _servicio = new ClienteServicios();
        }

        [HttpGet]
        [Route("ObtenerTodos")]
        public IHttpActionResult ObtenerTodos()
        {
            log.Info("Inicia el metodo ObtenerTodos - ClienteController");
            try
            {
                var list = _servicio.ObtenerTodos();
                log.Info("Finaliza el metodo ObtenerTodos - ClienteController");
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
            log.Info("Inicia el metodo Obtener - ClienteController");
            try
            {
                var item = _servicio.Obtener(id);
                log.Info("Finaliza el metodo Obtener - ClienteController");
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
        public IHttpActionResult Editar(Tbl_Cliente modelo)
        {
            log.Info("Inicia el metodo Editar - ClienteController");
            try
            {
                _servicio.Editar(modelo);
                log.Info("Finaliza el metodo Editar - ClienteController");
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
