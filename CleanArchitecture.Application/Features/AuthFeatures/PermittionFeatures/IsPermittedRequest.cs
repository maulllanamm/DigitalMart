using MediatR;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Application.Features.AuthFeatures.PermittionFeatures
{
    public sealed record IsPermittedRequest
    (
        HttpContext HttpContext
    ) : IRequest<bool>;

}
