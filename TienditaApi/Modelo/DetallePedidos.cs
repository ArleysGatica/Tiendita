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
		public decimal cant { get; set; }
		public decimal Precio { get; set; }
		public decimal Descuento { get; set; }
		public decimal MontoT { get; set; }
		public decimal MontoF { get; set; }
		public Guid Id_Articulo { get; set; }
		public Guid Id_Pedido { get; set; }
	}
}
