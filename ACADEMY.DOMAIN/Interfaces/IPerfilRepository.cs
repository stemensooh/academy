using ACADEMY.DOMAIN.DTOs;
using ACADEMY.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Interfaces
{
    public interface IPerfilRepository
    {
        IAsyncEnumerable<OpcionDTO> GetMenuOpcionesByIdUsuario(long idUsuario);
        List<OpcionDTO> GetMenuOpcionesByIdUsuario2(long idUsuario);
        IAsyncEnumerable<MenuDto> GetMenuByIdUsuario(long idUsuario);
    }
}
