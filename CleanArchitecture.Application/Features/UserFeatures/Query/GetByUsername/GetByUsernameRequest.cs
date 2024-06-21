using MediatR;

namespace CleanArchitecture.Application.Features.UserFeatures.Query.GetByUsername
{
    public sealed record GetByUsernameRequest
    (
        string Username    
    ) : IRequest<GetByUsernameResponse>;
}
