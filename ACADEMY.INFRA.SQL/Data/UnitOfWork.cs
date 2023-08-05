using ACADEMY.DOMAIN.Interfaces;
using ACADEMY.INFRA.SQL.Data;
using ACADEMY.INFRA.SQL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACADEMY.INFRA.UOW.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AcademyContext _context;
        private IUsuarioRepository _usuarioRepository;
        private ISesionRepository _sesionRepository;

        public UnitOfWork(AcademyContext context)
        {
            _context = context;
        }

        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                if (_usuarioRepository == null)
                {
                    _usuarioRepository = new UsuarioRepository(_context);
                }
                return _usuarioRepository;
            }
        }

        public ISesionRepository SesionRepository
        {
            get
            {
                if (_sesionRepository == null)
                {
                    _sesionRepository = new SesionRepository(_context);
                }
                return _sesionRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}