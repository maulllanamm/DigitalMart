using MediatR;

namespace CleanArchitecture.Application.Features.UserFeatures.Query.GetById
{
    public sealed record GetByIdUserRequest(int id) : IRequest<GetByIdUserResponse>;
}
