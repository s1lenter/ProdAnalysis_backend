using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionAnalysisBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductionAnalyses_ProductionAnalysisId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductionAnalysisId",
                table: "Products",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductionAnalyses_ProductionAnalysisId",
                table: "Products",
                column: "ProductionAnalysisId",
                principalTable: "ProductionAnalyses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductionAnalyses_ProductionAnalysisId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductionAnalysisId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductionAnalyses_ProductionAnalysisId",
                table: "Products",
                column: "ProductionAnalysisId",
                principalTable: "ProductionAnalyses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
