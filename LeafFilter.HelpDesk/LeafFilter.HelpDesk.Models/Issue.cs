using LeafFilter.HelpDesk.Model.Base;
using LeafFilter.HelpDesk.Model.Conditions;
using LeafFilter.HelpDesk.Model.XRef;
using System;
using System.Collections.Generic;

namespace LeafFilter.HelpDesk.Model
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
        public SeverityType SeverityType { get; set; }        
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public List<TicketIssueXRef> TicketIssues { get; set; }
        public List<IssueProcessXRef> IssueProcesses { get; set; }
    }
}