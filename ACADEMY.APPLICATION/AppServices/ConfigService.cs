using ACADEMY.DOMAIN.Interfaces.AppServices;
using ACADEMY.DOMAIN.Models;
using ACADEMY.DOMAIN.Utilities;

namespace ACADEMY.APPLICATION.AppServices
{
    public class ConfigService : IConfigService
    {
        public ConfigService(AppConfig appConfig)
        {
            AppConfig = appConfig;
            Config = appConfig.Config;
            Captcha = appConfig.Captcha;
            
            Token = appConfig.Token;
            //AcademyConexion = AcademyTools.CrearBasicConexion(
            //    Interop.Consulta.UrlApiAuth.Usuario,
            //    Interop.Consulta.UrlApiAuth.Clave
            //);

        }

        public AppConfig AppConfig { get; }
        public Config Config { get; }
        public Captcha Captcha { get; }
        public Token Token { get; }
        public string AcademyConexion { get; }
    }
}