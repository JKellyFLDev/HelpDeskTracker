using LeafFilter.HelpDesk.Models;
using LeafFilter.HelpDesk.Models.JoinTables;
using LeafFilter.HelpDesk.Models.Records;
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
            base.OnModelCreating(modelBuilder);
        }

    }
}
