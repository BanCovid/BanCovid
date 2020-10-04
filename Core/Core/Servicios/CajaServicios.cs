using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    class CajaServicios
    {
        public class CajaServicio
        {
            public BanCovid_DBEntities _db;
            public CajaServicio()
            {
                _db = new BanCovid_DBEntities();
            }


            public void Crear(Tbl_Caja modelo)
            {

                modelo.Estado = 1;
                _db.Tbl_Caja.Add(modelo);

                _db.SaveChanges();

            }


            public List<Tbl_Caja> ObtenerTodos()
            {
                return _db.Tbl_Caja.ToList();
            }


            public Tbl_Caja Obtener(int id)
            {
                return _db.Tbl_Caja.SingleOrDefault(x => x.Id == id);
            }

            public void Editar(Tbl_Caja modelo)
            {
                var registro = _db.Tbl_Caja.SingleOrDefault(x => x.Id == modelo.Id);

                if (string.IsNullOrWhiteSpace(modelo.Descripcion))
                    registro.Descripcion = modelo.Descripcion;

                if (modelo.FechaCreacion != null)
                    registro.FechaCreacion = modelo.FechaCreacion;

                if (modelo.Monto != 0)
                    registro.Monto = modelo.Monto;

                _db.SaveChanges();
            }

            public void Eliminar(int id)
            {
                var registro = _db.Tbl_Caja.SingleOrDefault(x => x.Id == id);

                registro.Estado = 0;

                _db.SaveChanges();
            }


        }

    }

}

