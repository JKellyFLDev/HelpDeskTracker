using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.TrackerApp.Services;
using LeafFilter.HelpDesk.TrackerApp.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel
{
    public class UserListViewModel
    {
        private IUserRepository _repository = new UserRepository();

        public ObservableCollection<User> Users { get; set; }

        public UserListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;
            Users = new ObservableCollection<User>(Task.Run(() => _repository.GetAllUsersAsync()).Result);
        }
    }
}