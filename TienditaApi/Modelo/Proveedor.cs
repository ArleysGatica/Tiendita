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
        public Guid Id_proveedor { get; set; }
        public decimal Nombres { get; set; }
        public decimal Telefono { get; set; }
        public decimal SitioWeb { get; set; }
    }
}
