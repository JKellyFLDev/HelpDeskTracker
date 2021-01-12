using LeafFilter.HelpDesk.Model.Conditions;
using System;

namespace LeafFilter.HelpDesk.Model.XRef
{
    public class UserPermissionTypeXRef
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid AppPermissionId { get; set; }
        public PermissionType AppPermission { get; set; }        
    }
}
