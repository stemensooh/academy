using ACADEMY.DOMAIN.Models;
using ACADEMY.APPLICATION.Extensions;
using ACADEMY.DOMAIN.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using ACADEMY.DOMAIN.Constants;
using ACADEMY.DOMAIN.Interfaces.AppServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = builder.Configuration.Get<AppConfig>();
builder.Services.AddMyLibraryService(config);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler((exceptionHandlerApp) =>
{
    exceptionHandlerApp.Run(async context =>
    {
        context.Response.ContentType = Text.Plain;
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (exceptionHandlerFeature != null)
        {
            Exception exception = exceptionHandlerFeature.Error;
            if (exception is AuthException)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync(exception.Message);
            }
            else if (exception is ValidatorException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(exception.Message);
            }
            else if (exception is NotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(exception.Message);
            }
            else if (exception is EdocException)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"Edoc: {exception.Message}");
            }
            else if (exception is SAPException)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"SAP: {exception.Message}");
            }
            else if (exception is SoporteException)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"Soporte: {exception.Message}");
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(CStrings.ERROR_GENERICO);
            }
            string usuario = context.User.FindFirst("Usuario")?.Value;
            var logService = exceptionHandlerApp.ApplicationServices.GetService<ILogService>();
            logService.LogException(exception, usuario);
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync(CStrings.ERROR_GENERICO);
        }
    });
});

app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;
    switch (response.StatusCode)
    {
        case 401: case 403: await response.WriteAsync(CStrings.NOT_AUTHORIZED); break;
        case 404: await response.WriteAsync(CStrings.NOT_FOUND); break;
        default: await response.WriteAsync(CStrings.ERROR_GENERICO); break;
    }
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapFallbackToFile("index.html"); ;
app.Run();

