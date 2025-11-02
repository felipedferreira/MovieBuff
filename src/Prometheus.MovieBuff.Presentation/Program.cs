using Prometheus.MovieBuff.Presentation.Features.Movies.CreateMovie.v1;
using Scalar.AspNetCore;
using Serilog;

namespace Prometheus.MovieBuff.Presentation;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
        });

        builder.Services.AddEndpointsApiExplorer();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            // --- 👇 Add Scalar UI (the modern Swagger alternative) ---
            app.MapScalarApiReference(options =>
            {
                options.Title = "🎬 MovieBuff API";
                options.Theme = ScalarTheme.BluePlanet;
                options.DarkMode = true;
            });
        }
        
        // logs requests
        app.UseSerilogRequestLogging();
        
        // Adds middleware for redirecting HTTP Requests to HTTPS. 
        app.UseHttpsRedirection();
        
        // Sets the path base to "api/movie-svc" so that all endpoints are prefixed with this path.
        app.UsePathBase("/api/movie-svc");
        
        // Maps endpoints
        app.MapCreateMovieEndpoint();
        
        await app.RunAsync();
    }
}