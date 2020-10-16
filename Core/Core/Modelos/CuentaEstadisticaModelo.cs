using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Modelos
{
    public class CuentaEstadisticaModelo
    {
        public decimal BalanceActual { get; set; }
        public decimal BalanceDisponible { get; set; }
        public decimal BalanceDisponiblePorcent { get; set; }
        public decimal BalanceUltimoCorte { get; set; }
        public decimal BalanceUltimoCortePorcent { get; set; }
    }
}
