using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.TrackerApp.Services;
using LeafFilter.HelpDesk.TrackerApp.Services.Interfaces;
using LeafFilter.HelpDesk.TrackerApp.Utilities;
using LeafFilter.HelpDesk.TrackerApp.View.TicketView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel.TicketViewModel
{
    public class TicketListViewModel : INotifyPropertyChanged
    {
        private ITicketRepository _repository = new TicketRepository();
        private ObservableCollection<Ticket> _tickets;
        private Ticket _selectedTicket;        
        private HelpDeskItem _selectedDetailView;

        public ObservableCollection<Ticket> Tickets
        {
            get { return _tickets; }
            set { _tickets = value; }
        }

        public Ticket SelectedTicket
        {
            get { return _selectedTicket; }
            set
            {
                _selectedTicket = value;                
                SelectedDetailView = new HelpDeskItem("", new TicketDetailView() { DataContext = new TicketDetailViewModel() { SelectedTicket = SelectedTicket } });
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedTicket)));
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
            SelectedTicket = Tickets[0];
        }
 

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnAddTicket()
        {
            SelectedTicket = _repository.CreateNewTicket();
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
