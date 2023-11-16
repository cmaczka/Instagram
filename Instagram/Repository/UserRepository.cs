using Instagram.DTO;
using Instagram.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Instagram.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _db;
        private string secretKey;
        public UserRepository(Context context, IConfiguration configuration)
        {
            _db = context;
            secretKey = configuration.GetValue<string>("APISettings:Secret");
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

        public async Task<LoginResponseDto> Login(LoginRequestDTO logingRequestDto)
        {
            var usuario = await _db.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == logingRequestDto.UserName.ToLower());

            if (usuario == null)
            {
                return new LoginResponseDto()
                {
                    Token = "",
                    User = null
                };
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            LoginResponseDto loginResponseDto = new()
            {
                Token = tokenHandler.WriteToken(token),
                User = usuario,      
            };
            return loginResponseDto;
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _db.Users.ToListAsync();
        }
    }
}
