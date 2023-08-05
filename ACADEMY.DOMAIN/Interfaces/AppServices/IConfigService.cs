using ACADEMY.DOMAIN.Models;

namespace ACADEMY.DOMAIN.Interfaces.AppServices
{
    public interface IConfigService
    {
        AppConfig AppConfig { get; }

        Config Config { get; }

        Captcha Captcha { get; }

        Token Token { get; }

        string AcademyConexion { get; }

    }
}