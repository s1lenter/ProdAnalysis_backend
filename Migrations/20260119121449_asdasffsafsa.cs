using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionAnalysisBackend.Migrations
{
    /// <inheritdoc />
    public partial class asdasffsafsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAProduct_ProductionAnalyses_ProductionAnalysisId",
                table: "PAProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PAProduct_Products_ProductId",
                table: "PAProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PAProduct",
                table: "PAProduct");

            migrationBuilder.RenameTable(
                name: "PAProduct",
                newName: "PAProducts");

            migrationBuilder.RenameIndex(
                name: "IX_PAProduct_ProductionAnalysisId",
                table: "PAProducts",
                newName: "IX_PAProducts_ProductionAnalysisId");

            migrationBuilder.RenameIndex(
                name: "IX_PAProduct_ProductId",
                table: "PAProducts",
                newName: "IX_PAProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PAProducts",
                table: "PAProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PAProducts_ProductionAnalyses_ProductionAnalysisId",
                table: "PAProducts",
                column: "ProductionAnalysisId",
                principalTable: "ProductionAnalyses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PAProducts_Products_ProductId",
                table: "PAProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PAProducts_ProductionAnalyses_ProductionAnalysisId",
                table: "PAProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PAProducts_Products_ProductId",
                table: "PAProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PAProducts",
                table: "PAProducts");

            migrationBuilder.RenameTable(
                name: "PAProducts",
                newName: "PAProduct");

            migrationBuilder.RenameIndex(
                name: "IX_PAProducts_ProductionAnalysisId",
                table: "PAProduct",
                newName: "IX_PAProduct_ProductionAnalysisId");

            migrationBuilder.RenameIndex(
                name: "IX_PAProducts_ProductId",
                table: "PAProduct",
                newName: "IX_PAProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PAProduct",
                table: "PAProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PAProduct_ProductionAnalyses_ProductionAnalysisId",
                table: "PAProduct",
                column: "ProductionAnalysisId",
                principalTable: "ProductionAnalyses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PAProduct_Products_ProductId",
                table: "PAProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
