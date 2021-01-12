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
    public interface IIssueService : IIssueRepository, IServiceAsync<Issue>
    {
        Task<List<SeverityType>> GetAllSeverity();
    }

    public class IssueService : IssueRepository, IIssueService
    {

        private readonly IIssueRepository _issueRepo;
        private readonly ISeverityTypeRepository _severityTypeRepo;
        private readonly HelpDeskContext _context;

        public IssueService(IIssueRepository issueRepo, ISeverityTypeRepository severityTypeRepo, HelpDeskContext context) : base(context)
        {
            _issueRepo = issueRepo;
            _severityTypeRepo = severityTypeRepo;
            _context = context;
        }

        public async Task<List<SeverityType>> GetAllSeverity()
        {           
            return await _severityTypeRepo.GetAllAsync();
        }

        public async Task<List<Issue>> LoadAllAsync()
        {
            var values = await _issueRepo.GetAllAsync();
            values.ForEach(async x => await _context.Entry(x).Reference(x => x.SeverityType).LoadAsync());

            return values;
        }

        public async Task<Issue> LoadSingleAsync(Guid id)
        {
            var value = await _issueRepo.GetSingleIdAsync(id);
            await _context.Entry(value).Reference(x => x.SeverityType).LoadAsync();

            return value;
        }     
    }
}