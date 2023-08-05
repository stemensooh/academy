using ACADEMY.DOMAIN.Interfaces.AppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace ACADEMY.APPLICATION.AppServices
{
    public class HttpContextService : IHttpContextService
    {
        public HttpContextService(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext != null)
            {
                IdUsuario = int.Parse(httpContextAccessor.HttpContext.User.FindFirst("Id")?.Value ?? "0");
                Sesion = int.Parse(httpContextAccessor.HttpContext.User.FindFirst("IdSesion")?.Value ?? "0");
                Usuario = httpContextAccessor.HttpContext.User.FindFirst("Usuario")?.Value;
                Ip = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                UserAgent = httpContextAccessor.HttpContext.Request.Headers[HeaderNames.UserAgent].ToString();
                Token = httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            }
        }

        public int IdUsuario { get; }

        public string Usuario { get; }

        public int Sesion { get; }

        public string Ip { get; }

        public string UserAgent { get; }

        public string Token { get; }
    }
}