using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QSANN.Data.Migrations
{
    public partial class OutputEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonitoringProject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonitoringProject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarpentryWorksOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Plyboard = table.Column<decimal>(type: "TEXT", nullable: false),
                    SizeOfLumber = table.Column<decimal>(type: "TEXT", nullable: false),
                    CommonWireNail = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredPlyboard = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredSizeOfLumber = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredCommonWireNail = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarpentryWorksOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarpentryWorksOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcreteBeamOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CementMixture = table.Column<decimal>(type: "TEXT", nullable: false),
                    Sand = table.Column<decimal>(type: "TEXT", nullable: false),
                    Gravel = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredCementMixture = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredSand = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredGravel = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteBeamOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcreteBeamOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcreteColumnOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CementMixture = table.Column<decimal>(type: "TEXT", nullable: false),
                    Sand = table.Column<decimal>(type: "TEXT", nullable: false),
                    Gravel = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredCementMixture = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredSand = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredGravel = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteColumnOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcreteColumnOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcreteFootingOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CementMixture = table.Column<decimal>(type: "TEXT", nullable: false),
                    Sand = table.Column<decimal>(type: "TEXT", nullable: false),
                    Gravel = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredCementMixture = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredSand = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredGravel = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteFootingOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcreteFootingOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcreteOtherOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CementMixture = table.Column<decimal>(type: "TEXT", nullable: false),
                    Sand = table.Column<decimal>(type: "TEXT", nullable: false),
                    Gravel = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteOtherOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcreteOtherOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConcreteSlabOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CementMixture = table.Column<decimal>(type: "TEXT", nullable: false),
                    Sand = table.Column<decimal>(type: "TEXT", nullable: false),
                    Gravel = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredCementMixture = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredSand = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredGravel = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcreteSlabOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcreteSlabOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormworksBeamOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NumberOfPlywood = table.Column<decimal>(type: "TEXT", nullable: false),
                    NumberOfBoardFeetLumber = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredNumberOfPlywood = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredNumberOfBoardFeetLumber = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormworksBeamOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormworksBeamOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormworksColumnOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NumberOfPlywood = table.Column<decimal>(type: "TEXT", nullable: false),
                    NumberOfBoardFeetLumber = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredNumberOfPlywood = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredNumberOfBoardFeetLumber = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormworksColumnOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormworksColumnOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasonryOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConcreteHollowBlocks = table.Column<decimal>(type: "TEXT", nullable: false),
                    Cement = table.Column<decimal>(type: "TEXT", nullable: false),
                    Sand = table.Column<decimal>(type: "TEXT", nullable: false),
                    HorizontalBars = table.Column<decimal>(type: "TEXT", nullable: false),
                    VerticalBars = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredConcreteHollowBlocks = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredCement = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredSand = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredHorizontalBars = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredVerticalBars = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasonryOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasonryOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OtherMaterialOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherMaterialOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherMaterialOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaintworksOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PrimerPaint = table.Column<decimal>(type: "TEXT", nullable: false),
                    SideBySideCoating = table.Column<decimal>(type: "TEXT", nullable: false),
                    Neutralizer = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredPrimerPaint = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredSideBySideCoating = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredNeutralizer = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaintworksOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaintworksOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RebarworksBeamOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Mainbar = table.Column<decimal>(type: "TEXT", nullable: false),
                    ShortBeamLength = table.Column<decimal>(type: "TEXT", nullable: false),
                    Tiewire = table.Column<decimal>(type: "TEXT", nullable: false),
                    LateralTies = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredMainbar = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredShortBeamLength = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredTiewire = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredLateralTies = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebarworksBeamOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RebarworksBeamOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RebarworksColumnOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Mainbar = table.Column<decimal>(type: "TEXT", nullable: false),
                    Tiewire = table.Column<decimal>(type: "TEXT", nullable: false),
                    LateralTies = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredMainbar = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredTiewire = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredLateralTies = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebarworksColumnOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RebarworksColumnOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RebarworksFootingOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Steelbar = table.Column<decimal>(type: "TEXT", nullable: false),
                    Tiewire = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredSteelbar = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredTiewire = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebarworksFootingOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RebarworksFootingOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RebarworksSlabOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Steelbar = table.Column<decimal>(type: "TEXT", nullable: false),
                    Tiewire = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredSteelbar = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredTiewire = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RebarworksSlabOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RebarworksSlabOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TileworksOutputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NumberOfPieces = table.Column<decimal>(type: "TEXT", nullable: false),
                    NumberOf40KgBagsOfCement = table.Column<decimal>(type: "TEXT", nullable: false),
                    NumberOfBagOfAdhesive = table.Column<decimal>(type: "TEXT", nullable: false),
                    NumberOfKgOfGrout = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredNumberOfPieces = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredNumberOf40KgBagsOfCement = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredNumberOfBagOfAdhesive = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalDeliveredNumberOfKgOfGrout = table.Column<decimal>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MonitoringProjectId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TileworksOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TileworksOutputs_MonitoringProject_MonitoringProjectId",
                        column: x => x.MonitoringProjectId,
                        principalTable: "MonitoringProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarpentryWorksOutputs_MonitoringProjectId",
                table: "CarpentryWorksOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteBeamOutputs_MonitoringProjectId",
                table: "ConcreteBeamOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteColumnOutputs_MonitoringProjectId",
                table: "ConcreteColumnOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteFootingOutputs_MonitoringProjectId",
                table: "ConcreteFootingOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteOtherOutputs_MonitoringProjectId",
                table: "ConcreteOtherOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcreteSlabOutputs_MonitoringProjectId",
                table: "ConcreteSlabOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FormworksBeamOutputs_MonitoringProjectId",
                table: "FormworksBeamOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FormworksColumnOutputs_MonitoringProjectId",
                table: "FormworksColumnOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MasonryOutputs_MonitoringProjectId",
                table: "MasonryOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherMaterialOutputs_MonitoringProjectId",
                table: "OtherMaterialOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PaintworksOutputs_MonitoringProjectId",
                table: "PaintworksOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RebarworksBeamOutputs_MonitoringProjectId",
                table: "RebarworksBeamOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RebarworksColumnOutputs_MonitoringProjectId",
                table: "RebarworksColumnOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RebarworksFootingOutputs_MonitoringProjectId",
                table: "RebarworksFootingOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RebarworksSlabOutputs_MonitoringProjectId",
                table: "RebarworksSlabOutputs",
                column: "MonitoringProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TileworksOutputs_MonitoringProjectId",
                table: "TileworksOutputs",
                column: "MonitoringProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarpentryWorksOutputs");

            migrationBuilder.DropTable(
                name: "ConcreteBeamOutputs");

            migrationBuilder.DropTable(
                name: "ConcreteColumnOutputs");

            migrationBuilder.DropTable(
                name: "ConcreteFootingOutputs");

            migrationBuilder.DropTable(
                name: "ConcreteOtherOutputs");

            migrationBuilder.DropTable(
                name: "ConcreteSlabOutputs");

            migrationBuilder.DropTable(
                name: "FormworksBeamOutputs");

            migrationBuilder.DropTable(
                name: "FormworksColumnOutputs");

            migrationBuilder.DropTable(
                name: "MasonryOutputs");

            migrationBuilder.DropTable(
                name: "OtherMaterialOutputs");

            migrationBuilder.DropTable(
                name: "PaintworksOutputs");

            migrationBuilder.DropTable(
                name: "RebarworksBeamOutputs");

            migrationBuilder.DropTable(
                name: "RebarworksColumnOutputs");

            migrationBuilder.DropTable(
                name: "RebarworksFootingOutputs");

            migrationBuilder.DropTable(
                name: "RebarworksSlabOutputs");

            migrationBuilder.DropTable(
                name: "TileworksOutputs");

            migrationBuilder.DropTable(
                name: "MonitoringProject");
        }
    }
}
