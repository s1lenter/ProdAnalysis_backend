using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductionAnalysisBackend.Migrations
{
    /// <inheritdoc />
    public partial class asdasf : Migration
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

            migrationBuilder.CreateTable(
                name: "PAProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductionAnalysisId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PAProduct_ProductionAnalyses_ProductionAnalysisId",
                        column: x => x.ProductionAnalysisId,
                        principalTable: "ProductionAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PAProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PAProduct_ProductId",
                table: "PAProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PAProduct_ProductionAnalysisId",
                table: "PAProduct",
                column: "ProductionAnalysisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PAProduct");

            migrationBuilder.AddColumn<int>(
                name: "ProductionAnalysisId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
