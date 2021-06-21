using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TienditaApi.Modelo
{
    public class Cliente {
         [Key]

        public Guid Id_Cliente { get; set; }
        public string Cedula { get; set; }
        public string NombresCl { get; set; }
        public string ApellidosCl { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }

    }
}
