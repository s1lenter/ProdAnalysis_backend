using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionAnalysisBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixProductAg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductionAnalyses_ProductionAnalysisId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductionAnalysisId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductionAnalysisId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductionAnalyses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionAnalyses_ProductId",
                table: "ProductionAnalyses",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionAnalyses_Products_ProductId",
                table: "ProductionAnalyses",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionAnalyses_Products_ProductId",
                table: "ProductionAnalyses");

            migrationBuilder.DropIndex(
                name: "IX_ProductionAnalyses_ProductId",
                table: "ProductionAnalyses");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductionAnalyses");

            migrationBuilder.AddColumn<int>(
                name: "ProductionAnalysisId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductionAnalysisId",
                table: "Products",
                column: "ProductionAnalysisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductionAnalyses_ProductionAnalysisId",
                table: "Products",
                column: "ProductionAnalysisId",
                principalTable: "ProductionAnalyses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
