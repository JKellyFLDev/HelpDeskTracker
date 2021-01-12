using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.Repository
{
    public interface IRepository { }

    public interface IRepository<T> : IRepository where T : class
    {
        void DeleteById(Guid id);
        List<T> GetAll();
        T GetSingleId(Guid id);
        T Insert(T value);
        T Update(T value);        
    }

    public interface IRepositoryAsync<T> : IRepository where T : class
    {                  
        Task DeleteByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<T> GetSingleIdAsync(Guid id);
        Task<T> InsertAsync(T value);
        Task<T> UpdateAsync(T value);
    }
}
