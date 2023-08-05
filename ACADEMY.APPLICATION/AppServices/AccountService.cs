using ACADEMY.DOMAIN.Constants;
using ACADEMY.DOMAIN.DTOs;
using ACADEMY.DOMAIN.Exceptions;
using ACADEMY.DOMAIN.Interfaces;
using ACADEMY.DOMAIN.Interfaces.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.APPLICATION.AppServices
{
    public class AccountService : IAccountService
    {
        private readonly IHttpContextService _httpContextService;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IHttpContextService httpContextService,
                              IUnitOfWork unitOfWork)
        {
            _httpContextService = httpContextService;
            _unitOfWork = unitOfWork;
        }

        public IAsyncEnumerable<OpcionDTO> GetMenu()
        {
            return _unitOfWork.PerfilRepository.GetMenuOpcionesByIdUsuario(_httpContextService.IdUsuario);
        }

        public async Task<UsuarioDTO> GetSesion()
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetUsuarioSesion(_httpContextService.IdUsuario, _httpContextService.Sesion);
            if (usuario == null)
            {
                throw new NotFoundException(CStrings.NOT_FOUND);
            }
            return usuario;
        }

    }
}
