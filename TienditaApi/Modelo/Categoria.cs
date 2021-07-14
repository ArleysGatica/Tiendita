using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TienditaApi.Modelo
{
    public class Categoria
    {

        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Articulo> Articulos { get; set; }
    }
    class CategoriaEntidadConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            //builder.ToTable("Proveedores");
            builder.HasKey(Categoria => Categoria.CategoriaID);
        }
    }
}
