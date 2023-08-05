using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? Estado { get; set; }
        public int? Intentos { get; set; }
        public DateTime? UltimaConexion { get; set; }
        public DateTime FechaActualizarPassword { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public int? UsuarioCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioModificacion { get; set; }

        public int? IdPerfil { get; set; }

        public Perfil? Perfil { get; set; }
        public List<UsuarioSesion>? Sesiones { get; set; }
    }
}
