using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorTicketsApi.Migrations
{
    /// <inheritdoc />
    public partial class @true : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "id",
                keyValue: 1,
                column: "is_resolved",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "id",
                keyValue: 1,
                column: "is_resolved",
                value: false);
        }
    }
}
