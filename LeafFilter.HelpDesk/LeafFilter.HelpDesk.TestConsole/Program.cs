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
            while (true)
            {
                Console.WriteLine("Menu:\n[1] - Build Test Data\n[2] - Remove Data From Database\n[0] - Quit");
                Console.Write("Enter: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        BuildTestData();
                        break;
                    case "2":
                        RemoveAllData();
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("ERROR: Invalid input please try again.");
                        break;
                }
            }
        }
        private static void BuildTestData()
        {
            if (_context.TicketStatus.FirstOrDefault() == null)
                CreateTicketStatuses();

            if (_context.IssueSeverity.FirstOrDefault() == null)
                CreateIssueSeverities();

            if (_context.AppPermissions.FirstOrDefault() == null)
                CreateAppPermissions();

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
        private static void RemoveAllData()
        {
            Console.WriteLine("Removing all records from database...");
            _context.Tickets.Clear();
            _context.Issues.Clear();
            _context.Processes.Clear();
            _context.Pages.Clear();
            _context.Scripts.Clear();
            _context.Users.Clear();
            _context.AppPermissions.Clear();
            _context.IssueSeverity.Clear();
            _context.TicketStatus.Clear();
            _context.SaveChanges();
        }
        private static void CreateTicketStatuses()
        {
            var ticketStatuses = new List<TicketStatus>()
            {
                new TicketStatus { Name = "New",            Order = 1,  CreatedBy = Environment.UserName},
                new TicketStatus { Name = "Assigned",       Order = 2,  CreatedBy = Environment.UserName},
                new TicketStatus { Name = "In-Progress",    Order = 3,  CreatedBy = Environment.UserName},
                new TicketStatus { Name = "Resolved",       Order = 4,  CreatedBy = Environment.UserName},
                new TicketStatus { Name = "Canceled",       Order = 4,  CreatedBy = Environment.UserName}
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
        private static void CreateAppPermissions()
        {
            var permissions = new List<AppPermission>()
            {
                new AppPermission
                {
                    Name = "Admin",
                    CreatedBy = Environment.UserName
                },
                new AppPermission
                {
                    Name = "User",
                    CreatedBy = Environment.UserName
                }
            };
            _context.AddRange(permissions);
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
                    UserAppPermissions = new List<UserAppPermissionXRef>()
                    {
                        new UserAppPermissionXRef
                        {
                            AppPermission = _context.AppPermissions.FirstOrDefault(p => p.Name == "Admin")
                        }
                    },
                    CreatedBy = Environment.UserName
                },
                new User
                {
                    FirstName = "James",
                    LastName = "Kelly",
                    Email = "jkelly@leaffilter.com",
                    UserName = "jkelly",
                    UserAppPermissions = new List<UserAppPermissionXRef>()
                    {
                        new UserAppPermissionXRef
                        {
                            AppPermission = _context.AppPermissions.FirstOrDefault(p => p.Name == "Admin")
                        }
                    },
                    CreatedBy = Environment.UserName
                },
                new User
                {
                    FirstName = "John",
                    LastName = "Smith",
                    UserName = "jsmith",
                    UserAppPermissions = new List<UserAppPermissionXRef>()
                    {
                        new UserAppPermissionXRef
                        {
                            AppPermission = _context.AppPermissions.FirstOrDefault(p => p.Name == "User")
                        }
                    },
                    CreatedBy = Environment.UserName
                },
                new User
                {
                    FirstName = "Mike",
                    LastName = "Barker",
                    UserName = "mbarker",
                    Email = "mbarker@leaffilter.com",
                    UserAppPermissions = new List<UserAppPermissionXRef>()
                    {
                        new UserAppPermissionXRef
                        {
                            AppPermission = _context.AppPermissions.FirstOrDefault(p => p.Name == "Admin")
                        }
                    },
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
                    Url = "google.com",
                    CreatedBy = Environment.UserName
                },
                new Page
                {
                    Name = "Remove-Lead",
                    Url = "bing.com",
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
                    Status = _context.TicketStatus.FirstOrDefault(s => s.Name == "Assigned"),
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
                    AssignedTo = _context.Users.FirstOrDefault(u => u.UserName == "jkelly"),
                    Status = _context.TicketStatus.FirstOrDefault(s => s.Name == "In-Progress"),
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
                    Name = "Ticket-AB-092",
                    RequestedBy = _context.Users.FirstOrDefault(u => u.UserName == "jsmith"),
                    AssignedTo = _context.Users.FirstOrDefault(u => u.UserName == "jkelly"),
                    Status = _context.TicketStatus.FirstOrDefault(s => s.Name == "Resolved"),
                    DateOpened = DateTime.Now.AddHours(-15),
                    DateResolved = DateTime.Now,                    
                    CreatedBy = Environment.UserName,
                    ModifiedBy = Environment.UserName,
                    ModifiedDate = DateTime.Now,
                    TicketIssues = new List<TicketIssueXRef>()
                    {
                        new TicketIssueXRef
                        {
                            Issue = _context.Issues.First(i => i.Name == "Issue-A-001")
                        }
                    }
                },
                new Ticket {
                    Name = "Ticket-AB-093",
                    RequestedBy = _context.Users.FirstOrDefault(u => u.UserName == "jkelly"),
                    AssignedTo = _context.Users.FirstOrDefault(u => u.UserName == "jkelly"),
                    Status = _context.TicketStatus.FirstOrDefault(s => s.Name == "Canceled"),
                    DateOpened = DateTime.Now.AddHours(-2),                    
                    CreatedBy = Environment.UserName,
                    ModifiedBy = Environment.UserName,
                    ModifiedDate = DateTime.Now,
                    TicketIssues = new List<TicketIssueXRef>()
                    {
                        new TicketIssueXRef
                        {
                            Issue = _context.Issues.First(i => i.Name == "Issue-A-002")                            
                        },
                        new TicketIssueXRef
                        {
                            Issue = _context.Issues.First(i => i.Name == "Issue-A-001")
                        }
                    }
                }
            };
            _context.AddRange(tickets);
            _context.SaveChanges();
        }
    }
}
