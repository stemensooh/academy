using ACADEMY.DOMAIN.Constants;
using ACADEMY.DOMAIN.DTOs;
using ACADEMY.DOMAIN.Interfaces.AppServices;
using ACADEMY.DOMAIN.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ACADEMY.UI.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public HomeController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //[HttpGet("menu")]
        //public IAsyncEnumerable<OpcionDTO> GetMenu()
        //{
        //    return _accountService.GetMenu();
        //}

        [HttpGet("menu")]
        public IAsyncEnumerable<MenuDto> GetMenu()
        {
            return _accountService.GetMenu2();
        }


        [HttpGet("permiso")]
        public Task<UsuarioDTO> GetSesion()
        {
            return _accountService.GetSesion();
        }

        [HttpPost("password")]
        public async Task<AcademyResponse> CambiarContraseña(RecuperacionDTO recuperacionDTO)
        {
            await _accountService.CambiarPassword(recuperacionDTO);
            return new AcademyResponse(CStrings.CLAVE_ACTUALIZADA);
        }

        [HttpGet("intentos")]
        public IAsyncEnumerable<UsuarioIntentoDTO> GetIntentos()
        {
            return _accountService.GetIntentos();
        }

        [HttpGet("sesiones")]
        public IAsyncEnumerable<UsuarioSesionDTO> GetSesiones()
        {
            return _accountService.GetSesiones(true);
        }

        [HttpPost("{id}/cerrar")]
        public async Task<AcademyResponse> CerrarSesion(string id)
        {
            await _accountService.CerrarSesion(id);
            return new AcademyResponse(CStrings.SESION_FINISHED);
        }
    }
}
