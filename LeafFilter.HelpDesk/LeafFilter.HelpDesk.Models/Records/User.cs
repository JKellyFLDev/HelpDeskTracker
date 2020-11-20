using LeafFilter.HelpDesk.Models.Base;

namespace LeafFilter.HelpDesk.Models.Records
{
    public class User : RecordEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
