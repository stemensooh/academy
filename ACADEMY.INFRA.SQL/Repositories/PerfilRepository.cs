using ACADEMY.DOMAIN.DTOs;
using ACADEMY.DOMAIN.Entities;
using ACADEMY.DOMAIN.Interfaces;
using ACADEMY.DOMAIN.Utilities;
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
    public class PerfilRepository : Repositorio<UsuarioSesion>, IPerfilRepository
    {
        public PerfilRepository(AcademyContext context) : base(context) { }


        public IAsyncEnumerable<OpcionDTO> GetMenuOpcionesByIdUsuario(long idUsuario)
        {
            return (from opcion in _context.Opciones
                    join asigna in _context.AsignaOpcionPerfil
                    on opcion.Id equals asigna.IdOpcion into lasigna
                    from asigna in lasigna.DefaultIfEmpty()
                    join perfil in _context.Perfil
                    on asigna.IdPerfil equals perfil.Id into lperfil
                    from perfil in lperfil.DefaultIfEmpty()
                    join usuario in _context.Usuario
                    on perfil.Id equals usuario.IdPerfil into lusuario
                    from usuario in lusuario.DefaultIfEmpty()
                    where
                        opcion.Estado == true &&
                        (opcion.IdPadre == null ||
                        (usuario.Id == idUsuario &&
                         usuario.Estado == true &&
                         perfil.Estado == true &&
                         asigna.Estado == true))
                    select new OpcionDTO
                    {
                        Id = AcademyTools.CifrarIdBase64(opcion.Id),
                        Nombre = opcion.DescripcionHTML,
                        IdPadre = opcion.IdPadre == null ? null : AcademyTools.CifrarIdBase64(opcion.IdPadre.Value),
                        Url = opcion.Url,
                        Icono = opcion.Icono
                    }).AsAsyncEnumerable();
        }

    }
}
