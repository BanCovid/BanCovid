using Core.General;
using Core.ModeloData;
using Core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Servicios
{
    public class UsuariosServicio
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public BanCovid_DBEntities _db;
        public UsuariosServicio()
        {
            _db = new BanCovid_DBEntities();
        }

        public void Crear(Tbl_Usuario modelo)
        {
            log.Info("UsuariosServicio - Crear - Inicio");
            modelo.Estado = 1;
            modelo.Password = Seguridad.EncriptarContrasena(modelo.Password);
            _db.Tbl_Usuario.Add(modelo);

            _db.SaveChanges();
            log.Info("UsuariosServicio - Crear - Fin");
        }

        public Tbl_Usuario InicioSesion(UsuarioModelo modelo)
        {
            log.Info("UsuariosServicio - InicioSesion - Inicio");

            var usuario = _db.Tbl_Usuario.SingleOrDefault(x => x.UserName == modelo.UserName);

            if (!Seguridad.Validar(modelo.Password, usuario.Password))
                throw new Exception("Usuario o contraseña incorrecta");
            
            log.Info("UsuariosServicio - InicioSesion - Fin");
            return usuario;
        }

        public List<Tbl_Usuario> ObtenerTodos()
        {
            log.Info("UsuariosServicio - ObtenerTodos - Inicio");
            var data = _db.Tbl_Usuario.ToList();
            log.Info("UsuariosServicio - ObtenerTodos - Fin");
            return data;
        }

        public Tbl_Usuario Obtener(int id)
        {
            log.Info("UsuariosServicio - Obtener - Inicio");
            var data = _db.Tbl_Usuario.SingleOrDefault(x => x.Id == id);
            log.Info("UsuariosServicio - Obtener - Fin");
            return data;
        }

        public void Editar(Tbl_Usuario modelo)
        {
            log.Info("UsuariosServicio - Editar - Inicio");
            var registro = _db.Tbl_Usuario.SingleOrDefault(x => x.Id == modelo.Id);

            if (!string.IsNullOrWhiteSpace(modelo.UserName))
                registro.UserName = modelo.UserName;

            if (modelo.Password != null)
                registro.Password = modelo.Password;

            if (!string.IsNullOrWhiteSpace(modelo.Nombre))
                registro.Nombre = modelo.Nombre;

            if (!string.IsNullOrWhiteSpace(modelo.Apellido))
                registro.Apellido = modelo.Apellido;

            if (!string.IsNullOrWhiteSpace(modelo.Telefono))
                registro.Telefono = modelo.Telefono;

            if (!string.IsNullOrWhiteSpace(modelo.Nombre))
                registro.Nombre = modelo.Nombre;

            if (modelo.Perfil_Id != 0)
                registro.Perfil_Id = modelo.Perfil_Id;

            _db.SaveChanges();
            log.Info("UsuariosServicio - Editar - Fin");
        }

        public void Eliminar(int id)
        {
            log.Info("UsuariosServicio - Eliminar - Inicio");
            var registro = _db.Tbl_Usuario.SingleOrDefault(x => x.Id == id);

            registro.Estado = 0;

            _db.SaveChanges();
            log.Info("UsuariosServicio - Eliminar - Fin");
        }
    }
}
