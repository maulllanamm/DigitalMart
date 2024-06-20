using MediatR;

namespace CleanArchitecture.Application.Features.UserFeatures.Query.GetAll
{
    public sealed record GetAllUserRequest : IRequest<List<GetAllUserResponse>>
    {

    }
}
