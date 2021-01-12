using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Model.Conditions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.Repository
{
    public interface ISeverityTypeRepository : IRepositoryAsync<SeverityType> { }

    public class SeverityTypeRepository : ISeverityTypeRepository
    {
        private readonly HelpDeskContext _context;

        public SeverityTypeRepository(HelpDeskContext context)
        {
            _context = context;
        }

        #region Async Methods
        public async Task DeleteByIdAsync(Guid id)
        {
            var value = _context.SeverityType.FirstOrDefault(x => x.Id == id);
            if (value != null)
            {
                _context.SeverityType.Remove(value);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<SeverityType>> GetAllAsync()
        {
            return await _context.SeverityType.ToListAsync();
        }                

        public async Task<SeverityType> GetSingleByIdAsync(Guid id)
        {
            return await _context.SeverityType.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SeverityType> InsertAsync(SeverityType value)
        {
            _context.SeverityType.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }       

        public async Task<SeverityType> UpdateAsync(SeverityType value)
        {
            if (!_context.SeverityType.Local.Any(x => x.Id == value.Id))
            {
                _context.SeverityType.Attach(value);
            }
            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return value;
        }
        #endregion
    }
}
