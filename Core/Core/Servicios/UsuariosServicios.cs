using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class UsuariosServicio
    {
        public BanCovid_DBEntities _db;
        public UsuariosServicio()
        {
            _db = new BanCovid_DBEntities();
        }


        public void Crear(Tbl_Usuario modelo)
        {

            modelo.Estado = 1;
            _db.Tbl_Usuario.Add(modelo);

            _db.SaveChanges();

        }


        public List<Tbl_Usuario> ObtenerTodos()
        {
            return _db.Tbl_Usuario.ToList();
        }


        public Tbl_Usuario Obtener(int id)
        {
            return _db.Tbl_Usuario.SingleOrDefault(x => x.Id == id);
        }

        public void Editar(Tbl_Usuario modelo)
        {
            var registro = _db.Tbl_Usuario.SingleOrDefault(x => x.Id == modelo.Id);

            if (string.IsNullOrWhiteSpace(modelo.UserName))
                registro.UserName = modelo.UserName;

            if (modelo.Password != null)
                registro.Password = modelo.Password;

            if (modelo.Salt != null)
                registro.Salt = modelo.Salt;

            if (string.IsNullOrWhiteSpace(modelo.Nombre))
                registro.Nombre = modelo.Nombre;

            if (string.IsNullOrWhiteSpace(modelo.Apellido))
                registro.Apellido = modelo.Apellido;

            if (string.IsNullOrWhiteSpace(modelo.Telefono))
                registro.Telefono = modelo.Telefono;

            if (string.IsNullOrWhiteSpace(modelo.Nombre))
                registro.Nombre = modelo.Nombre;

            if (string.IsNullOrWhiteSpace(modelo.Perfil_Id))
                registro.Perfil_Id = modelo.Perfil_Id;



            _db.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var registro = _db.Tbl_Usuario.SingleOrDefault(x => x.Id == id);

            registro.Estado = 0;

            _db.SaveChanges();
        }
    }

}
