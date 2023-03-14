using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Nostalgia.API.Helpers
{
    public class JwtHelper
    {
        public static string GenerateToken(string userName, IConfiguration _configuration) {

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtKey = _configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtKey.GetValue<string>("Key"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
