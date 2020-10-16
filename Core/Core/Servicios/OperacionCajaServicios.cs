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
    public enum TipoOperacion : short
    {
        AperturaCaja = 1,
        CierreCaja = 2,
        EntradaEfectivo = 3,
        SalidaEfectivo = 4
    }

    public class OperacionCajaServicios
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BanCovid_DBEntities _db;
        public OperacionCajaServicios()
        {
            _db = new BanCovid_DBEntities();
        }

        public void Crear(Tbl_OperacionCaja modelo)
        {
            log.Info("OperacionCajaServicios - Crear - Inicio");
            DbContextTransaction transaccion = null;
            try
            {
                modelo.Estado = true;
                modelo.Fecha = DateTime.Now;

                var caja = _db.Tbl_Caja.SingleOrDefault(x => x.Id == modelo.CajaId);

                if (caja == null)
                    throw new Exception("La cuenta no existe");

                if (modelo.TipoId == (short)TipoOperacion.AperturaCaja)
                {
                    var cajaOp = _db.Tbl_OperacionCaja.SingleOrDefault(x => x.CajaId == modelo.CajaId
                                    && x.TipoId == (short)TipoOperacion.AperturaCaja
                                    && x.Fecha.Date == DateTime.Now.Date);
                    if (cajaOp != null)
                        throw new Exception("La caja ya se encuentra abierta");
                    caja.Estado = true;
                }
                else if (modelo.TipoId == (short)TipoOperacion.CierreCaja)
                {
                    decimal entradasDeHoy = 0, salidasDeHoy = 0;

                    _db.Tbl_OperacionCaja
                                    .Where(x => 
                                        x.CajaId == modelo.CajaId && 
                                        x.TipoId == (short)TipoOperacion.EntradaEfectivo && 
                                        x.Fecha.Date == DateTime.Now.Date)
                                    .ToList()
                                    .Aggregate(entradasDeHoy, (x, y) => entradasDeHoy + y.Monto);

                    _db.Tbl_OperacionCaja
                                    .Where(x => 
                                        x.CajaId == modelo.CajaId && 
                                        x.TipoId == (short)TipoOperacion.SalidaEfectivo && 
                                        x.Fecha.Date == DateTime.Now.Date)
                                    .ToList()
                                    .Aggregate(salidasDeHoy, (x, y) => entradasDeHoy + y.Monto);
                    
                    caja.Monto = entradasDeHoy - salidasDeHoy;
                    caja.Estado = false;
                }

                _db.Tbl_OperacionCaja.Add(modelo);


                _db.SaveChanges();
                log.Info("OperacionCajaServicios - Crear - Fin");
                transaccion.Commit();
            }
            catch (Exception ex)
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

        public void Entrada(OperacionCajaES modelo)
        {
            log.Info("OperacionCajaServicios - Entrada - Inicio");

            DbContextTransaction transaccion = null;
            try
            {
                transaccion = _db.Database.BeginTransaction();
                var cuenta = _db.Tbl_Cuenta.SingleOrDefault(x => x.NoCuenta == modelo.CuentaDestino.Trim());

                if (cuenta == null)
                    throw new Exception("La cuenta no existe");

                var modeloObj = new Tbl_OperacionCaja();

                modeloObj.CajaId = modelo.CajaId;
                modeloObj.Estado = true;
                modeloObj.Fecha = DateTime.Now;
                modeloObj.Monto = modelo.Monto;
                modeloObj.TipoId = (short)TipoOperacion.EntradaEfectivo;

                _db.Tbl_OperacionCaja.Add(modeloObj);

                _db.SaveChanges();

                _db.Tbl_Transaccion.Add(new Tbl_Transaccion
                {
                    Monto = modelo.Monto,
                    CuentaId = cuenta.Id,
                    CuentaDestinoId = null,
                    TipoTransaccionId = (short)TipoTransaccion.Deposito,
                    Fecha = DateTime.Now,
                    Estado = (short)EstadoTransaccion.Realizado, // Deberia ser en proceso
                    OperacionCajaId = modeloObj.Id,
                    Concepto = "Entrada de efectivo desde cajero"
                });

                _db.SaveChanges();

                log.Info("OperacionCajaServicios - Entrada - Fin");

                transaccion.Commit();
            }
            catch (Exception ex)
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


        public void Salida(OperacionCajaES modelo)
        {
            log.Info("OperacionCajaServicios - Salida - Inicio");

            DbContextTransaction transaccion = null;
            try
            {
                transaccion = _db.Database.BeginTransaction();
                var cuenta = _db.Tbl_Cuenta.SingleOrDefault(x => x.NoCuenta == modelo.CuentaDestino.Trim());

                if (cuenta == null)
                    throw new Exception("La cuenta no existe");

                var modeloObj = new Tbl_OperacionCaja();

                modeloObj.CajaId = modelo.CajaId;
                modeloObj.Estado = true;
                modeloObj.Fecha = DateTime.Now;
                modeloObj.Monto = modelo.Monto;
                modeloObj.TipoId = (short)TipoOperacion.SalidaEfectivo;

                _db.Tbl_OperacionCaja.Add(modeloObj);

                _db.SaveChanges();

                _db.Tbl_Transaccion.Add(new Tbl_Transaccion
                {
                    Monto = modelo.Monto,
                    CuentaId = cuenta.Id,
                    CuentaDestinoId = null,
                    TipoTransaccionId = (short)TipoTransaccion.Retiro,
                    Fecha = DateTime.Now,
                    Estado = (short)EstadoTransaccion.Realizado, // Deberia ser en proceso
                    OperacionCajaId = modeloObj.Id,
                    Concepto = "Salida de efectivo desde cajero"
                });

                _db.SaveChanges();

                log.Info("OperacionCajaServicios - Salida - Fin");

                transaccion.Commit();
            }
            catch (Exception ex)
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


        public List<Tbl_OperacionCaja> ObtenerTodos()
        {
            log.Info("OperacionCajaServicios - ObtenerTodos - Inicio");
            var data = _db.Tbl_OperacionCaja.ToList();
            log.Info("OperacionCajaServicios - ObtenerTodos - Fin");
            return data;
        }

        public Tbl_OperacionCaja Obtener(int id)
        {
            log.Info("OperacionCajaServicios - Obtener - Inicio");
            var data = _db.Tbl_OperacionCaja.SingleOrDefault(x => x.Id == id);
            log.Info("OperacionCajaServicios - Obtener - Fin");
            return data;
        }

        public void Editar(Tbl_OperacionCaja modelo)
        {
            log.Info("OperacionCajaServicios - Editar - Inicio");
            var registro = _db.Tbl_OperacionCaja.SingleOrDefault(x => x.Id == modelo.Id);

            if (modelo.TipoId != 0)
                registro.TipoId = modelo.TipoId;

            if (modelo.Monto != 0)
                registro.Monto = modelo.Monto;
            
            _db.SaveChanges();
            log.Info("OperacionCajaServicios - Editar - Fin");
        }

        public void Eliminar(int id)
        {
            log.Info("OperacionCajaServicios - Eliminar - Inicio");
            var registro = _db.Tbl_OperacionCaja.SingleOrDefault(x => x.Id == id);

            registro.Estado = false;

            _db.SaveChanges();
            log.Info("OperacionCajaServicios - Eliminar - Fin");
        }
    }
}
