using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class CajaServicio
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BanCovid_DBEntities _db;
        public CajaServicio()
        {
            _db = new BanCovid_DBEntities();
        }

        public void Crear(Tbl_Caja modelo)
        {
            log.Info("CajaServicio - Crear - Inicio");
            modelo.Estado = true;
            _db.Tbl_Caja.Add(modelo);

            _db.SaveChanges();
            log.Info("CajaServicio - Crear - Fin");
        }

        public List<Tbl_Caja> ObtenerTodos()
        {
            log.Info("CajaServicio - ObtenerTodos - Inicio");
            var data = _db.Tbl_Caja.ToList();
            log.Info("CajaServicio - ObtenerTodos - Fin");
            return data;
        }

        public Tbl_Caja Obtener(int id)
        {
            log.Info("CajaServicio - Obtener - Inicio");
            var data = _db.Tbl_Caja.SingleOrDefault(x => x.Id == id);
            log.Info("CajaServicio - Obtener - Fin");
            return data;
        }

        public void Editar(Tbl_Caja modelo)
        {
            log.Info("CajaServicio - Editar - Inicio");
            var registro = _db.Tbl_Caja.SingleOrDefault(x => x.Id == modelo.Id);

            if (!string.IsNullOrWhiteSpace(modelo.Descripcion))
                registro.Descripcion = modelo.Descripcion;
           
            if (modelo.Monto != 0)
                registro.Monto = modelo.Monto;

            _db.SaveChanges();
            log.Info("CajaServicio - Editar - Fin");
        }

        public void Eliminar(int id)
        {
            log.Info("CajaServicio - Eliminar - Inicio");
            var registro = _db.Tbl_Caja.SingleOrDefault(x => x.Id == id);

            registro.Estado = false;

            _db.SaveChanges();
            log.Info("CajaServicio - Eliminar - Fin");
        }
    }
}

