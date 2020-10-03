using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
     public class EstadosUsuariosServicio
    {
        public BanCovid_DBEntities _db;
        public EstadosUsuariosServicio()
        {
            _db = new BanCovid_DBEntities();
        }


        public void Crear(Tbl_EstadoUsuario modelo) 
        {

            modelo.Estado = true;
            _db.Tbl_EstadoUsuario.Add(modelo);

            _db.SaveChanges();

        }

       
        public List<Tbl_EstadoUsuario> ObtenerTodos()
        {
            return _db.Tbl_EstadoUsuario.ToList();
        }

        
        public Tbl_EstadoUsuario Obtener(int id)
        {
            return _db.Tbl_EstadoUsuario.SingleOrDefault(x => x.Id == id);
        }

        public void Editar(Tbl_EstadoUsuario modelo)
        {
            var registro = _db.Tbl_EstadoUsuario.SingleOrDefault(x => x.Id == modelo.Id);

            if (string.IsNullOrWhiteSpace(modelo.Nombre))
                registro.Nombre = modelo.Nombre;

            _db.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var registro = _db.Tbl_EstadoUsuario.SingleOrDefault(x => x.Id == id);

            registro.Estado = false;

            _db.SaveChanges();
        }
    }
}
