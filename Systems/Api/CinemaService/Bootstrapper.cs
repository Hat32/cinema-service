using CinemaService.Services.Settings;
using System.Runtime.CompilerServices;

namespace CinemaService.Api;


public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddMainSettings()
            .AddSwaggerSettings()
            //.AddApiSpecialSettings()
            ;

        return services;
    }


}

