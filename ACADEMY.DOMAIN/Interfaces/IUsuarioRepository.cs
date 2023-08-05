using ACADEMY.DOMAIN.DTOs;
using ACADEMY.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Interfaces
{
    public interface IUsuarioRepository : IRepositorio<Usuario>
    {
        bool TienePermisoUsuario(int idUsuario, string[] permisos, int idSesion);
        Task<Usuario?> GetByUserName(string? Username);
        Task<UsuarioDTO?> GetUsuarioSesion(long idUsuario, long idSesion);
        IAsyncEnumerable<UsuarioIntentoDTO> GetUsuarioIntentos(long? idUsuario);
    }
}
