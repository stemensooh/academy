namespace ACADEMY.DOMAIN.DTOs
{
    public class PerfilDTO
    {
        public string? Id { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public bool Estado { get; set; }

        public List<string> Opciones { get; set; }

        public List<OpcionDTO> Permisos { get; set; }
    }

    public class OpcionDTO
    {
        public string? Id { get; set; }

        public string? Nombre { get; set; }

        public string? IdPadre { get; set; }

        public string? Url { get; set; }

        public string? Icono { get; set; }

        public bool Estado { get; set; }
    }
}