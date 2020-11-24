using LeafFilter.HelpDesk.Models.Records;
using System;

namespace LeafFilter.HelpDesk.Models.XRef
{
    public class ProcessPageXRef
    {
        public Guid ProcessId { get; set; }
        public Process Process { get; set; }
        public Guid PageId { get; set; }
        public Page Page { get; set; }
    }
}
