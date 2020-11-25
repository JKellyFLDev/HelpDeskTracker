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

        public ObservableCollection<Ticket> Tickets { get; set; }

        public TicketListViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject())) return;
            Tickets = new ObservableCollection<Ticket>(Task.Run(() => _repository.GetAllTicketsAsync()).Result);
        }
    }
}
