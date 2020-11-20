using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.Models.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace LeafFilter.HelpDesk.Data
{
    public class ConnectedData
    {
        private HelpDeskContext _context;

        public ConnectedData()
        {
            _context = new HelpDeskContext();
            _context.Database.Migrate();
        }

        public ObservableCollection<Ticket> TicketsListInMemory()
        {
            if (_context.Tickets.Local.Count == 0)
            {
                _context.Tickets.ToList();
            }
            return _context.Tickets.Local.ToObservableCollection();
        }

        public User LoadUser(Guid userId)
        {
            var user = _context.Users.Find(userId);
            return user;
        }

        public Ticket LoadTicket(Guid ticketId)
        {
            var ticket = _context.Tickets.Find(ticketId);
            _context.Entry(ticket).Reference(u => u.AssignedTo).Load();
            _context.Entry(ticket).Reference(u => u.RequestedBy).Load();
            _context.Entry(ticket).Reference(s => s.Status).Load();

            return ticket;
        }

        public TicketStatus LoadSingleStatus(string text)
        {
            var status = _context.TicketStatus.First(s => s.Name == text);
            return status;
        }

        public List<TicketStatus> LoadTickStatuses()
        {
            var statuses = _context.TicketStatus.ToList();
            return statuses;
        }

        public Ticket CreateNewTicket()
        {
            var ticket = new Ticket { Status = _context.TicketStatus.FirstOrDefault(s => s.Name == "New") };
            _context.Tickets.Add(ticket);
            return ticket;
        }

        public bool ChangesNeedToBeSaved()
        {
            return _context.ChangeTracker.Entries()
                .Any(e => e.State == EntityState.Added
                        | e.State == EntityState.Modified
                        | e.State == EntityState.Deleted);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }        
    }
}
