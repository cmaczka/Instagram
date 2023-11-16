using Instagram.DTO;
using Instagram.Models;

namespace Instagram.Repository
{
    public interface IPostRepository
    {
        Task<bool> CreateAsync(Post entity);
        Task<bool> LikeAsync(Like entity);
    }
}
