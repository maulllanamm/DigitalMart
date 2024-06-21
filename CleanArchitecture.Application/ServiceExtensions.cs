using CleanArchitecture.Application.Common.Behaviors;
using CleanArchitecture.Application.Helper;
using CleanArchitecture.Application.Helper.Interface;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArchitecture.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapConfig));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddScoped<IPasswordHelper, PasswordHelper>();
            services.AddScoped<IAccessTokenHelper, AccessTokenHelper>();
            services.AddScoped<IRefreshTokenHelper, RefreshTokenHelper>();
        }
    }
}