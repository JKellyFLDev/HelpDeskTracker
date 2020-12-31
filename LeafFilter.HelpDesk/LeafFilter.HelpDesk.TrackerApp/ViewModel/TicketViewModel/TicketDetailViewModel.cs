using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.TrackerApp.Services;
using LeafFilter.HelpDesk.TrackerApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeafFilter.HelpDesk.TrackerApp.ViewModel.TicketViewModel
{
    public class TicketDetailViewModel
    {
        private ITicketRepository _repository = new TicketRepository();
        private Ticket _selectedTicket;        
        
        public Ticket SelectedTicket
        {
            get => _selectedTicket;
            set { _selectedTicket = value; }
        }
    }
}
