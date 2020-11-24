using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Models.XRef;
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
            Console.Write("Menu:\n[1] - Build Test Data\n[2] - Remove Data From Database\n[0] - Quit\nEnter: ");
            switch (Console.ReadLine())
            {
                case "1":
                    BuildTestData();
                    break;
                case "2":
                    RemoveData();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Write("Invalid input please try again.\nEnter: ");
                    break;
            }
        }  
        private static void BuildTestData()
        {
            if(_context.TicketStatus.FirstOrDefault() == null)
                CreateTicketStatuses();

            if (_context.IssueSeverity.FirstOrDefault() == null)
                CreateIssueSeverities();

            if (_context.Users.FirstOrDefault() == null)
                CreateNewUsers();

            if (_context.Scripts.FirstOrDefault() == null)
                CreateNewScripts();

            if (_context.Pages.FirstOrDefault() == null)
                CreateNewPages();

            if (_context.Processes.FirstOrDefault() == null)
                CreateNewProcesses();

            if (_context.Issues.FirstOrDefault() == null)
                CreateMultipleIssues();

            if (_context.Tickets.FirstOrDefault() == null)
                CreateMultipleTickets();
        }
        private static void RemoveData()
        {
            Console.WriteLine("Need to implement method");
        }
        private static void CreateTicketStatuses()
        {
            var ticketStatuses = new List<TicketStatus>()
            {
                new TicketStatus { Name = "New",            CreatedBy = Environment.UserName},
                new TicketStatus { Name = "Pending",        CreatedBy = Environment.UserName},
                new TicketStatus { Name = "In-Progress",    CreatedBy = Environment.UserName},
                new TicketStatus { Name = "Done",           CreatedBy = Environment.UserName},
                new TicketStatus { Name = "Canceled",       CreatedBy = Environment.UserName}
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
                    CreatedBy = Environment.UserName
                },
                new IssueSeverity
                {
                    Level = "S2",
                    Name = "Critical",
                    Description = "The System is adversely impacted.",
                    CreatedBy = Environment.UserName
                },
                new IssueSeverity {
                    Level = "S3",
                    Name = "Major",
                    Description = "The system experienced an error, short-term workaround available.",
                    CreatedBy = Environment.UserName
                },
                new IssueSeverity
                {
                    Level = "S4",
                    Name = "Minor",
                    Description = "Issue and requests without significant impact on system.",
                    CreatedBy = Environment.UserName
                },
                new IssueSeverity
                {
                    Level = "S5",
                    Name = "Trivial",
                    Description = "A condition might warrant action.",
                    CreatedBy = Environment.UserName
                }
            };
            _context.AddRange(issueSeverities);
            _context.SaveChanges();
        }
        private static void CreateNewUsers()
        {            
            var users = new List<User>()
            {
                new User
                {
                    FirstName = "Glenn",
                    LastName = "Weber",
                    Email = "gweber@leaffilter.com",
                    UserName = "gweber",
                    CreatedBy = Environment.UserName
                },
                new User
                {
                    FirstName = "James",
                    LastName = "Kelly",
                    Email = "jkelly@leaffilter.com",
                    UserName = "jkelly",
                    CreatedBy = Environment.UserName
                },
                new User
                {
                    FirstName = "John",
                    LastName = "Smith",
                    UserName = "jsmith",
                    CreatedBy = Environment.UserName
                },
                new User
                {
                    FirstName = "Mike",
                    LastName = "Barker",
                    UserName = "mbarker",
                    Email = "mbarker@leaffilter.com",
                    CreatedBy = Environment.UserName
                },
            };
            _context.AddRange(users);
            _context.SaveChanges();
        }        
        private static void CreateNewScripts()
        {
            var scripts = new List<Script>()
            {
                new Script
                {
                    Name = "Get-Info",
                    Header = @"--Basic Scripts for getting info",
                    Body = @"SELECT * FROM dbo.Tickets",
                    CreatedBy = Environment.UserName
                },
                new Script
                {
                    Name = "Delete-Info",
                    Header = @"--Basic Scripts for deleting info",
                    Body = @"DELECT FROM dbo.Tickets",
                    CreatedBy = Environment.UserName
                }
            };
            _context.AddRange(scripts);
            _context.SaveChanges();
        }
        private static void CreateNewPages()
        {
            var pages = new List<Page>()
            {
                new Page
                {
                    Name = "Search-Web",
                    Uri = new Uri("google.com"),                    
                    CreatedBy = Environment.UserName
                },
                new Page
                {
                    Name = "Remove-Lead",
                    Uri = new Uri("bing.com"),
                    CreatedBy = Environment.UserName
                }
            };
            _context.AddRange(pages);
            _context.SaveChanges();
        }
        private static void CreateNewProcesses()
        {
            var processes = new List<Process>()
            {
                new Process
                {
                    Name = "PRO-010-001",
                    Description = "Select From Specific Table",
                    UsesScript = true,
                    UsesAdminPage = false,
                    ProcessScripts = new List<ProcessScriptXRef>()
                    {
                        new ProcessScriptXRef
                        {
                            Script = _context.Scripts.FirstOrDefault(s => s.Name == "Get-Info")
                        }
                    },
                    CreatedBy = Environment.UserName
                },
                new Process
                {
                    Name = "PRO-510-011",
                    Description = "Select From Specific Table",
                    UsesScript = true,
                    UsesAdminPage = false,
                    ProcessScripts = new List<ProcessScriptXRef>()
                    {
                        new ProcessScriptXRef
                        {
                            Script = _context.Scripts.FirstOrDefault(s => s.Name == "Get-Info")
                        },
                        new ProcessScriptXRef
                        {
                            Script = _context.Scripts.FirstOrDefault(s => s.Name == "Delete-Info")
                        }
                    },
                    CreatedBy = Environment.UserName
                },
                new Process
                {
                    Name = "PRO-213-001",
                    Description = "Select From Specific Table",
                    UsesScript = true,
                    UsesAdminPage = false,
                    ProcessScripts = new List<ProcessScriptXRef>()
                    {
                        new ProcessScriptXRef
                        {
                            Script = _context.Scripts.FirstOrDefault(s => s.Name == "Get-Info")
                        },
                        new ProcessScriptXRef
                        {
                            Script = _context.Scripts.FirstOrDefault(s => s.Name == "Delete-Info")
                        }
                    },
                    CreatedBy = Environment.UserName
                },
                new Process
                {
                    Name = "PRO-464-001",
                    Description = "Jeff Super Secret Page",
                    UsesScript = false,
                    UsesAdminPage = true,
                    ProcessPages = new List<ProcessPageXRef>()
                    {
                        new ProcessPageXRef
                        {
                            Page = _context.Pages.FirstOrDefault(s => s.Name == "Search-Web")
                        },
                        new ProcessPageXRef
                        {
                            Page = _context.Pages.FirstOrDefault(s => s.Name == "Remove-Lead")
                        }
                    },
                    CreatedBy = Environment.UserName
                }
            };
            _context.Processes.AddRange(processes);
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
                    CreatedBy = Environment.UserName,
                    IssueProcesses = new List<IssueProcessXRef>()
                    {
                        new IssueProcessXRef
                        {
                            Process = _context.Processes.First(p => p.Name == "PRO-010-001"),
                            Order = 1
                        }
                    }
                },
                new Issue
                {
                    Name = "Issue-A-002",
                    Description = "Does a thing.",
                    IssueSeverity = _context.IssueSeverity.FirstOrDefault(s => s.Level == "S1"),
                    CreatedBy = Environment.UserName,
                    IssueProcesses = new List<IssueProcessXRef>()
                    {
                        new IssueProcessXRef
                        {
                            Process = _context.Processes.First(p => p.Name == "PRO-010-001"),
                            Order = 1
                        }
                    }
                },
                new Issue
                {
                    Name = "Issue-F-003",
                    Description = "Does a thing.",
                    IssueSeverity = _context.IssueSeverity.FirstOrDefault(s => s.Level == "S1"),
                    CreatedBy = Environment.UserName,
                    IssueProcesses = new List<IssueProcessXRef>()
                    {
                        new IssueProcessXRef
                        {
                            Process = _context.Processes.First(p => p.Name == "PRO-010-001"),
                            Order = 1
                        }
                    }
                },
                new Issue
                {
                    Name = "Issue-D-004",
                    Description = "Does a thing.",
                    IssueSeverity = _context.IssueSeverity.FirstOrDefault(s => s.Level == "S1"),
                    CreatedBy = Environment.UserName,
                    IssueProcesses = new List<IssueProcessXRef>()
                    {
                        new IssueProcessXRef
                        {
                            Process = _context.Processes.First(p => p.Name == "PRO-010-001"),
                            Order = 1
                        }
                    }
                },
                new Issue
                {
                    Name = "Issue-C-005",
                    Description = "Does a thing.",
                    IssueSeverity = _context.IssueSeverity.FirstOrDefault(s => s.Level == "S1"),
                    CreatedBy = Environment.UserName,
                    IssueProcesses = new List<IssueProcessXRef>()
                    {
                        new IssueProcessXRef
                        {
                            Process = _context.Processes.First(p => p.Name == "PRO-010-001"),
                            Order = 1
                        }
                    }
                },
                new Issue
                {
                    Name = "Issue-B-006",
                    Description = "Does a thing.",
                    IssueSeverity = _context.IssueSeverity.FirstOrDefault(s => s.Level == "S1"),
                    CreatedBy = Environment.UserName,
                    IssueProcesses = new List<IssueProcessXRef>()
                    {
                        new IssueProcessXRef
                        {
                            Process = _context.Processes.First(p => p.Name == "PRO-010-001"),
                            Order = 1
                        }
                    }
                },
                new Issue
                {
                    Name = "Issue-A-019",
                    Description = "Does a thing.",
                    IssueSeverity = _context.IssueSeverity.FirstOrDefault(s => s.Level == "S1"),
                    CreatedBy = Environment.UserName,
                    IssueProcesses = new List<IssueProcessXRef>()
                    {
                        new IssueProcessXRef
                        {
                            Process = _context.Processes.First(p => p.Name == "PRO-010-001"),
                            Order = 1
                        }
                    }
                }
            };
            _context.AddRange(issues);
            _context.SaveChanges();
        }
        private static void CreateMultipleTickets()
        {
            var tickets = new List<Ticket>()
            {
                new Ticket {
                    Name = "Ticket-ACD-s11",
                    RequestedBy = _context.Users.FirstOrDefault(u => u.UserName == "gweber"),
                    AssignedTo = _context.Users.FirstOrDefault(u => u.UserName == "jkelly"),
                    Status = _context.TicketStatus.FirstOrDefault(s => s.Name == "New"),
                    CreatedBy = Environment.UserName,
                    TicketIssues = new List<TicketIssueXRef>()
                    {
                        new TicketIssueXRef
                        {
                            Issue = _context.Issues.First(i => i.Name == "Issue-A-001")
                        }
                    }
                },
                new Ticket {
                    Name = "Ticket-AB-s11",
                    RequestedBy = _context.Users.FirstOrDefault(u => u.UserName == "jsmith"),
                    AssignedTo = _context.Users.FirstOrDefault(u => u.UserName == "mbarker"),
                    Status = _context.TicketStatus.FirstOrDefault(s => s.Name == "Pending"),
                    CreatedBy = Environment.UserName,
                    TicketIssues = new List<TicketIssueXRef>()
                    {
                        new TicketIssueXRef
                        {
                            Issue = _context.Issues.First(i => i.Name == "Issue-F-003")
                        }
                    }
                },
                new Ticket {
                    Name = "Ticket-AB-091",
                    RequestedBy = _context.Users.FirstOrDefault(u => u.UserName == "jsmith"),     
                    Status = _context.TicketStatus.FirstOrDefault(s => s.Name == "Pending"),
                    CreatedBy = Environment.UserName,
                    TicketIssues = new List<TicketIssueXRef>()
                    {
                        new TicketIssueXRef
                        {
                            Issue = _context.Issues.First(i => i.Name == "Issue-A-001")
                        }
                    }
                },
            };
            _context.AddRange(tickets);
            _context.SaveChanges();
        }
    }
}
