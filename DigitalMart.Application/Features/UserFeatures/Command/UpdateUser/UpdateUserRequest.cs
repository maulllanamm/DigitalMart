using MediatR;

namespace DigitalMart.Application.Features.UserFeatures.Command.UpdateUser
{
    public sealed record UpdateUserRequest
    (
        int id,
        string Username,
        string Email,
        string Fullname,
        string PhoneNumber,
        string Address
    ) : IRequest<UpdateUserResponse>;
}
