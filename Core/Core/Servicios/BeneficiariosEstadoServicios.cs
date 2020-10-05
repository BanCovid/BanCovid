using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{    
    public class BeneficiariosEstadoServicios
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BanCovid_DBEntities _db;
        public BeneficiariosEstadoServicios()
        {
            _db = new BanCovid_DBEntities();
        }

        public List<Tbl_BeneficiarioEstado> ObtenerTodos()
        {
            log.Info("BeneficiariosEstadoServicios - ObtenerTodos - Inicio");
            var data = _db.Tbl_BeneficiarioEstado.ToList();
            log.Info("BeneficiariosEstadoServicios - ObtenerTodos - Fin");
            return data;
        }

        public Tbl_BeneficiarioEstado Obtener(int id)
        {
            log.Info("BeneficiariosEstadoServicios - Obtener - Inicio");
            var data = _db.Tbl_BeneficiarioEstado.SingleOrDefault(x => x.Id == id);
            log.Info("BeneficiariosEstadoServicios - Obtener - Fin");
            return data;
        }

        public void Editar(Tbl_BeneficiarioEstado modelo)
        {
            log.Info("BeneficiariosEstadoServicios - Editar - Inicio");           
            var registro = _db.Tbl_BeneficiarioEstado.SingleOrDefault(x => x.Id == modelo.Id);

            if (!string.IsNullOrWhiteSpace(modelo.Nombre))
                registro.Nombre = modelo.Nombre;

            _db.SaveChanges();
            log.Info("BeneficiariosEstadoServicios - Editar - Fin");
        }
    }
}
