using DigitalMart.Domain.Entities;

namespace DigitalMart.Application.Features.UserFeatures.Query.GetByCategory
{
    public sealed record GetByCategoryResponse(
        string Name,
        decimal Price,
        string Description,
        string CategoryName,
        string? ImageUrl,
        string? ImageLocalPath
    );

}