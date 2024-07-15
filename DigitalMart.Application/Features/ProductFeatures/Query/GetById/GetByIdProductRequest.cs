using MediatR;

namespace DigitalMart.Application.Features.UserFeatures.Query.GetById
{
    public sealed record GetByIdProductRequest(int Id) : IRequest<GetByIdProductResponse>;
}
