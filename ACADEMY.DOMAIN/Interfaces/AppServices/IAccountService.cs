using ACADEMY.DOMAIN.Constants;
using ACADEMY.DOMAIN.DTOs;
using ACADEMY.DOMAIN.Exceptions;
using ACADEMY.DOMAIN.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Interfaces.AppServices
{
    public interface IAccountService
    {
        IAsyncEnumerable<OpcionDTO> GetMenu();
        IAsyncEnumerable<MenuDto> GetMenu2();
        Task<UsuarioDTO> GetSesion();
        Task CambiarPassword(RecuperacionDTO recuperacionDTO);
        IAsyncEnumerable<UsuarioIntentoDTO> GetIntentos();
        IAsyncEnumerable<UsuarioSesionDTO> GetSesiones(bool isUser = false);
        Task CerrarSesion(string id);
    }
}
