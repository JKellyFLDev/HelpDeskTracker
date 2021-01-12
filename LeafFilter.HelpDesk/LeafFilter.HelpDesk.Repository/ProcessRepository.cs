using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.Repository
{
    public interface IProcessRepository : IRepositoryAsync<Process> { }

    public class ProcessRepository : IProcessRepository
    {
        private readonly HelpDeskContext _context;

        public ProcessRepository(HelpDeskContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var value = _context.Process.FirstOrDefault(x => x.Id == id);
            if (value != null)
            {
                _context.Process.Remove(value);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Process>> GetAllAsync()
        {
            return await _context.Process.ToListAsync();
        }

        public async Task<Process> GetSingleByIdAsync(Guid id)
        {
            return await _context.Process.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Process> InsertAsync(Process value)
        {
            _context.Process.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<Process> UpdateAsync(Process value)
        {
            if (!_context.Process.Local.Any(x => x.Id == value.Id))
            {
                _context.Process.Attach(value);
            }
            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return value;
        }
    }
}
