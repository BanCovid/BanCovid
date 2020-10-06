using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class PerfilServicio
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BanCovid_DBEntities _db;
        public PerfilServicio()
        {
            _db = new BanCovid_DBEntities();
        }

        public void Crear(Tbl_Perfil modelo)
        {
            log.Info("PerfilServicio - Crear - Inicio");
            modelo.Estado = true;
            _db.Tbl_Perfil.Add(modelo);

            _db.SaveChanges();
            log.Info("PerfilServicio - Crear - Fin");
        }

        public List<Tbl_Perfil> ObtenerTodos()
        {
            log.Info("PerfilServicio - ObtenerTodos - Inicio");
            var data = _db.Tbl_Perfil.ToList();
            log.Info("PerfilServicio - ObtenerTodos - Fin");
            return data;
        }

        public Tbl_Perfil Obtener(int id)
        {
            log.Info("PerfilServicio - Obtener - Inicio");
            var data = _db.Tbl_Perfil.SingleOrDefault(x => x.Id == id);
            log.Info("PerfilServicio - Obtener - Fin");
            return data;
        }

        public void Editar(Tbl_Perfil modelo)
        {
            log.Info("PerfilServicio - Editar - Inicio");
            var registro = _db.Tbl_Perfil.SingleOrDefault(x => x.Id == modelo.Id);

            if (!string.IsNullOrWhiteSpace(modelo.Nombre))
                registro.Nombre = modelo.Nombre;

            if (!string.IsNullOrWhiteSpace(modelo.Descripcion))
                registro.Descripcion = modelo.Descripcion;
            _db.SaveChanges();
            log.Info("PerfilServicio - Editar - Fin");
        }

        public void Eliminar(int id)
        {
            log.Info("PerfilServicio - Eliminar - Inicio");
            var registro = _db.Tbl_Perfil.SingleOrDefault(x => x.Id == id);

            registro.Estado = false;

            _db.SaveChanges();
            log.Info("PerfilServicio - Eliminar - Fin");
        }
    }
}

