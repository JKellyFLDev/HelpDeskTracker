using LeafFilter.HelpDesk.Models.Base;
using LeafFilter.HelpDesk.Models.JoinTables;
using LeafFilter.HelpDesk.Models.Types;

namespace LeafFilter.HelpDesk.Models.Records
{
    public class Issue : RecordEntity
    {        
        public Process Process { get; set; }
        public IssueSeverity IssueSeverity { get; set; } 
        public TicketIssue TicketIssue { get; set; }        
    }
}
