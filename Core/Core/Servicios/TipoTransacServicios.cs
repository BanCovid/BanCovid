using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    class TipoTransacServicios
    {
        public class TipoTransacServicio
        {
            public BanCovid_DBEntities _db;
            public TipoTransacServicio()
            {
                _db = new BanCovid_DBEntities();
            }


            public List<Tbl_TipoTransaccion> ObtenerTodos()
            {
                return _db.Tbl_TipoTransaccion.ToList();
            }


            public Tbl_TipoTransaccion Obtener(int id)
            {
                return _db.Tbl_TipoTransaccion.SingleOrDefault(x => x.Id == id);
            }

            public void Editar(Tbl_TipoTransaccion modelo)
            {
                var registro = _db.Tbl_TipoTransaccion.SingleOrDefault(x => x.Id == modelo.Id);

                if (string.IsNullOrWhiteSpace(modelo.Nombre))
                    registro.Nombre = modelo.Nombre;

                _db.SaveChanges();
            }


        }
    }
}
