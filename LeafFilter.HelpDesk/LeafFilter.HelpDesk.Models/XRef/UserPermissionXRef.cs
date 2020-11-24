using LeafFilter.HelpDesk.Models.Types;
using LeafFilter.HelpDesk.Models.Records;
using System;

namespace LeafFilter.HelpDesk.Models.XRef
{
    public class UserPermissionXRef
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }        
    }
}
