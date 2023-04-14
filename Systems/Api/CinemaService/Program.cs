using CinemaService.Api;
using CinemaService.Api.Configuration;
using CinemaService.Services.Settings;
using CinemaService.Settings;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Pkix;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

var mainSettings = Settings.Load<MainSettings>("Main");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

var services = builder.Services;

// Configure services

services.AddHttpContextAccessor();
services.AddAppCors();

services.AddAppHealthChecks();
services.AddAppVersioning();
services.AddAppSwagger(mainSettings, swaggerSettings);

services.RegisterAppServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseAppSwagger();
}

app.UseAppHealthChecks();
app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();

app.Run();
