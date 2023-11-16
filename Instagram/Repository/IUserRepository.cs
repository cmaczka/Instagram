using Instagram.DTO;
using Instagram.Models;

namespace Instagram.Repository
{
    public interface IUserRepository
    {
        Task<bool> CreateAsync(User entity);
        bool IsUniqueUser(string userName);
        Task<LoginResponseDto> Login(LoginRequestDTO logingRequestDto);
        Task<List<User>> GetAllAsync();
    }
}
