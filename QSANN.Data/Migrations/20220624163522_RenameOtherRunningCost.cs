using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QSANN.Data.Migrations
{
    public partial class RenameOtherRunningCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RunningCost",
                table: "OtherMaterialOutputs",
                newName: "TotalCost");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalCost",
                table: "OtherMaterialOutputs",
                newName: "RunningCost");
        }
    }
}
