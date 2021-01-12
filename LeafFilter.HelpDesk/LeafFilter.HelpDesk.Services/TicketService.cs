using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Model;
using LeafFilter.HelpDesk.Model.Conditions;
using LeafFilter.HelpDesk.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.Service
{
    public interface ITicketService : ITicketRepository, IServiceAsync<Ticket>
    {
        Task<List<TicketStatus>> GetAllStatus();
    }

    public class TicketService : TicketRepository, ITicketService
    {
        private readonly ITicketRepository _ticketRepo;
        private readonly IIssueRepository _issueRepo;
        private readonly ITicketStatusRepository _ticketStatusRepo;
        private readonly IUserRepository _userRepo;
        private readonly HelpDeskContext _context;

        public TicketService(ITicketRepository ticketRepo, IIssueRepository issueRepo, ITicketStatusRepository ticketStatusRepo, IUserRepository userRepo, HelpDeskContext context) : base(context)
        {
            _ticketRepo = ticketRepo;
            _issueRepo = issueRepo;
            _ticketStatusRepo = ticketStatusRepo;
            _userRepo = userRepo;
            _context = context;
        }

        public TicketService(HelpDeskContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<TicketStatus>> GetAllStatus()
        {
            return await _ticketStatusRepo.GetAllAsync();
        }

        public async Task<List<Ticket>> LoadAllAsync()
        {
            var value = await _ticketRepo.GetAllAsync();
            value.ForEach(async x => await LoadSingleAsync(x.Id));
            return value;
        }

        public async Task<Ticket> LoadSingleAsync(Guid id)
        {
            var value = await _ticketRepo.GetSingleIdAsync(id);
            await _context.Entry(value).Reference(x => x.AssignedTo).LoadAsync();
            await _context.Entry(value).Reference(x => x.RequestedBy).LoadAsync();
            await _context.Entry(value).Reference(x => x.Status).LoadAsync();
            await _context.Entry(value).Collection(x => x.TicketIssues).LoadAsync();

            value.TicketIssues.ForEach(async ti => ti.Issue = await _issueRepo.GetSingleIdAsync(ti.IssueId));

            return value;
        }
    }
}
