using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaloAPI.Infrastructure.Database;

namespace SaloAPI.BusinessLogic.DependencyInjection;

public static class DatabaseDependencyInjection
{
    public static IServiceCollection AddDatabaseContextServices(
        this IServiceCollection services,
        string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString));
        }

        services.AddDbContext<SaloDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}