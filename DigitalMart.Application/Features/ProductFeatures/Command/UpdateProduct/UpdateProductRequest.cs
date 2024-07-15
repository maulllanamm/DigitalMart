using MediatR;

namespace DigitalMart.Application.Features.UserFeatures.Command.UpdateProduct
{
    public sealed record UpdateProductRequest
    (
        int Id,
        string Name,
        decimal Price,
        string Description,
        string CategoryName,
        string? ImageUrl,
        string? ImageLocalPath
    ) : IRequest<UpdateProductResponse>;
}
