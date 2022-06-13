using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QSANN.Data.Migrations
{
    public partial class AllRemainingInputTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarpentryworksInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AreaOfDesignation = table.Column<string>(type: "TEXT", nullable: true),
                    SizeOfLumber = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarpentryworksInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarpentryworksInputs_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherMaterials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemName = table.Column<string>(type: "TEXT", nullable: true),
                    ConstructionScope = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherMaterials_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaintworksInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AreaOfApplication = table.Column<string>(type: "TEXT", nullable: true),
                    Finish = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintworksInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaintworksInputs_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RebarworksBeamInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LengthOfBeam = table.Column<string>(type: "TEXT", nullable: true),
                    WidthOfBeam = table.Column<string>(type: "TEXT", nullable: true),
                    HeightOfBeam = table.Column<string>(type: "TEXT", nullable: true),
                    NumbersOfBeam = table.Column<string>(type: "TEXT", nullable: true),
                    SizeOfMainbar = table.Column<string>(type: "TEXT", nullable: true),
                    SizeOfStirrups = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebarworksBeamInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RebarworksBeamInputs_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RebarworksColumnInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LengthOfColumn = table.Column<string>(type: "TEXT", nullable: true),
                    WidthOfColumn = table.Column<string>(type: "TEXT", nullable: true),
                    HeightOfColumn = table.Column<string>(type: "TEXT", nullable: true),
                    NumbersOfColumn = table.Column<string>(type: "TEXT", nullable: true),
                    SizeOfMainBar = table.Column<string>(type: "TEXT", nullable: true),
                    SizeOfLateralties = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebarworksColumnInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RebarworksColumnInputs_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RebarworksFootingInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    LengthOfFooting = table.Column<string>(type: "TEXT", nullable: true),
                    WidthOfFooting = table.Column<string>(type: "TEXT", nullable: true),
                    NumbersOfFoooting = table.Column<string>(type: "TEXT", nullable: true),
                    SizeOfSteelbar = table.Column<string>(type: "TEXT", nullable: true),
                    SpacingOfSteelbar = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebarworksFootingInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RebarworksFootingInputs_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RebarworksSlabInputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FloorArea = table.Column<string>(type: "TEXT", nullable: true),
                    SteelbarSpacing = table.Column<string>(type: "TEXT", nullable: true),
                    SizeOfSteelbar = table.Column<string>(type: "TEXT", nullable: true),
                    OneWayOrTwoWay = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebarworksSlabInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RebarworksSlabInputs_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarpentryworksInputs_ProjectId",
                table: "CarpentryworksInputs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherMaterials_ProjectId",
                table: "OtherMaterials",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PaintworksInputs_ProjectId",
                table: "PaintworksInputs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RebarworksBeamInputs_ProjectId",
                table: "RebarworksBeamInputs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RebarworksColumnInputs_ProjectId",
                table: "RebarworksColumnInputs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RebarworksFootingInputs_ProjectId",
                table: "RebarworksFootingInputs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RebarworksSlabInputs_ProjectId",
                table: "RebarworksSlabInputs",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarpentryworksInputs");

            migrationBuilder.DropTable(
                name: "OtherMaterials");

            migrationBuilder.DropTable(
                name: "PaintworksInputs");

            migrationBuilder.DropTable(
                name: "RebarworksBeamInputs");

            migrationBuilder.DropTable(
                name: "RebarworksColumnInputs");

            migrationBuilder.DropTable(
                name: "RebarworksFootingInputs");

            migrationBuilder.DropTable(
                name: "RebarworksSlabInputs");
        }
    }
}
