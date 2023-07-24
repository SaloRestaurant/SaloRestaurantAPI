using Microsoft.OpenApi.Models;
using SaloAPI.Application.Interfaces;
using SaloAPI.Application.Services;
using SaloAPI.BusinessLogic.DependencyInjection;
using SaloAPI.Domain.Constants;
using System.Reflection;
using System.Text.Json;

namespace SaloAPI.Presentation;

public class Startup
{
    private readonly IConfiguration configuration;

    public Startup(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        });

        var databaseUrl = ConfigurationHelper.TryGetFromEnvironment(EnvironmentConstants.DatabaseUrl, configuration);

        services.AddDatabaseContextServices(databaseUrl);

        services.AddSingleton<IVersionService, VersionService>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "",
                    Version = "v1",
                    Description = "",
                    Contact = new OpenApiContact { Name = "GitHub", Url = new Uri("???") }
                });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        services.AddCors();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "SaloRestaurant API"); });

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors(builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        app.MigrateDatabase();
    }
}