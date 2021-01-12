using LeafFilter.HelpDesk.Model.Base;
using LeafFilter.HelpDesk.Model.XRef;
using System;
using System.Collections.Generic;

namespace LeafFilter.HelpDesk.Model
{
    public class User : IEntity
    {
        public User()
        {
            UserAppPermissions = new List<UserPermissionTypeXRef>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Active { get;set; }
        public List<UserPermissionTypeXRef> UserAppPermissions { get; set; }
    }
}
