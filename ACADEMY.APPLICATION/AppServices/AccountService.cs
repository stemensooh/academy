using ACADEMY.DOMAIN.Constants;
using ACADEMY.DOMAIN.DTOs;
using ACADEMY.DOMAIN.Entities;
using ACADEMY.DOMAIN.Exceptions;
using ACADEMY.DOMAIN.Interfaces;
using ACADEMY.DOMAIN.Interfaces.AppServices;
using ACADEMY.DOMAIN.Utilities;
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

        public IAsyncEnumerable<MenuDto> GetMenu2()
        {
            return _unitOfWork.PerfilRepository.GetMenuByIdUsuario(_httpContextService.IdUsuario);

            //List<MenuDto> menuDto = new List<MenuDto>();

            //foreach (var item in opciones)
            //{
            //    var opcion = new MenuDto
            //    {
            //        Active = item.Active,
            //        BadgeType = item.BadgeType,
            //        BadgeValue = item.BadgeValue,
            //        Bookmark = item.Bookmark,
            //        Children = new MenuDto[] { },
            //        HeadTitle1 = item.HeadTitle1,
            //        HeadTitle2 = item.HeadTitle2,
            //        Icon = item.Icon,
            //        Id = item.Id,
            //        Path = item.Path,
            //        Type = item.Type
            //    };
            //}

            //return menuDto;
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

        public async Task CambiarPassword(RecuperacionDTO recuperacionDTO)
        {
            string clave = AcademyTools.CifrarClave(recuperacionDTO.Clave);
            var usuario = await _unitOfWork.UsuarioRepository.FirstOrDefaultAsync(u => u.Id == _httpContextService.IdUsuario && u.Password == clave);
            if (usuario == null)
            {
                throw new ValidatorException(CStrings.VERIFICA_CLAVE);
            }
            usuario.Password = AcademyTools.CifrarClave(recuperacionDTO.NuevaClave);
            usuario.FechaActualizarPassword = DateTime.Now.AddMonths(3);
            usuario.UsuarioModificacion = _httpContextService.IdUsuario;
            usuario.FechaModificacion = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();
        }

        public IAsyncEnumerable<UsuarioIntentoDTO> GetIntentos()
        {
            return _unitOfWork.UsuarioRepository.GetUsuarioIntentos(_httpContextService.IdUsuario);
        }

        public IAsyncEnumerable<UsuarioSesionDTO> GetSesiones(bool isUser = false)
        {
            return _unitOfWork.SesionRepository.GetSesionesByIdUsuario(isUser ? _httpContextService.IdUsuario : null);
        }

        public async Task CerrarSesion(string id)
        {
            var idsesion = AcademyTools.DescifrarIdBase64(id);
            var sesion = await _unitOfWork.SesionRepository.FirstOrDefaultAsync(s => s.Id == idsesion);
            if (sesion == null)
            {
                throw new NotFoundException(CStrings.NOT_FOUND);
            }
            sesion.Estado = false;
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
