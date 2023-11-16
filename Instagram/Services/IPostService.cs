using Instagram.DTO;
using Instagram.Models;

namespace Instagram.Services
{
    public interface IPostService : IGenericService<Post>
    {
        Task<bool> LikeAsync(Like entity);
    }
}
