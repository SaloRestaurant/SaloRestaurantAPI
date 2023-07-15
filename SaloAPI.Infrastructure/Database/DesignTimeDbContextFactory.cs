using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SaloAPI.Application.Services;
using SaloAPI.Domain.Constants;
using SaloAPI.Infrastructure.Database.Exceptions;
using System.Data;

namespace SaloAPI.Infrastructure.Database;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SaloDbContext>
{
    private readonly string saloDatabaseUrl;

    public DesignTimeDbContextFactory()
    {
        var appSettingsPath = AppSettingsService.GetAppSettingsPath();

        var configuration = new ConfigurationBuilder().AddJsonFile(appSettingsPath).Build();

        saloDatabaseUrl = Environment.GetEnvironmentVariable(EnvironmentConstants.DatabaseUrl)
                          ?? configuration[EnvironmentConstants.DatabaseUrl]
                          ?? throw new AppSettingException(EnvironmentConstants.DatabaseUrl);
    }

    public SaloDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<SaloDbContext>();

        options.UseSqlServer(saloDatabaseUrl);

        return new SaloDbContext(options.Options);
    }
}