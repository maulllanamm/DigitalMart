using DigitalMart.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace DigitalMart.Application.Features.AuthFeatures.PermittionFeatures
{
    public sealed record IsPermittedRequest
    (
        HttpContext HttpContext,
        Role? role
    ) : IRequest<bool>;

}
