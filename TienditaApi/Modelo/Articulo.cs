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
        public int Id_Articulo { get; set; }
        public int NombreArt { get; set; }
        public int Precio { get; set; }
        public decimal Stock { get; set; }
        public int Id_Proveedor { get; set; }
    }
}
