using ACADEMY.DOMAIN.DTOs;
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
    }
}
