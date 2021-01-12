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
    public interface ITicketRepository : IRepositoryAsync<Ticket> 
    {
        Task<int> SaveAsync();
    }

    public class TicketRepository : ITicketRepository
    {
        private readonly HelpDeskContext _context;

        public TicketRepository(HelpDeskContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var value = _context.Ticket.FirstOrDefault(x => x.Id == id);
            if (value != null)
            {
                _context.Ticket.Remove(value);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _context.Ticket.ToListAsync();
        }

        public async Task<Ticket> GetSingleByIdAsync(Guid id)
        {
            return await _context.Ticket.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Ticket> InsertAsync(Ticket value)
        {
            _context.Ticket.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }  

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();            
        }

        public async Task<Ticket> UpdateAsync(Ticket value)
        {
            if (!_context.Ticket.Local.Any(x => x.Id == value.Id))
            {
                _context.Ticket.Attach(value);
            }
            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return value;
        }
    }
}
