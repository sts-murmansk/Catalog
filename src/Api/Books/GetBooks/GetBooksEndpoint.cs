namespace Api.Books.GetBooks;

public record GetBooksRequest(int? PageNumber = 1, int? PageSize = 5);

public record GetBooksResponse(IEnumerable<Book> Books);

public class GetBooksEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/books", async (
            [AsParameters] GetBooksRequest request,
            ISender sender) =>
        {
            GetBooksQuery query = request.Adapt<GetBooksQuery>();
            GetBooksResult result = await sender.Send(query);
            GetBooksResponse response = result.Adapt<GetBooksResponse>();
            return Results.Ok(response);
        });
    }
}
