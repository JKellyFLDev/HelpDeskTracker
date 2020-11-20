using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Models.JoinTables;
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

            if (_context.Issues.FirstOrDefault() == null)
                CreateMultipleIssues();

            if (_context.Tickets.FirstOrDefault() == null)
                InsertMultipleTickets();            

            if (_context.Tickets.FirstOrDefault().TicketIssues.Count == 0)
                AddIssuesToTickets();
        }

        private static void InsertMultipleTickets()
        {
            var tickets = new List<Ticket>()
            {
                new Ticket {
                    Name = "Ticket-ACD-s11",
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
                    Status = _context.TicketStatus.FirstOrDefault(s => s.Name == "New")
                },
                new Ticket {
                    Name = "Ticket-AB-s11",
                    RequestedBy = new User
                    {
                        FirstName = "John",
                        LastName = "Smith"
                    },
                    AssignedTo = new User
                    {
                        FirstName = "Mike",
                        LastName = "Baker"
                    },
                    Status = _context.TicketStatus.FirstOrDefault(s => s.Name == "Pending")
                },
                new Ticket {
                    Name = "Ticket-AB-091",
                    RequestedBy = new User
                    {
                        FirstName = "John",
                        LastName = "Smith"
                    },
                    Status = _context.TicketStatus.FirstOrDefault(s => s.Name == "Pending")
                },
            };
            _context.AddRange(tickets);
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

        private static void CreateMultipleIssues()
        {
            var issues = new List<Issue>()
            {
                new Issue
                {
                    Name = "Issue-A-001",
                    Description = "Does a thing.",
                    IssueSeverity = _context.IssueSeverity.FirstOrDefault(s => s.Level == "S1"),
                    CreatedBy = "jkelly",
                    Process = new Process
                    {
                        Name = "Select [id] From [table]",
                        UsesScript = true
                    }
                },
                new Issue
                {
                    Name = "Issue-A-002",
                    Description = "Does a thing.",
                    IssueSeverity = _context.IssueSeverity.FirstOrDefault(s => s.Level == "S1"),
                    CreatedBy = "jkelly",
                    Process = new Process
                    {
                        Name = "Select [id],[Name] From [table]",
                        UsesScript = true
                    }
                },
                new Issue
                {
                    Name = "Issue-F-003",
                    Description = "Does a thing.",
                    IssueSeverity = _context.IssueSeverity.FirstOrDefault(s => s.Level == "S1"),
                    CreatedBy = "jkelly",
                    Process = new Process
                    {
                        Name = "Select all From table",
                        UsesScript = true
                    }
                },
                new Issue
                {
                    Name = "Issue-D-004",
                    Description = "Does a thing.",
                    IssueSeverity = _context.IssueSeverity.FirstOrDefault(s => s.Level == "S1"),
                    CreatedBy = "jkelly",
                    Process = new Process
                    {
                        Name = "Delect From table",
                        UsesScript = true
                    }
                },
                new Issue
                {
                    Name = "Issue-C-005",
                    Description = "Does a thing.",
                    IssueSeverity = _context.IssueSeverity.FirstOrDefault(s => s.Level == "S1"),
                    CreatedBy = "jkelly",
                    Process = new Process
                    {
                        Name = "Update value From table",
                        UsesScript = true
                    }
                },
                new Issue
                {
                    Name = "Issue-B-006",
                    Description = "Does a thing.",
                    IssueSeverity = _context.IssueSeverity.FirstOrDefault(s => s.Level == "S1"),
                    CreatedBy = "jkelly",
                    Process = new Process
                    {
                        Name = "Insert value into table",
                        UsesScript = true
                    }
                },
                new Issue
                {
                    Name = "Issue-A-019",
                    Description = "Does a thing.",
                    IssueSeverity = _context.IssueSeverity.FirstOrDefault(s => s.Level == "S1"),
                    CreatedBy = "jkelly",
                    Process = new Process
                    {
                        Name = "Select results From table",
                        UsesScript = true
                    }
                }
            };
            _context.AddRange(issues);
            _context.SaveChanges();
        }

        private static void AddIssuesToTickets()
        {  
            _context.Tickets.First(t => t.Name == "Ticket-ACD-s11")
                .TicketIssues.Add(new TicketIssue
                {
                    Issue = _context.Issues.First(i => i.Name == "Issue-A-001")
                });

            _context.Tickets.First(t => t.Name == "Ticket-AB-s11")
                .TicketIssues.Add(new TicketIssue
                {
                    Issue = _context.Issues.First(i => i.Name == "Issue-F-003")
                });

            _context.Tickets.First(t => t.Name == "Ticket-AB-091")
                .TicketIssues.Add(new TicketIssue
                {
                    Issue = _context.Issues.First(i => i.Name == "Issue-A-001")
                });
            _context.SaveChanges();
        }
    }
}
