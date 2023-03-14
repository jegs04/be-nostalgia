using Microsoft.EntityFrameworkCore;
using Nostalgia.API.Context.Account;
using Nostalgia.API.Models.Login;

namespace Nostalgia.API.Repository.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AccountDbContext _accountDbContext;
        public LoginRepository(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public async Task<bool> ValidateUser(string userName, string password)
        {
            var userExist = await _accountDbContext.TblUsers.FirstOrDefaultAsync(f => f.UserId == userName && f.UserPwd == password);
            if(userExist == null)
            {
                return false;
            }
            return true;
        }


    }
}
