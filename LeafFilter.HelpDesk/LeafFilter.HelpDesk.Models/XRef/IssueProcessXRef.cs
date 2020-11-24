using LeafFilter.HelpDesk.Models.Records;
using System;

namespace LeafFilter.HelpDesk.Models.XRef
{
    public class IssueProcessXRef
    {        
        public int Order { get; set; }
        public Guid IssueId { get; set; }
        public Issue Issue { get; set; }
        public Guid ProcessId { get; set; }
        public Process Process { get; set; }
    }
}
