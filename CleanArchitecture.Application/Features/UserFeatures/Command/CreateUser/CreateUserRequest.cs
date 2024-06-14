using MediatR;

namespace CleanArchitecture.Application.Features.UserFeatures.Command.Create
{
    public sealed record CreateUserRequest
    (
        string Username,
        string Password,
        string Email,
        string Fullname,
        string PhoneNumber,
        string Address
    ) : IRequest<CreateUserResponse>;
}
