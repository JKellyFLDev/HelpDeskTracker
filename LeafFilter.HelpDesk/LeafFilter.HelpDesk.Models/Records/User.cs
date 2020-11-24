using LeafFilter.HelpDesk.Models.Interfaces;
using LeafFilter.HelpDesk.Models.XRef;
using System;
using System.Collections.Generic;

namespace LeafFilter.HelpDesk.Models.Records
{
    public class User : IEntity
    {
        public User()
        {
            UserAppPermissions = new List<UserAppPermissionXRef>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool Active { get;set; }
        public List<UserAppPermissionXRef> UserAppPermissions { get; set; }
    }
}
