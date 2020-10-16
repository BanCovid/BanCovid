using Core.ModeloData;
using Core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class CuentasServicio
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BanCovid_DBEntities _db;
        public CuentasServicio()
        {
            _db = new BanCovid_DBEntities();
        }


        public void Crear(Tbl_Cuenta modelo)
        {
            log.Info("CajaServicio - Crear - Inicio");
            modelo.FechaCreacion = DateTime.Now;

            do
            {
                modelo.NoCuenta = "010" + (new Random().Next(100000000, 999999999)).ToString();

            } while (_db.Tbl_Cuenta.Any(x => x.NoCuenta == modelo.NoCuenta));
            

            _db.Tbl_Cuenta.Add(modelo);

            _db.SaveChanges();
            log.Info("CajaServicio - Crear - Fin");
        }

        public List<Tbl_Cuenta> ObtenerTodos(int clienteId)
        {
            log.Info("CuentaServicio - ObtenerTodos - Inicio");
            var data = _db.Tbl_Cuenta.Where(x => x.ClienteId == clienteId).ToList();
            log.Info("CuentaServicio - ObtenerTodos - Fin");
            return data;
        }

        public Tbl_Cuenta Obtener(string noCuenta)
        {
            log.Info("CuentaServicio - Obtener - Inicio");
            var data = _db.Tbl_Cuenta.SingleOrDefault(x => x.NoCuenta.Trim() == noCuenta.Trim());

            if (data == null)
                throw new Exception("La cuenta no existe");

            log.Info("CuentaServicio - Obtener - Fin");
            return data;
        }

        public CuentaEstadisticaModelo Estadisticas(string noCuenta)
        {
            log.Info("CuentaServicio - Estadisticas - Inicio");
            var cuenta = _db.Tbl_Cuenta.SingleOrDefault(x => x.NoCuenta == noCuenta.Trim());

            if (cuenta == null)
                throw new Exception("La cuenta no existe");

            decimal montoEnSalida = 0, montoEnEntrada = 0;
            _db.Tbl_Transaccion
                .Where(x => 
                    x.Id == cuenta.Id && 
                    x.Fecha.Month == DateTime.Now.Month && //Mes actual
                    x.Estado == 2 // En Proceso
                )
                .ToList()
                .Aggregate(montoEnSalida, (x, y)=> montoEnSalida + y.Monto);

            _db.Tbl_Transaccion
                .Where(x =>
                    x.CuentaDestinoId == cuenta.Id &&
                    x.Fecha.Month == DateTime.Now.Month && //Mes actual
                    x.Estado == 2 // En Proceso
                )
                .ToList()
                .Aggregate(montoEnEntrada, (x, y) => montoEnEntrada + y.Monto);

            var result = new CuentaEstadisticaModelo
            {
                BalanceActual = cuenta.Monto,
                BalanceDisponible = cuenta.Monto + montoEnEntrada - montoEnSalida,
                BalanceUltimoCorte = cuenta.MontoAlCorte
            };

            result.BalanceDisponiblePorcent = result.BalanceDisponible / result.BalanceActual;
            result.BalanceUltimoCortePorcent = result.BalanceUltimoCorte / result.BalanceActual;

            log.Info("CuentaServicio - Estadisticas - Fin");
            return result;
        }

        public void Editar(Tbl_Cuenta modelo)
        {
            log.Info("CuentaServicio - Editar - Inicio");
            var registro = _db.Tbl_Cuenta.SingleOrDefault(x => x.Id == modelo.Id);

            if (modelo.ClienteId != 0 )
                registro.ClienteId = modelo.ClienteId;

            if (modelo.Monto != 0)
                registro.Monto = modelo.Monto;
          
            _db.SaveChanges();
            log.Info("CuentaServicio - Editar - Fin");
        }       
    }
}
