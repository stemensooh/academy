using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Entities
{
    public class UsuarioSesion
    {
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public string? IpSesion { get; set; }

        public DateTime FechaExpiraSesion { get; set; }

        public string? Navegador { get; set; }

        public string? Os { get; set; }

        public string? Dispositivo { get; set; }

        public bool Estado { get; set; }

        public Usuario? Usuario { get; set; }
    }
}
