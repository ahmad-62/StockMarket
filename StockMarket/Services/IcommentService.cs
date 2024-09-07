using StockMarket.Models;
using StockMarket.Services.Base;

namespace StockMarket.Services
{
    public interface IcommentService:IBaseService<Comment>
    {
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<Comment>> GetAllWithUser();
        Task<Comment> GetWithUSer(int id);
    }
}
