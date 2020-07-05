using Microsoft.EntityFrameworkCore;
using RegistroPedidosDetalle.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPedidosDetalle.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Suplidores> suplidores { get; set; }
        public DbSet<Productos> productos { get; set; }
        public DbSet<Ordenes> ordenes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source = Pedidos.db");
        }
    }
}
