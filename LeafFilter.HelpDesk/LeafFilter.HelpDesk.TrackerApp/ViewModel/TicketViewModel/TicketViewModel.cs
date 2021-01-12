using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Model;
using LeafFilter.HelpDesk.Repository;
using LeafFilter.HelpDesk.Service;
using LeafFilter.HelpDesk.TrackerApp.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel.TicketViewModel
{
    public class TicketViewModel : INotifyPropertyChanged
    {
        private readonly ITicketService _ticketService;
        private ObservableCollection<Ticket> _tickets;
        private Ticket _selectedTicket;
        private HelpDeskItem _selectedDetailView;

        public event PropertyChangedEventHandler PropertyChanged;

        public TicketViewModel()
        {
            // TODO: Use dependency injection to remove instances of HelpDeskContext
            HelpDeskContext context = new HelpDeskContext();
            _ticketService = new TicketService(new TicketRepository(context), new IssueRepository(context), new TicketStatusRepository(context), new UserRepository(context), context);
        }
    }
}
