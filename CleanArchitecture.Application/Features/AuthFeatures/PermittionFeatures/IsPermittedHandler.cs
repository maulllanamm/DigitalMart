using CleanArchitecture.Application.Helper;
using MediatR;
using Microsoft.Extensions.Options;

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
            // Logika pengecekan izin
            bool isPermitted = true;
            return isPermitted;
        }
    }
}
