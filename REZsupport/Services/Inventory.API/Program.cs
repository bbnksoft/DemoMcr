using Microsoft.EntityFrameworkCore;
using Inventory.API.Middleware;
using Inventory.Application;
using Inventory.Infrastructure;
using Inventory.Infrastructure.Persistence;
using Serilog;

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("Starting Inventory API application");

    var builder = WebApplication.CreateBuilder(args);

    // Add Serilog
    builder.Host.UseSerilog();

    // Add services to the container
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new() { Title = "Inventory API", Version = "v1" });
    });

    // Add Application and Infrastructure layers
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure(builder.Configuration);

    // Add CORS
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

    var app = builder.Build();

    // Run migrations automatically (with error handling)
    try
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
            Log.Information("Database migration completed successfully");
        }
    }
    catch (Exception ex)
    {
        Log.Warning(ex, "Unable to apply database migrations. Database may not be available. Application will continue without database connection.");
    }

    // Configure the HTTP request pipeline
    app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

    // Enable Swagger in all environments
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventory API v1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at root
    });

    app.UseSerilogRequestLogging();

    // Only redirect HTTPS in Development when not using Docker
    if (app.Environment.IsDevelopment() && !app.Environment.IsEnvironment("Docker"))
    {
        app.UseHttpsRedirection();
    }

    app.UseCors("AllowAll");
    app.UseAuthorization();
    app.MapControllers();

    Log.Information("Inventory API starting on {Urls}", builder.Configuration["ASPNETCORE_URLS"] ?? "default port");
    
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
