using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.ForgotPasswordFeatures
{
    public sealed record ForgotPasswordRequest
    (
        string Email
    ) : IRequest<string>;
}
