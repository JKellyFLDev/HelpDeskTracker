using LeafFilter.HelpDesk.Models;
using LeafFilter.HelpDesk.Models.Interfaces;
using LeafFilter.HelpDesk.Models.XRef;
using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.Models.Types;
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

        public DbSet<IssueSeverity> IssueSeverity { get; set; }
        public DbSet<TicketStatus> TicketStatus { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Script> Scripts { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        //public DbSet<UserPermissionXRef> UserPermissions { get; set; }
        //public DbSet<ProcessScriptXRef> ProcessScripts { get; set; }
        //public DbSet<ProcessPageXRef> ProcessPages { get; set; }
        //public DbSet<IssueProcessXRef> IssueProcesses { get; set; }
        //public DbSet<TicketIssueXRef> TicketIssues { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            var connectionString = "Server=localhost; Initial Catalog=HelpDeskDB; Integrated Security=SSPI";
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
            modelBuilder.Entity<UserPermissionXRef>()
                .HasKey(x => new { x.UserId, x.PermissionId });
            modelBuilder.Entity<UserPermissionXRef>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserPermissions)
                .HasForeignKey(up => up.UserId);
            modelBuilder.Entity<UserPermissionXRef>()
                .HasOne(up => up.Permission)
                .WithMany(p => p.UserPermissions)
                .HasForeignKey(up => up.PermissionId);

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

            modelBuilder.Entity<IssueSeverity>()
                .Property(s => s.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<IssueSeverity>()
                .Property(s => s.Active)
                .HasDefaultValueSql("1");

            modelBuilder.Entity<TicketStatus>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TicketStatus>()
                .Property(s => s.Active)
                .HasDefaultValueSql("1");

            modelBuilder.Entity<Permission>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Permission>()
                .Property(t => t.Active)
                .HasDefaultValueSql("1");         
            
            modelBuilder.Entity<User>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Script>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Page>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Process>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Issue>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Ticket>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
