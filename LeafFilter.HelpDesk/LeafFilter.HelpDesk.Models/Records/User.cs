using LeafFilter.HelpDesk.Models.Base;
using System;

namespace LeafFilter.HelpDesk.Models.Records
{
    public class User : RecordEntity
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
    }
}
