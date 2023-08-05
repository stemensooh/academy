using ACADEMY.DOMAIN.DTOs;
using ACADEMY.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Interfaces
{
    public interface ISesionRepository : IRepositorio<UsuarioSesion>
    {
        IAsyncEnumerable<UsuarioSesionDTO> GetSesionesByIdUsuario(int? idUsuario);
    }
}
