using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Entities
{
    public class Opciones
    {
        public int Id { get; set; }

        public int? IdPadre { get; set; }

        public string? Descripcion { get; set; }

        public string? DescripcionHTML { get; set; }

        public string? Url { get; set; }

        public string? Icono { get; set; }

        public string? IdElemento { get; set; }

        public bool Estado { get; set; }

        public int UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public List<AsignaOpcionPerfil> AsignaOpcionPerfil { get; set; }
    }
}
