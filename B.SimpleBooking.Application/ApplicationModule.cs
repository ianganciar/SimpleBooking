using AutoMapper;
using B.SimpleBooking.Application.Services.Automapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace B.SimpleBooking.Application;
public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.
            AddAutomapper()
            .AddMediator()
            .AddFluentValidation()
            ;


        return services;
    }

    private static IServiceCollection AddAutomapper(this IServiceCollection services)
    {
        services.AddScoped(provider => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutomapperConfigurations());
        }).CreateMapper());

        return services;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }

    private static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Transient);

        return services;
    }
}
