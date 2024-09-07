using Microsoft.EntityFrameworkCore;
using StockMarket.Data;
using StockMarket.DTOs;
using StockMarket.Models;
using StockMarket.Services.Base;

namespace StockMarket.Services
{
    public class PortfolioService:BaseService<Protfolio>,IPortfolioService
    {
        
        public PortfolioService(AppDbContext context):base(context)
        {}

        public async Task<Protfolio> GetPortoflioofuser(ApplicationUser user, string Symbol)
        {
            return await context.protfolios.FirstOrDefaultAsync(x=>x.Stock.Symbol.ToLower() == Symbol.ToLower()&&x.applicationUser.Id==user.Id);   
        }

        public async Task<List<StockDtoDisplay>> GetStokcsByuser(ApplicationUser user)
        {
            return await  context.protfolios.Where(x => x.ApplicationuserId == user.Id)
                .Select(Stock=>new StockDtoDisplay
                {
                    CompanyName=Stock.Stock.CompanyName,
                    Symbol=Stock.Stock.Symbol,
                    Purchase = Stock.Stock.Purchase,
                    marketcamp = Stock.Stock.marketcamp,
                    Industry=Stock.Stock.Industry,
                    LastDiv = Stock.Stock.LastDiv



                }).ToListAsync();
            
        }
    }
}
