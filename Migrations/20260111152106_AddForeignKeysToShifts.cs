using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionAnalysisBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeysToShifts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Shifts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Shifts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Shifts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "Shifts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Shifts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_CreatorId",
                table: "Shifts",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_DepartmentId",
                table: "Shifts",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_OperatorId",
                table: "Shifts",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Departments_DepartmentId",
                table: "Shifts",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Users_CreatorId",
                table: "Shifts",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Users_OperatorId",
                table: "Shifts",
                column: "OperatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Departments_DepartmentId",
                table: "Shifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Users_CreatorId",
                table: "Shifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Users_OperatorId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_CreatorId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_DepartmentId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_OperatorId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Shifts");
        }
    }
}
