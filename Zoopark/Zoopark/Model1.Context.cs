﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zoopark
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ZooparkDEntities : DbContext
    {
        public ZooparkDEntities()
            : base("name=ZooparkDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AnimalsT> AnimalsT { get; set; }
        public virtual DbSet<Inform> Inform { get; set; }
        public virtual DbSet<TicketT> TicketT { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<ZooparkT> ZooparkT { get; set; }
    }
}