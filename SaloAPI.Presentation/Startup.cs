using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.HttpOverrides;
using SaloAPI.Application.Interfaces;
using SaloAPI.Application.Services;
using SaloAPI.BusinessLogic.ApiCommands.Sessions;
using SaloAPI.BusinessLogic.ApiCommands.Users;
using SaloAPI.BusinessLogic.DependencyInjection;
using SaloAPI.BusinessLogic.Pipelines;
using SaloAPI.BusinessLogic.Responses;
using SaloAPI.Domain.Constants;
using SaloAPI.Presentation.Controllers;
using System.Text.Json;

namespace SaloAPI.Presentation;

public class Startup
{
    private const string CorsPolicy = "SaloCorsPolicy";
    private readonly IConfiguration configuration;

    private readonly string swaggerTitle;

    private readonly string version;

    public Startup(IConfiguration configuration)
    {
        var versionService = new VersionService();

        this.configuration = configuration;
        version = versionService.GetVersion();
        swaggerTitle = $"SaloAPI v{version}";
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        });

        var databaseUrl = ConfigurationHelper.TryGetFromEnvironment(EnvironmentConstants.DatabaseUrl, configuration);

        var jwtSignKey = configuration[EnvironmentConstants.JwtSignKey];

        var blobUrl = configuration[EnvironmentConstants.BlobUrl];

        var blobContainerName = configuration[EnvironmentConstants.BlobContainer];

        var blobAccess = configuration[EnvironmentConstants.BlobAccess];

        const int jwtLifetimeDays = EnvironmentConstants.JwtLifetimeDays;

        services.AddDatabaseContextServices(databaseUrl);

        services.AddSwagger(swaggerTitle, version);

        services.AddJwtGeneratorServices(
            jwtSignKey,
            jwtLifetimeDays);

        /*services.AddAzureBlobServices(
            blobUrl,
            blobContainerName,
            blobAccess);*/

        services.AddSingleton<IVersionService, VersionService>();

        services.AddSingleton<IPasswordService, PasswordService>();

        services.AddValidatorsFromAssembly(typeof(LoginCommandValidator).Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddTransient(typeof(ResponseFactory<>));

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegisterCommandHandler).Assembly));

        services.AddAppAuthorization();

        services.AddAppAuthentication(jwtSignKey);

        services.AddLogging();

        services.AddHttpClient();

        services.ConfigureCors(configuration, CorsPolicy);

        services.AddHttpContextAccessor();

        services.AddTransient<ICorrelationContext, CorrelationContext>();

        services.AddAutoMapper(typeof(ApiControllerBase<AppInfoController>));

        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(CorsPolicy);

        app.UseSwagger();

        app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/v{version}/swagger.json", swaggerTitle));

        app.UseAuthorization();

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                               ForwardedHeaders.XForwardedProto
        });

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        app.MigrateDatabase();
    }
}