using CadastrosFiap.Business.Interfaces;
using CadastrosFiap.Business.Notificacoes;
using CadastrosFiap.Business.Services;
using CadastrosFiap.Data.Context;
using CadastrosFiap.Data.Repository;

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

            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ITurmaService, TurmaService>();
            services.AddScoped<IAlunoTurmaService, AlunoTurmaService>();

            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
