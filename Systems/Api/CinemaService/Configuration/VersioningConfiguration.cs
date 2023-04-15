namespace CinemaService.Api.Configuration;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Versioning configuration
/// </summary>
public static class VersioningConfiguration
{
    /// <summary>
    /// Adds version support for API
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <returns>The service collection</returns>
    public static IServiceCollection AddAppVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        });
        
        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
}