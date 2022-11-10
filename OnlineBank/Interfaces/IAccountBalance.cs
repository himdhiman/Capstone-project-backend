//placeholder for method declaration, by default public and abstract
namespace OnlineBank.API.Interfaces
{
    public interface IAccountBalance<T>
    {

        Task<T?> GetAsync(long acnt);

    }
}
