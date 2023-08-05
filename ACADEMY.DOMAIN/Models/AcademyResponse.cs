using static ACADEMY.DOMAIN.Constants.CEnums;
using static ACADEMY.DOMAIN.Constants.CStrings;

namespace ACADEMY.DOMAIN.Models
{
    public class AcademyResponse
    {
        public AcademyResponse() { }

        public AcademyResponse(string mensaje) => Mensaje = mensaje;

        public AcademyResponse(AcademyStatus AcademyStatus) => Mensaje = ToMensaje(AcademyStatus);

        public AcademyResponse(AcademyStatus AcademyStatus, string data)
        {
            Mensaje = ToMensaje(AcademyStatus);
            Data = data;
        }

        public string Data { get; set; }

        public string Mensaje { get; set; }

        private static string? ToMensaje(AcademyStatus AcademyStatus)
        {
            return AcademyStatus switch
            {
                AcademyStatus.DELETED => RESPONSE_ESTADO,
                AcademyStatus.INSERTED => RESPONSE_INSERT,
                AcademyStatus.UPDATED => RESPONSE_UPDATE,
                _ => null
            };
        }
    }
}
