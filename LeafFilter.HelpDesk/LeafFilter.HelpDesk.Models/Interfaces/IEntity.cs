using System;

namespace LeafFilter.HelpDesk.Models.Interfaces
{
    public interface IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }  
}