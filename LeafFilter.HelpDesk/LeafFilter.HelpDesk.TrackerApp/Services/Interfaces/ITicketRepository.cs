using LeafFilter.HelpDesk.Models.Records;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.Services.Interfaces
{
    public interface ITicketRepository : IRepository
    {
        Task<List<Ticket>> GetAllTicketsAsync();
        Task<Ticket> GetTicketAsync(Guid ticketId);
        Task<Ticket> CreateNewTicketAsync();
        Task<Ticket> AddTicketAsync(Ticket ticket);
        Task<Ticket> UpdateTicketAsync(Ticket ticket);
        Task<int> SaveTicketsAsync();
        Task DeleteTicketAsync(Guid ticketId);
    }
}
