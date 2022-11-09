//placeholder for method declaration, by default public and abstract
namespace OnlineBank.API.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAsync();
        Task<T?> GetAsync(string id);
        Task CreateAsync(T newObject);
        Task UpdateAsync(string id, T updatedObject);
        Task RemoveAsync(string id);
    }
}
