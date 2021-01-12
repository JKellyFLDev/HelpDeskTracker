using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Model;
using LeafFilter.HelpDesk.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.Service
{
    public interface IUserService : IUserRepository, IServiceAsync<User>
    {
        User CreateNewUser();
    }

    public class UserService : UserRepository, IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly HelpDeskContext _context;

        public UserService(IUserRepository userRepo, HelpDeskContext context) : base(context)
        {
            _userRepo = userRepo;
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
            _context.User.Add(user);
            return user;
        }

        public async Task<List<User>> LoadAllAsync()
        {
            return await _userRepo.GetAllAsync();
        }

        public async Task<User> LoadSingleAsync(Guid id)
        {
            return await _userRepo.GetSingleByIdAsync(id);
        }
    }
}
