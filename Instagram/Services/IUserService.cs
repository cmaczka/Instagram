using Instagram.Models;

namespace Instagram.Services
{
    public interface IUserService : IGenericService<User>
    {
        bool IsUniqueUser(string userName);
    }
}
