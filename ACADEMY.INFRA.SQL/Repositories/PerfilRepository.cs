using ACADEMY.DOMAIN.DTOs;
using ACADEMY.DOMAIN.Entities;
using ACADEMY.DOMAIN.Interfaces;
using ACADEMY.DOMAIN.Utilities;
using ACADEMY.INFRA.SQL.Data;
using ACADEMY.INFRA.UOW.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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

        public IAsyncEnumerable<MenuDto> GetMenuByIdUsuario(long idUsuario)
        {
            return (
                from item in _context.Menu
                join asigna in _context.AsignaOpcionPerfil on item.Id equals asigna.IdOpcion into lasigna

                from asigna in lasigna.DefaultIfEmpty()
                join perfil in _context.Perfil on asigna.IdPerfil equals perfil.Id into lperfil

                from perfil in lperfil.DefaultIfEmpty()
                join usuario in _context.Usuario on perfil.Id equals usuario.IdPerfil into lusuario

                from usuario in lusuario.DefaultIfEmpty()
                where
                        item.Estado == true &&
                        (item.IdPadre == null ||
                        (usuario.Id == idUsuario &&
                         usuario.Estado == true &&
                         perfil.Estado == true &&
                         asigna.Estado == true))

                select new MenuDto
                {
                    Active = item.Active,
                    BadgeType = item.BadgeType,
                    BadgeValue = item.BadgeValue,
                    Bookmark = item.Bookmark,
                    Children = new MenuDto[] { },
                    HeadTitle1 = item.HeadTitle1,
                    HeadTitle2 = item.HeadTitle2,
                    Title = item.Title,
                    Icon = item.Icon,
                    Id = item.Id,
                    Path = item.Path,
                    Type = item.Type,
                    IdPadre = item.IdPadre// == null ? null : AcademyTools.CifrarIdBase64(item.IdPadre),
                }
            ).AsAsyncEnumerable();
        }

        public List<OpcionDTO> GetMenuOpcionesByIdUsuario2(long idUsuario)
        {
            return (from opcion in _context.Opciones
                    join asigna in _context.AsignaOpcionPerfil on opcion.Id equals asigna.IdOpcion into lasigna

                    from asigna in lasigna.DefaultIfEmpty()
                    join perfil in _context.Perfil on asigna.IdPerfil equals perfil.Id into lperfil

                    from perfil in lperfil.DefaultIfEmpty()
                    join usuario in _context.Usuario on perfil.Id equals usuario.IdPerfil into lusuario

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
                        IdPadre = opcion.IdPadre == null ? null : AcademyTools.CifrarIdBase64(opcion.IdPadre),
                        Url = opcion.Url,
                        Icono = opcion.Icono
                    }).ToList();
        }

        public IAsyncEnumerable<OpcionDTO> GetMenuOpcionesByIdUsuario(long idUsuario)
        {
            return (from opcion in _context.Opciones
                    join asigna in _context.AsignaOpcionPerfil on opcion.Id equals asigna.IdOpcion into lasigna

                    from asigna in lasigna.DefaultIfEmpty()
                    join perfil in _context.Perfil on asigna.IdPerfil equals perfil.Id into lperfil

                    from perfil in lperfil.DefaultIfEmpty()
                    join usuario in _context.Usuario on perfil.Id equals usuario.IdPerfil into lusuario

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
                        IdPadre = opcion.IdPadre == null ? null : AcademyTools.CifrarIdBase64(opcion.IdPadre),
                        Url = opcion.Url,
                        Icono = opcion.Icono
                    }).AsAsyncEnumerable();
        }

    }
}
