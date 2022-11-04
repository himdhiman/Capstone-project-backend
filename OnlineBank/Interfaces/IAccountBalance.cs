namespace OnlineBank.API.Interfaces
{
    public interface IAccountBalance<T>
    {

        Task<T?> GetAsync(long acnt);

    }
}
