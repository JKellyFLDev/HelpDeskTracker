using LeafFilter.HelpDesk.Models.Interfaces;
using System;

namespace LeafFilter.HelpDesk.Models.Types
{
    public class TicketStatus : ITypeEntity
    {       
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Active { get; set; }
    }
}
