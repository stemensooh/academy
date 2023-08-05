using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Interfaces
{
    public interface IUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }
        ISesionRepository SesionRepository { get; }
        Task SaveChangesAsync();
    }
}
