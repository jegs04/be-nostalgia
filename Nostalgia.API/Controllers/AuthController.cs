using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nostalgia.API.Helpers;
using Nostalgia.API.Models.Login;
using Nostalgia.API.Models.Response;
using Nostalgia.API.Repository.Account;
using Nostalgia.API.Repository.Login;
using System.Net;

namespace Nostalgia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _configuration;


        public AuthController(ILoginRepository accountRepository, IConfiguration configuration)
        {
            _loginRepository = accountRepository;
            _configuration = configuration;
        }

        [HttpPost("userLogin")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var isValid= await _loginRepository.ValidateUser(model.userName, model.password);
            if(!isValid) {
                var problemDetails = new ProblemDetails
                {
                    Title = "Authentication failed",
                    Detail = "Invalid username or password",
                    Status = (int)HttpStatusCode.Unauthorized
                };
                return Unauthorized(problemDetails);
            
            }

            var token = JwtHelper.GenerateToken(model.userName, _configuration);
            return Ok(new ResponseModel() {  token = token, success = true });

        }
    }
}
