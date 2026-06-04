namespace Api.Books.DeleteBook;

public record DeleteBookResult(bool IsSuccess);

public record DeleteBookCommand(
    string Id
) : ICommand<DeleteBookResult>;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(item => item.Id)
            .NotEmpty().WithMessage("Id не может быть пустым.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Id не является валидным Guid.");
    }
}

public class DeleteBookCommandHandler(IDocumentSession session)
    : ICommandHandler<DeleteBookCommand, DeleteBookResult>
{
    public async Task<DeleteBookResult> Handle(
        DeleteBookCommand command,
        CancellationToken cancellationToken)
    {
        var isSuccess = Guid.TryParse(command.Id, out var id);
        
        var book = await session.LoadAsync<Book>(id, cancellationToken);

        if (book is null)
        {
            return new DeleteBookResult(false);
        }

        session.Delete(book);
        await session.SaveChangesAsync(cancellationToken);

        return new DeleteBookResult(true);
    }
}
