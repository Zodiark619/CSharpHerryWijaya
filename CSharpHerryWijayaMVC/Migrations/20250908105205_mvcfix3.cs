using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpHerryWijayaMVC.Migrations
{
    /// <inheritdoc />
    public partial class mvcfix3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ModuleDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "Category",
                value: "DEF");

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "Category",
                value: "Max Shield");

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "Category",
                value: "Toxic Skill Power");

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "Category",
                value: "All Attribute Resistances");

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "Category",
                value: "-");

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "Category",
                value: "-");

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "Category",
                value: "Skill Effect Range");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "ModuleDetails");
        }
    }
}
