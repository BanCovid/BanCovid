using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class PerfilServicio
    {
        public BanCovid_DBEntities _db;
        public PerfilServicio()
        {
            _db = new BanCovid_DBEntities();
        }


        public void Crear(Tbl_Perfil modelo)
        {

            modelo.Estado = true;
            _db.Tbl_Perfil.Add(modelo);

            _db.SaveChanges();

        }


        public List<Tbl_Perfil> ObtenerTodos()
        {
            return _db.Tbl_Perfil.ToList();
        }


        public Tbl_Perfil Obtener(int id)
        {
            return _db.Tbl_Perfil.SingleOrDefault(x => x.Id == id);
        }

        public void Editar(Tbl_Perfil modelo)
        {
            var registro = _db.Tbl_Perfil.SingleOrDefault(x => x.Id == modelo.Id);

            if (string.IsNullOrWhiteSpace(modelo.Nombre))
                registro.Nombre = modelo.Nombre;

            if (string.IsNullOrWhiteSpace(modelo.Descripcion))
                registro.Descripcion = modelo.Descripcion;
            _db.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var registro = _db.Tbl_Perfil.SingleOrDefault(x => x.Id == id);

            registro.Estado = false;

            _db.SaveChanges();
        }

    }

}

