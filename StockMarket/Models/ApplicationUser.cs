using Microsoft.AspNetCore.Identity;

namespace StockMarket.Models
{
    public class ApplicationUser:IdentityUser
    {
        public String FullName{ get; set; }
        public List<Protfolio> protfolios { get; set; }=new List<Protfolio>();
    }
}
