using MediatR;

namespace DigitalMart.Application.Features.UserFeatures.Query.GetByCategory
{
    public sealed record GetByCategoryRequest
    (
        string CategoryName    
    ) : IRequest<List<GetByCategoryResponse>>;
}
