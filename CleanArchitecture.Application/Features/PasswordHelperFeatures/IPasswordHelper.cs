namespace CleanArchitecture.Application.Features.PasswordHelperFeatures
{
    public interface IPasswordHelper
    {
        public string ComputeHash(string password, string salt, string papper, int iteration);
        public string GenerateSalt();
    }
}
