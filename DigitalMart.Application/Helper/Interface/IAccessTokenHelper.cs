using DigitalMart.Domain.Entities;
using System.Security.Claims;

namespace DigitalMart.Application.Helper.Interface
{
    public interface IAccessTokenHelper
    {
        public string GenerateAccessToken(string username , string roleName);
        public ClaimsPrincipal ValidateAccessToken(string token);
    }
}
