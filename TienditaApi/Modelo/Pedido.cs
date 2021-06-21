using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TienditaApi.Modelo
{
    public class Pedido
    {
        [Key]

        public Guid Id_Pedido { get; set; }
        public DateTime Fecha { get; set; }
        public Guid Id_Cliente { get; set; }

        public List<DetallePedidos> DetallePedidoss { get; set; }
    }
}
