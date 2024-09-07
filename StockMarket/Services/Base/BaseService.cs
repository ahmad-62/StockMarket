
using Microsoft.EntityFrameworkCore;
using StockMarket.Data;
using StockMarket.Models;

namespace StockMarket.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T:class
    {
        protected readonly AppDbContext context;
        public BaseService(AppDbContext context) {
        this.context = context;
        
        }
        public async Task CreateAsync(T entity)
        {
            await  context.Set<T>().AddAsync(entity);

        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);

        }

        public  IQueryable<T> GetAllAsync()
        {
            return  context.Set<T>();
        }

        public async Task<T> GetAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

      

        public T Update (T entity)
        {
          
             context.Set<T>().Update(entity);
            return entity;


        }
        
    }
}
