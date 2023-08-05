using ACADEMY.DOMAIN.DTOs;
using ACADEMY.DOMAIN.Interfaces.AppServices;
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

        [HttpGet("menu")]
        public IAsyncEnumerable<OpcionDTO> GetMenu()
        {
            return _accountService.GetMenu();
        }

        [HttpGet("permiso")]
        public Task<UsuarioDTO> GetSesion()
        {
            return _accountService.GetSesion();
        }

    }
}
