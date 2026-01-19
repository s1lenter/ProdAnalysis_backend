using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductionAnalysisBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionCycleAnalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    OperatorId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CycleTimeMinutes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCycleAnalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionCycleAnalyses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionCycleAnalyses_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionCycleAnalyses_Users_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CycleOperations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductionCycleAnalysisId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DurationMinutes = table.Column<int>(type: "integer", nullable: false),
                    PlanQty = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CycleOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CycleOperations_ProductionCycleAnalyses_ProductionCycleAnal~",
                        column: x => x.ProductionCycleAnalysisId,
                        principalTable: "ProductionCycleAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CycleOperations_ProductionCycleAnalysisId",
                table: "CycleOperations",
                column: "ProductionCycleAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCycleAnalyses_DepartmentId",
                table: "ProductionCycleAnalyses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCycleAnalyses_OperatorId",
                table: "ProductionCycleAnalyses",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCycleAnalyses_ProductId",
                table: "ProductionCycleAnalyses",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CycleOperations");

            migrationBuilder.DropTable(
                name: "ProductionCycleAnalyses");
        }
    }
}
