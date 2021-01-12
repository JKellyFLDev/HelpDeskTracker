using LeafFilter.HelpDesk.Model.Base;
using LeafFilter.HelpDesk.Model.XRef;
using System;
using System.Collections.Generic;

namespace LeafFilter.HelpDesk.Model
{
    public class Script : IEntity
    {
        public Script()
        {
            ProcessScripts = new List<ProcessScriptXRef>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public List<ProcessScriptXRef> ProcessScripts { get; set; }
    }
}