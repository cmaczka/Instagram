using Instagram.DTO;
using Instagram.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Instagram.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly Context _db;
        public PostRepository(Context context, IConfiguration configuration)
        {
            _db = context;
        }
      
        public async Task<bool> CreateAsync(Post entity)
        {
            await _db.Posts.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }
       
    }
}
