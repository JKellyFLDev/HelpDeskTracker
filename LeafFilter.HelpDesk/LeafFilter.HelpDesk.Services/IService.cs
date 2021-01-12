using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.Service
{
    public interface IService { }

    public interface IService<T> : IService where T : class
    {
        List<T> LoadAll();
        T LoadSingle(Guid id);
    }

    public interface IServiceAsync<T> : IService where T : class
    {
        Task<List<T>> LoadAllAsync();
        Task<T> LoadSingleAsync(Guid id);
        
    }
}
