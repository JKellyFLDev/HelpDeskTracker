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
    public interface IUserRepository : IRepositoryAsync<User> { }

    public class UserRepository : IUserRepository
    {
        private readonly HelpDeskContext _context;

        public UserRepository(HelpDeskContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var value = _context.User.FirstOrDefault(x => x.Id == id);
            if (value != null)
            {
                _context.User.Remove(value);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetSingleIdAsync(Guid id)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> InsertAsync(User value)
        {
            _context.User.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<User> UpdateAsync(User value)
        {
            if (!_context.User.Local.Any(x => x.Id == value.Id))
            {
                _context.User.Attach(value);
            }
            _context.Entry(value).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return value;
        }
    }
}
