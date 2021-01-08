using LeafFilter.HelpDesk.Models.Records;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.Services.Interfaces
{
    public interface IUserRepository : IRepository
    {
        Task<List<User>> GetAllUsersAsync();
        User CreateNewUser();
        Task<User> GetUserAsync(Guid userId);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid userId);
    }
}
