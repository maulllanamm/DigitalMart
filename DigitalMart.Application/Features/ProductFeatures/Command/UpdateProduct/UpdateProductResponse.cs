namespace DigitalMart.Application.Features.UserFeatures.Command.UpdateProduct
{
    public sealed record UpdateProductResponse(
        string Name,
        decimal Price,
        string Description,
        string CategoryName,
        string? ImageUrl,
        string? ImageLocalPath
    );
}
