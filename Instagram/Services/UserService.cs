using Instagram.DTO;
using Instagram.Models;
using Instagram.Repository;

namespace Instagram.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public Task<LoginResponseDto> Login(LoginRequestDTO loginRequestDto)
        {
            return _userRepository.Login(loginRequestDto);
        }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateAsync(User entity)
        {
            entity.CreationDate = DateTime.Now;
            entity.Password= BCrypt.Net.BCrypt.EnhancedHashPassword(entity.Password, 10);
            return await _userRepository.CreateAsync(entity);
        }

        public Task<bool> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteConfirmedAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public Task<User> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public bool IsUniqueUser(string userName)
        {
            return _userRepository.IsUniqueUser(userName);
        }

        public Task<bool> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }      
    }
}
