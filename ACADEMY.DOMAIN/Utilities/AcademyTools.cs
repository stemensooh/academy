using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Utilities
{
    public static class AcademyTools
    {
        private static readonly TripleDES DES;

        private static readonly MD5 MD5;

        public static string Semilla;

        static AcademyTools()
        {
            Semilla = "3m1l10";
            DES = TripleDES.Create();
            MD5 = System.Security.Cryptography.MD5.Create();
        }

        public static string CrearCadenaConexion(string datasource, string catalog, string userid, string clave, bool trustservercertificate = true, int timeout = 90)
        {
            //string[] obj = new string[6]
            //{
            //    "Data Source=" + datasource,
            //    "Initial Catalog=" + catalog,
            //    "User Id=" + userid,
            //    "Password=\"" + DescifrarClave(clave) + "\"",
            //    "TrustServerCertificate=" + (trustservercertificate ? "True" : "False"),
            //    null
            //};

            string[] obj = new string[6]
            {
                "Data Source=" + datasource,
                "Initial Catalog=" + catalog,
                "User Id=" + userid,
                "Password=\"" + clave + "\"",
                "TrustServerCertificate=" + (trustservercertificate ? "True" : "False"),
                null
            };

            DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
            defaultInterpolatedStringHandler.AppendLiteral("Connection Timeout=");
            defaultInterpolatedStringHandler.AppendFormatted(timeout);
            obj[5] = defaultInterpolatedStringHandler.ToStringAndClear();
            string[] value = obj;
            return string.Join(";", value);
        }

        public static string CrearSAPConexion(string companyDB, string usuario, string clave)
        {
            return JsonSerializer.Serialize(new
            {
                CompanyDB = companyDB,
                UserName = usuario,
                Password = DescifrarClave(clave)
            });
        }

        public static string CrearBasicConexion(string usuario, string clave)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(usuario + ":" + DescifrarClave(clave)));
        }

        public static string CifrarClave(string? stringToEncrypt)
        {
            if (!string.IsNullOrWhiteSpace(stringToEncrypt))
            {
                DES.Key = MD5.ComputeHash(Encoding.ASCII.GetBytes(Semilla));
                DES.Mode = CipherMode.ECB;
                byte[] bytes = Encoding.ASCII.GetBytes(stringToEncrypt);
                return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
            }

            return string.Empty;
        }

        public static string CifrarIdBase64(long? id)
        {
            if (id.HasValue)
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(CifrarClave(id.ToString())));
            }

            return string.Empty;
        }

        public static string DescifrarClave(string encryptedString)
        {
            try
            {
                DES.Key = MD5.ComputeHash(Encoding.ASCII.GetBytes(Semilla));
                DES.Mode = CipherMode.ECB;
                byte[] array = Convert.FromBase64String(encryptedString);
                return Encoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(array, 0, array.Length));
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static long? DescifrarIdBase64(string encryptedId)
        {
            try
            {
                return long.Parse(DescifrarClave(Encoding.UTF8.GetString(Convert.FromBase64String(encryptedId))));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string GeneraCodigoAleatorio(int longitud = 10)
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("=", "").Replace("+", "")
                .Substring(0, longitud);
        }

        public static ValueTask<T?> DeserializeAsync<T>(Stream stream)
        {
            return JsonSerializer.DeserializeAsync<T>(stream, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

    }
}
