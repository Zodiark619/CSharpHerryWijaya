using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpHerryWijayaMVC.Migrations
{
    /// <inheritdoc />
    public partial class mvcfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ModuleDetails");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Module",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "DEF +166.80%, Max Shield -36.50%");

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Toxic Skill Power +81.2");

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "All Attribute Resistances +640.80");

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "When Shield is at 0%, DEF +128.30%");

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "When an enemy inflicted with Room 0 Trauma is killed, a contagion of Room 0 Trauma surrounds it.");

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Skill Speed & Range Increase Modifier +19.20%");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Module");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ModuleDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "DEF +166.80%, Max Shield -36.50%");

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "DEF +166.80%, Max Shield -36.50%");

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Toxic Skill Power +81.2");

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "All Attribute Resistances +640.80");

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "When Shield is at 0%, DEF +128.30%");

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "When an enemy inflicted with Room 0 Trauma is killed, a contagion of Room 0 Trauma surrounds it.");

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Skill Speed & Range Increase Modifier +19.20%");
        }
    }
}
