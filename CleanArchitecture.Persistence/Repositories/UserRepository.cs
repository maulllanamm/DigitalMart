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
            return await _context.Users
                .Include(r => r.role)
                .ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return _context.Users
                .Include(r => r.role)
                .FirstOrDefault(e => e.id == id );
        }

        public async Task<User> GetByUsername(string username)
        {
            return _context.Users
                .Include(r => r.role)
                .ThenInclude(rp => rp.role_permissions)
                .ThenInclude(p => p.permission)
                .FirstOrDefault(e => e.username == username);
        }

        public async Task<User> GetByVerifyToken(string verifyToken)
        {
            return _context.Users
                .FirstOrDefault(t => t.verify_token == verifyToken);
        }

        public async Task<User> GetByEmail(string email)
        {
            return _context.Users
                .FirstOrDefault(t => t.email == email);
        }

        public async Task<User> GetByPasswordResetToken(string resetPasswordToken)
        {
            return _context.Users
                .FirstOrDefault(rpt => rpt.password_reset_token == resetPasswordToken);
        }
    }
}
