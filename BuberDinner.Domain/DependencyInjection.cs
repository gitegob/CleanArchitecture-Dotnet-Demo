using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}