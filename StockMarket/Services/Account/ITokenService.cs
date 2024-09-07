using StockMarket.Models;

namespace StockMarket.Services.Account
{
    public interface ITokenService
    {
        public string CreateToken(ApplicationUser user);

    }
}
