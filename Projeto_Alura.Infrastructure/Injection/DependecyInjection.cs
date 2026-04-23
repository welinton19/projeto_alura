using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto_Alura.Domain.Interfaces;
using Projeto_Alura.Infrastructure.Auth;
using Projeto_Alura.Infrastructure.Data;
using Projeto_Alura.Infrastructure.Repositories;

namespace Projeto_Alura.Infrastructure.Injection;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AluraDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("AluraConnection"),
                (b => b.MigrationsAssembly(typeof(AluraDbContext).Assembly.FullName)));
        });

        services.AddScoped<JwtService>();
        services.AddScoped<IUserRepository, UsersRepositorie>();
        services.AddScoped<ILoginRepository, LoginRepositories>();
        services.AddScoped<IMatriculasRepository, MatriculaRepositories>();
        services.AddScoped<ICursosRepository, CursosRepositories>();

        return services;
    }
}
