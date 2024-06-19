using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAll();
        public Task<User> GetById(int id);
        public Task<User> Create(User user);
        public Task<User> Update(User user);
    }
}
