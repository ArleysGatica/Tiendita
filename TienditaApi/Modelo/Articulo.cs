using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TienditaApi.Modelo
{
    public class Articulo
    {
        [Key]
        public Guid ArticuloID { get; set; }
        public int CategoriaID { get; set; }
        public Guid ProveedorID { get; set; }
        public string NombreArt { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
        public Proveedor Proveedor { get; set; }
       public Categoria Categoria { get; set; }
        

        public List<DetallePedidos> DetallePedidoss { get; set; }

    }
}
