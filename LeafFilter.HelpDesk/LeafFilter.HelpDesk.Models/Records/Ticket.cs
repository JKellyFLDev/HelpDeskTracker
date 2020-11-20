using LeafFilter.HelpDesk.Models.Base;
using LeafFilter.HelpDesk.Models.JoinTables;
using LeafFilter.HelpDesk.Models.Types;
using System;

namespace LeafFilter.HelpDesk.Models.Records
{
    public class Ticket : RecordEntity
    {
        public int TicketNumber { get; set; }
        public TicketIssue TicketIssue { get; set; }
        public User RequestedBy { get; set; }
        public User AssignedTo { get; set; }
        public DateTime DateOpen { get; set; }
        public DateTime DateClosed { get; set; }
        public TicketStatus Status { get; set; }
        public String Company { get; set; }
    }
}
