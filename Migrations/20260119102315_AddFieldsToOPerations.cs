using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionAnalysisBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToOPerations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "CycleOperations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactDurationMinutes",
                table: "CycleOperations",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "CycleOperations");

            migrationBuilder.DropColumn(
                name: "FactDurationMinutes",
                table: "CycleOperations");
        }
    }
}
