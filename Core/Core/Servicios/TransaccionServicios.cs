using Core.ModeloData;
using Core.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public enum TipoTransaccion : short
    {
        Deposito = 1,
        Retiro = 2,
        TransferenciaInterna = 3,
        TransferenciaExterna = 4
    }

    public enum  EstadoTransaccion: short
    {
        Cancelado = 0,
        EnProceso = 1,
        Realizado = 2
    }

    public class TransaccionServicio
    {
        const decimal IMPUESTOS_POR_TRANSACCION = 0.015m;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BanCovid_DBEntities _db;
        public TransaccionServicio()
        {
            _db = new BanCovid_DBEntities();
        }

        public void Crear(TransaccionModelo modelo)
        {
            log.Info("TransaccionServicio - Crear - Inicio");
            DbContextTransaction transaccion = null;
            try
            {
                transaccion = _db.Database.BeginTransaction();

                var cuenta = _db.Tbl_Cuenta.SingleOrDefault(x => x.NoCuenta == modelo.Cuenta);

                if (cuenta == null)
                    throw new Exception($"La cuenta principal no existe ({modelo.Cuenta})");

                var cuentaDestino = _db.Tbl_Cuenta.SingleOrDefault(x => x.NoCuenta == modelo.CuentaDestino);
                
                if (cuentaDestino == null)
                    throw new Exception($"La cuenta destino no existe ({modelo.CuentaDestino})");

                decimal montoADescontar = modelo.Monto + (modelo.Monto * IMPUESTOS_POR_TRANSACCION);
                
                if (cuenta.Monto < (montoADescontar))
                    throw new Exception("No cuenta con los fondos suficientes para realizar esta transacción");

                cuenta.Monto -= montoADescontar;
                cuentaDestino.Monto += modelo.Monto;

                _db.Tbl_Transaccion.Add(new Tbl_Transaccion
                {
                    Monto = modelo.Monto,
                    CuentaId = cuenta.Id,
                    CuentaDestinoId = cuentaDestino.Id,
                    TipoTransaccionId = (short)modelo.TipoTransaccion,
                    Fecha = DateTime.Now,
                    Estado = (short)EstadoTransaccion.Realizado,
                    OperacionCajaId = modelo.OperacionCajaId,
                    Concepto = modelo.Concepto
                });

                _db.SaveChanges();

                transaccion.Commit();

                log.Info("TransaccionServicio - Crear - Fin");
            }
            catch(Exception ex)
            {
                if (transaccion != null) transaccion.Rollback();
                log.Error(ex);
                throw;
            }
            finally
            {
                if (transaccion != null) transaccion.Dispose();
            }
        }

        public List<Tbl_Transaccion> ObtenerTodos(string noCuenta)
        {
            log.Info("TransaccionServicio - ObtenerTodos - Inicio");
            var cuenta = _db.Tbl_Cuenta.SingleOrDefault(x => x.NoCuenta == noCuenta.Trim());

            if (cuenta == null)
                throw new Exception($"La cuenta no existe ({noCuenta})");

            var data = _db.Tbl_Transaccion.Where(x => x.CuentaId == cuenta.Id || x.CuentaDestinoId == cuenta.Id)
                .OrderByDescending(x => x.Fecha).ToList();

            log.Info("TransaccionServicio - ObtenerTodos - Fin");
            return data;
        }

        public Tbl_Transaccion Obtener(int id)
        {
            log.Info("TransaccionServicio - Obtener - Inicio");
            var data = _db.Tbl_Transaccion.SingleOrDefault(x => x.Id == id);
            log.Info("TransaccionServicio - Obtener - Fin");
            return data;
        }

        public void Editar(Tbl_Transaccion modelo)
        {
            log.Info("TransaccionServicio - Editar - Inicio");
            var registro = _db.Tbl_Transaccion.SingleOrDefault(x => x.Id == modelo.Id);

            if (modelo.TipoTransaccionId != 0)
                registro.TipoTransaccionId = modelo.TipoTransaccionId;

            if (modelo.Monto != 0)
                registro.Monto = modelo.Monto;

            if (modelo.CuentaId != 0)
                registro.CuentaId = modelo.CuentaId;

            if (modelo.OperacionCajaId != 0)
                registro.OperacionCajaId = modelo.OperacionCajaId;

            _db.SaveChanges();
            log.Info("TransaccionServicio - Editar - Fin");
        }
    }
}

