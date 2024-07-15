using DigitalMart.Domain.Entities;

namespace DigitalMart.Application.Features.UserFeatures.Query.GetById
{
    public sealed record GetByIdProductResponse(
        string Name,
        decimal Price,
        string Description,
        string CategoryName,
        string? ImageUrl,
        string? ImageLocalPath
    );
}
