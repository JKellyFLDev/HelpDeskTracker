﻿// <auto-generated />
using System;
using LeafFilter.HelpDesk.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LeafFilter.HelpDesk.Data.Migrations
{
    [DbContext(typeof(HelpDeskContext))]
    [Migration("20210111212248_initial-v1.3")]
    partial class initialv13
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Conditions.PermissionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("1");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PermissionType");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Conditions.SeverityType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("1");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SeverityType");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Conditions.TicketStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TicketStatus");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Issue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SeverityTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SeverityTypeId");

                    b.ToTable("Issue");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Page", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Page");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Process", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UsesAdminPage")
                        .HasColumnType("bit");

                    b.Property<bool>("UsesScript")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Process");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Script", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Footer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Header")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Script");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssignedToId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateOpened")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateResolved")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RequestedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AssignedToId");

                    b.HasIndex("RequestedById");

                    b.HasIndex("StatusId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.XRef.IssueProcessXRef", b =>
                {
                    b.Property<Guid>("IssueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProcessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("IssueId", "ProcessId");

                    b.HasIndex("ProcessId");

                    b.ToTable("IssueProcessXRef");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.XRef.ProcessPageXRef", b =>
                {
                    b.Property<Guid>("ProcessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProcessId", "PageId");

                    b.HasIndex("PageId");

                    b.ToTable("ProcessPageXRef");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.XRef.ProcessScriptXRef", b =>
                {
                    b.Property<Guid>("ProcessId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ScriptId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProcessId", "ScriptId");

                    b.HasIndex("ScriptId");

                    b.ToTable("ProcessScriptXRef");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.XRef.TicketIssueXRef", b =>
                {
                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IssueId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TicketId", "IssueId");

                    b.HasIndex("IssueId");

                    b.ToTable("TicketIssueXRef");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.XRef.UserPermissionTypeXRef", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppPermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "AppPermissionId");

                    b.HasIndex("AppPermissionId");

                    b.ToTable("UserPermissionTypeXRef");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Issue", b =>
                {
                    b.HasOne("LeafFilter.HelpDesk.Model.Conditions.SeverityType", "SeverityType")
                        .WithMany()
                        .HasForeignKey("SeverityTypeId");

                    b.Navigation("SeverityType");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Ticket", b =>
                {
                    b.HasOne("LeafFilter.HelpDesk.Model.User", "AssignedTo")
                        .WithMany()
                        .HasForeignKey("AssignedToId");

                    b.HasOne("LeafFilter.HelpDesk.Model.User", "RequestedBy")
                        .WithMany()
                        .HasForeignKey("RequestedById");

                    b.HasOne("LeafFilter.HelpDesk.Model.Conditions.TicketStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("AssignedTo");

                    b.Navigation("RequestedBy");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.XRef.IssueProcessXRef", b =>
                {
                    b.HasOne("LeafFilter.HelpDesk.Model.Issue", "Issue")
                        .WithMany("IssueProcesses")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeafFilter.HelpDesk.Model.Process", "Process")
                        .WithMany("IssueProcesses")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issue");

                    b.Navigation("Process");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.XRef.ProcessPageXRef", b =>
                {
                    b.HasOne("LeafFilter.HelpDesk.Model.Page", "Page")
                        .WithMany("ProcessPages")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeafFilter.HelpDesk.Model.Process", "Process")
                        .WithMany("ProcessPages")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Page");

                    b.Navigation("Process");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.XRef.ProcessScriptXRef", b =>
                {
                    b.HasOne("LeafFilter.HelpDesk.Model.Process", "Process")
                        .WithMany("ProcessScripts")
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeafFilter.HelpDesk.Model.Script", "Script")
                        .WithMany("ProcessScripts")
                        .HasForeignKey("ScriptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Process");

                    b.Navigation("Script");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.XRef.TicketIssueXRef", b =>
                {
                    b.HasOne("LeafFilter.HelpDesk.Model.Issue", "Issue")
                        .WithMany("TicketIssues")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeafFilter.HelpDesk.Model.Ticket", "Ticket")
                        .WithMany("TicketIssues")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issue");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.XRef.UserPermissionTypeXRef", b =>
                {
                    b.HasOne("LeafFilter.HelpDesk.Model.Conditions.PermissionType", "AppPermission")
                        .WithMany("UserPermissions")
                        .HasForeignKey("AppPermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeafFilter.HelpDesk.Model.User", "User")
                        .WithMany("UserAppPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppPermission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Conditions.PermissionType", b =>
                {
                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Issue", b =>
                {
                    b.Navigation("IssueProcesses");

                    b.Navigation("TicketIssues");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Page", b =>
                {
                    b.Navigation("ProcessPages");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Process", b =>
                {
                    b.Navigation("IssueProcesses");

                    b.Navigation("ProcessPages");

                    b.Navigation("ProcessScripts");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Script", b =>
                {
                    b.Navigation("ProcessScripts");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.Ticket", b =>
                {
                    b.Navigation("TicketIssues");
                });

            modelBuilder.Entity("LeafFilter.HelpDesk.Model.User", b =>
                {
                    b.Navigation("UserAppPermissions");
                });
#pragma warning restore 612, 618
        }
    }
}
