using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QSANN.Data.Migrations
{
    public partial class MasonryInput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasonryInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    HeightOfWall = table.Column<string>(type: "TEXT", nullable: true),
                    LengthOfWall = table.Column<string>(type: "TEXT", nullable: true),
                    HorizontalBarSpacing = table.Column<string>(type: "TEXT", nullable: true),
                    VerticalBarSpacing = table.Column<string>(type: "TEXT", nullable: true),
                    ClassMixtureForMortar = table.Column<string>(type: "TEXT", nullable: true),
                    ThicknessInMillimeter = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasonryInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasonryInputs_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MasonryInputs_ProjectId",
                table: "MasonryInputs",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasonryInputs");
        }
    }
}
