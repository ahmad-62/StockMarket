using StockMarket.Models;

namespace StockMarket.Services.Base
{
    public interface IBaseService<T> where T : class
    {
        IQueryable<T> GetAllAsync();
        Task<T> GetAsync(int id);
        Task CreateAsync(T entity);
        T Update (T entity);
        void Delete(T entity);



    }
}
