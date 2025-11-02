namespace Prometheus.MovieBuff.Presentation.Features.Movies.CreateMovie.v1;

internal static class CreateMovieEndpoint
{
    internal static IEndpointRouteBuilder MapCreateMovieEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/movies", async (CreateMovieRequest request, CancellationToken cancellationToken = default) =>
        {
            return Results.Created();
        })
        .WithName("CreateMovie")
        .WithTags("Movies");

        return app;
    }
}