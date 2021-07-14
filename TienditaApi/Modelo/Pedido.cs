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
        public Guid PedidoID { get; set; }
        public DateTime Fecha { get; set; }
        public Guid ClienteID { get; set; }
        public Cliente cliente { get; set; }

    public List<DetallePedidos> DetallePedidoss { get; set; }
    }
}
