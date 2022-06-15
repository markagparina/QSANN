using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QSANN.Data.Migrations
{
    public partial class SizeOfMainbarTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SizeOfMainBar",
                table: "RebarworksColumnInputs",
                newName: "SizeOfMainbar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SizeOfMainbar",
                table: "RebarworksColumnInputs",
                newName: "SizeOfMainBar");
        }
    }
}
