using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class TransaccionServicio
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BanCovid_DBEntities _db;
        public TransaccionServicio()
        {
            _db = new BanCovid_DBEntities();
        }

        public List<Tbl_Transaccion> ObtenerTodos()
        {
            log.Info("TransaccionServicio - ObtenerTodos - Inicio");
            var data = _db.Tbl_Transaccion.ToList();
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

            if (modelo.CajaId != 0)
                registro.CajaId = modelo.CajaId;

            _db.SaveChanges();
            log.Info("TransaccionServicio - Editar - Fin");
        }
    }
}

