namespace Instagram.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetByIdAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<bool> CreateAsync(T entity);
        Task<bool> DeleteAsync(int? id);
        Task<bool> DeleteConfirmedAsync(int? id);
        Task<bool> UpdateAsync(T entity);
    }
}
