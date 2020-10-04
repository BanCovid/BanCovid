using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    class OperacionCajaServicios
    {
        public BanCovid_DBEntities _db;
        public OperacionCajaServicios()
        {
            _db = new BanCovid_DBEntities();
        }


        public void Crear(Tbl_OperacionCaja modelo)
        {

            modelo.Estado = true;
            _db.Tbl_OperacionCaja.Add(modelo);

            _db.SaveChanges();

        }


        public List<Tbl_OperacionCaja> ObtenerTodos()
        {
            return _db.Tbl_OperacionCaja.ToList();
        }


        public Tbl_OperacionCaja Obtener(int id)
        {
            return _db.Tbl_OperacionCaja.SingleOrDefault(x => x.Id == id);
        }

        public void Editar(Tbl_OperacionCaja modelo)
        {
            var registro = _db.Tbl_OperacionCaja.SingleOrDefault(x => x.Id == modelo.Id);

            if (modelo.TipoId != 0)
                registro.TipoId = modelo.TipoId;

            if (modelo.Monto != 0)
                registro.Monto = modelo.Monto;

            

            _db.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var registro = _db.Tbl_OperacionCaja.SingleOrDefault(x => x.Id == id);

            registro.Estado = false;

            _db.SaveChanges();
        }
    }
}
