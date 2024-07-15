using MediatR;

namespace DigitalMart.Application.Features.UserFeatures.Query.GetById
{
    public sealed record GetByIdUserRequest(int id) : IRequest<GetByIdUserResponse>;
}
