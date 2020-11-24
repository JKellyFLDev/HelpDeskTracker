using LeafFilter.HelpDesk.Models.Types;
using LeafFilter.HelpDesk.Models.Records;
using System;

namespace LeafFilter.HelpDesk.Models.XRef
{
    public class UserAppPermissionXRef
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid AppPermissionId { get; set; }
        public AppPermission AppPermission { get; set; }        
    }
}
