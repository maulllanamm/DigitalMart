using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Repositories
{
    public interface IUserRepository
    {
        public Task<User> Create(User user);
    }
}
