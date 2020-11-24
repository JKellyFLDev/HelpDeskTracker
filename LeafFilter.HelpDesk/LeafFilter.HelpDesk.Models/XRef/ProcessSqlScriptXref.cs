using LeafFilter.HelpDesk.Models.Records;
using System;

namespace LeafFilter.HelpDesk.Models.XRef
{
    public class ProcessScriptXRef
    {
        public Guid ProcessId { get; set; }
        public Process Process { get; set; }
        public Guid ScriptId { get; set; }
        public Script Script { get; set; }
    }
}
