namespace CinemaService.Services.Settings;


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CinemaService.Settings;
public static class Bootstrapper
{
    public static IServiceCollection AddMainSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = SettingsLoader.Load<MainSettings>("Main", configuration);
        services.AddSingleton(settings);

        return services;
    }

    //public static IServiceCollection AddIdentitySettings(this IServiceCollection services, IConfiguration configuration = null)
    //{
    //    var settings = Settings.Load<IdentitySettings>("Identity", configuration);
    //    services.AddSingleton(settings);

    //    return services;
    //}

    public static IServiceCollection AddSwaggerSettings(this IServiceCollection services, IConfiguration configuration = null)
    {
        var settings = SettingsLoader.Load<SwaggerSettings>("Swagger", configuration);
        services.AddSingleton(settings);

        return services;
    }
}