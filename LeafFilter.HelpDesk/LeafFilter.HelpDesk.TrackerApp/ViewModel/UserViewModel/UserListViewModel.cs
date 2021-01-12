using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Model;
using LeafFilter.HelpDesk.Repository;
using LeafFilter.HelpDesk.Service;
using LeafFilter.HelpDesk.TrackerApp.Utilities;
using LeafFilter.HelpDesk.TrackerApp.View.UserView;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel.UserViewModel
{
    public class UserListViewModel : INotifyPropertyChanged
    {               
        private IUserService _userService;

        private ObservableCollection<User> _users;
        private User _selectedUser;
        private HelpDeskItem _selectedDetailView;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        
        public User SelectedUser
        {
            get { return _selectedUser; }
            set 
            { 
                _selectedUser = value;
                SelectedDetailView = new HelpDeskItem("", new UserDetailView() { DataContext = new UserDetailViewModel() { SelectedUser = SelectedUser } });
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedUser)));
            }
        }

        public HelpDeskItem SelectedDetailView
        {
            get { return _selectedDetailView; }
            set
            {
                _selectedDetailView = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedDetailView)));
            }
        }

        public RelayCommand AddUserCommand { get; private set; }
        public RelayCommand SaveUserCommand { get; private set; }
        public RelayCommand DeleteUserCommand { get; private set; }

        public UserListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;
            
            AddUserCommand = new RelayCommand(OnAddUser);
            DeleteUserCommand = new RelayCommand(OnDelete, CanDelete);
            SaveUserCommand = new RelayCommand(OnSaveUsers);

            HelpDeskContext context = new HelpDeskContext();
            _userService = new UserService(new UserRepository(context), context);

            Users = new ObservableCollection<User>(Task.Run(() => _userService.LoadAllAsync()).Result);
            SelectedUser = Users[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void OnAddUser()
        {
            SelectedUser = Task.Run(() => _userService.CreateNewUser()).Result;
            Task.Run(() => _userService.InsertAsync(SelectedUser));
            Users.Add(SelectedUser);
        }

        private void OnSaveUsers()
        {
            var result = Task.Run(() => _userService.UpdateAsync(SelectedUser)).Result;
            return;
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