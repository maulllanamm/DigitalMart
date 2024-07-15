namespace DigitalMart.Application.Features.ProductFeatures.Command.CreateProduct;

public sealed record CreateProductResponse(
    string Name,
    decimal Price,
    string Description,
    string CategoryName,
    string? ImageUrl,
    string? ImageLocalPath
);