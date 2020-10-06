using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class ClienteServicios
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BanCovid_DBEntities _db;
        public ClienteServicios()
        {
            _db = new BanCovid_DBEntities();
        }

        public List<Tbl_Cliente> ObtenerTodos()
        {
            log.Info("ClienteServicios - ObtenerTodos - Inicio");
            var data = _db.Tbl_Cliente.ToList();
            log.Info("ClienteServicios - ObtenerTodos - Fin");
            return data;
        }

        public Tbl_Cliente Obtener(int id)
        {
            log.Info("ClienteServicios - Obtener - Inicio");
            var data = _db.Tbl_Cliente.SingleOrDefault(x => x.Id == id);
            log.Info("ClienteServicios - Obtener - Fin");
            return data;
        }

        public void Editar(Tbl_Cliente modelo)
        {
            log.Info("ClienteServicios - Editar - Inicio");
            var registro = _db.Tbl_Cliente.SingleOrDefault(x => x.Id == modelo.Id);

            if (!string.IsNullOrWhiteSpace(modelo.Direccion))
                registro.Direccion = modelo.Direccion;
            
            _db.SaveChanges();
            log.Info("ClienteServicios - Editar - Fin");
        }       
    }
}
