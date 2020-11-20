using LeafFilter.HelpDesk.Models.Base;
using System;

namespace LeafFilter.HelpDesk.Models.Records
{
    public class Process : RecordEntity
    {
        public String Description { get; set; }
        public String AdminPage { get; set; }
        public SqlScript Script { get; set; }
        public Boolean UsesScript { get; set; }
        public Boolean UsesAdminPage { get; set; }
    }
}
