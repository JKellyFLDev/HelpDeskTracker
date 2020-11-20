using System;

namespace LeafFilter.HelpDesk.Models.Base
{
    public class TypeEntity : IEntity
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public String CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public String ModifiedBy { get; set; }     
    }
}
