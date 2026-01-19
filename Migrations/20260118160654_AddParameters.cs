using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionAnalysisBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddParameters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameter_ProductionAnalyses_ProductionAnalysisId",
                table: "Parameter");

            migrationBuilder.DropIndex(
                name: "IX_WorkIntervals_ProductionAnalysisId",
                table: "WorkIntervals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parameter",
                table: "Parameter");

            migrationBuilder.RenameTable(
                name: "Parameter",
                newName: "Parameters");

            migrationBuilder.RenameIndex(
                name: "IX_Parameter_ProductionAnalysisId",
                table: "Parameters",
                newName: "IX_Parameters_ProductionAnalysisId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parameters",
                table: "Parameters",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkIntervals_ProductionAnalysisId",
                table: "WorkIntervals",
                column: "ProductionAnalysisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parameters_ProductionAnalyses_ProductionAnalysisId",
                table: "Parameters",
                column: "ProductionAnalysisId",
                principalTable: "ProductionAnalyses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parameters_ProductionAnalyses_ProductionAnalysisId",
                table: "Parameters");

            migrationBuilder.DropIndex(
                name: "IX_WorkIntervals_ProductionAnalysisId",
                table: "WorkIntervals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parameters",
                table: "Parameters");

            migrationBuilder.RenameTable(
                name: "Parameters",
                newName: "Parameter");

            migrationBuilder.RenameIndex(
                name: "IX_Parameters_ProductionAnalysisId",
                table: "Parameter",
                newName: "IX_Parameter_ProductionAnalysisId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parameter",
                table: "Parameter",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkIntervals_ProductionAnalysisId",
                table: "WorkIntervals",
                column: "ProductionAnalysisId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Parameter_ProductionAnalyses_ProductionAnalysisId",
                table: "Parameter",
                column: "ProductionAnalysisId",
                principalTable: "ProductionAnalyses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
