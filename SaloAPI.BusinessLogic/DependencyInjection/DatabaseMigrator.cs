﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaloAPI.Infrastructure.Database;

namespace SaloAPI.BusinessLogic.DependencyInjection;

public static class DatabaseMigrator
{
    public static void MigrateDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
            .CreateScope();

        using var context = serviceScope.ServiceProvider.GetService<SaloDbContext>();

        if (context == null)
        {
            throw new InvalidOperationException("Database context is NULL at Migrator service.");
        }

        context.Database.Migrate();
    }
}