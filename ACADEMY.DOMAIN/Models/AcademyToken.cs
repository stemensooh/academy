using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Models
{
    public class AcademyToken
    {
        public string? Id { get; set; }

        public string? Nombres { get; set; }

        public string? Usuario { get; set; }

        public string? Perfil { get; set; }

        public string? FechaClave { get; set; }

        public string? Token { get; set; }

        public DateTime FechaExpiracion { get; set; }
    }
}
