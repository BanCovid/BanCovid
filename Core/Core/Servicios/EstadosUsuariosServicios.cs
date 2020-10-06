using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
     public class EstadosUsuariosServicios
     {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BanCovid_DBEntities _db;
        public EstadosUsuariosServicios()
        {
            _db = new BanCovid_DBEntities();
        }

        public void Crear(Tbl_EstadoUsuario modelo) 
        {
            log.Info("EstadosUsuariosServicios - Crear - Inicio");
            modelo.Estado = true;
            _db.Tbl_EstadoUsuario.Add(modelo);

            _db.SaveChanges();
            log.Info("EstadosUsuariosServicios - Crear - Fin");
        }
      
        public List<Tbl_EstadoUsuario> ObtenerTodos()
        {
            log.Info("EstadosUsuariosServicios - ObtenerTodos - Inicio");
            var data = _db.Tbl_EstadoUsuario.ToList();
            log.Info("EstadosUsuariosServicios - ObtenerTodos - Fin");
            return data;
        }
       
        public Tbl_EstadoUsuario Obtener(int id)
        {
            log.Info("EstadosUsuariosServicios - Obtener - Inicio");
            var data = _db.Tbl_EstadoUsuario.SingleOrDefault(x => x.Id == id);
            log.Info("EstadosUsuariosServicios - Obtener - Fin");
            return data;
        }

        public void Editar(Tbl_EstadoUsuario modelo)
        {
            log.Info("EstadosUsuariosServicios - Editar - Inicio");
            var registro = _db.Tbl_EstadoUsuario.SingleOrDefault(x => x.Id == modelo.Id);

            if (!string.IsNullOrWhiteSpace(modelo.Nombre))
                registro.Nombre = modelo.Nombre;

            _db.SaveChanges();
            log.Info("EstadosUsuariosServicios - Editar - Fin");
        }

        public void Eliminar(int id)
        {
            log.Info("EstadosUsuariosServicios - Eliminar - Inicio");
            var registro = _db.Tbl_EstadoUsuario.SingleOrDefault(x => x.Id == id);

            registro.Estado = false;

            _db.SaveChanges();
            log.Info("EstadosUsuariosServicios - Eliminar - Fin");
        }
     }
}
