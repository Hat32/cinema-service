namespace CinemaService.Api.Configuration;

using System;
using System.Reflection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
public class SelfHealthCheck : IHealthCheck
{
	public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
	{
		var assembly = Assembly.Load("CinemaService");
		var versionNumber = assembly.GetName().Version;

		return Task.FromResult(HealthCheckResult.Healthy(description: $"Build {versionNumber}"));
	}
}
