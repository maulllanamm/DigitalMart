using MediatR;

namespace DigitalMart.Application.Features.AuthFeatures.VerifyFeatures
{
    public sealed record VerifyRequest
    (
        string VerifyToken
    ) : IRequest<string>;
}
