using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorTicketsApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Python" },
                    { 2, "CSharp" },
                    { 3, "WebDevelopment" },
                    { 4, "DataStructures" },
                    { 5, "JavaScript" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "id", "description", "is_resolved", "submitted_by", "title" },
                values: new object[,]
                {
                    { 1, "Application crashes on startup.", false, "John Doe", "Bug Fix" },
                    { 2, "Add dark mode to settings.", false, "Alice Smith", "Feature Request" },
                    { 3, "Users are unable to connect to the database server.", false, "Emily Johnson", "Database Connection Issue" },
                    { 4, "Improve button styling on the login page.", false, "Mark Adams", "UI Enhancement" },
                    { 5, "Application response time is slow during data retrieval.", false, "Alex Chen", "Performance Optimization" },
                    { 6, "Add export functionality for user data.", false, "Laura Lee", "Missing Feature" },
                    { 7, "The \"Contact Us\" link leads to a 404 page.", false, "Michael Brown", "Broken Link" },
                    { 8, "Vulnerability in authentication process.", false, "Sophia Rodriguez", "Security Concern" },
                    { 9, "Incorrect translations in the French version.", false, "Pierre Dupont", "Localization Issue" },
                    { 10, "CSV import fails for large datasets.", false, "Grace Liu", "Data Import Error" }
                });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "id", "response", "submitted_by", "ticket_id" },
                values: new object[,]
                {
                    { 1, "Thank you for reporting the issue.", "Support Team", 3 },
                    { 2, "We have escalated your feature request.", "Product Manager", 2 },
                    { 3, "Investigating the database connection issue.", "Database Administrator", 1 },
                    { 4, "UI enhancement task assigned to design team.", "Project Lead", 4 },
                    { 5, "Security vulnerability patched.", "Security Analyst", 5 }
                });

            migrationBuilder.InsertData(
                table: "TicketTags",
                columns: new[] { "tag_id", "ticket_id" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 5, 1 },
                    { 2, 6 },
                    { 3, 6 },
                    { 5, 6 },
                    { 3, 9 },
                    { 1, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TicketTags",
                keyColumns: new[] { "tag_id", "ticket_id" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "TicketTags",
                keyColumns: new[] { "tag_id", "ticket_id" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "TicketTags",
                keyColumns: new[] { "tag_id", "ticket_id" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "TicketTags",
                keyColumns: new[] { "tag_id", "ticket_id" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "TicketTags",
                keyColumns: new[] { "tag_id", "ticket_id" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "TicketTags",
                keyColumns: new[] { "tag_id", "ticket_id" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "TicketTags",
                keyColumns: new[] { "tag_id", "ticket_id" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "id",
                keyValue: 10);
        }
    }
}
