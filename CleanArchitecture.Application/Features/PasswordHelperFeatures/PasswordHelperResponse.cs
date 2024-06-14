namespace CleanArchitecture.Application.Features.PasswordHelperFeatures
{
    public sealed class PasswordHelperResponse
    {
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
    }
}
