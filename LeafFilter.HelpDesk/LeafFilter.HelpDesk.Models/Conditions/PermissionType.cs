using LeafFilter.HelpDesk.Model.Base;
using LeafFilter.HelpDesk.Model.XRef;
using System;
using System.Collections.Generic;

namespace LeafFilter.HelpDesk.Model.Conditions
{
    public class PermissionType : ITypeEntity
    {
        public PermissionType()
        {
            UserPermissions = new List<UserPermissionTypeXRef>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Active { get; set; }
        public List<UserPermissionTypeXRef> UserPermissions { get; set; }
    }
}
