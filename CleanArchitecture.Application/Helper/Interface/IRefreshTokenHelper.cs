using CleanArchitecture.Application.Features.AuthFeatures.LoginFeatures;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Helper.Interface
{
    public interface IRefreshTokenHelper
    {
        public string GenerateRefreshToken(string username);
        public void SetRefreshToken(string newRefreshToken, string username);
    }
}
