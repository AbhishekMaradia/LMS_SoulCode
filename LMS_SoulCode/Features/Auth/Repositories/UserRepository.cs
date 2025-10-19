using LMS_SoulCode.Features.Auth.Entities;
using LMS_SoulCode.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS_SoulCode.Features.Auth.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LmsDbContext _context;
        public UserRepository(LmsDbContext context) => _context = context;

        public async Task<User?> GetByUsernameOrEmailAsync(string usernameOrEmail)
        {
            return await _context.Users.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
        }
    }

}
