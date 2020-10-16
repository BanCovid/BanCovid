using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{

    public class TipoTransaccionServicio
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BanCovid_DBEntities _db;
        public TipoTransaccionServicio()
        {
            _db = new BanCovid_DBEntities();
        }

        public List<Tbl_TipoTransaccion> ObtenerTodos()
        {
            log.Info("TipoTransaccionServicio - ObtenerTodos - Inicio");
            var data = _db.Tbl_TipoTransaccion.ToList();
            log.Info("TipoTransaccionServicio - ObtenerTodos - Fin");
            return data;
        }

        public Tbl_TipoTransaccion Obtener(int id)
        {
            log.Info("TipoTransaccionServicio - Obtener - Inicio");
            var data = _db.Tbl_TipoTransaccion.SingleOrDefault(x => x.Id == id);
            log.Info("TipoTransaccionServicio - Obtener - Fin");
            return data;
        }

        public void Editar(Tbl_TipoTransaccion modelo)
        {
            log.Info("TipoTransaccionServicio - Editar - Inicio");
            var registro = _db.Tbl_TipoTransaccion.SingleOrDefault(x => x.Id == modelo.Id);

            if (!string.IsNullOrWhiteSpace(modelo.Nombre))
                registro.Nombre = modelo.Nombre;

            _db.SaveChanges();
            log.Info("TipoTransaccionServicio - Editar - Fin");
        }
    }
}