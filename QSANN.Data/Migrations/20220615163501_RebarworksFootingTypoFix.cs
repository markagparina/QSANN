using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QSANN.Data.Migrations
{
    public partial class RebarworksFootingTypoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumbersOfFoooting",
                table: "RebarworksFootingInputs",
                newName: "NumbersOfFooting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumbersOfFooting",
                table: "RebarworksFootingInputs",
                newName: "NumbersOfFoooting");
        }
    }
}
