﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core
{
    using Core.ModeloData;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BanCovid_DBEntities : DbContext
    {
        public BanCovid_DBEntities()
            : base("name=BanCovid_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Beneficiario> Tbl_Beneficiario { get; set; }
        public virtual DbSet<Tbl_BeneficiarioEstado> Tbl_BeneficiarioEstado { get; set; }
        public virtual DbSet<Tbl_Caja> Tbl_Caja { get; set; }
        public virtual DbSet<Tbl_Cliente> Tbl_Cliente { get; set; }
        public virtual DbSet<Tbl_Cuenta> Tbl_Cuenta { get; set; }
        public virtual DbSet<Tbl_EstadoUsuario> Tbl_EstadoUsuario { get; set; }
        public virtual DbSet<Tbl_OperacionCaja> Tbl_OperacionCaja { get; set; }
        public virtual DbSet<Tbl_OperacionCajaTipo> Tbl_OperacionCajaTipo { get; set; }
        public virtual DbSet<Tbl_Perfil> Tbl_Perfil { get; set; }
        public virtual DbSet<Tbl_TipoTransaccion> Tbl_TipoTransaccion { get; set; }
        public virtual DbSet<Tbl_Transaccion> Tbl_Transaccion { get; set; }
        public virtual DbSet<Tbl_Usuario> Tbl_Usuario { get; set; }
    }
}