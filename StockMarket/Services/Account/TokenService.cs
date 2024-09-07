using Microsoft.IdentityModel.Tokens;
using StockMarket.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockMarket.Services.Account
{
    public class TokenService:ITokenService
    {
    private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;

            
        }

        public string CreateToken(ApplicationUser user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, user.Email),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.GivenName,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.FullName)

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var SignInCredentials=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audiance"],

                claims: claims,
                expires:DateTime.Now.AddDays(7),
                signingCredentials:SignInCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
