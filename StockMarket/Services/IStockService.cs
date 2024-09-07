using StockMarket.Models;
using StockMarket.Services.Base;

namespace StockMarket.Services
{
    public interface IStockService:IBaseService<Stock>
    {
        Task<IEnumerable<Stock>> GetStockswithComments();
        Task <Stock> GetStockWithcomment(int id);
         Task<bool> ExistsAsync(int id);
        Task <Stock> GeyBySymbol(string symbol);
        
    }
}
