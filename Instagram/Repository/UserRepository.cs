using Instagram.DTO;
using Instagram.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _db;
        public UserRepository(Context context, IConfiguration configuration)
        {
            _db = context;
        }
      
        public async Task<bool> CreateAsync(User entity)
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }
        public bool IsUniqueUser(string userName)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());
            if (user == null)
            {
                return true;
            }
            return false;
        }
    }
}
