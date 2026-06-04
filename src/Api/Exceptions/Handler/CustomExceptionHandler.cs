namespace Api.Exceptions.Handler;

public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(
            "",
            exception.Message,
            DateTime.Now
        );

        (string Detail, string Title, int StatusCode) details = exception switch
        {
            BookNotFoundException =>
            (
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound
            ),
            _ => (
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError
            )            
        };

        var problems = new ProblemDetails
        {
            Title = details.Title,
            Detail = details.Detail,
            Status = details.StatusCode,
            Instance = httpContext.Request.Path
        };

        if (exception is ValidationException validationException)
        {
            problems.Extensions.Add("Errors", validationException.Errors);
        }

        await httpContext.Response.WriteAsJsonAsync(
            problems,
            cancellationToken: cancellationToken
        );

        return true;
    }
}
