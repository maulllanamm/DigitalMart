using DigitalMart.Domain.Entities;

namespace DigitalMart.Application.Features.UserFeatures.Query.GetAll
{
    public sealed record GetAllProductResponse(
        string Name,
        decimal Price,
        string Description,
        string CategoryName,
        string? ImageUrl,
        string? ImageLocalPath
    );
}
