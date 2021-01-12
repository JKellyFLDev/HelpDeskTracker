using LeafFilter.HelpDesk.Model.Base;
using System;

namespace LeafFilter.HelpDesk.Model.Conditions
{
    public class SeverityType : ITypeEntity 
    {
        public Guid Id { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Active { get; set; }
    }
}