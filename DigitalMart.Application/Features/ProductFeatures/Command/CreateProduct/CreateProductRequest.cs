using MediatR;

namespace DigitalMart.Application.Features.ProductFeatures.Command.CreateProduct;

public sealed record CreateProductRequest
    (
        string Name,
        decimal Price,
        string Description,
        string CategoryName,
        string? ImageUrl,
        string? ImageLocalPath
    ) : IRequest<CreateProductResponse>;