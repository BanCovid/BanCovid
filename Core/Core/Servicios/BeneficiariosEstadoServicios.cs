using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    class BeneficiariosEstadoServicios
    {
        public class BeneficiariosEsadoServicios
        {
            public BanCovid_DBEntities _db;
            public BeneficiariosEsadoServicios()
            {
                _db = new BanCovid_DBEntities();
            }


           


            public List<Tbl_BeneficiarioEstado> ObtenerTodos()
            {
                return _db.Tbl_BeneficiarioEstado.ToList();
            }


            public Tbl_BeneficiarioEstado Obtener(int id)
            {
                return _db.Tbl_BeneficiarioEstado.SingleOrDefault(x => x.Id == id);
            }

            public void Editar(Tbl_BeneficiarioEstado modelo)
            {
                var registro = _db.Tbl_BeneficiarioEstado.SingleOrDefault(x => x.Id == modelo.Id);

                if (string.IsNullOrWhiteSpace(modelo.Nombre))
                    registro.Nombre = modelo.Nombre;





                _db.SaveChanges();
            }

           
        }
    }
}
