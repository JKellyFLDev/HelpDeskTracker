﻿using LeafFilter.HelpDesk.Model.Base;
using LeafFilter.HelpDesk.Model.XRef;
using LeafFilter.HelpDesk.Model.Conditions;
using System;
using System.Collections.Generic;

namespace LeafFilter.HelpDesk.Model
{
    public class Ticket : IEntity
    {
        public Ticket()
        {
            TicketIssues = new List<TicketIssueXRef>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public User RequestedBy { get; set; }
        public User AssignedTo { get; set; }    
        public DateTime? DateOpened { get; set; }
        public DateTime? DateResolved { get; set; }        
        public TicketStatus Status { get; set; }
        public string Company { get; set; }  
        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public List<TicketIssueXRef> TicketIssues { get; set; }
    }
}