using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TienditaApi.Modelo;

namespace TienditaApi.Context
{
    public class AppDbContext : DbContext 
    {

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
          
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<DetallePedidos> DetallePedido { get; set; }
        public DbSet<Pedido> pedido { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Categoria> categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         
            modelBuilder.ApplyConfiguration(new DetallePedidoEntidadConfig()); 
            modelBuilder.ApplyConfiguration(new ProveedorEntidadConfig());
            modelBuilder.ApplyConfiguration(new CategoriaEntidadConfig());



        }

    }//databe.ensured cre
}
