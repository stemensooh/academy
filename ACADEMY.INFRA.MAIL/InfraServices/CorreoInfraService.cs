using ACADEMY.DOMAIN.Interfaces.AppServices;
using ACADEMY.DOMAIN.Interfaces;
using ACADEMY.DOMAIN.Interfaces.InfraServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.INFRA.MAIL.InfraServices
{
    public class CorreoInfraService : ICorreoInfraService
    {
        private readonly IHttpContextService _httpContextService;
        private readonly ILogService _logService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _urlWsCorreo;
        private readonly string _claveWsCorreo;
        private readonly string _rutaArchivo;

        public CorreoInfraService(IHttpContextService httpContextService,
                                  ILogService logService,
                                  IUnitOfWork unitOfWork,
                                  IConfigService configService)
        {
            _httpContextService = httpContextService;
            _logService = logService;
            _unitOfWork = unitOfWork;
            //_urlWsCorreo = configService.SendGrid.Url;
            //_claveWsCorreo = configService.SendGrid.Clave;
            _rutaArchivo = configService.Config.RutaArchivo;
        }
    }
}
