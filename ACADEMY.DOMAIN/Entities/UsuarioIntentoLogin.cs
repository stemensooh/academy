using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Entities
{
    public class UsuarioIntentoLogin
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? IpIntento { get; set; }
        public DateTime FechaIntento { get; set; }
    }
}
