using Microsoft.AspNetCore.Identity;

namespace StockMarket.Helpers
{
    public class Response
    {
        public IdentityResult Result { get; set; }
        public string Token { get; set; }
    }
   
}
