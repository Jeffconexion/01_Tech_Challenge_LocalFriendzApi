using LocalFriendzApi.UI.Configuration;
using LocalFriendzApi.UI.Endpoints;
using LocalFriendzApi.UI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDataContexts();
builder.AddServices();
builder.AddDocumentation();
builder.AddLogging();
builder.ExternalServices();
builder.AddFluentValidation();

var app = builder.Build();
app.MapEndpoints();


if (app.Environment.IsDevelopment())
{
    app.ConfigureDevEnvironment();
}

app.UseLoggingMiddleware();
app.UseHttpsRedirection();

app.Run();

