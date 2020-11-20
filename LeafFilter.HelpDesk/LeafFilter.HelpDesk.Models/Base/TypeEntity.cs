﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeafFilter.HelpDesk.Models.Base
{
    public class TypeEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }        
        public DateTime? ModifiedDate { get; set; }        
        public string ModifiedBy { get; set; }     
    }
}
