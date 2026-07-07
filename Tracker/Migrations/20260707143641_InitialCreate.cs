#nullable disable

namespace Tracker.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Severity = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReferenceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Projects_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DepartmentLeadId = table.Column<int>(type: "integer", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_People_DepartmentLeadId",
                        column: x => x.DepartmentLeadId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    ReferenceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machines_Machines_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Machines_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineComputerPersons",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "integer", nullable: false),
                    Machine4Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineComputerPersons", x => new { x.ComputerId, x.Machine4Id });
                    table.ForeignKey(
                        name: "FK_MachineComputerPersons_Machines_Machine4Id",
                        column: x => x.Machine4Id,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineComputerPersons_People_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineControlsPersons",
                columns: table => new
                {
                    ControlsId = table.Column<int>(type: "integer", nullable: false),
                    Machine1Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineControlsPersons", x => new { x.ControlsId, x.Machine1Id });
                    table.ForeignKey(
                        name: "FK_MachineControlsPersons_Machines_Machine1Id",
                        column: x => x.Machine1Id,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineControlsPersons_People_ControlsId",
                        column: x => x.ControlsId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineFluidPersons",
                columns: table => new
                {
                    FluidId = table.Column<int>(type: "integer", nullable: false),
                    Machine2Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineFluidPersons", x => new { x.FluidId, x.Machine2Id });
                    table.ForeignKey(
                        name: "FK_MachineFluidPersons_Machines_Machine2Id",
                        column: x => x.Machine2Id,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineFluidPersons_People_FluidId",
                        column: x => x.FluidId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineProgrammingPersons",
                columns: table => new
                {
                    Machine6Id = table.Column<int>(type: "integer", nullable: false),
                    ProgrammingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineProgrammingPersons", x => new { x.Machine6Id, x.ProgrammingId });
                    table.ForeignKey(
                        name: "FK_MachineProgrammingPersons_Machines_Machine6Id",
                        column: x => x.Machine6Id,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineProgrammingPersons_People_ProgrammingId",
                        column: x => x.ProgrammingId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineProjectPersons",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineProjectPersons", x => new { x.MachineId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_MachineProjectPersons_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineProjectPersons_People_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineQualityPersons",
                columns: table => new
                {
                    Machine7Id = table.Column<int>(type: "integer", nullable: false),
                    QualityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineQualityPersons", x => new { x.Machine7Id, x.QualityId });
                    table.ForeignKey(
                        name: "FK_MachineQualityPersons_Machines_Machine7Id",
                        column: x => x.Machine7Id,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineQualityPersons_People_QualityId",
                        column: x => x.QualityId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineServicePersons",
                columns: table => new
                {
                    Machine8Id = table.Column<int>(type: "integer", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineServicePersons", x => new { x.Machine8Id, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_MachineServicePersons_Machines_Machine8Id",
                        column: x => x.Machine8Id,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineServicePersons_People_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineSoftwarePersons",
                columns: table => new
                {
                    Machine3Id = table.Column<int>(type: "integer", nullable: false),
                    SoftwareId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineSoftwarePersons", x => new { x.Machine3Id, x.SoftwareId });
                    table.ForeignKey(
                        name: "FK_MachineSoftwarePersons_Machines_Machine3Id",
                        column: x => x.Machine3Id,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineSoftwarePersons_People_SoftwareId",
                        column: x => x.SoftwareId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineVisionPersons",
                columns: table => new
                {
                    Machine5Id = table.Column<int>(type: "integer", nullable: false),
                    VisionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineVisionPersons", x => new { x.Machine5Id, x.VisionId });
                    table.ForeignKey(
                        name: "FK_MachineVisionPersons_Machines_Machine5Id",
                        column: x => x.Machine5Id,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineVisionPersons_People_VisionId",
                        column: x => x.VisionId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachineComputerPersons_Machine4Id",
                table: "MachineComputerPersons",
                column: "Machine4Id");

            migrationBuilder.CreateIndex(
                name: "IX_MachineControlsPersons_Machine1Id",
                table: "MachineControlsPersons",
                column: "Machine1Id");

            migrationBuilder.CreateIndex(
                name: "IX_MachineFluidPersons_Machine2Id",
                table: "MachineFluidPersons",
                column: "Machine2Id");

            migrationBuilder.CreateIndex(
                name: "IX_MachineProgrammingPersons_ProgrammingId",
                table: "MachineProgrammingPersons",
                column: "ProgrammingId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineProjectPersons_ProjectId",
                table: "MachineProjectPersons",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineQualityPersons_QualityId",
                table: "MachineQualityPersons",
                column: "QualityId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_ProjectId",
                table: "Machines",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_ReferenceId",
                table: "Machines",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineServicePersons_ServiceId",
                table: "MachineServicePersons",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineSoftwarePersons_SoftwareId",
                table: "MachineSoftwarePersons",
                column: "SoftwareId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineVisionPersons_VisionId",
                table: "MachineVisionPersons",
                column: "VisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ReferenceId",
                table: "Projects",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_DepartmentLeadId",
                table: "Roles",
                column: "DepartmentLeadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "MachineComputerPersons");

            migrationBuilder.DropTable(
                name: "MachineControlsPersons");

            migrationBuilder.DropTable(
                name: "MachineFluidPersons");

            migrationBuilder.DropTable(
                name: "MachineProgrammingPersons");

            migrationBuilder.DropTable(
                name: "MachineProjectPersons");

            migrationBuilder.DropTable(
                name: "MachineQualityPersons");

            migrationBuilder.DropTable(
                name: "MachineServicePersons");

            migrationBuilder.DropTable(
                name: "MachineSoftwarePersons");

            migrationBuilder.DropTable(
                name: "MachineVisionPersons");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
