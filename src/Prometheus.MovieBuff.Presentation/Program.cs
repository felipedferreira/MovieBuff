using Prometheus.MovieBuff.Presentation.Features.Movies.CreateMovie.v1;
using Scalar.AspNetCore;

namespace Prometheus.MovieBuff.Presentation;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        // Add services to the container.
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

        // Adds middleware for redirecting HTTP Requests to HTTPS. 
        app.UseHttpsRedirection();
        
        // Maps endpoints
        app.MapCreateMovieEndpoint();
        
        await app.RunAsync();
    }
}