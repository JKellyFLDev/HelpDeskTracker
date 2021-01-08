using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.Models.Types;
using LeafFilter.HelpDesk.TrackerApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.Services
{
    public class IssueRepository : IIssueRepository
    {
        HelpDeskContext _context = new HelpDeskContext();

        public async Task<List<Issue>> GetAllIssuesAsync()
        {
            var issues = await _context.Issues.ToListAsync();
            issues.ForEach(x => x = Task.Run(() => GetIssueAsync(x.Id)).Result);
            

            return issues;
        }
        public async Task<List<IssueSeverity>> GetAllSeveritiesAsync()
        {
            return await _context.IssueSeverity.ToListAsync();
        }
        public async Task<Issue> GetIssueAsync(Guid issueId)
        {
            var issue = await _context.Issues.FirstOrDefaultAsync(x => x.Id == issueId);
            await _context.Entry(issue).Reference(u => u.IssueSeverity).LoadAsync();

            return issue;
        }

        public async Task<Issue> AddIssueAsync(Issue issue)
        {
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
            return issue;
        }

        public async Task<Issue> UpdateIssueAsync(Issue issue)
        {
            if (!_context.Issues.Local.Any(x => x.Id == issue.Id))
            {
                _context.Issues.Attach(issue);
            }
            _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return issue;
        }

        public async Task DeleteIssueAsync(Guid issueId)
        {
            var issue = _context.Issues.FirstOrDefault(x => x.Id == issueId);
            if (issue != null)
            {
                _context.Issues.Remove(issue);
            }
            await _context.SaveChangesAsync();
        }


    }
}
