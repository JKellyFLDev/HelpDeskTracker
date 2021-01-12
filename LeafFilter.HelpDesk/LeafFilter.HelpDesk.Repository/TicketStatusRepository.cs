using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Model.Conditions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.Repository
{
    public interface ITicketStatusRepository : IRepositoryAsync<TicketStatus>
    {
        Task<TicketStatus> GetSingleByNameAsync(string name);
    }

    public class TicketStatusRepository : ITicketStatusRepository
    {
        private readonly HelpDeskContext _context;

        public TicketStatusRepository(HelpDeskContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var value = _context.TicketStatus.FirstOrDefault(x => x.Id == id);
            if (value != null)
            {
                _context.TicketStatus.Remove(value);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<TicketStatus>> GetAllAsync()
        {
            return await _context.TicketStatus.ToListAsync();
        }

        public async Task<TicketStatus> GetSingleByIdAsync(Guid id)
        {
            return await _context.TicketStatus.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TicketStatus> GetSingleByNameAsync(string name)
        {
            return await _context.TicketStatus.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<TicketStatus> InsertAsync(TicketStatus value)
        {
            _context.TicketStatus.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<TicketStatus> UpdateAsync(TicketStatus value)
        {
            if (!_context.TicketStatus.Local.Any(x => x.Id == value.Id))
            {
                _context.TicketStatus.Attach(value);
            }
            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return value;
        }
    }
}
