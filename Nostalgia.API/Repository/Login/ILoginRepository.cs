using Nostalgia.API.Models.Login;

namespace Nostalgia.API.Repository.Login
{
    public interface ILoginRepository
    {
        Task<bool> ValidateUser(string userName, string password);
    }
}
