using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductionAnalysisBackend.Migrations
{
    /// <inheritdoc />
    public partial class FinalFixRelations : Migration
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
                name: "FK_Deviation_Users_UserId",
                table: "Deviation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reason_ReasonGroup_ReasonGroupId",
                table: "Reason");

            migrationBuilder.DropIndex(
                name: "IX_Reason_ReasonGroupId",
                table: "Reason");

            migrationBuilder.DropIndex(
                name: "IX_Deviation_UserId",
                table: "Deviation");

            migrationBuilder.DropColumn(
                name: "ReasonGroupId",
                table: "Reason");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Deviation");

            migrationBuilder.AlterColumn<string>(
                name: "TakenMeasures",
                table: "Deviation",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Deviation",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Reason_GroupId",
                table: "Reason",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Deviation_ResponsibleUserId",
                table: "Deviation",
                column: "ResponsibleUserId");

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
                name: "FK_Deviation_Users_ResponsibleUserId",
                table: "Deviation",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reason_ReasonGroup_GroupId",
                table: "Reason",
                column: "GroupId",
                principalTable: "ReasonGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deviation_ReasonGroup_ReasonGroupId",
                table: "Deviation");

            migrationBuilder.DropForeignKey(
                name: "FK_Deviation_Reason_ReasonId",
                table: "Deviation");

            migrationBuilder.DropForeignKey(
                name: "FK_Deviation_Users_ResponsibleUserId",
                table: "Deviation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reason_ReasonGroup_GroupId",
                table: "Reason");

            migrationBuilder.DropIndex(
                name: "IX_Reason_GroupId",
                table: "Reason");

            migrationBuilder.DropIndex(
                name: "IX_Deviation_ResponsibleUserId",
                table: "Deviation");

            migrationBuilder.AddColumn<int>(
                name: "ReasonGroupId",
                table: "Reason",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "TakenMeasures",
                table: "Deviation",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Deviation",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Deviation",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reason_ReasonGroupId",
                table: "Reason",
                column: "ReasonGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Deviation_UserId",
                table: "Deviation",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deviation_ReasonGroup_ReasonGroupId",
                table: "Deviation",
                column: "ReasonGroupId",
                principalTable: "ReasonGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deviation_Reason_ReasonId",
                table: "Deviation",
                column: "ReasonId",
                principalTable: "Reason",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deviation_Users_UserId",
                table: "Deviation",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reason_ReasonGroup_ReasonGroupId",
                table: "Reason",
                column: "ReasonGroupId",
                principalTable: "ReasonGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
