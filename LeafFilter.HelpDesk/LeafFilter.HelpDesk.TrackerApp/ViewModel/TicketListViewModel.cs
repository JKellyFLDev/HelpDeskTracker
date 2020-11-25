using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.TrackerApp.Services;
using LeafFilter.HelpDesk.TrackerApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel
{
    public class TicketListViewModel
    {
        private ITicketRepository _repository = new TicketRepository();

        private ObservableCollection<Ticket> _tickets;
        public ObservableCollection<Ticket> Tickets
        {
            get { return _tickets; }
            set { _tickets = value; }
        }

        private Ticket _selectedTicket;
        public Ticket SelectedTicket
        {
            get { return _selectedTicket; }
            set
            {
                _selectedTicket = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand AddTicketCommand { get; private set; }
        public RelayCommand SaveTicketCommand { get; private set; }
        public RelayCommand DeleteCommand { get; private set; }

        public event Action<Ticket> AddTicketRequested = delegate { };

        public TicketListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            AddTicketCommand = new RelayCommand(OnAddTicket);
            SaveTicketCommand = new RelayCommand(OnSaveTickets);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);

            Tickets = new ObservableCollection<Ticket>(Task.Run(() => _repository.GetAllTicketsAsync()).Result);
        }

        
        private void OnAddTicket()
        {
            SelectedTicket = Task.Run(() => _repository.CreateNewTicketAsync()).Result;
            Tickets.Add(SelectedTicket);
        }

        private void OnSaveTickets()
        {
            var result = Task.Run(() => _repository.SaveTicketsAsync()).Result;
            return;
        }

        private void OnDelete()
        {
            Tickets.Remove(SelectedTicket);
        }

        private bool CanDelete()
        {
            return SelectedTicket != null;
        }
    }
}
