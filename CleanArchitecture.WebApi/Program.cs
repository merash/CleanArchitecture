using CleanArchitecture.Application.UseCases;
using CleanArchitecture.Persistence;
using CleanArchitecture.External;
using CleanArchitecture.WebApi.Extensions.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add methods Extensions
builder.Services.AddInjectionPersistence();
builder.Services.AddInjectionExternal();
builder.Services.AddInjectionApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.AddMiddleware();

app.MapControllers();

app.Run();
