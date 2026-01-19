using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionAnalysisBackend.Migrations
{
    /// <inheritdoc />
    public partial class ReworkPaToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ProductionAnalysisId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductionAnalysisId",
                table: "Products",
                column: "ProductionAnalysisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ProductionAnalysisId",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductionAnalysisId",
                table: "Products",
                column: "ProductionAnalysisId",
                unique: true);
        }
    }
}
