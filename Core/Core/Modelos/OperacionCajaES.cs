using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Modelos
{
    public class OperacionCajaES
    {
        public int CajaId { get; set; }
        public int TipoId { get; set; }
        public int ClienteId { get; set; }
        public string CuentaDestino { get; set; }
        public decimal Monto { get; set; }
    }
}
