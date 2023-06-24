using CadastrosFiap.Business.Interfaces;
using CadastrosFiap.Business.Notificacoes;
using CadastrosFiap.Data.Context;
using CadastrosFiap.Data.Repository;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace CadastrosFiap.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<CadastrosFiapContext>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IAlunoTurmaRepository, AlunoTurmaRepository>();

            services.AddScoped<INotificador, Notificador>();

            //services.AddScoped<IFilmeService, FilmeService>();
            //services.AddScoped<IGeneroService, GeneroService>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IUser, AspNetUser>();

            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
