using Microsoft.EntityFrameworkCore;
using StockMarket.Data;
using StockMarket.Models;
using StockMarket.Services.Base;

namespace StockMarket.Services
{
    public class StockService: BaseService<Stock>, IStockService
    {
        public StockService(AppDbContext context):base(context) { }

        public async Task<IEnumerable<Stock>> GetStockswithComments()
        {
            return await context.stocks.Include(x=>x.comments).ThenInclude(x=>x.applicationuser).ToListAsync();
        }

        public async Task<Stock> GetStockWithcomment(int id)
        {
            return await context.stocks.Include(x => x.comments).ThenInclude(x=>x.applicationuser).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await context.stocks.AnyAsync(e => e.Id == id);
        }

        public async Task<Stock> GeyBySymbol(string symbol)
        {
            return await context.stocks.FirstOrDefaultAsync(x => x.Symbol == symbol);
        }
    }
}
