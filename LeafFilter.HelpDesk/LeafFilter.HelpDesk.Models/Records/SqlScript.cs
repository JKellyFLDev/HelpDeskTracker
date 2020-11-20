using LeafFilter.HelpDesk.Models.Base;
using System;

namespace LeafFilter.HelpDesk.Models.Records
{

    public class SqlScript : RecordEntity
    {
        public String Header { get; set; }
        public String Body { get; set; }
    }
}
