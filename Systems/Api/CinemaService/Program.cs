using CinemaService.Api;
using CinemaService.Api.Configuration;
using CinemaService.Services.Settings;
using CinemaService.Settings;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

var mainSettings = SettingsLoader.Load<MainSettings>("Main");
var swaggerSettings = SettingsLoader.Load<SwaggerSettings>("Swagger");

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
