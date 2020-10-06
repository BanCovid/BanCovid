using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class CuentaServicio
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BanCovid_DBEntities _db;
        public CuentaServicio()
        {
            _db = new BanCovid_DBEntities();
        }
     
        public List<Tbl_Cuenta> ObtenerTodos()
        {
            log.Info("CuentaServicio - ObtenerTodos - Inicio");
            var data = _db.Tbl_Cuenta.ToList();
            log.Info("CuentaServicio - ObtenerTodos - Fin");
            return data;
        }

        public Tbl_Cuenta Obtener(int id)
        {
            log.Info("CuentaServicio - Obtener - Inicio");
            var data = _db.Tbl_Cuenta.SingleOrDefault(x => x.Id == id);
            log.Info("CuentaServicio - Obtener - Fin");
            return data;
        }

        public void Editar(Tbl_Cuenta modelo)
        {
            log.Info("CuentaServicio - Editar - Inicio");
            var registro = _db.Tbl_Cuenta.SingleOrDefault(x => x.Id == modelo.Id);

            if (modelo.ClienteId != 0 )
                registro.ClienteId = modelo.ClienteId;

            if (modelo.Monto != 0)
                registro.Monto = modelo.Monto;
          
            _db.SaveChanges();
            log.Info("CuentaServicio - Editar - Fin");
        }       
    }
}
