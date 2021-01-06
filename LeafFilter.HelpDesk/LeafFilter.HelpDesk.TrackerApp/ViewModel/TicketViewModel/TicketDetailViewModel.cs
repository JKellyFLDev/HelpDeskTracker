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

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel.TicketViewModel
{
    public class TicketDetailViewModel : INotifyPropertyChanged
    {
        private ITicketRepository _repository = new TicketRepository();
        private IUserRepository _userRepository = new UserRepository();
        private Ticket _selectedTicket;
        private List<Issue> _ticketIssues;
        //private User _selectedUser;
        private int _selectedIndexRequested;
        private int _selectedIndexAssigned;
        private int _progress;

        public List<User> Users { get; set; }

        public TicketDetailViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
               new System.Windows.DependencyObject())) return;

            Users = Task.Run(() => _userRepository.GetAllUsersAsync()).Result;
        }

        public List<Issue> TicketIssues
        {
            get => _ticketIssues;
            set
            {
                _ticketIssues = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TicketIssues)));
            }
        }

        public Ticket SelectedTicket
        {
            get => _selectedTicket;
            set
            {
                _selectedTicket = value;

                if (value.Status != null)
                {
                    Progress = value.Status.Order;
                }
                if (value.TicketIssues != null)
                {
                    TicketIssues = value.TicketIssues.Select(x => x.Issue).ToList();
                }
                if (value.RequestedBy != null)
                {
                    SelectedIndexRequested = Users.FindIndex(x => x.Id.Equals(value.RequestedBy.Id));                    
                }
                if (value.AssignedTo != null)
                {
                    SelectedIndexAssigned = Users.FindIndex(x => x.Id.Equals(value.AssignedTo.Id));
                }

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTicket)));
            }
        }

        //public User SelectedUser
        //{
        //    get => _selectedUser;
        //    set
        //    {
        //        _selectedUser = value;
        //        if(SelectedTicket != null)
        //            SelectedTicket.RequestedBy = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedUser)));
        //    }
        //}

        public int SelectedIndexAssigned
        {
            get => _selectedIndexAssigned;
            set
            {
                _selectedIndexAssigned = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedIndexAssigned)));
            }
        }

        public int SelectedIndexRequested
        {
            get => _selectedIndexRequested;
            set
            {
                _selectedIndexRequested = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedIndexRequested)));
            }
        }

        public int Progress
        {
            get => _progress;
            set => _progress = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
