using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeafFilter.HelpDesk.Data.Migrations
{
    public partial class fixmanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TicketIssue_IssueId",
                table: "TicketIssue");

            migrationBuilder.DropIndex(
                name: "IX_TicketIssue_TicketId",
                table: "TicketIssue");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Processes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Issues",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Issues",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketIssue_IssueId",
                table: "TicketIssue",
                column: "IssueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TicketIssue_IssueId",
                table: "TicketIssue");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Issues");

            migrationBuilder.CreateIndex(
                name: "IX_TicketIssue_IssueId",
                table: "TicketIssue",
                column: "IssueId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketIssue_TicketId",
                table: "TicketIssue",
                column: "TicketId",
                unique: true);
        }
    }
}
