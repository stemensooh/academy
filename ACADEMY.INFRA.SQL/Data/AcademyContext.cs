﻿using ACADEMY.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.INFRA.SQL.Data
{
    public class AcademyContext : DbContext
    {
        public AcademyContext(DbContextOptions<AcademyContext> options) : base(options) { }
        
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<UsuarioSesion> UsuarioSesion { get; set; }
        public DbSet<AsignaOpcionPerfil> AsignaOpcionPerfil { get; set; }
        public DbSet<Opciones> Opciones { get; set; }
        public DbSet<UsuarioIntentoLogin> UsuarioIntentoLogin { get; set; }
        public DbSet<Menu> Menu { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Usuario>().HasOne(u => u.Perfil).WithMany(p => p.Usuarios).HasForeignKey(u => u.IdPerfil);
            modelBuilder.Entity<Usuario>().HasMany(u => u.Sesiones).WithOne(p => p.Usuario).HasForeignKey(u => u.IdUsuario);
            modelBuilder.Entity<AsignaOpcionPerfil>().HasOne(op => op.Perfil).WithMany(p => p.AsignaOpcionPerfil).HasForeignKey(op => op.IdPerfil);
            modelBuilder.Entity<AsignaOpcionPerfil>().HasOne(op => op.Opcion).WithMany(o => o.AsignaOpcionPerfil).HasForeignKey(op => op.IdOpcion);

            modelBuilder.HasDbFunction(typeof(AcademyContext)
                           .GetMethod(nameof(FormatFecha), new[] { typeof(DateTime?), typeof(string) }))
                           .HasName("FormatFecha");
            modelBuilder.HasDbFunction(typeof(AcademyContext)
                .GetMethod(nameof(FromPeriodoToDateMonth), new[] { typeof(int?) }))
                .HasName("FromPeriodoToDateMonth");
        }

        public string FormatFecha(DateTime? fecha, string formato)
            => throw new NotSupportedException();

        public string FromPeriodoToDateMonth(int? periodo)
            => throw new NotSupportedException();
    }
}
