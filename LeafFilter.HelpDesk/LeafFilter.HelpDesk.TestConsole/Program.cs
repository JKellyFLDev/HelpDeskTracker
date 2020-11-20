using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeafFilter.HelpDesk.TestConsole
{
    public class Program
    {
        private static readonly HelpDeskContext _context = new HelpDeskContext();        

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Help Desk Tracking!");

            if (_context.TicketStatus.FirstOrDefault() == null)
                CreateTicketStatuses();

            if (_context.IssueSeverity.FirstOrDefault() == null)
                CreateIssueSeverities();

            InsertNewTicket();
        }

        private static void InsertNewTicket()
        {
            var ticket = new Ticket
            {

                RequestedBy = new User
                {
                    FirstName = "Glenn",
                    LastName = "Weber",
                    Email = "gweber@leaffilter.com",
                    UserName = "gweber"
                },
                AssignedTo = new User
                {
                    FirstName = "James",
                    LastName = "Kelly",
                    Email = "jkelly@leaffilter.com",
                    UserName = "jkelly"                    
                },
                Status = _context.TicketStatus.Where(s => s.Name == "New").FirstOrDefault()               
            };
            _context.Add(ticket);
            _context.SaveChanges();
        }

        private static void CreateTicketStatuses()
        {
            var ticketStatuses = new List<TicketStatus>()
            {
                new TicketStatus { Name = "New",            CreatedBy = "jkelly"},
                new TicketStatus { Name = "Pending",        CreatedBy = "jkelly"},
                new TicketStatus { Name = "In-Progress",    CreatedBy = "jkelly"},
                new TicketStatus { Name = "Done",           CreatedBy = "jkelly"},
                new TicketStatus { Name = "Canceled",       CreatedBy = "jkelly"}
            };
            _context.AddRange(ticketStatuses);
            _context.SaveChanges();
        }

        private static void CreateIssueSeverities()
        {
            var issueSeverities = new List<IssueSeverity>()
            {
                new IssueSeverity
                {
                    Level = "S1",
                    Name = "Emergency",
                    Description = "The issue is prevent all or most Users from using Platform",                    
                    CreatedBy = "jkelly"
                },
                new IssueSeverity
                {
                    Level = "S2",
                    Name = "Critical",
                    Description = "The System is adversely impacted.",                    
                    CreatedBy = "jkelly"
                },
                new IssueSeverity {
                    Level = "S3",
                    Name = "Major",
                    Description = "The system experienced an error, short-term workaround available.",                    
                    CreatedBy = "jkelly"
                },
                new IssueSeverity
                {
                    Level = "S4",
                    Name = "Minor",
                    Description = "Issue and requests without significant impact on system.",                    
                    CreatedBy = "jkelly"
                },
                new IssueSeverity
                {
                    Level = "S5",
                    Name = "Trivial",
                    Description = "A condition might warrant action.",                    
                    CreatedBy = "jkelly"}
            };
            _context.AddRange(issueSeverities);
            _context.SaveChanges();
        }
    }
}
