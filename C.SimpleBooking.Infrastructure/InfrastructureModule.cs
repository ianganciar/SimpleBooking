using C.SimpleBooking.Infrastructure.Persistence;
using C.SimpleBooking.Infrastructure.Repositories;
using D.SimpleBooking.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace C.SimpleBooking.Infrastructure;
public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddRepositories()
            .AddDbContext(configuration);

        return services;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServer");

        services.AddDbContext<SimpleBookingDbContext>(options => options.UseSqlServer(connectionString));


        return services;
    }
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProfessionalRepository, ProfessionalRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}

