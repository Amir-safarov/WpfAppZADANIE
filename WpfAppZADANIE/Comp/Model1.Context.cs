﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfAppZADANIE.Comp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HardwareShop_SAFEntities8 : DbContext
    {
        public HardwareShop_SAFEntities8()
            : base("name=HardwareShop_SAFEntities8")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Prod_Ord> Prod_Ord { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
