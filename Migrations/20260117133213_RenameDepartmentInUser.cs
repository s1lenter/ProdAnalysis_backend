using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionAnalysisBackend.Migrations
{
    /// <inheritdoc />
    public partial class RenameDepartmentInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartamentId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "DepartamentId",
                table: "Users",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_DepartamentId",
                table: "Users",
                newName: "IX_Users_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Departments_DepartmentId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Users",
                newName: "DepartamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                newName: "IX_Users_DepartamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Departments_DepartamentId",
                table: "Users",
                column: "DepartamentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
