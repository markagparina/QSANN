using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QSANN.Data.Migrations
{
    public partial class ThicknessOfSlab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeightOfSlab",
                table: "ConcreteSlabInputs",
                newName: "ThicknessOfSlab");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThicknessOfSlab",
                table: "ConcreteSlabInputs",
                newName: "HeightOfSlab");
        }
    }
}
