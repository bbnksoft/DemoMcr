using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Retry;
using Inventory.Core.Interfaces;
using Inventory.Infrastructure.Persistence;
using Inventory.Infrastructure.Repositories;

namespace Inventory.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        // Configure retry policy
        var retryPolicy = new RetryStrategyOptions
        {
            MaxRetryAttempts = 3,
            Delay = TimeSpan.FromSeconds(2),
            BackoffType = DelayBackoffType.Exponential,
            UseJitter = true
        };

        // Add DbContext with retry policy
        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });
        });

        // Register repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
