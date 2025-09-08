using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSharpHerryWijayaMVC.Migrations
{
    /// <inheritdoc />
    public partial class module : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModuleDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueModifier = table.Column<double>(type: "float", nullable: false),
                    ValueModifierType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuleDetails_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Module",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Shield Conversion (DEF)" },
                    { 2, "Toxic Specialist" },
                    { 3, "Polygenic Antibody" },
                    { 4, "An Iron Will" },
                    { 5, "Contagion" },
                    { 6, "Arche Acceleration" }
                });

            migrationBuilder.InsertData(
                table: "ModuleDetails",
                columns: new[] { "Id", "Description", "ModuleId", "ValueModifier", "ValueModifierType" },
                values: new object[,]
                {
                    { 1, "DEF +166.80%, Max Shield -36.50%", 1, 166.80000000000001, "percentage" },
                    { 2, "DEF +166.80%, Max Shield -36.50%", 1, -36.5, "percentage" },
                    { 3, "Toxic Skill Power +81.2", 2, 81.200000000000003, "percentage" },
                    { 4, "All Attribute Resistances +640.80", 3, 640.79999999999995, "raw" },
                    { 5, "When Shield is at 0%, DEF +128.30%", 4, 0.0, "situational" },
                    { 6, "When an enemy inflicted with Room 0 Trauma is killed, a contagion of Room 0 Trauma surrounds it.", 5, 0.0, "situational" },
                    { 7, "Skill Speed & Range Increase Modifier +19.20%", 6, 19.199999999999999, "percentage" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModuleDetails_ModuleId",
                table: "ModuleDetails",
                column: "ModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModuleDetails");

            migrationBuilder.DropTable(
                name: "Module");
        }
    }
}
