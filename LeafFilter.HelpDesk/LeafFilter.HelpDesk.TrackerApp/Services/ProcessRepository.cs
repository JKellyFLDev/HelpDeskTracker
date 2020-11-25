using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.TrackerApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.Services
{
    public class ProcessRepository : IProcessRepository
    {
        HelpDeskContext _context = new HelpDeskContext();

        public async Task<List<Process>> GetAllProcessesAsync()
        {
            return await _context.Processes.ToListAsync();
        }

        public async Task<Process> GetProcessAsync(Guid processId)
        {
            return await _context.Processes.FirstOrDefaultAsync(x => x.Id == processId);
        }

        public async Task<Process> AddProcessAsync(Process process)
        {
            _context.Processes.Add(process);
            await _context.SaveChangesAsync();
            return process;
        }

        public async Task<Process> UpdateProcessAsync(Process process)
        {
            if (!_context.Processes.Local.Any(x => x.Id == process.Id))
            {
                _context.Processes.Attach(process);
            }
            _context.Entry(process).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return process;
        }

        public async Task DeleteProcessAsync(Guid processId)
        {
            var process = _context.Processes.FirstOrDefault(x => x.Id == processId);
            if (process != null)
            {
                _context.Processes.Remove(process);
            }
            await _context.SaveChangesAsync();
        }    
    }
}
