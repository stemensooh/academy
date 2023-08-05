using ACADEMY.DOMAIN.DTOs;
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
        Task<UsuarioDTO> GetSesion();
    }
}
