using Scalar.AspNetCore;
using the_webapi.Middlewares;
using the_webapi.Repository;
using the_webapi.Services;
using the_webapi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddSingleton<IPersonService, PersonService>();
builder.Services.AddSingleton<IPersonRepository, PersonRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options => {
        options.Title = "Person API";
        options.Theme = ScalarTheme.Mars;
    });
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestLoggingMiddleware>();

//Endpoints
PersonEndpoints.Map(app);

app.Run();