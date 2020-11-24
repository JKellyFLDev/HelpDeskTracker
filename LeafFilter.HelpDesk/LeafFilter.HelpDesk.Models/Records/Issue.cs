using LeafFilter.HelpDesk.Models.Interfaces;
using LeafFilter.HelpDesk.Models.Types;
using LeafFilter.HelpDesk.Models.XRef;
using System;
using System.Collections.Generic;

namespace LeafFilter.HelpDesk.Models.Records
{
    public class Issue : IEntity
    {                
        public Issue()
        {
            TicketIssues = new List<TicketIssueXRef>();
            IssueProcesses = new List<IssueProcessXRef>();
        }

        public Guid Id { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
        public IssueSeverity IssueSeverity { get; set; }        
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public List<TicketIssueXRef> TicketIssues { get; set; }
        public List<IssueProcessXRef> IssueProcesses { get; set; }
    }
}