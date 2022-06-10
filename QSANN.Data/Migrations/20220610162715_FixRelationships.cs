using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QSANN.Data.Migrations
{
    public partial class FixRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteBeamInputs_Projects_ProjectId",
                table: "ConcreteBeamInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteColumnInputs_Projects_ProjectId",
                table: "ConcreteColumnInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteOtherInputs_Projects_ProjectId",
                table: "ConcreteOtherInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteSlabInputs_Projects_ProjectId",
                table: "ConcreteSlabInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Projects_ProjectId1",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TileworksInputs_Projects_ProjectId",
                table: "TileworksInputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProjectId1",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ConcreteFootingInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LengthOfFooting = table.Column<string>(type: "TEXT", nullable: true),
                    WidthOfFooting = table.Column<string>(type: "TEXT", nullable: true),
                    HeightOfFooting = table.Column<string>(type: "TEXT", nullable: true),
                    NumbersOfCount = table.Column<string>(type: "TEXT", nullable: true),
                    ClassMixture = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteFootingInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcreteFootingInputs_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteFootingInputs_ProjectId",
                table: "ConcreteFootingInputs",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteBeamInputs_Project_ProjectId",
                table: "ConcreteBeamInputs",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteColumnInputs_Project_ProjectId",
                table: "ConcreteColumnInputs",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteOtherInputs_Project_ProjectId",
                table: "ConcreteOtherInputs",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteSlabInputs_Project_ProjectId",
                table: "ConcreteSlabInputs",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TileworksInputs_Project_ProjectId",
                table: "TileworksInputs",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteBeamInputs_Project_ProjectId",
                table: "ConcreteBeamInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteColumnInputs_Project_ProjectId",
                table: "ConcreteColumnInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteOtherInputs_Project_ProjectId",
                table: "ConcreteOtherInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_ConcreteSlabInputs_Project_ProjectId",
                table: "ConcreteSlabInputs");

            migrationBuilder.DropForeignKey(
                name: "FK_TileworksInputs_Project_ProjectId",
                table: "TileworksInputs");

            migrationBuilder.DropTable(
                name: "ConcreteFootingInputs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId1",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectId1",
                table: "Projects",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteBeamInputs_Projects_ProjectId",
                table: "ConcreteBeamInputs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteColumnInputs_Projects_ProjectId",
                table: "ConcreteColumnInputs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteOtherInputs_Projects_ProjectId",
                table: "ConcreteOtherInputs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConcreteSlabInputs_Projects_ProjectId",
                table: "ConcreteSlabInputs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
