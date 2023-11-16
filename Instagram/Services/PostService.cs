using Instagram.DTO;
using Instagram.Models;
using Instagram.Repository;
using Microsoft.AspNetCore.Identity;

namespace Instagram.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<bool> CreateAsync(Post entity)
        {
            return await _postRepository.CreateAsync(entity);
        }


        public Task<bool> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteConfirmedAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Post entity)
        {
            throw new NotImplementedException();
        }
    }
}
