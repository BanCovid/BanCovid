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

        public BanCovid_DBEntities _db;
        public BeneficiarioServicio()
        {
            _db = new BanCovid_DBEntities();
        }


        public void Crear(Tbl_Beneficiario modelo)
        {

            modelo.Estado = 1;
            _db.Tbl_Beneficiario.Add(modelo);

            _db.SaveChanges();

        }


        public List<Tbl_Beneficiario> ObtenerTodos()
        {
            return _db.Tbl_Beneficiario.ToList();
        }
     

        public Tbl_Beneficiario Obtener(int id)
        {
            return _db.Tbl_Beneficiario.SingleOrDefault(x => x.IdCuenta == id);
        }

        

        public void Eliminar(int idCuenta , int idCuentaDestino)
        {
            var registro = _db.Tbl_Beneficiario.SingleOrDefault(x => x.IdCuenta == idCuenta && x.IdCuentaDestino == idCuentaDestino);

            registro.Estado = 0;

            _db.SaveChanges();
        }

    }
}
