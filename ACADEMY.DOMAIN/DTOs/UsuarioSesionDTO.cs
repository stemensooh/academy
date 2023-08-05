using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.DTOs
{
    public class UsuarioSesionDTO
    {
        public string? Id { get; set; }

        public string? Usuario { get; set; }

        public string? IpSesion { get; set; }

        public string? FechaExpiraSesion { get; set; }

        public string? Navegador { get; set; }

        public string? Os { get; set; }

        public string? Dispositivo { get; set; }
    }
}
