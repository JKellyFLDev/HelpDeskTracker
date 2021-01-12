using System;

namespace LeafFilter.HelpDesk.Model.XRef
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
