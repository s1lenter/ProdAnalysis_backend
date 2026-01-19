using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductionAnalysisBackend.Migrations
{
    /// <inheritdoc />
    public partial class FinalFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deviation_ReasonGroup_ReasonGroupId",
                table: "Deviation");

            migrationBuilder.DropForeignKey(
                name: "FK_Deviation_Reason_ReasonId",
                table: "Deviation");

            migrationBuilder.DropForeignKey(
                name: "FK_Deviation_Row_RowId",
                table: "Deviation");

            migrationBuilder.DropForeignKey(
                name: "FK_Deviation_Users_ResponsibleUserId",
                table: "Deviation");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Departments_DepartmentId",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_MultiplyProductions_MultiplyProductionId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Reason_ReasonGroup_GroupId",
                table: "Reason");

            migrationBuilder.DropForeignKey(
                name: "FK_Row_ProductionAnalyses_ProductionAnalysisId",
                table: "Row");

            migrationBuilder.DropForeignKey(
                name: "FK_Row_Products_ProductId",
                table: "Row");

            migrationBuilder.DropForeignKey(
                name: "FK_Row_WorkIntervals_WorkIntervalId",
                table: "Row");

            migrationBuilder.DropTable(
                name: "DownTimeReasons");

            migrationBuilder.DropTable(
                name: "HourlyDates");

            migrationBuilder.DropTable(
                name: "LongCycles");

            migrationBuilder.DropTable(
                name: "MultiplyProductions");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Products_MultiplyProductionId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Row",
                table: "Row");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReasonGroup",
                table: "ReasonGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reason",
                table: "Reason");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deviation",
                table: "Deviation");

            migrationBuilder.DropColumn(
                name: "MultiplyProductionId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Row",
                newName: "Rows");

            migrationBuilder.RenameTable(
                name: "ReasonGroup",
                newName: "ReasonGroups");

            migrationBuilder.RenameTable(
                name: "Reason",
                newName: "Reasons");

            migrationBuilder.RenameTable(
                name: "Equipments",
                newName: "Equipment");

            migrationBuilder.RenameTable(
                name: "Deviation",
                newName: "Deviations");

            migrationBuilder.RenameIndex(
                name: "IX_Row_WorkIntervalId",
                table: "Rows",
                newName: "IX_Rows_WorkIntervalId");

            migrationBuilder.RenameIndex(
                name: "IX_Row_ProductionAnalysisId",
                table: "Rows",
                newName: "IX_Rows_ProductionAnalysisId");

            migrationBuilder.RenameIndex(
                name: "IX_Row_ProductId",
                table: "Rows",
                newName: "IX_Rows_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Reason_GroupId",
                table: "Reasons",
                newName: "IX_Reasons_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipments_DepartmentId",
                table: "Equipment",
                newName: "IX_Equipment_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Deviation_RowId",
                table: "Deviations",
                newName: "IX_Deviations_RowId");

            migrationBuilder.RenameIndex(
                name: "IX_Deviation_ResponsibleUserId",
                table: "Deviations",
                newName: "IX_Deviations_ResponsibleUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Deviation_ReasonId",
                table: "Deviations",
                newName: "IX_Deviations_ReasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Deviation_ReasonGroupId",
                table: "Deviations",
                newName: "IX_Deviations_ReasonGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rows",
                table: "Rows",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReasonGroups",
                table: "ReasonGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reasons",
                table: "Reasons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deviations",
                table: "Deviations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Deviations_ReasonGroups_ReasonGroupId",
                table: "Deviations",
                column: "ReasonGroupId",
                principalTable: "ReasonGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deviations_Reasons_ReasonId",
                table: "Deviations",
                column: "ReasonId",
                principalTable: "Reasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deviations_Rows_RowId",
                table: "Deviations",
                column: "RowId",
                principalTable: "Rows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deviations_Users_ResponsibleUserId",
                table: "Deviations",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Departments_DepartmentId",
                table: "Equipment",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reasons_ReasonGroups_GroupId",
                table: "Reasons",
                column: "GroupId",
                principalTable: "ReasonGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rows_ProductionAnalyses_ProductionAnalysisId",
                table: "Rows",
                column: "ProductionAnalysisId",
                principalTable: "ProductionAnalyses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rows_Products_ProductId",
                table: "Rows",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rows_WorkIntervals_WorkIntervalId",
                table: "Rows",
                column: "WorkIntervalId",
                principalTable: "WorkIntervals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deviations_ReasonGroups_ReasonGroupId",
                table: "Deviations");

            migrationBuilder.DropForeignKey(
                name: "FK_Deviations_Reasons_ReasonId",
                table: "Deviations");

            migrationBuilder.DropForeignKey(
                name: "FK_Deviations_Rows_RowId",
                table: "Deviations");

            migrationBuilder.DropForeignKey(
                name: "FK_Deviations_Users_ResponsibleUserId",
                table: "Deviations");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Departments_DepartmentId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Reasons_ReasonGroups_GroupId",
                table: "Reasons");

            migrationBuilder.DropForeignKey(
                name: "FK_Rows_ProductionAnalyses_ProductionAnalysisId",
                table: "Rows");

            migrationBuilder.DropForeignKey(
                name: "FK_Rows_Products_ProductId",
                table: "Rows");

            migrationBuilder.DropForeignKey(
                name: "FK_Rows_WorkIntervals_WorkIntervalId",
                table: "Rows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rows",
                table: "Rows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reasons",
                table: "Reasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReasonGroups",
                table: "ReasonGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipment",
                table: "Equipment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Deviations",
                table: "Deviations");

            migrationBuilder.RenameTable(
                name: "Rows",
                newName: "Row");

            migrationBuilder.RenameTable(
                name: "Reasons",
                newName: "Reason");

            migrationBuilder.RenameTable(
                name: "ReasonGroups",
                newName: "ReasonGroup");

            migrationBuilder.RenameTable(
                name: "Equipment",
                newName: "Equipments");

            migrationBuilder.RenameTable(
                name: "Deviations",
                newName: "Deviation");

            migrationBuilder.RenameIndex(
                name: "IX_Rows_WorkIntervalId",
                table: "Row",
                newName: "IX_Row_WorkIntervalId");

            migrationBuilder.RenameIndex(
                name: "IX_Rows_ProductionAnalysisId",
                table: "Row",
                newName: "IX_Row_ProductionAnalysisId");

            migrationBuilder.RenameIndex(
                name: "IX_Rows_ProductId",
                table: "Row",
                newName: "IX_Row_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Reasons_GroupId",
                table: "Reason",
                newName: "IX_Reason_GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_DepartmentId",
                table: "Equipments",
                newName: "IX_Equipments_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Deviations_RowId",
                table: "Deviation",
                newName: "IX_Deviation_RowId");

            migrationBuilder.RenameIndex(
                name: "IX_Deviations_ResponsibleUserId",
                table: "Deviation",
                newName: "IX_Deviation_ResponsibleUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Deviations_ReasonId",
                table: "Deviation",
                newName: "IX_Deviation_ReasonId");

            migrationBuilder.RenameIndex(
                name: "IX_Deviations_ReasonGroupId",
                table: "Deviation",
                newName: "IX_Deviation_ReasonGroupId");

            migrationBuilder.AddColumn<int>(
                name: "MultiplyProductionId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Row",
                table: "Row",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reason",
                table: "Reason",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReasonGroup",
                table: "ReasonGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipments",
                table: "Equipments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Deviation",
                table: "Deviation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DownTimeReasons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Group = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Responsobility = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownTimeReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HourlyDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductionAnalysisId = table.Column<int>(type: "integer", nullable: false),
                    ActualQuantity = table.Column<int>(type: "integer", nullable: false),
                    AnalysisId = table.Column<int>(type: "integer", nullable: false),
                    CumulativeActual = table.Column<int>(type: "integer", nullable: false),
                    CumulativePlan = table.Column<int>(type: "integer", nullable: false),
                    Deviation = table.Column<int>(type: "integer", nullable: false),
                    DowntimeMinutes = table.Column<int>(type: "integer", nullable: false),
                    HourInterval = table.Column<int>(type: "integer", nullable: false),
                    PlanQuantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlyDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourlyDates_ProductionAnalyses_ProductionAnalysisId",
                        column: x => x.ProductionAnalysisId,
                        principalTable: "ProductionAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LongCycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductionAnalysisId = table.Column<int>(type: "integer", nullable: false),
                    ActualEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActualStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AnalysisId = table.Column<int>(type: "integer", nullable: false),
                    DeviationMinutes = table.Column<int>(type: "integer", nullable: false),
                    OperationName = table.Column<string>(type: "text", nullable: false),
                    PlanEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PlanStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LongCycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LongCycles_ProductionAnalyses_ProductionAnalysisId",
                        column: x => x.ProductionAnalysisId,
                        principalTable: "ProductionAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultiplyProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductionAnalysisId = table.Column<int>(type: "integer", nullable: false),
                    AnalysisId = table.Column<int>(type: "integer", nullable: false),
                    ChangeOverTime = table.Column<int>(type: "integer", nullable: false),
                    CycleTime = table.Column<int>(type: "integer", nullable: false),
                    DailyTempo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiplyProductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiplyProductions_ProductionAnalyses_ProductionAnalysisId",
                        column: x => x.ProductionAnalysisId,
                        principalTable: "ProductionAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false),
                    ScenarioId = table.Column<int>(type: "integer", nullable: false),
                    ChangeoverMinutes = table.Column<int>(type: "integer", nullable: false),
                    CleaningMinutes = table.Column<int>(type: "integer", nullable: false),
                    LunchBreakMinutes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settings_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Settings_Scenarios_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_MultiplyProductionId",
                table: "Products",
                column: "MultiplyProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_HourlyDates_ProductionAnalysisId",
                table: "HourlyDates",
                column: "ProductionAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_LongCycles_ProductionAnalysisId",
                table: "LongCycles",
                column: "ProductionAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiplyProductions_ProductionAnalysisId",
                table: "MultiplyProductions",
                column: "ProductionAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_DepartmentId",
                table: "Settings",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_ScenarioId",
                table: "Settings",
                column: "ScenarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deviation_ReasonGroup_ReasonGroupId",
                table: "Deviation",
                column: "ReasonGroupId",
                principalTable: "ReasonGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deviation_Reason_ReasonId",
                table: "Deviation",
                column: "ReasonId",
                principalTable: "Reason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deviation_Row_RowId",
                table: "Deviation",
                column: "RowId",
                principalTable: "Row",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deviation_Users_ResponsibleUserId",
                table: "Deviation",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Departments_DepartmentId",
                table: "Equipments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MultiplyProductions_MultiplyProductionId",
                table: "Products",
                column: "MultiplyProductionId",
                principalTable: "MultiplyProductions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reason_ReasonGroup_GroupId",
                table: "Reason",
                column: "GroupId",
                principalTable: "ReasonGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Row_ProductionAnalyses_ProductionAnalysisId",
                table: "Row",
                column: "ProductionAnalysisId",
                principalTable: "ProductionAnalyses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Row_Products_ProductId",
                table: "Row",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Row_WorkIntervals_WorkIntervalId",
                table: "Row",
                column: "WorkIntervalId",
                principalTable: "WorkIntervals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
