using LeafFilter.HelpDesk.Models.Interfaces;
using LeafFilter.HelpDesk.Models.XRef;
using System;
using System.Collections.Generic;

namespace LeafFilter.HelpDesk.Models.Records
{
    public class Process : IEntity
    {
        public Process()
        {
            IssueProcesses = new List<IssueProcessXRef>();
            ProcessScripts = new List<ProcessScriptXRef>();
            ProcessPages = new List<ProcessPageXRef>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool UsesScript { get; set; }
        public bool UsesAdminPage { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public List<IssueProcessXRef> IssueProcesses { get; set; }
        public List<ProcessScriptXRef> ProcessScripts { get; set; }
        public List<ProcessPageXRef> ProcessPages { get; set; }
    }
}