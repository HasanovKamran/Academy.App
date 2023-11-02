using Academy.Core.Models.BaseModel;
using System;
namespace Academy.Core.Repositories
{
   public interface IRepository<T> where T : BaseModel
    {
        public  Task AddAsync(T entity);
        public Task RemoveAsync(T entity);
        public Task <List<T>> GetAllAsync(T entity);
        public Task<List<T>> GetAllAsync(Func<T, bool>func);
        public Task<T> GetAsync(Func<T, bool> func);
    }
}
