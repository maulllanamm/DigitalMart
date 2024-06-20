using CleanArchitecture.Application.Helper;
using CleanArchitecture.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace CleanArchitecture.Application.Features.AuthFeatures.PermittionFeatures
{
    public class IsPermittedHandler : IRequestHandler<IsPermittedRequest, bool>
    {
        private readonly TokenManagement _token;

        public IsPermittedHandler(IOptions<TokenManagement> token)
        {
            _token = token.Value;
        }

        public async Task<bool> Handle(IsPermittedRequest request, CancellationToken cancellationToken)
        {
            var username = request.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var role = request.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            var path = request.HttpContext.Request.Path.Value;
            var method = request.HttpContext.Request.Method.ToString();


            if (role == "Administrator")
            {
                return true;
            }


            bool isPermitted = true;
            return isPermitted;
        }
    }
}
