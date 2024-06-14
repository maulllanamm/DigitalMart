using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                var res =  await base.GetAll();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> Create(User user)
        {
            try
            {
                var res = await base.Create(user);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
