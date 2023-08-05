using ACADEMY.DOMAIN.Constants;
using ACADEMY.DOMAIN.DTOs;
using ACADEMY.DOMAIN.Entities;
using ACADEMY.DOMAIN.Exceptions;
using ACADEMY.DOMAIN.Interfaces;
using ACADEMY.DOMAIN.Interfaces.AppServices;
using ACADEMY.DOMAIN.Interfaces.InfraServices;
using ACADEMY.DOMAIN.Models;
using ACADEMY.DOMAIN.Utilities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UAParser;

namespace ACADEMY.APPLICATION.AppServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfigService _configService;
        private readonly IHttpContextService _httpContextService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICorreoInfraService _emailService;

        public AuthService(IConfigService configService,
                           IHttpContextService httpContextService,
                           IUnitOfWork unitOfWork,
                           ICorreoInfraService emailService)
        {
            _configService = configService;
            _httpContextService = httpContextService;
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public async Task<AcademyToken> Login(LoginDto usuarioDTO)
        {
            var usuario = await _unitOfWork.UsuarioRepository.GetByUserName(usuarioDTO.Username);
            if (usuario != null)
            {
                if (usuario.Password == AcademyTools.CifrarClave(usuarioDTO.Password) &&
                    usuario.Estado == true &&
                    (usuario.Intentos == null || usuario.Intentos < 5) &&
                    usuario.FechaActualizarPassword > DateTime.Now)
                {
                    usuario.Intentos = 0;
                    usuario.UltimaConexion = DateTime.Now;
                    var clientInfo = Parser.GetDefault().Parse(_httpContextService.UserAgent);
                    var newSesion = new UsuarioSesion
                    {
                        IdUsuario = usuario.Id,
                        IpSesion = _httpContextService.Ip,
                        FechaExpiraSesion = DateTime.Now.AddMinutes(_configService.Token.Minutes),
                        Navegador = $"{clientInfo.UA.Family} {clientInfo.UA.Major}.{clientInfo.UA.Minor}",
                        Os = $"{clientInfo.OS.Family} {clientInfo.OS.Major}.{clientInfo.OS.Minor}",
                        Dispositivo = clientInfo.Device.Family,
                        Estado = true
                    };
                    await _unitOfWork.SesionRepository.AddAsync(newSesion);
                    await _unitOfWork.SaveChangesAsync();
                    return CreateToken(usuario, newSesion.Id);
                }
                else
                {
                    string error = await GetErrors(usuario);
                    await _unitOfWork.SaveChangesAsync();
                    throw new AuthException(error);
                }
            }

            throw new AuthException(CStrings.ERROR_CREDENTIALS);
        }


        private AcademyToken CreateToken(Usuario usuario, int idSesion)
        {
            var claims = new[]
            {
                new Claim("Id", usuario.Id.ToString()),
                new Claim("IdSesion", idSesion.ToString()),
                new Claim("Usuario", usuario.Username)
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configService.Token.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var result = new JwtSecurityToken(_configService.Token.Issuer, _configService.Token.Audience, claims,
                DateTime.UtcNow, DateTime.UtcNow.AddMinutes(_configService.Token.Minutes), credentials);
            return new AcademyToken
            {
                Id = AcademyTools.CifrarIdBase64(usuario.Id),
                Nombres = $"{usuario.Perfil.Nombre} {usuario.Perfil.Apellido}",
                Usuario = usuario.Username,
                Perfil = usuario.Perfil.Nombre,
                FechaClave = usuario.FechaActualizarPassword.ToString("dd-MM-yyyy"),
                Token = new JwtSecurityTokenHandler().WriteToken(result),
                FechaExpiracion = result.ValidTo
            };
        }

        private async Task<string> GetErrors(Usuario usuario)
        {
            if (usuario.FechaActualizarPassword > DateTime.Now)
            {
                //await _unitOfWork.UsuarioIntentosRepository.AddAsync(new GhUsuarioIntentoLogin
                //{
                //    Usuario = usuario.Username,
                //    IpIntento = _httpContextService.Ip,
                //    FechaIntento = DateTime.Now
                //});
                usuario.Intentos = (usuario.Intentos ?? 0) + 1;
                if (usuario.Intentos >= 5)
                {
                    if (usuario.Estado ?? false) usuario.Estado = false;
                    return CStrings.MAX_INTENTOS;
                }
                else
                {
                    return CStrings.ERROR_CREDENTIALS;
                }
            }
            else
            {
                if (usuario.Estado ?? false) usuario.Estado = false;
                return CStrings.VENC_CONTRASEÑA;
            }
        }

    }
}
