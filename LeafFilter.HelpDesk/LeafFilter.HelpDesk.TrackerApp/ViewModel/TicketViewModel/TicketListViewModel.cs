using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Model;
using LeafFilter.HelpDesk.Repository;
using LeafFilter.HelpDesk.Service;
//using LeafFilter.HelpDesk.TrackerApp.Services;
//using LeafFilter.HelpDesk.TrackerApp.Services.Interfaces;
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
    public class TicketListViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private readonly ITicketService _ticketService;

        //private ITicketRepository _repository = new TicketRepository();
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
            // TODO: Use dependency injection to remove instances of HelpDeskContext
            HelpDeskContext context = new HelpDeskContext();
            _ticketService = new TicketService(new TicketRepository(context), new IssueRepository(context), new TicketStatusRepository(context), new UserRepository(context), context);

            if (DesignerProperties.GetIsInDesignMode(
               new System.Windows.DependencyObject())) return;

            AddTicketCommand = new RelayCommand(OnAddTicket);
            SaveTicketCommand = new RelayCommand(OnSaveTickets);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);

            

            //Tickets = new ObservableCollection<Ticket>(Task.Run(() => _repository.GetAllTicketsAsync()).Result);
            Tickets = new ObservableCollection<Ticket>(Task.Run(() => _ticketService.LoadAllAsync()).Result);
            SelectedTicket = Tickets[0];
        }
 

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnAddTicket()
        {
            SelectedTicket = _ticketService.CreateNewTicket();
            Tickets.Add(SelectedTicket);           
        }

        private void OnSaveTickets()
        {
            var result = Task.Run(() => _ticketService.SaveAsync()).Result;
            return;
        }

        private void OnDelete()
        {            
            _ticketService.DeleteByIdAsync(SelectedTicket.Id);
        }

        private bool CanDelete()
        {
            return SelectedTicket != null;
        }
    }
}
