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
        private ObservableCollection<HelpDeskItem> _detailViews;
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

        public ObservableCollection<HelpDeskItem> DetailViews
        {
            get { return _detailViews; }
            set
            {
                _detailViews = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DetailViews)));
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
        //public RelayCommand TicketChangeCommand { get; private set; }

        public event Action<Ticket> AddTicketRequested = delegate { };

        public TicketListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;

            AddTicketCommand = new RelayCommand(OnAddTicket);
            SaveTicketCommand = new RelayCommand(OnSaveTickets);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            //TicketChangeCommand = new RelayCommand(OnTicketChange);            

            Tickets = new ObservableCollection<Ticket>(Task.Run(() => _repository.GetAllTicketsAsync()).Result);            
        }

        //private void OnTicketChange()
        //{
        //    DetailView =
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        //private void GenerateDetailViews()
        //{
        //    DetailViews = new ObservableCollection<HelpDeskItem>();
        //    if (Tickets != null)
        //        foreach (var v in Tickets)
        //            DetailViews.Add(new HelpDeskItem("", new TicketDetailViewModel(v)));
        //}

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
