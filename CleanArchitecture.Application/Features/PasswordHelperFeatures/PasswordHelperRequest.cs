using MediatR;

namespace CleanArchitecture.Application.Features.PasswordHelperFeatures
{
    public sealed record  PasswordHelperRequest(string Password) : IRequest<PasswordHelperResponse>;
}
