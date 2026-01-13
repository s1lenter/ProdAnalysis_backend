using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductionAnalysisBackend.Migrations
{
    /// <inheritdoc />
    public partial class EditDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionAnalyses_Users_UserId",
                table: "ProductionAnalyses");

            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_Users_CreatorId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_CreatorId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "ActualQuantity",
                table: "ProductionAnalyses");

            migrationBuilder.DropColumn(
                name: "DowntimeMinutes",
                table: "ProductionAnalyses");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "ProductionAnalyses");

            migrationBuilder.DropColumn(
                name: "PlanQuantity",
                table: "ProductionAnalyses");

            migrationBuilder.DropColumn(
                name: "TakenMeasures",
                table: "ProductionAnalyses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Users",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "WorkDate",
                table: "ProductionAnalyses",
                newName: "SendToReviewAt");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ProductionAnalyses",
                newName: "OperatorId");

            migrationBuilder.RenameColumn(
                name: "ReasonId",
                table: "ProductionAnalyses",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductionAnalyses",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductionAnalyses_UserId",
                table: "ProductionAnalyses",
                newName: "IX_ProductionAnalyses_OperatorId");

            migrationBuilder.AddColumn<int>(
                name: "ProductionAnalysisId",
                table: "WorkIntervals",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Scenarios",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ScenarioId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedAt",
                table: "ProductionAnalyses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    ProductionAnalysisId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_ProductionAnalyses_ProductionAnalysisId",
                        column: x => x.ProductionAnalysisId,
                        principalTable: "ProductionAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parameter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaktTimeSec = table.Column<int>(type: "integer", nullable: false),
                    CycleTimeSec = table.Column<int>(type: "integer", nullable: false),
                    DailyTarget = table.Column<int>(type: "integer", nullable: false),
                    PowerPerHour = table.Column<int>(type: "integer", nullable: false),
                    LunchBreakMinutes = table.Column<int>(type: "integer", nullable: false),
                    ChangeOverMinutes = table.Column<int>(type: "integer", nullable: false),
                    CleaningMinutes = table.Column<int>(type: "integer", nullable: false),
                    ProductionAnalysisId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parameter_ProductionAnalyses_ProductionAnalysisId",
                        column: x => x.ProductionAnalysisId,
                        principalTable: "ProductionAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReasonGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Row",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlanQTY = table.Column<int>(type: "integer", nullable: false),
                    PlanCumulative = table.Column<int>(type: "integer", nullable: false),
                    FactQTY = table.Column<int>(type: "integer", nullable: false),
                    FactCumulative = table.Column<int>(type: "integer", nullable: false),
                    DowntimeMinutes = table.Column<int>(type: "integer", nullable: false),
                    ProductionAnalysisId = table.Column<int>(type: "integer", nullable: false),
                    WorkIntervalId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Row", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Row_ProductionAnalyses_ProductionAnalysisId",
                        column: x => x.ProductionAnalysisId,
                        principalTable: "ProductionAnalyses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Row_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Row_WorkIntervals_WorkIntervalId",
                        column: x => x.WorkIntervalId,
                        principalTable: "WorkIntervals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reason",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    ReasonGroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reason", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reason_ReasonGroup_ReasonGroupId",
                        column: x => x.ReasonGroupId,
                        principalTable: "ReasonGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deviation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    TakenMeasures = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    RowId = table.Column<int>(type: "integer", nullable: false),
                    ReasonGroupId = table.Column<int>(type: "integer", nullable: false),
                    ReasonId = table.Column<int>(type: "integer", nullable: false),
                    ResponsibleUserId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deviation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deviation_ReasonGroup_ReasonGroupId",
                        column: x => x.ReasonGroupId,
                        principalTable: "ReasonGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deviation_Reason_ReasonId",
                        column: x => x.ReasonId,
                        principalTable: "Reason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deviation_Row_RowId",
                        column: x => x.RowId,
                        principalTable: "Row",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deviation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkIntervals_ProductionAnalysisId",
                table: "WorkIntervals",
                column: "ProductionAnalysisId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ScenarioId",
                table: "Products",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionAnalyses_DepartmentId",
                table: "ProductionAnalyses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionAnalyses_ScenarioId",
                table: "ProductionAnalyses",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionAnalyses_ShiftId",
                table: "ProductionAnalyses",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProductionAnalysisId",
                table: "Comment",
                column: "ProductionAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_Deviation_ReasonGroupId",
                table: "Deviation",
                column: "ReasonGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Deviation_ReasonId",
                table: "Deviation",
                column: "ReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Deviation_RowId",
                table: "Deviation",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_Deviation_UserId",
                table: "Deviation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Parameter_ProductionAnalysisId",
                table: "Parameter",
                column: "ProductionAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_Reason_ReasonGroupId",
                table: "Reason",
                column: "ReasonGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Row_ProductId",
                table: "Row",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Row_ProductionAnalysisId",
                table: "Row",
                column: "ProductionAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_Row_WorkIntervalId",
                table: "Row",
                column: "WorkIntervalId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionAnalyses_Departments_DepartmentId",
                table: "ProductionAnalyses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionAnalyses_Scenarios_ScenarioId",
                table: "ProductionAnalyses",
                column: "ScenarioId",
                principalTable: "Scenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionAnalyses_Shifts_ShiftId",
                table: "ProductionAnalyses",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionAnalyses_Users_OperatorId",
                table: "ProductionAnalyses",
                column: "OperatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Scenarios_ScenarioId",
                table: "Products",
                column: "ScenarioId",
                principalTable: "Scenarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkIntervals_ProductionAnalyses_ProductionAnalysisId",
                table: "WorkIntervals",
                column: "ProductionAnalysisId",
                principalTable: "ProductionAnalyses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionAnalyses_Departments_DepartmentId",
                table: "ProductionAnalyses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionAnalyses_Scenarios_ScenarioId",
                table: "ProductionAnalyses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionAnalyses_Shifts_ShiftId",
                table: "ProductionAnalyses");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionAnalyses_Users_OperatorId",
                table: "ProductionAnalyses");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Scenarios_ScenarioId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkIntervals_ProductionAnalyses_ProductionAnalysisId",
                table: "WorkIntervals");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Deviation");

            migrationBuilder.DropTable(
                name: "Parameter");

            migrationBuilder.DropTable(
                name: "Reason");

            migrationBuilder.DropTable(
                name: "Row");

            migrationBuilder.DropTable(
                name: "ReasonGroup");

            migrationBuilder.DropIndex(
                name: "IX_WorkIntervals_ProductionAnalysisId",
                table: "WorkIntervals");

            migrationBuilder.DropIndex(
                name: "IX_Products_ScenarioId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductionAnalyses_DepartmentId",
                table: "ProductionAnalyses");

            migrationBuilder.DropIndex(
                name: "IX_ProductionAnalyses_ScenarioId",
                table: "ProductionAnalyses");

            migrationBuilder.DropIndex(
                name: "IX_ProductionAnalyses_ShiftId",
                table: "ProductionAnalyses");

            migrationBuilder.DropColumn(
                name: "ProductionAnalysisId",
                table: "WorkIntervals");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Scenarios");

            migrationBuilder.DropColumn(
                name: "ScenarioId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ApprovedAt",
                table: "ProductionAnalyses");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Users",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "SendToReviewAt",
                table: "ProductionAnalyses",
                newName: "WorkDate");

            migrationBuilder.RenameColumn(
                name: "OperatorId",
                table: "ProductionAnalyses",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "ProductionAnalyses",
                newName: "ReasonId");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "ProductionAnalyses",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductionAnalyses_OperatorId",
                table: "ProductionAnalyses",
                newName: "IX_ProductionAnalyses_UserId");

            migrationBuilder.AddColumn<int>(
                name: "ActualQuantity",
                table: "ProductionAnalyses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DowntimeMinutes",
                table: "ProductionAnalyses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "ProductionAnalyses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanQuantity",
                table: "ProductionAnalyses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TakenMeasures",
                table: "ProductionAnalyses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_CreatorId",
                table: "Shifts",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionAnalyses_Users_UserId",
                table: "ProductionAnalyses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_Users_CreatorId",
                table: "Shifts",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
