using LeafFilter.HelpDesk.Model;
using LeafFilter.HelpDesk.Model.XRef;
using LeafFilter.HelpDesk.Model.Conditions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace LeafFilter.HelpDesk.Data
{
    public class HelpDeskContext : DbContext
    {
        public static readonly ILoggerFactory logger
            = LoggerFactory.Create(builder =>
            {
                builder.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
                       .AddConsole();
            });

        public DbSet<SeverityType> SeverityType { get; set; }
        public DbSet<TicketStatus> TicketStatus { get; set; }
        public DbSet<PermissionType> PermissionType { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<Script> Script { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<Ticket> Ticket { get; set; }

        //public DbSet<UserAppPermissionXRef> UserAppPermissions { get; set; }
        //public DbSet<ProcessScriptXRef> ProcessScripts { get; set; }
        //public DbSet<ProcessPageXRef> ProcessPages { get; set; }
        //public DbSet<IssueProcessXRef> IssueProcesses { get; set; }
        //public DbSet<TicketIssueXRef> TicketIssues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            //var connectionString = "Server=localhost; Initial Catalog=HelpDeskDB; Integrated Security=SSPI";
            var connectionString = ConfigurationManager.ConnectionStrings["LocalDatabase"].ToString();
            //var connectionString = "Server=LF942\\MSSQLSERVERLOCAL; Initial Catalog=HelpDeskData; Integrated Security=SSPI";
#elif RELEASE
            var connectionString = ConfigurationManager.ConnectionStrings["LocalDatabase"].ToString();
            //var connectionString = ConfigurationManager.ConnectionStrings["DevDatabase"].ToString();
#endif
            optionsBuilder
                .UseLoggerFactory(logger)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // UserPermissionXRef
            modelBuilder.Entity<UserPermissionTypeXRef>()
                .HasKey(x => new { x.UserId, x.AppPermissionId });
            modelBuilder.Entity<UserPermissionTypeXRef>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserAppPermissions)
                .HasForeignKey(up => up.UserId);
            modelBuilder.Entity<UserPermissionTypeXRef>()
                .HasOne(up => up.AppPermission)
                .WithMany(p => p.UserPermissions)
                .HasForeignKey(up => up.AppPermissionId);

            // ProcessScriptXRef
            modelBuilder.Entity<ProcessScriptXRef>()
                .HasKey(x => new { x.ProcessId, x.ScriptId });
            modelBuilder.Entity<ProcessScriptXRef>()
                .HasOne(ps => ps.Process)
                .WithMany(p => p.ProcessScripts)
                .HasForeignKey(ps => ps.ProcessId);
            modelBuilder.Entity<ProcessScriptXRef>()
                .HasOne(ps => ps.Script)
                .WithMany(s => s.ProcessScripts)
                .HasForeignKey(ps => ps.ScriptId);

            // ProcessPageXRef
            modelBuilder.Entity<ProcessPageXRef>()
                .HasKey(x => new { x.ProcessId, x.PageId });
            modelBuilder.Entity<ProcessPageXRef>()
                .HasOne(pp => pp.Process)
                .WithMany(p => p.ProcessPages)
                .HasForeignKey(pp => pp.ProcessId);
            modelBuilder.Entity<ProcessPageXRef>()
                .HasOne(pp => pp.Page)
                .WithMany(p => p.ProcessPages)
                .HasForeignKey(pp => pp.PageId);

            // IssuesProcessXRef
            modelBuilder.Entity<IssueProcessXRef>()
                .HasKey(p => new { p.IssueId, p.ProcessId });
            modelBuilder.Entity<IssueProcessXRef>()
                .HasOne(ip => ip.Issue)
                .WithMany(i => i.IssueProcesses)
                .HasForeignKey(ip => ip.IssueId);
            modelBuilder.Entity<IssueProcessXRef>()
                .HasOne(ip => ip.Process)
                .WithMany(p => p.IssueProcesses)
                .HasForeignKey(ip => ip.ProcessId);

            // TicketIssue
            modelBuilder.Entity<TicketIssueXRef>()
                .HasKey(t => new { t.TicketId, t.IssueId });
            modelBuilder.Entity<TicketIssueXRef>()
                .HasOne(ti => ti.Ticket)
                .WithMany(t => t.TicketIssues)
                .HasForeignKey(ti => ti.TicketId);
            modelBuilder.Entity<TicketIssueXRef>()
                .HasOne(ti => ti.Issue)
                .WithMany(i => i.TicketIssues)
                .HasForeignKey(ti => ti.IssueId);

            // SeverityType
            modelBuilder.Entity<SeverityType>()
                .Property(s => s.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<SeverityType>()
                .Property(t => t.ModifiedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<SeverityType>()
                .Property(s => s.Active)
                .HasDefaultValueSql("1");

            // TicketStatus
            modelBuilder.Entity<TicketStatus>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TicketStatus>()
                .Property(t => t.ModifiedDate)
                .HasDefaultValueSql("GETDATE()");

            // PermissionType
            modelBuilder.Entity<PermissionType>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<PermissionType>()
                .Property(t => t.ModifiedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<PermissionType>()
                .Property(t => t.Active)
                .HasDefaultValueSql("1");         
            
            // User
            modelBuilder.Entity<User>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<User>()
                .Property(t => t.ModifiedDate)
                .HasDefaultValueSql("GETDATE()");

            // Script
            modelBuilder.Entity<Script>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Script>()
                .Property(t => t.ModifiedDate)
                .HasDefaultValueSql("GETDATE()");

            // Page
            modelBuilder.Entity<Page>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Page>()
                .Property(t => t.ModifiedDate)
                .HasDefaultValueSql("GETDATE()");

            // Process
            modelBuilder.Entity<Process>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Process>()
                .Property(t => t.ModifiedDate)
                .HasDefaultValueSql("GETDATE()");
                        
            // Issue
            modelBuilder.Entity<Issue>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Issue>()
                .Property(t => t.ModifiedDate)
                .HasDefaultValueSql("GETDATE()");

            // Ticket
            modelBuilder.Entity<Ticket>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Ticket>()
                .Property(t => t.ModifiedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Ticket>()
                .Property(t => t.DateOpened)
                .HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
