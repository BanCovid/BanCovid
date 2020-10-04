using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class OperacionCajaTipoServicios
    {
        public BanCovid_DBEntities _db;
        public OperacionCajaTipoServicios()
        {
            _db = new BanCovid_DBEntities();
        }


        public void Crear(Tbl_OperacionCajaTipo modelo)
        {

            modelo.Estado = true;
            _db.Tbl_OperacionCajaTipo.Add(modelo);

            _db.SaveChanges();

        }


        public List<Tbl_OperacionCajaTipo> ObtenerTodos()
        {
            return _db.Tbl_OperacionCajaTipo.ToList();
        }


        public Tbl_OperacionCajaTipo Obtener(int id)
        {
            return _db.Tbl_OperacionCajaTipo.SingleOrDefault(x => x.Id == id);
        }

        public void Editar(Tbl_OperacionCajaTipo modelo)
        {
            var registro = _db.Tbl_OperacionCajaTipo.SingleOrDefault(x => x.Id == modelo.Id);

            if (string.IsNullOrWhiteSpace(modelo.Nombre))
                registro.Nombre = modelo.Nombre;

           
            _db.SaveChanges();
        }

        public void Eliminar(int idCuenta, int idCuentaDestino)
        {
            var registro = _db.Tbl_OperacionCajaTipo.SingleOrDefault(x => x.Id == idCuenta );

            registro.Estado = false;

            _db.SaveChanges();
        }

    }
}
