using LeafFilter.HelpDesk.Models.Interfaces;
using LeafFilter.HelpDesk.Models.XRef;
using System;
using System.Collections.Generic;

namespace LeafFilter.HelpDesk.Models.Types
{
    public class AppPermission : ITypeEntity
    {
        public AppPermission()
        {
            UserAppPermissions = new List<UserAppPermissionXRef>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Active { get; set; }
        public List<UserAppPermissionXRef> UserAppPermissions { get; set; }
    }
}
