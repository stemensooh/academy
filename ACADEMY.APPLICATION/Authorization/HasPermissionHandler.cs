using ACADEMY.DOMAIN.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace ACADEMY.APPLICATION.Authorization
{
    public class HasPermissionHandler : AuthorizationHandler<HasPermissionRequirement>
    {
        private readonly IServiceProvider _serviceProvider;

        public HasPermissionHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermissionRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == "Id"))
            {
                return Task.CompletedTask;
            }
            using var scope = _serviceProvider.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            int id = int.Parse(context.User.FindFirst("Id").Value);
            int idSesion = int.Parse(context.User.FindFirst("IdSesion").Value);
            string[] permisos = requirement.Permission.Split(",");
            var tienePermiso = unitOfWork.UsuarioRepository.TienePermisoUsuario(id, permisos, idSesion);
            if (tienePermiso)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    }
}