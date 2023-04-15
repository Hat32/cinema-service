namespace CinemaService.Api.Configuration;

using System;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using CinemaService.Common;
/// <summary>
/// Health checks configuration
/// </summary>
public static class HealthCheckConfiguration
{
	/// <summary>
	/// Adds health check for API to <paramref name="services"/>
	/// </summary>
	/// <param name="services">Service collection</param>
	/// <returns>The service collection</returns>
	public static IServiceCollection AddAppHealthChecks(this IServiceCollection services)
	{
		services.AddHealthChecks()
			.AddCheck<SelfHealthCheck>("CinemaService");
		return services;
	}
    /// <summary>
    /// Adds and configures health check endpoint
    /// </summary>
    /// <param name="app"></param>
    public static void UseAppHealthChecks(this WebApplication app)
	{
		app.MapHealthChecks("/health");
		//app.MapHealthChecksUI();
		app.MapHealthChecks("/health/detail", new HealthCheckOptions
		{
			ResponseWriter = HealthCheckHelper.WriteHealthCheckResponseAsync,
			AllowCachingResponses = false,
		});
	}
}
