using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Application.Features.AuthFeatures.PermittionFeatures
{
    public sealed record IsPermittedRequest
    (
        HttpContext HttpContext,
        Role? role
    ) : IRequest<bool>;

}
