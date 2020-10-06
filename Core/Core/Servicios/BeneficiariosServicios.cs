using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class BeneficiarioServicio
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BanCovid_DBEntities _db;
        public BeneficiarioServicio()
        {
            _db = new BanCovid_DBEntities();
        }

        public void Crear(Tbl_Beneficiario modelo)
        {
            log.Info("BeneficiarioServicio - Crear - Inicio");
            modelo.Estado = 1;
            _db.Tbl_Beneficiario.Add(modelo);

            _db.SaveChanges();
            log.Info("BeneficiarioServicio - Crear - Fin");
        }

        public List<Tbl_Beneficiario> ObtenerTodos()
        {
            log.Info("BeneficiarioServicio - ObtenerTodos - Inicio");
            var data = _db.Tbl_Beneficiario.ToList();
            log.Info("BeneficiarioServicio - ObtenerTodos - Fin");
            return data;
        }
     
        public Tbl_Beneficiario Obtener(int id)
        {
            log.Info("BeneficiarioServicio - Obtener - Inicio");
            var data = _db.Tbl_Beneficiario.SingleOrDefault(x => x.CuentaId == id);
            log.Info("BeneficiarioServicio - Obtener - Fin");
            return data;
        }

        public void Eliminar(int idCuenta , int idCuentaDestino)
        {
            log.Info("BeneficiarioServicio - Eliminar - Inicio");
            var registro = _db.Tbl_Beneficiario.SingleOrDefault(x => x.CuentaId == idCuenta && x.CuentaDestinoId== idCuentaDestino);

            registro.Estado = 0;

            _db.SaveChanges();
            log.Info("BeneficiarioServicio - Eliminar - Fin");
        }
    }
}
