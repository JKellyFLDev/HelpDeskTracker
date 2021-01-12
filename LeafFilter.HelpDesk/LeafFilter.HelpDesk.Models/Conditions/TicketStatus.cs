using LeafFilter.HelpDesk.Model.Base;
using System;

namespace LeafFilter.HelpDesk.Model.Conditions
{
    public class TicketStatus : IStatusEntity
    {       
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }        
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
