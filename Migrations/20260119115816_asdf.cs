using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionAnalysisBackend.Migrations
{
    /// <inheritdoc />
    public partial class asdf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkIntervals_ProductionAnalyses_ProductionAnalysisId",
                table: "WorkIntervals");

            migrationBuilder.DropIndex(
                name: "IX_WorkIntervals_ProductionAnalysisId",
                table: "WorkIntervals");

            migrationBuilder.DropColumn(
                name: "ProductionAnalysisId",
                table: "WorkIntervals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductionAnalysisId",
                table: "WorkIntervals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkIntervals_ProductionAnalysisId",
                table: "WorkIntervals",
                column: "ProductionAnalysisId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkIntervals_ProductionAnalyses_ProductionAnalysisId",
                table: "WorkIntervals",
                column: "ProductionAnalysisId",
                principalTable: "ProductionAnalyses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
