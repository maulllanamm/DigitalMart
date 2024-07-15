using DigitalMart.Application.Features.AuthFeatures.LoginFeatures;
using DigitalMart.Domain.Entities;
using System.Security.Claims;

namespace DigitalMart.Application.Helper.Interface
{
    public interface IRefreshTokenHelper
    {
        public string GenerateRefreshToken(string username, string roleName);
        public void SetRefreshToken(string newRefreshToken, string username);
        public Task ValidateRefreshToken(string username, string refreshToken);
    }
}
