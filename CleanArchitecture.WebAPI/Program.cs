using CleanArchitecture.Application;
using CleanArchitecture.Application.Helper;
using CleanArchitecture.Persistence;
using CleanArchitecture.WebAPI.Extensions;
using CleanArchitecture.WebAPI.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

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

// ngambil token management dari appseting.json (option pattern)
builder.Services.Configure<TokenManagement>(builder.Configuration.GetSection("TokenManagement"));
var token = builder.Configuration.GetSection("TokenManagement").Get<TokenManagement>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// instal package Microsoft.AspNetCore.Authentication.Jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.Secret)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = token.Issuer,
            ValidAudience = token.Audience,
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// jika UseAuthentication dibawah UseAuthorization
// maka meskipun udah login, ketika hit api yang authorize
// dia bakalan return 401 (unauthorized)

// jika UseAuthentication di comment
// maka meskipun udah login, ketika hit api yang authorize
// namun bakalan return 401 (unauthorized)

// Middleware otentikasi JWT
app.UseAuthentication();

// jika UseAuthorization di comment
// maka meskipun udah login, tetap bisa hit api yang authorize
// namun bakalan error

// Middleware autorisasi
app.UseAuthorization();

app.UseMiddleware<BaseMiddleware>();

app.MapControllers();

app.Run();
