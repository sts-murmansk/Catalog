namespace Api.Books.GetBooks;

public record GetBooksResult(IEnumerable<Book> Books);

public record GetBooksQuery(int? PageNumber = 1, int? PageSize = 5)
    : IQuery<GetBooksResult>;

public class GetBooksQueryHandler(IDocumentSession session)
    : IQueryHandler<GetBooksQuery, GetBooksResult>
{
    public async Task<GetBooksResult> Handle(GetBooksQuery query, CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(5));
        var books = await session.Query<Book>()
            //.ToListAsync(cancellationToken);
            .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 5, cancellationToken);
            
        return new GetBooksResult(books);
    }
}
