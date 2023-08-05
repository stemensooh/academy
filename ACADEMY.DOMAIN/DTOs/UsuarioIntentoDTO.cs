using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.DTOs
{
    public class UsuarioIntentoDTO
    {
        public string? Ip { get; set; }

        public string? Fecha { get; set; }

        public long Cantidad { get; set; }
    }
}
