using Api.Behaviors;
using Api.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddMarten(option =>
{
    option.Connection(connectionString);
}).UseLightweightSessions().InitializeWith<InitializeBookDatabase>();

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(TimeoutBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.UseExceptionHandler(opt => { });

app.MapCarter();

app.Run();
