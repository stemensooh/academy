namespace ACADEMY.DOMAIN.Models
{
    public class AppConfig
    {
        public ConnectionCredentials ConnectionCredentials { get; set; }

        public Captcha Captcha { get; set; }

        public Token Token { get; set; }

        public Config Config { get; set; }



    }

    public class ConnectionCredentials
    {
        public SfedocPanama AcademySQL { get; set; }
    }

    public class SfedocPanama
    {
        public string DataSource { get; set; }

        public string InitialCatalog { get; set; }

        public string UserId { get; set; }

        public string Password { get; set; }
    }

    public class Captcha
    {
        public string ClaveSitioWeb { get; set; }

        public string ClaveGoogle { get; set; }

        public bool Habilitar { get; set; }
    }

    public class Token
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Secret { get; set; }

        public string Scheme { get; set; }

        public long Minutes { get; set; }
    }

    public class Config
    {
        public string NombreApp { get; set; }

        public string Version { get; set; }

        public string RutaLog { get; set; }

        public string RutaArchivo { get; set; }
    }

    public class UrlApiAuth
    {
        public string Url { get; set; }

        public string Usuario { get; set; }

        public string Clave { get; set; }
    }


}