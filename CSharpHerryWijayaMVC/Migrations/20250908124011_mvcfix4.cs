using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSharpHerryWijayaMVC.Migrations
{
    /// <inheritdoc />
    public partial class mvcfix4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "ModuleDetails");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Module");

            migrationBuilder.AddColumn<int>(
                name: "ModuleStatsId",
                table: "ModuleDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ModuleCategoryId",
                table: "Module",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ModuleCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModuleStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleStats", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModuleCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModuleCategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModuleCategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 4,
                column: "ModuleCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 5,
                column: "ModuleCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 6,
                column: "ModuleCategoryId",
                value: 1);

            migrationBuilder.InsertData(
                table: "ModuleCategory",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "None" },
                    { 2, "Defense" },
                    { 3, "Battle" },
                    { 4, "Support Tech" },
                    { 5, "Transcendent" }
                });

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "ModuleStatsId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "ModuleStatsId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "ModuleStatsId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 4,
                column: "ModuleStatsId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 5,
                column: "ModuleStatsId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 6,
                column: "ModuleStatsId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ModuleDetails",
                keyColumn: "Id",
                keyValue: 7,
                column: "ModuleStatsId",
                value: 2);

            migrationBuilder.InsertData(
                table: "ModuleStats",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "DEF" },
                    { 2, "Skill Effect Range" },
                    { 3, "Toxic Skill Power" },
                    { 4, "All Attribute Resistances" },
                    { 5, "-" },
                    { 6, "Max Shield" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleDetails_ModuleStatsId",
                table: "ModuleDetails",
                column: "ModuleStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Module_ModuleCategoryId",
                table: "Module",
                column: "ModuleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Module_ModuleCategory_ModuleCategoryId",
                table: "Module",
                column: "ModuleCategoryId",
                principalTable: "ModuleCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ModuleDetails_ModuleStats_ModuleStatsId",
                table: "ModuleDetails",
                column: "ModuleStatsId",
                principalTable: "ModuleStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Module_ModuleCategory_ModuleCategoryId",
                table: "Module");

            migrationBuilder.DropForeignKey(
                name: "FK_ModuleDetails_ModuleStats_ModuleStatsId",
                table: "ModuleDetails");

            migrationBuilder.DropTable(
                name: "ModuleCategory");

            migrationBuilder.DropTable(
                name: "ModuleStats");

            migrationBuilder.DropIndex(
                name: "IX_ModuleDetails_ModuleStatsId",
                table: "ModuleDetails");

            migrationBuilder.DropIndex(
                name: "IX_Module_ModuleCategoryId",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "ModuleStatsId",
                table: "ModuleDetails");

            migrationBuilder.DropColumn(
                name: "ModuleCategoryId",
                table: "Module");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ModuleDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Module",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 1,
                column: "Category",
                value: "Defense");

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 2,
                column: "Category",
                value: "Battle");

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 3,
                column: "Category",
                value: "-");

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 4,
                column: "Category",
                value: "Support Tech");

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 5,
                column: "Category",
                value: "Transcendent");

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 6,
                column: "Category",
                value: "-");

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
    }
}
