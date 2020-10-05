using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class TransaccionServicio
    {
        public BanCovid_DBEntities _db;
        public TransaccionServicio()
        {
            _db = new BanCovid_DBEntities();
        }

        public List<Tbl_Transaccion> ObtenerTodos()
        {
            return _db.Tbl_Transaccion.ToList();
        }


        public Tbl_Transaccion Obtener(int id)
        {
            return _db.Tbl_Transaccion.SingleOrDefault(x => x.Id == id);
        }

        public void Editar(Tbl_Transaccion modelo)
        {
            var registro = _db.Tbl_Transaccion.SingleOrDefault(x => x.Id == modelo.Id);

            if (modelo.TipoTransaccionId != 0)
                registro.TipoTransaccionId = modelo.TipoTransaccionId;

            if (modelo.Monto != 0)
                registro.Monto = modelo.Monto;



            if (modelo.CuentaId != 0)
                registro.CuentaId = modelo.CuentaId;

            if (modelo.CajaId != 0)
                registro.CajaId = modelo.CajaId;
            _db.SaveChanges();
        }



    }

}

