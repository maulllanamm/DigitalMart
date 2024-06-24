using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.ResetPasswordFeatures
{
    public sealed record ResetPasswordRequest
     (
        string PasswordResetToken,
        string NewPassword,
        string ConfirmPassword
     ) : IRequest<string>;
}
