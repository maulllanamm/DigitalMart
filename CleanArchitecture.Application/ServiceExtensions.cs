using CleanArchitecture.Application.Features.PasswordHelperFeatures;
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

            services.AddScoped<IPasswordHelper, PasswordHelper>();
        }
    }
}