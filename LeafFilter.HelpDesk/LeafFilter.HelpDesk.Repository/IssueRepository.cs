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
    public interface IIssueRepository : IRepositoryAsync<Issue> { }

    public class IssueRepository : IIssueRepository
    {
        private readonly HelpDeskContext _context;

        public IssueRepository(HelpDeskContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var value = _context.Issue.FirstOrDefault(x => x.Id == id);
            if (value != null)
            {
                _context.Issue.Remove(value);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Issue>> GetAllAsync()
        {
            return await _context.Issue.ToListAsync();
        }

        public async Task<Issue> GetSingleByIdAsync(Guid id)
        {
            return await _context.Issue.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Issue> InsertAsync(Issue value)
        {
            _context.Issue.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<Issue> UpdateAsync(Issue value)
        {
            if (!_context.Issue.Local.Any(x => x.Id == value.Id))
            {
                _context.Issue.Attach(value);
            }
            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return value;
        }
    }
}
