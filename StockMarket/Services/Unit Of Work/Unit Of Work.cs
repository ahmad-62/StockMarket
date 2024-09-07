using StockMarket.Data;

namespace StockMarket.Services.Unit_Of_Work
{
    public class Unit_Of_Work : IUnitOfWork
    {
        private readonly AppDbContext context;
        public Unit_Of_Work(AppDbContext context) {
        
        this.context = context;
        
        }
        public async Task savechanges()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch {
                await context.Database.CurrentTransaction.RollbackAsync();
            }
        }
       
    }
}
