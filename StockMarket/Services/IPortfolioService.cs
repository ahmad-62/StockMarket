
using StockMarket.DTOs;
using StockMarket.Models;
using StockMarket.Services.Base;

namespace StockMarket.Services
{
    public interface IPortfolioService: IBaseService<Protfolio>
    {
       Task<List<StockDtoDisplay>> GetStokcsByuser(ApplicationUser user);
        Task<Protfolio> GetPortoflioofuser(ApplicationUser use, String Symbol); 
    }
}
