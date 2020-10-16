using Core.Servicios;
using System;

namespace Core.Modelos
{
    public class TransaccionModelo
    {
        public long Id { get; set; }
        public string Concepto { get; set; }
        public string Titular { get; set; }
        public TipoTransaccion TipoTransaccion { get; set; }
        public decimal Monto { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Cuenta { get; set; }
        public string CuentaDestino { get; set; }
        public Nullable<long> OperacionCajaId { get; set; }
        public short Estado { get; set; }
    }
}
