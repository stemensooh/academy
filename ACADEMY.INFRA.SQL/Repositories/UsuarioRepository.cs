using ACADEMY.DOMAIN.DTOs;
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


        public Task<UsuarioDTO?> GetUsuarioSesion(long idUsuario, long idSesion)
        {
            return (from usuario in _context.Usuario
                    join sesion in _context.UsuarioSesion
                    on usuario.Id equals sesion.IdUsuario
                    join perfil in _context.Perfil
                    on usuario.IdPerfil equals perfil.Id
                    where
                        usuario.Id == idUsuario &&
                        sesion.Id == idSesion
                    select new UsuarioDTO
                    {
                        Estado = (usuario.Estado ?? false) && DateTime.Now <= usuario.FechaActualizarPassword && sesion.Estado,
                        Rol = new PerfilDTO
                        {
                            Estado = perfil.Estado ?? false,
                            Permisos = (from asigna in perfil.AsignaOpcionPerfil
                                        join opcion in _context.Opciones
                                        on asigna.IdOpcion equals opcion.Id
                                        select new OpcionDTO
                                        {
                                            Estado = asigna.Estado && opcion.Estado,
                                            Id = opcion.IdElemento
                                        }).ToList()
                        }
                    }).FirstOrDefaultAsync();
        }

    }
}
