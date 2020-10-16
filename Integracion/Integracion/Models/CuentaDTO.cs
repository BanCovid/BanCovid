using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracion.Models
{
    public class CuentaDTO
    {
        public string NoCuenta { get; set; }
        public string Titular { get; set; }
        public int ClienteId { get; set; }
        public decimal Monto { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}