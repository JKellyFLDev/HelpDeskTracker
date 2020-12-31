using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.TrackerApp.Services;
using LeafFilter.HelpDesk.TrackerApp.Services.Interfaces;
using LeafFilter.HelpDesk.TrackerApp.Utilities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel.UserViewModel
{
    public class UserListViewModel
    {       
        private IUserRepository _repository = new UserRepository();

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set 
            { 
                _selectedUser = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand DeleteCommand { get; private set; }

        public UserListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            DeleteCommand = new RelayCommand(OnDelete, CanDelete);

            Users = new ObservableCollection<User>(Task.Run(() => _repository.GetAllUsersAsync()).Result);
        }
   
        private void OnDelete()
        {
            Users.Remove(SelectedUser);
        }

        private bool CanDelete()
        {
            return SelectedUser != null;
        }        
    }
}