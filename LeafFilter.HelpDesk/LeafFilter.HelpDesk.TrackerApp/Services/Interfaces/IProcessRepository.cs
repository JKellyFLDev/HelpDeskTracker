using LeafFilter.HelpDesk.Models.Records;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.Services.Interfaces
{
    public interface IProcessRepository : IRepository
    {
        Task<List<Process>> GetAllProcessesAsync();
        Task<Process> GetProcessAsync(Guid processId);
        Task<Process> AddProcessAsync(Process process);
        Task<Process> UpdateProcessAsync(Process process);
        Task DeleteProcessAsync(Guid processId);
    }
}
