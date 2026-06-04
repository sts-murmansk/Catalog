namespace Api.Exceptions;

public class BookNotFoundException : Exception
{
    public BookNotFoundException(Guid Id)
        : base($"Книга с id: {Id} не существует.")
    { }
}
