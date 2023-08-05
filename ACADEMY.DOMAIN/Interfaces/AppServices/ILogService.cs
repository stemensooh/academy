using ACADEMY.DOMAIN.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACADEMY.DOMAIN.Interfaces.AppServices
{
    public interface ILogService
    {
        void LogException(Exception ex, string? usuario = null);

        void LogTexto(string texto, string? usuario = null);

        IEnumerable<EntryDTO> GetArchivos(string ruta);
    }
}
