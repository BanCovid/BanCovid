using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class OperacionCajaTipoServicios
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BanCovid_DBEntities _db;
        public OperacionCajaTipoServicios()
        {
            _db = new BanCovid_DBEntities();
        }

        public void Crear(Tbl_OperacionCajaTipo modelo)
        {
            log.Info("OperacionCajaTipoServicios - Crear - Inicio");
            modelo.Estado = true;
            _db.Tbl_OperacionCajaTipo.Add(modelo);

            _db.SaveChanges();
            log.Info("OperacionCajaTipoServicios - Crear - Fin");
        }

        public List<Tbl_OperacionCajaTipo> ObtenerTodos()
        {
            log.Info("OperacionCajaTipoServicios - ObtenerTodos - Inicio");
            var data = _db.Tbl_OperacionCajaTipo.ToList();
            log.Info("OperacionCajaTipoServicios - ObtenerTodos - Fin");
            return data;
        }

        public Tbl_OperacionCajaTipo Obtener(int id)
        {
            log.Info("OperacionCajaTipoServicios - Obtener - Inicio");
            var data = _db.Tbl_OperacionCajaTipo.SingleOrDefault(x => x.Id == id);
            log.Info("OperacionCajaTipoServicios - Obtener - Fin");
            return data;
        }

        public void Editar(Tbl_OperacionCajaTipo modelo)
        {
            log.Info("OperacionCajaTipoServicios - Editar - Inicio");
            var registro = _db.Tbl_OperacionCajaTipo.SingleOrDefault(x => x.Id == modelo.Id);

            if (!string.IsNullOrWhiteSpace(modelo.Nombre))
                registro.Nombre = modelo.Nombre;
          
            _db.SaveChanges();
            log.Info("OperacionCajaTipoServicios - Editar - Fin");
        }

        public void Eliminar(int idCuenta, int idCuentaDestino)
        {
            log.Info("OperacionCajaTipoServicios - Eliminar - Inicio");
            var registro = _db.Tbl_OperacionCajaTipo.SingleOrDefault(x => x.Id == idCuenta );

            registro.Estado = false;

            _db.SaveChanges();
            log.Info("OperacionCajaTipoServicios - Eliminar - Fin");
        }
    }
}
