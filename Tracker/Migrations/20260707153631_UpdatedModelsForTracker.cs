namespace Tracker.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class UpdatedModelsForTracker : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Issues",
                newName: "Title");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Projects",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AssignedToId",
                table: "Issues",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Issues",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsResolved",
                table: "Issues",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "Issues",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Issues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReportedById",
                table: "Issues",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReportedDate",
                table: "Issues",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ResolutionNotes",
                table: "Issues",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResolvedDate",
                table: "Issues",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectPeople",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPeople", x => new { x.PeopleId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectPeople_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectPeople_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_AssignedToId",
                table: "Issues",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_MachineId",
                table: "Issues",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ProjectId",
                table: "Issues",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_ReportedById",
                table: "Issues",
                column: "ReportedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPeople_ProjectId",
                table: "ProjectPeople",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Machines_MachineId",
                table: "Issues",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_People_AssignedToId",
                table: "Issues",
                column: "AssignedToId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_People_ReportedById",
                table: "Issues",
                column: "ReportedById",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Projects_ProjectId",
                table: "Issues",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Machines_MachineId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_People_AssignedToId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_People_ReportedById",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Projects_ProjectId",
                table: "Issues");

            migrationBuilder.DropTable(
                name: "ProjectPeople");

            migrationBuilder.DropIndex(
                name: "IX_Issues_AssignedToId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_MachineId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_ProjectId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_ReportedById",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AssignedToId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "IsResolved",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ReportedById",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ReportedDate",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ResolutionNotes",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ResolvedDate",
                table: "Issues");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Issues",
                newName: "Message");
        }
    }
}
