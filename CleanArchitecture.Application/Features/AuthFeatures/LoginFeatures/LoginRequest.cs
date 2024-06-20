using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.LoginFeatures
{
    public sealed record LoginRequest
    (
        string Username,
        string Password
    ) : IRequest<bool>;
}
