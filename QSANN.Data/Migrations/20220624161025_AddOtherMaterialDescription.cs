using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QSANN.Data.Migrations
{
    public partial class AddOtherMaterialDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OtherMaterials",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConstructionScope",
                table: "OtherMaterialOutputs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OtherMaterialOutputs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "OtherMaterialOutputs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "OtherMaterialOutputs",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RunningCost",
                table: "OtherMaterialOutputs",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "OtherMaterials");

            migrationBuilder.DropColumn(
                name: "ConstructionScope",
                table: "OtherMaterialOutputs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OtherMaterialOutputs");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "OtherMaterialOutputs");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OtherMaterialOutputs");

            migrationBuilder.DropColumn(
                name: "RunningCost",
                table: "OtherMaterialOutputs");
        }
    }
}
