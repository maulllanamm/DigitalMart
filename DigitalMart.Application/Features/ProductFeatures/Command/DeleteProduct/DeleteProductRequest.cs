using MediatR;

namespace DigitalMart.Application.Features.ProductFeatures.Command.DeleteProduct
{
    public sealed record DeleteProductRequest
    (
        int id
    ) : IRequest<bool>;
}
