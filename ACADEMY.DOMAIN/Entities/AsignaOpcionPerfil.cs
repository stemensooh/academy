using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Entities
{
    public class AsignaOpcionPerfil
    {
        public int Id { get; set; }

        public int? IdPerfil { get; set; }

        public int? IdOpcion { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public Perfil Perfil { get; set; }

        public Opciones Opcion { get; set; }
    }
}
