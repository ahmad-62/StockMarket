using Microsoft.EntityFrameworkCore;
using StockMarket.Data;
using StockMarket.Models;
using StockMarket.Services.Base;

namespace StockMarket.Services
{
    public class commentService:BaseService<Comment>,IcommentService
    {
        public commentService(AppDbContext context):base(context) { }
        public async Task<bool> ExistsAsync(int id)
        {
            return await context.comments.AnyAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetAllWithUser()
        {
            return await context.comments.Include(x=>x.applicationuser).ToListAsync();
        }

        public async Task<Comment> GetWithUSer(int id)
        {
            return await context.comments.Include(x=>x.applicationuser).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
