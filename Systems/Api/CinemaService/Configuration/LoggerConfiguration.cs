namespace CinemaService.Api.Configuration;
using Serilog;


/// <summary>
///  Logger Configuration
/// </summary>
public static class LoggerConfiguration
{
    public static void AddAppLogger(this WebApplicationBuilder builder)
    {
        /// <summary>
        /// Add logger 
        /// </summary>
        var logger = new Serilog.LoggerConfiguration()
            .Enrich.WithCorrelationIdHeader()
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(builder.Configuration)
            .CreateLogger();

        builder.Host.UseSerilog(logger, true);
    }

}

