﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Production
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Production_of_productsEntities1 : DbContext
    {
        private static Production_of_productsEntities1 _context;
        public Production_of_productsEntities1()
            : base("name=Production_of_productsEntities1")
        {
        }
        public static Production_of_productsEntities1 GetContext()
        {
            if (_context == null)
                _context = new Production_of_productsEntities1();
            return _context;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Агенты> Агенты { get; set; }
        public virtual DbSet<ВремяРаботыСотрудн> ВремяРаботыСотрудн { get; set; }
        public virtual DbSet<Заявки> Заявки { get; set; }
        public virtual DbSet<ИсторИзменПриорит> ИсторИзменПриорит { get; set; }
        public virtual DbSet<ИсторияИзмМинСтоимПродук> ИсторияИзмМинСтоимПродук { get; set; }
        public virtual DbSet<Материалы> Материалы { get; set; }
        public virtual DbSet<ПередвижСотрудников> ПередвижСотрудников { get; set; }
        public virtual DbSet<Поставщики> Поставщики { get; set; }
        public virtual DbSet<Продукция> Продукция { get; set; }
        public virtual DbSet<Производство> Производство { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }
        public virtual DbSet<ИсторияИзмКолМатер> ИсторияИзмКолМатер { get; set; }
    }
}