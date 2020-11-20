using LeafFilter.HelpDesk.Models.Base;
using System;

namespace LeafFilter.HelpDesk.Models.Records
{
    public class Process : RecordEntity
    {
        public string Description { get; set; }
        public string AdminPage { get; set; }
        public SqlScript Script { get; set; }
        public bool UsesScript { get; set; }
        public bool UsesAdminPage { get; set; }
    }
}
