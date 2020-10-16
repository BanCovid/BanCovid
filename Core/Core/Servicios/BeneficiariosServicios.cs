using Core.ModeloData;
using Core.Modelos;
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

        public void Crear(BeneficiarioModelo modelo)
        {
            log.Info("BeneficiarioServicio - Crear - Inicio");

            var cuenta = _db.Tbl_Cuenta.SingleOrDefault(x => x.NoCuenta == modelo.CuentaDestino.Trim());

            if (cuenta == null)
                throw new Exception("La cuenta no existe");

            if (cuenta.ClienteId == modelo.ClienteId)
                throw new Exception("No puedes agregar una de tus cuentas como beneficiario");

            var beneficiario = _db.Tbl_Beneficiario.SingleOrDefault(x => x.ClienteId == modelo.ClienteId &&
                x.CuentaDestinoId == cuenta.Id);

            if (beneficiario != null)
                throw new Exception("La cuenta ya existe como beneficiario");

            _db.Tbl_Beneficiario.Add(new Tbl_Beneficiario 
            {
                ClienteId = modelo.ClienteId,
                CuentaDestinoId = cuenta.Id,
                Estado = 1,
                Alias = modelo.Alias,
                FechaCreacion = DateTime.Now
            });

            _db.SaveChanges();
            log.Info("BeneficiarioServicio - Crear - Fin");
        }

        public List<Tbl_Beneficiario> ObtenerTodos(int clienteId)
        {
            log.Info("BeneficiarioServicio - ObtenerTodos - Inicio");
            var data = _db.Tbl_Beneficiario.Where(x => x.ClienteId == clienteId).ToList();
            log.Info("BeneficiarioServicio - ObtenerTodos - Fin");
            return data;
        }
     
        public Tbl_Beneficiario Obtener(int id)
        {
            log.Info("BeneficiarioServicio - Obtener - Inicio");
            var data = _db.Tbl_Beneficiario.SingleOrDefault(x => x.ClienteId == id);
            log.Info("BeneficiarioServicio - Obtener - Fin");
            return data;
        }

        public void Editar(BeneficiarioModelo modelo)
        {
            log.Info("BeneficiarioServicio - Editar - Inicio");
            var cuenta = _db.Tbl_Cuenta.SingleOrDefault(x => x.NoCuenta == modelo.CuentaDestino.Trim());

            if (cuenta == null)
                throw new Exception("La cuenta no existe");

            var beneficiario = _db.Tbl_Beneficiario.SingleOrDefault(x => x.ClienteId == modelo.ClienteId &&
                x.CuentaDestinoId == cuenta.Id);

            if (beneficiario == null)
                throw new Exception("El beneficiario no existe");

            beneficiario.Alias = modelo.Alias;

            log.Info("BeneficiarioServicio - Editar - Fin");
            _db.SaveChanges();
        }

        public void Eliminar(int idCuenta , int idCuentaDestino)
        {
            log.Info("BeneficiarioServicio - Eliminar - Inicio");
            var registro = _db.Tbl_Beneficiario.SingleOrDefault(x => x.ClienteId == idCuenta && x.CuentaDestinoId== idCuentaDestino);

            registro.Estado = 0;

            _db.SaveChanges();
            log.Info("BeneficiarioServicio - Eliminar - Fin");
        }
    }
}
