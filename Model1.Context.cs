﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bd
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class sqlEntities : DbContext
    {
        public sqlEntities()
            : base("name=sqlEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C3_НДФЛ> C3_НДФЛ { get; set; }
        public virtual DbSet<C6_НДФЛ> C6_НДФЛ { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<Декларация> Декларация { get; set; }
        public virtual DbSet<ЕНВД> ЕНВД { get; set; }
        public virtual DbSet<Налоги> Налоги { get; set; }
        public virtual DbSet<НДС> НДС { get; set; }
        public virtual DbSet<Организация> Организация { get; set; }
        public virtual DbSet<Прибыль> Прибыль { get; set; }
        public virtual DbSet<РСВ> РСВ { get; set; }
        public virtual DbSet<ФСС> ФСС { get; set; }
    }
}
