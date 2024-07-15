using MediatR;

namespace DigitalMart.Application.Features.AuthFeatures.LoginFeatures
{
    public sealed record LoginRequest
    (
        string Username,
        string Password
    ) : IRequest<LoginResponse>;
}
