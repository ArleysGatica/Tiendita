using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TienditaApi.Modelo
{
    public class DetallePedidos
    { 
		[Key]
		public Guid ArticuloID { get; set; }
		public Guid PedidoID { get; set; }
		public int Cantidad { get; set; }
		public decimal Precio { get; set; }
		public decimal Descuento { get; set; }
		public decimal MontoT { get; set; }
		public decimal MontoF { get; set; }
		public Pedido Pedido { get; set; }
		public Articulo Articulo { get; set; }
		
	}
	class DetallePedidoEntidadConfig : IEntityTypeConfiguration<DetallePedidos>
	{
		public void Configure(EntityTypeBuilder<DetallePedidos> builder)
		{

			//builder.HasKey(DetallePedidoEntidad => DetallePedidoEntidad.Id_DetallePedidoEntidad);
			builder.HasKey(e => new { e.ArticuloID, e.PedidoID })

					.IsClustered(false);
		}
	}
}
