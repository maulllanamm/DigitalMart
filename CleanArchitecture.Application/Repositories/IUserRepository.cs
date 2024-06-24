using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Repositories
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAll();
        public Task<User> GetById(int id);
        public Task<User> GetByUsername(string username);
        public Task<User> GetByVerifyToken(string verifyToken);
        public Task<User> GetByEmail(string email);
        public Task<User> Create(User user);
        public Task<User> Update(User user);
        public Task<bool> Delete(int id);
    }
}
