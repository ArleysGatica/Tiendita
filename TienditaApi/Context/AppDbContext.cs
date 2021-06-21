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
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Articulo> articulo { get; set; }
        public DbSet<DetallePedidos> detallePedido { get; set; }
        public DbSet<Pedido> pedido { get; set; }
        public DbSet<Proveedor> proveedor { get; set; }



    }//databe.ensured cre
}
