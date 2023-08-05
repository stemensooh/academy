namespace ACADEMY.DOMAIN.DTOs
{
    public class UsuarioDTO
    {
        public string? Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Cedula { get; set; }
        public string? Correo { get; set; }
        public string? Perfil { get; set; }
        public DateTime? UltimaConexion { get; set; }
        public bool Estado { get; set; }
        public string? FechaClave { get; set; }
        public PerfilDTO Rol { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
