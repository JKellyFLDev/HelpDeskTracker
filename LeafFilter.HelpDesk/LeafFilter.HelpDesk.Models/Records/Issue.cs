using LeafFilter.HelpDesk.Models.Base;
using LeafFilter.HelpDesk.Models.JoinTables;
using LeafFilter.HelpDesk.Models.Types;
using System.Collections.Generic;

namespace LeafFilter.HelpDesk.Models.Records
{
    public class Issue : TypeEntity
    {                
        public Issue()
        {
            TicketIssues = new List<TicketIssue>();
        }

        public Process Process { get; set; }
        public IssueSeverity IssueSeverity { get; set; }
        public List<TicketIssue> TicketIssues { get; set; }
    }
}
