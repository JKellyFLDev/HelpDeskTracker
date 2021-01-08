using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.TrackerApp.Services;
using LeafFilter.HelpDesk.TrackerApp.Services.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel.UserViewModel
{
    public class UserDetailViewModel : INotifyPropertyChanged
    {
        private IUserRepository _userRepository = new UserRepository();
        private User _selectedUser;
        public List<User> Users { get; set; }

        public UserDetailViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
               new System.Windows.DependencyObject())) return;

            Users = Task.Run(() => _userRepository.GetAllUsersAsync()).Result;
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;

                if (value.FirstName != null)
                {
                    SelectedUser.FirstName = value.FirstName;   
                }
                if (value.LastName != null)
                {
                    SelectedUser.LastName = value.LastName;                
                }
                if (value.UserName != null)
                {
                    SelectedUser.UserName = value.UserName;  
                }
                if (value.Email != null)
                {
                    SelectedUser.Email = value.Email;
                }
                if (value.Active)
                {
                    SelectedUser.Active = true;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedUser)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
