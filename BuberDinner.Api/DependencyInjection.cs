using Mapster;
using MapsterMapper;

namespace BuberDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();

        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(IBuberDinnerApiMarker).Assembly);
        services.AddSingleton(config);

        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}