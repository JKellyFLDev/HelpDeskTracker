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
        Task<List<User>> GetAllUsers();
        Ticket CreateNewTicket();        
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

        public Ticket CreateNewTicket()
        {
            var ticket = new Ticket
            {
                Name = "TempName",
                Status = Task.Run(() => _ticketStatusRepo.GetSingleByNameAsync("New")).Result,
                DateOpened = DateTime.Now,
                CreatedBy = Environment.UserName,
            };
            _context.Ticket.Add(ticket);
            return ticket;
        }

        public async Task<List<TicketStatus>> GetAllStatus()
        {
            return await _ticketStatusRepo.GetAllAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepo.GetAllAsync();
        }

        public async Task<List<Ticket>> LoadAllAsync()
        {
            var value = await _ticketRepo.GetAllAsync();
            value.ForEach(x => x = Task.Run(() => LoadSingleAsync(x.Id)).Result);
            return value;
        }      

        public async Task<Ticket> LoadSingleAsync(Guid id)
        {
            var value = await _ticketRepo.GetSingleByIdAsync(id);
            await _context.Entry(value).Reference(x => x.AssignedTo).LoadAsync();
            await _context.Entry(value).Reference(x => x.RequestedBy).LoadAsync();
            await _context.Entry(value).Reference(x => x.Status).LoadAsync();
            await _context.Entry(value).Collection(x => x.TicketIssues).LoadAsync();

            value.TicketIssues.ForEach(ti => ti.Issue = Task.Run(() =>  _issueRepo.GetSingleByIdAsync(ti.IssueId)).Result);

            return value;
        }
    }
}
