using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.DTOs
{
    public class RecuperacionDTO
    {
        public string? Opcion { get; set; }

        public string? Correo { get; set; }

        public string? Codigo { get; set; }

        public string? Clave { get; set; }

        public string? NuevaClave { get; set; }

        public bool? IsLogOut { get; set; }
    }
}
