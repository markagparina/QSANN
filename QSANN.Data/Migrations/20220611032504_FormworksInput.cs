using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QSANN.Data.Migrations
{
    public partial class FormworksInput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormworksBeamInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LengthOfBeam = table.Column<string>(type: "TEXT", nullable: true),
                    WidthOfBeam = table.Column<string>(type: "TEXT", nullable: true),
                    HeightOfBeam = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfCounts = table.Column<string>(type: "TEXT", nullable: true),
                    LumberSize = table.Column<string>(type: "TEXT", nullable: true),
                    ThicknessOfPlywood = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormworksBeamInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormworksBeamInputs_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormworksColumnInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LengthOfColumn = table.Column<string>(type: "TEXT", nullable: true),
                    WidthOfColumn = table.Column<string>(type: "TEXT", nullable: true),
                    HeightOfColumn = table.Column<string>(type: "TEXT", nullable: true),
                    NumberOfCounts = table.Column<string>(type: "TEXT", nullable: true),
                    LumberSize = table.Column<string>(type: "TEXT", nullable: true),
                    ThicknessOfPlywood = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormworksColumnInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormworksColumnInputs_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormworksBeamInputs_ProjectId",
                table: "FormworksBeamInputs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FormworksColumnInputs_ProjectId",
                table: "FormworksColumnInputs",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormworksBeamInputs");

            migrationBuilder.DropTable(
                name: "FormworksColumnInputs");
        }
    }
}
