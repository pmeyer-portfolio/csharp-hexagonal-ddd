using Microsoft.Extensions.DependencyInjection;
using Neusta.Workshop.Buchungssystem.Domain.Raum;
using Neusta.Workshop.Buchungssystem.Domain.Person;
using Neusta.Workshop.Buchungssystem.Storage.Interfaces;
using Neusta.Workshop.Buchungssystem.Storage.Mappers;
using Neusta.Workshop.Buchungssystem.Storage.Repositories;

namespace Neusta.Workshop.Buchungssystem.Storage;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {

        services.AddSingleton<IRaumRepository, RaumRepository>();
        services.AddSingleton<IPersonRepository, PersonRepository>();
        services.AddTransient<IRoomEntityMapper, RoomEntityMapper>();
        services.AddTransient<IPersonEntityMapper, PersonEntityMapper>();
  
        return services;
    }
}