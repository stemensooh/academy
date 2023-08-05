using ACADEMY.DOMAIN.DTOs;
using ACADEMY.DOMAIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Interfaces.AppServices
{
    public interface IAuthService
    {
        Task<AcademyToken> Login(UsuarioDTO usuarioDTO);
    }
}
