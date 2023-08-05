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
    public class SesionRepository : Repositorio<UsuarioSesion>, ISesionRepository
    {
        public SesionRepository(AcademyContext context) : base(context) { }


        public IAsyncEnumerable<UsuarioSesionDTO> GetSesionesByIdUsuario(int? idUsuario)
        {
            var fechaActual = DateTime.Now;
            return (from sesion in _context.UsuarioSesion
                    join user in _context.Usuario on sesion.IdUsuario equals user.Id
                    join perfil in _context.Perfil on user.IdPerfil equals perfil.Id

                    where
                        (idUsuario == null || sesion.IdUsuario == idUsuario) &&
                        sesion.Estado == true &&
                        fechaActual <= sesion.FechaExpiraSesion
                    orderby sesion.FechaExpiraSesion descending
                    select new UsuarioSesionDTO
                    {
                        Id = AcademyTools.CifrarIdBase64(sesion.Id),
                        Usuario = perfil.Nombre + " " + perfil.Apellido,
                        IpSesion = sesion.IpSesion,
                        FechaExpiraSesion = sesion.FechaExpiraSesion.ToString("s"),
                        Navegador = sesion.Navegador,
                        Os = sesion.Os,
                        Dispositivo = sesion.Dispositivo
                    }).AsAsyncEnumerable();
        }
    }
}
