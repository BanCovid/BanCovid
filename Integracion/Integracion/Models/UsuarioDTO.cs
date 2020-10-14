using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Integracion.Models
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public short Perfil_Id { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public short Estado { get; set; }
    }
}