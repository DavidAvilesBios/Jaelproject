﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CorteCaja
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class adMarissa_Bios_no_le_pEntities : DbContext
    {
        public adMarissa_Bios_no_le_pEntities()
            : base("name=adMarissa_Bios_no_le_pEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<admAgente> admAgentes { get; set; }
        public virtual DbSet<admConcepto> admConceptos { get; set; }
        public virtual DbSet<admDocumento> admDocumentos { get; set; }
        public virtual DbSet<TablaUsuario> TablaUsuarios { get; set; }
    }
}
