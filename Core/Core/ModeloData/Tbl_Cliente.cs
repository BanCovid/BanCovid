//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.ModeloData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Cliente()
        {
            this.Tbl_Cuenta = new HashSet<Tbl_Cuenta>();
        }
    
        public int Id { get; set; }
        public string Direccion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
    
        public virtual Tbl_Usuario Tbl_Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Cuenta> Tbl_Cuenta { get; set; }
    }
}
