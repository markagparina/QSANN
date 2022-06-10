using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QSANN.Data.Migrations
{
    public partial class ThicknessOfFooting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HeightOfFooting",
                table: "ConcreteFootingInputs",
                newName: "ThicknessOfFooting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThicknessOfFooting",
                table: "ConcreteFootingInputs",
                newName: "HeightOfFooting");
        }
    }
}
