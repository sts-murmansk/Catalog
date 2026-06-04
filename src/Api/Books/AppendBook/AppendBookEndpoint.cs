namespace Api.Books.AppendBook;

public record AppendBookRequest(
    string Title,
    string Name,
    string Description,
    string ImageUrl,
    decimal Price,
    List<string> Category
);

public record AppendBookResponse(Guid Id);

public class AppendBookEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/books", async (
            AppendBookRequest request,
            ISender sender
        ) =>
        {
            var command = request.Adapt<AppendBookCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<AppendBookResponse>();
            return Results.Ok(response);
        });
    }
}
