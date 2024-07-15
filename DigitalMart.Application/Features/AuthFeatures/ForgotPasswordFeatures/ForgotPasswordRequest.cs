using MediatR;

namespace DigitalMart.Application.Features.AuthFeatures.ForgotPasswordFeatures
{
    public sealed record ForgotPasswordRequest
    (
        string Email
    ) : IRequest<string>;
}
