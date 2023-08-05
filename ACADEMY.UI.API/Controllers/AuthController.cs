using ACADEMY.DOMAIN.DTOs;
using ACADEMY.DOMAIN.Interfaces.AppServices;
using ACADEMY.DOMAIN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACADEMY.UI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfigService _configService;
        private readonly IAuthService _authService;

        public AuthController(IConfigService configService, IAuthService authService)
        {
            _configService = configService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult GetInformacion()
        {
            return Ok(new { Nombre = _configService.Config.NombreApp, _configService.Config.Version });
        }

        [HttpGet("captcha")]
        public IActionResult GetInformacionCaptcha()
        {
            return Ok(new { CaptchaHabilitado = _configService.Captcha.Habilitar, CaptchaSitio = _configService.Captcha.ClaveSitioWeb });
        }

        [HttpPost("login")]
        public Task<AcademyToken> Login(LoginDto usuarioDTO)
        {
            return _authService.Login(usuarioDTO);
        }

    }
}
