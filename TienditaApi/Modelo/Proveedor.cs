using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TienditaApi.Modelo
{
    public class Proveedor
    {
        [Key]
        public Guid ProveedorID { get; set; }
        public string Nombres { get; set; }
        public int Telefono { get; set; }
        public string SitioWeb { get; set; }
        public List<Articulo> articulos { get; set; }
    }
    class ProveedorEntidadConfig : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.ToTable("Proveedores");
            builder.HasKey(Proveedor => Proveedor.ProveedorID);
        }
    }
}
