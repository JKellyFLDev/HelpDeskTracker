using LeafFilter.HelpDesk.Models.Records;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.Services.Interfaces
{
    public interface IIssueRepository : IRepository
    {
        Task<List<Issue>> GetAllIssuesAsync();
        Task<Issue> GetIssueAsync(Guid issueId);
        Task<Issue> AddIssueAsync(Issue issue);
        Task<Issue> UpdateIssueAsync(Issue issue);
        Task DeleteIssueAsync(Guid issueId);
    }
}
