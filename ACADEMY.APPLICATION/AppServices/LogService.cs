using ACADEMY.DOMAIN.DTOs;
using ACADEMY.DOMAIN.Interfaces.AppServices;
using System.Text.Json;

namespace ACADEMY.APPLICATION.AppServices
{
    public class LogService : ILogService
    {
        private readonly string _nombreApp;
        private readonly string _version;
        private readonly string _rutaLog;

        public LogService(IConfigService configService)
        {
            _nombreApp = configService.Config.NombreApp;
            _version = configService.Config.Version;
            _rutaLog = configService.Config.RutaLog;
            LogTexto($"Bienvenido a {configService.Config.NombreApp} v{configService.Config.Version}");
            LogTexto(JsonSerializer.Serialize(configService.AppConfig));
        }

        public void LogException(Exception ex, string? usuario = null)
        {
            LogTexto($"{ex.GetType().Name} - {(ex.InnerException == null ? ex.Message : ex.InnerException.Message)} - {ex.StackTrace}", usuario);
        }

        public void LogTexto(string texto, string? usuario = null)
        {
            string nombreArchivo = _nombreApp + "_v" + _version;
            string Patch = Path.Combine(_rutaLog, DateTime.Now.Year.ToString(), DateTime.Now.ToString("MM"), nombreArchivo);
            if (!Directory.Exists(Patch))
            {
                Directory.CreateDirectory(Patch);
            }
            string ArhivoLog = nombreArchivo + "_" + DateTime.Now.Date.ToString("yyyy/MM/dd").Replace("/", "") + ".txt";
            using StreamWriter sw = File.AppendText(Path.Combine(Patch, ArhivoLog));
            string hora = DateTime.Now.Date.ToString("yyyy/MM/dd").Replace("/", "") + " " + DateTime.Now.TimeOfDay.ToString();
            if (!string.IsNullOrEmpty(usuario))
            {
                sw.WriteLine(hora + " => (Usuario: " + usuario + ") " + texto);
            }
            else
            {
                sw.WriteLine(hora + " => " + texto);
            }
        }

        public IEnumerable<EntryDTO> GetArchivos(string ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta))
            {
                ruta = _rutaLog;
            }
            var entries = new List<EntryDTO>();
            if (ruta != _rutaLog)
            {
                entries.Add(new EntryDTO
                {
                    Nombre = "...",
                    Ruta = Directory.GetParent(ruta).FullName
                });
            }
            if (File.Exists(ruta))
            {
                entries.Add(new EntryDTO
                {
                    Contenido = File.ReadAllText(ruta).Replace("\r\n", "<br />")
                });
                return entries;
            }
            else
            {
                string[] fileSystemEntries = Directory.GetFileSystemEntries(ruta);
                return entries.Concat(from entry in fileSystemEntries
                                      select new EntryDTO
                                      {
                                          Nombre = Path.GetFileName(entry),
                                          Ruta = entry
                                      });
            }
        }
    }
}
