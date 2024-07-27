using MatrimonialCapstoneApplication.Interfaces;
using MatrimonialCapstoneApplication.Modals;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MatrimonialCapstoneApplication.Services
{
    public class TokenService : ITokenService
    {
        private string _secretKey;
        private SymmetricSecurityKey Key;

        public TokenService(IConfiguration configuration)
        {
            _secretKey = configuration.GetSection("TokenKey").GetSection("JWT").Value.ToString();
            Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        }
        public string GenerateToken(Member member)
        {
            string token;
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name,member.Email.ToString()),
                new Claim(ClaimTypes.Role, member.Role.ToString())
            };
            var credentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha512);
            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(2), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(myToken);
            return token;
        }
    }
}
