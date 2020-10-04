using Core.ModeloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    class ClienteServicios
    {
        public BanCovid_DBEntities _db;
        public ClienteServicios()
        {
            _db = new BanCovid_DBEntities();
        }


       
        

        public List<Tbl_Cliente> ObtenerTodos()
        {
            return _db.Tbl_Cliente.ToList();
        }


        public Tbl_Cliente Obtener(int id)
        {
            return _db.Tbl_Cliente.SingleOrDefault(x => x.Id == id);
        }

        public void Editar(Tbl_Cliente modelo)
        {
            var registro = _db.Tbl_Cliente.SingleOrDefault(x => x.Id == modelo.Id);

            if (string.IsNullOrWhiteSpace(modelo.Direccion))
                registro.Direccion = modelo.Direccion;

            

            if (modelo.UsuarioId != 0)
                registro.UsuarioId = modelo.UsuarioId;

            _db.SaveChanges();
        }

       
    }

}
