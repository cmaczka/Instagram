using Instagram.Models;
using Instagram.Repository;

namespace Instagram.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateAsync(User entity)
        {
            entity.CreationDate = DateTime.Now;

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

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
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
