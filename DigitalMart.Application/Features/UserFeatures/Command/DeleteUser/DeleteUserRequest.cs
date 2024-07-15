using MediatR;

namespace DigitalMart.Application.Features.UserFeatures.Command.DeleteUser
{
    public sealed record DeleteUserRequest
    (
        int id
    ) : IRequest<bool>;
}
