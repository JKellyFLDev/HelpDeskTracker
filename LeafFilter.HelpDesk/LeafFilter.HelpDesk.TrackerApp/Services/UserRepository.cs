using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.TrackerApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.Services
{
    public class UserRepository : IUserRepository
    {
        HelpDeskContext _context = new HelpDeskContext();

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Id == userId);
        }
        
        public async Task<User> AddUserAsync(User user)
        {
            if (!_context.Users.Local.Contains(user))
            {
                _context.Users.Add(user);
            }
            await _context.SaveChangesAsync();
            return user;
        }
        public User CreateNewUser()
        {
            var user = new User
            {
                FirstName = "Temp First Name",
                LastName = "Temp Last Name",
                UserName = "Temp User Name",
                CreatedBy = Environment.UserName,
            };
            _context.Users.Add(user);
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            if (!_context.Users.Local.Any(u => u.Id == user.Id))
            {
                _context.Users.Attach(user);
            }
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            await _context.SaveChangesAsync();
        }
    }
}
