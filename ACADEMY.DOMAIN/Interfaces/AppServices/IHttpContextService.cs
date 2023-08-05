namespace ACADEMY.DOMAIN.Interfaces.AppServices
{
    public interface IHttpContextService
    {
        int IdUsuario { get; }

        string Usuario { get; }

        int Sesion { get; }

        string Ip { get; }

        string UserAgent { get; }

        string Token { get; }
    }
}