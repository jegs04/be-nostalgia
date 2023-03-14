using Microsoft.EntityFrameworkCore;
using Nostalgia.API.Context.Account;
using Nostalgia.API.Helpers;
using Nostalgia.API.Models.Account;
using System.Security.Cryptography;
using System.Text;

namespace Nostalgia.API.Repository.Account
{
    public class AccountRepositroy : IAccountRepository
    {
        private readonly AccountDbContext _accountDbContext;
        public AccountRepositroy(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public async Task<UserProfile> GetUserByUserName(string userName)
        {
            return await _accountDbContext.UserProfiles.FirstOrDefaultAsync(f => f.UserId == userName);
        }

        public async Task<UserProfile> CreateUser(UserProfileModel userProfileModel)
        {
            var hash = new PasswordHasher();
            var user = new UserProfile()
            {
                UserNo= GenerateUserNo(),
                UserId= userProfileModel.UserId,
                UserPwd= hash.hashPassword(userProfileModel.UserPwd!),
                ResidentNo= "801011000000",
                UserType = "1",
                LoginFlag= 0,
                LoginTag= "Y",
                IptTime= DateTime.Now,
                LoginTime= null,
                LogoutTime  = null,
                UserIpAddr= null,
                ServerId= "000",
            };

            var userToTableUser = new TblUser()
            {
                UserNo = user.UserNo,
                UserId = user.UserId,
                UserPwd = userProfileModel.UserPwd,
                UserMail = userProfileModel.UserMail,
                UserAnswer = "0",
                UserQuestion = "0",
            };

            _accountDbContext.TblUsers.Add(userToTableUser);
            _accountDbContext.UserProfiles.Add(user);
            await _accountDbContext.SaveChangesAsync();

            return user;
        }

        private string GenerateUserNo()
        {
            string dk_time = DateTime.Now.ToString("yyMMddHHmmss");
            (string usec1, string sec1) = GetMicrotime();
            return dk_time + usec1.Substring(2, 2);
        }

        private static (string, string) GetMicrotime()
        {
            DateTime dt = DateTime.Now;
            string usec1 = (dt.Ticks % 10000000).ToString("0000000");
            string sec1 = ((int)(dt.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString();
            return (usec1, sec1);
        }

    }
}
