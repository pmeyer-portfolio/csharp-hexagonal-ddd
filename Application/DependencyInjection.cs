using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Neusta.Workshop.Buchungssystem.Application.Interfaces;

namespace Neusta.Workshop.Buchungssystem.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IRaumAbfragen, RaumAbfragen>();
        services.AddTransient<IRaumAnlegen, RaumAnlegen>();
        services.AddTransient<IPersonHinzufügen, PersonHinzufügen>();
  
        return services;
    }
}