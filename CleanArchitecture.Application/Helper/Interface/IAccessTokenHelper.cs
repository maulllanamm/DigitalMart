using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Helper.Interface
{
    public interface IAccessTokenHelper
    {
        public string GenerateAccessToken(string username , Role role);
    }
}
