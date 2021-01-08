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
    public class TicketRepository : ITicketRepository
    {
        HelpDeskContext _context = new HelpDeskContext();        

        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            var tickets = await _context.Tickets.ToListAsync();
            tickets.ForEach(x => x = Task.Run(() => GetTicketAsync(x.Id)).Result);

            return tickets;
        }        

        public async Task<Ticket> GetTicketAsync(Guid ticketId)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == ticketId);
            await _context.Entry(ticket).Reference(u => u.AssignedTo).LoadAsync();
            await _context.Entry(ticket).Reference(u => u.RequestedBy).LoadAsync();
            await _context.Entry(ticket).Reference(s => s.Status).LoadAsync();
            await _context.Entry(ticket).Collection(i => i.TicketIssues).LoadAsync();

            ticket.TicketIssues.ForEach(ti => ti.Issue = Task.Run(() => new IssueRepository().GetIssueAsync(ti.IssueId)).Result);

            return ticket;
        }

        public Ticket CreateNewTicket()
        {
            var ticket = new Ticket
            {
                Name = "TempName",
                Status = Task.Run(() => _context.TicketStatus.FirstOrDefaultAsync(x => x.Name == "New")).Result,
                DateOpened = DateTime.Now,
                CreatedBy = Environment.UserName,                
            };
            _context.Tickets.Add(ticket);
            return ticket;
        }

        public async Task<Ticket> AddTicketAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<int> SaveTicketsAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Ticket> UpdateTicketAsync(Ticket ticket)
        {
            if (!_context.Tickets.Local.Any(x => x.Id == ticket.Id))
            {
                _context.Tickets.Attach(ticket);
            }
            _context.Entry(ticket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task DeleteTicketAsync(Guid ticketId)
        {
            var ticket = _context.Tickets.FirstOrDefault(x => x.Id == ticketId);
            if(ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }
            await _context.SaveChangesAsync();           
        }      
    }
}
