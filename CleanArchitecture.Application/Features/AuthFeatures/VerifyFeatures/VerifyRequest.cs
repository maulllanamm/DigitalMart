using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.VerifyFeatures
{
    public sealed record VerifyRequest
    (
        string VerifyToken
    ) : IRequest<string>;
}
