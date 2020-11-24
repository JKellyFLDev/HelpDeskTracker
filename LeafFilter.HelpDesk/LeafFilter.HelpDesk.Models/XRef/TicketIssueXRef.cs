using LeafFilter.HelpDesk.Models.Records;
using System;

namespace LeafFilter.HelpDesk.Models.XRef
{
    public class TicketIssueXRef
    {               
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public Guid IssueId { get; set; }
        public Issue Issue { get; set; }
    }
}
