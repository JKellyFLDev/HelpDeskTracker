using LeafFilter.HelpDesk.Models.Records;
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

            return ticket;
        }
    }
}
