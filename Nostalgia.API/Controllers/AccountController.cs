using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nostalgia.API.Models.Account;
using Nostalgia.API.Repository.Account;

namespace Nostalgia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(UserProfileModel userProfileModel)
        {
            if( await _accountRepository.GetUserByUserName(userProfileModel.UserId) !=null )
            {
                return BadRequest("Username Already Exists!");
            }

            var createdUser = await _accountRepository.CreateUser(userProfileModel);

            return Ok(createdUser);
        }

    }
}
