namespace Api.Data.Seed;

public class InitializeBookDatabase : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();
        if (!await session.Query<Book>().AnyAsync())
        {
            session.Store<Book>(InitialData.Books);
            await session.SaveChangesAsync(cancellation);
        }
    }
}
