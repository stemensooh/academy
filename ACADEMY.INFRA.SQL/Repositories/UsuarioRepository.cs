using ACADEMY.DOMAIN.Entities;
using ACADEMY.DOMAIN.Interfaces;
using ACADEMY.INFRA.SQL.Data;
using ACADEMY.INFRA.UOW.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.INFRA.SQL.Repositories
{
    public class UsuarioRepository : Repositorio<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AcademyContext context) : base(context) { }



        public bool TienePermisoUsuario(int idUsuario, string[] permisos, int idSesion)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> GetByUserName(string? Username)
        {
            return _context.Usuario.Include(u => u.Perfil).FirstOrDefaultAsync(u => u.Username == Username);
        }
    }
}
