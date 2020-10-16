using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Modelos
{
    public class BeneficiarioModelo
    {
        public int ClienteId { get; set; }
        public string Titular { get; set; }
        public string Alias { get; set; }
        public string CuentaDestino { get; set; }
        public DateTime FechaCreacion { get; set; }
        public short Estado { get; set; }
    }
}
