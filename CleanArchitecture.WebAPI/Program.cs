using CleanArchitecture.Application;
using CleanArchitecture.Persistence;
using CleanArchitecture.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services dari layer Persistence
builder.Services.ConfigurePersistence(builder.Configuration);

// Add services dari layer Application
builder.Services.ConfigureApplication();

// Add services dari Extension
builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
