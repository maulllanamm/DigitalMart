using MediatR;

namespace DigitalMart.Application.Features.UserFeatures.Query.GetAll
{
    public sealed record GetAllProductRequest : IRequest<List<GetAllProductResponse>>
    {

    }
}
