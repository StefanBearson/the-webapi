using the_webapi.Endpoints;
using the_webapi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.AddDevStuff();
}

app.UseHttpsRedirection();

app.AddMyMiddleware();
//Endpoints
PersonEndpoints.Map(app);

app.Run();