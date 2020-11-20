using LeafFilter.HelpDesk.Models;
using LeafFilter.HelpDesk.Models.Base;
using LeafFilter.HelpDesk.Models.JoinTables;
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

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<SqlScript> SqlScripts { get; set; }
        public DbSet<IssueSeverity> IssueSeverity { get; set; }
        public DbSet<TicketStatus> TicketStatus { get; set; }
        //public DbSet<TicketIssue> TicketIssue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["HelpDeskDatabase"].ToString();
            var connectionString = "Server=localhost; Initial Catalog=HelpDeskData; Integrated Security=SSPI";
            optionsBuilder
                .UseLoggerFactory(logger)
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TicketIssue>()
                .HasKey(t => new { t.TicketId, t.IssueId });

            modelBuilder.Entity<TicketIssue>()
                .HasOne(ti => ti.Issue)
                .WithMany(i => i.TicketIssues)
                .HasForeignKey(ti => ti.IssueId);

            modelBuilder.Entity<TicketIssue>()
                .HasOne(ti => ti.Ticket)
                .WithMany(t => t.TicketIssues)
                .HasForeignKey(ti => ti.TicketId);

            modelBuilder.Entity<IssueSeverity>()
                .Property(s => s.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<TicketStatus>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Ticket>()
                .Property(t => t.DateOpen)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Issue>()
                .Property(i => i.CreatedDate)
                .HasDefaultValueSql("GETDATE()");           

            base.OnModelCreating(modelBuilder);
        }
    }
}
