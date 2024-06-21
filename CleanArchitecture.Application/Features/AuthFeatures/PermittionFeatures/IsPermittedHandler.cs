using CleanArchitecture.Application.Helper;
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
            var role = request.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            var path = request.HttpContext.Request.Path.Value;
            var method = request.HttpContext.Request.Method.ToString();
            var isPermitted = true;


            if (role == "Administrator" || role is null)
            {
                return isPermitted;
            }

            foreach (var rolePermission in request.role.role_permissions)
            {
                if (path == rolePermission.permission.path && method == rolePermission.permission.http_method)
                {
                    isPermitted = true;
                    return isPermitted;
                }
                else
                {
                    isPermitted = false;
                }
            }

            return isPermitted;
        }
    }
}
