
using Api.Exceptions;

namespace Api.Books.UpdateBook;

public record UpdateBookResult(bool IsSuccess);

public record UpdateBookCommand(
    Guid Id,
    string Title,
    string Name,
    string Description,
    string ImageUrl,
    decimal Price,
    List<string> Category
) : ICommand<UpdateBookResult>;

public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(item => item.Title).NotEmpty().WithMessage("Title не может быть пустым.");
        RuleFor(item => item.Price).GreaterThanOrEqualTo(0).WithMessage("Price не должен быть отрицательным.");
    }
}

public class UpdateBookCommandHandler(IDocumentSession session)
    : ICommandHandler<UpdateBookCommand, UpdateBookResult>
{
    public async Task<UpdateBookResult> Handle(
        UpdateBookCommand command,
        CancellationToken cancellationToken)
    {
        var book = await session.LoadAsync<Book>(command.Id, cancellationToken);

        if (book is null)
        {
            throw new BookNotFoundException(command.Id);
        }

        /*book.Title = command.Title;
        book.Name = command.Name;
        book.Description = command.Description;
        book.ImageUrl = command.ImageUrl;
        book.Price = command.Price;
        book.Category = command.Category;*/
        command.Adapt(book);
        session.Update(book);

        await session.SaveChangesAsync(cancellationToken);

        return new UpdateBookResult(true);
    }

}
