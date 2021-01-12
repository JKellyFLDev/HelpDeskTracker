using LeafFilter.HelpDesk.Model.Base;
using LeafFilter.HelpDesk.Model.XRef;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeafFilter.HelpDesk.Model
{
    public class Page : IEntity
    {
        public Page()
        {
            ProcessPages = new List<ProcessPageXRef>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Label { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public List<ProcessPageXRef> ProcessPages { get; set; }
    }
}