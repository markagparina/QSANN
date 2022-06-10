using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QSANN.Data.Migrations
{
    public partial class AddConcreteTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tileworks_Projects_ProjectId",
                table: "Tileworks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tileworks",
                table: "Tileworks");

            migrationBuilder.RenameTable(
                name: "Tileworks",
                newName: "TileworksInputs");

            migrationBuilder.RenameIndex(
                name: "IX_Tileworks_ProjectId",
                table: "TileworksInputs",
                newName: "IX_TileworksInputs_ProjectId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: Guid.NewGuid());

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId1",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TileworksInputs",
                table: "TileworksInputs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ConcreteBeamInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LengthOfBeam = table.Column<string>(type: "TEXT", nullable: true),
                    WidthOfBeam = table.Column<string>(type: "TEXT", nullable: true),
                    HeightOfBeam = table.Column<string>(type: "TEXT", nullable: true),
                    NumbersOfCount = table.Column<string>(type: "TEXT", nullable: true),
                    ClassMixture = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteBeamInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcreteBeamInputs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcreteColumnInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LengthOfColumn = table.Column<string>(type: "TEXT", nullable: true),
                    WidthOfColumn = table.Column<string>(type: "TEXT", nullable: true),
                    HeightOfColumn = table.Column<string>(type: "TEXT", nullable: true),
                    NumbersOfCount = table.Column<string>(type: "TEXT", nullable: true),
                    ClassMixture = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteColumnInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcreteColumnInputs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcreteOtherInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TotalVolume = table.Column<string>(type: "TEXT", nullable: true),
                    NumbersOfCount = table.Column<string>(type: "TEXT", nullable: true),
                    ClassMixture = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteOtherInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcreteOtherInputs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcreteSlabInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LengthOfSlab = table.Column<string>(type: "TEXT", nullable: true),
                    WidthOfSlab = table.Column<string>(type: "TEXT", nullable: true),
                    HeightOfSlab = table.Column<string>(type: "TEXT", nullable: true),
                    NumbersOfCount = table.Column<string>(type: "TEXT", nullable: true),
                    ClassMixture = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteSlabInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcreteSlabInputs_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectId1",
                table: "Projects",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteBeamInputs_ProjectId",
                table: "ConcreteBeamInputs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteColumnInputs_ProjectId",
                table: "ConcreteColumnInputs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteOtherInputs_ProjectId",
                table: "ConcreteOtherInputs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteSlabInputs_ProjectId",
                table: "ConcreteSlabInputs",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Projects_ProjectId1",
                table: "Projects",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TileworksInputs_Projects_ProjectId",
                table: "TileworksInputs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Projects_ProjectId1",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TileworksInputs_Projects_ProjectId",
                table: "TileworksInputs");

            migrationBuilder.DropTable(
                name: "ConcreteBeamInputs");

            migrationBuilder.DropTable(
                name: "ConcreteColumnInputs");

            migrationBuilder.DropTable(
                name: "ConcreteOtherInputs");

            migrationBuilder.DropTable(
                name: "ConcreteSlabInputs");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectId1",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TileworksInputs",
                table: "TileworksInputs");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "TileworksInputs",
                newName: "Tileworks");

            migrationBuilder.RenameIndex(
                name: "IX_TileworksInputs_ProjectId",
                table: "Tileworks",
                newName: "IX_Tileworks_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tileworks",
                table: "Tileworks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tileworks_Projects_ProjectId",
                table: "Tileworks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}