using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
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
            modelo.Estado = true;
            _db.Tbl_OperacionCaja.Add(modelo);

            _db.SaveChanges();
            log.Info("OperacionCajaServicios - Crear - Fin");
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
