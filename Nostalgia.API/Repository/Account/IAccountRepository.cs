using Nostalgia.API.Context.Account;
using Nostalgia.API.Models.Account;

namespace Nostalgia.API.Repository.Account
{
    public interface IAccountRepository
    {
        Task<UserProfile> GetUserByUserName(string userName);
        Task<UserProfile> CreateUser(UserProfileModel userProfileModel);
    }
}
