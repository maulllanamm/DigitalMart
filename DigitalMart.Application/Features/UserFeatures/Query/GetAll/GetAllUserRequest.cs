using MediatR;

namespace DigitalMart.Application.Features.UserFeatures.Query.GetAll
{
    public sealed record GetAllUserRequest : IRequest<List<GetAllUserResponse>>
    {

    }
}
