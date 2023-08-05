using ACADEMY.APPLICATION.AppServices;
using ACADEMY.APPLICATION.Authorization;
using ACADEMY.DOMAIN.Interfaces;
using ACADEMY.DOMAIN.Interfaces.AppServices;
using ACADEMY.DOMAIN.Interfaces.InfraServices;
using ACADEMY.DOMAIN.Models;
using ACADEMY.DOMAIN.Utilities;
using ACADEMY.INFRA.MAIL.InfraServices;
using ACADEMY.INFRA.SQL.Data;
using ACADEMY.INFRA.SQL.Repositories;
using ACADEMY.INFRA.UOW.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ACADEMY.APPLICATION.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMyLibraryService(this IServiceCollection services, AppConfig config)
        {
            services.AddAuthentication()
                .AddJwtBearer(config.Token.Scheme, jwtBearerOptions =>
                {
                    jwtBearerOptions.SaveToken = true;
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = config.Token.Issuer,
                        ValidAudience = config.Token.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Token.Secret)),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            services.AddHttpContextAccessor();
            services.AddHttpClient("MyClient")
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler
                    {
                        ClientCertificateOptions = ClientCertificateOption.Manual,
                        ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
                    };
                });
            services.AddSingleton<IConfigService>(_ => new ConfigService(config));
            services.AddSingleton<ILogService, LogService>();
            services.AddScoped<IHttpContextService, HttpContextService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ISesionRepository, SesionRepository>(); 
            services.AddScoped<IPerfilRepository, PerfilRepository>();

            services.AddScoped<ICorreoInfraService, CorreoInfraService>(); 
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAuthService, AuthService>(); 
            string cadenaConexion = AcademyTools.CrearCadenaConexion(
                config.ConnectionCredentials.AcademySQL.DataSource,
                config.ConnectionCredentials.AcademySQL.InitialCatalog,
                config.ConnectionCredentials.AcademySQL.UserId,
                config.ConnectionCredentials.AcademySQL.Password);
            services.AddDbContext<AcademyContext>(options => options.UseSqlServer(cadenaConexion));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IAuthorizationPolicyProvider>(_ => new HasPermissionProvider(config.Token.Scheme));
            services.AddSingleton<IAuthorizationHandler, HasPermissionHandler>();
            return services;
        }
    }
}