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
        public BanCovid_DBEntities _db;
        public CuentaServicio()
        {
            _db = new BanCovid_DBEntities();
        }


       


        public List<Tbl_Cuenta> ObtenerTodos()
        {
            return _db.Tbl_Cuenta.ToList();
        }


        public Tbl_Cuenta Obtener(int id)
        {
            return _db.Tbl_Cuenta.SingleOrDefault(x => x.Id == id);
        }

        public void Editar(Tbl_Cuenta modelo)
        {
            var registro = _db.Tbl_Cuenta.SingleOrDefault(x => x.Id == modelo.Id);

            if (modelo.ClienteId != 0 )
                registro.ClienteId = modelo.ClienteId;

            if (modelo.Monto != 0)
                registro.Monto = modelo.Monto;

            

            _db.SaveChanges();
        }

       
    }
}
