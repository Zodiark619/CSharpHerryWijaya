using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSharpHerryWijayaMVC.Migrations
{
    /// <inheritdoc />
    public partial class mvcfix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Module",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DescendantId",
                table: "Module",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Descendant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descendant", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Descendant",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Freyna" },
                    { 2, "Serena" },
                    { 3, "Ines" }
                });

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "DescendantId" },
                values: new object[] { "Defense", null });

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "DescendantId", "Description" },
                values: new object[] { "Battle", null, "Toxic Skill Power +81.20%" });

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "DescendantId" },
                values: new object[] { "-", null });

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "DescendantId" },
                values: new object[] { "Support Tech", null });

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "DescendantId" },
                values: new object[] { "Transcendent", 1 });

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "DescendantId" },
                values: new object[] { "-", null });

            migrationBuilder.CreateIndex(
                name: "IX_Module_DescendantId",
                table: "Module",
                column: "DescendantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Descendant_DescendantId",
                table: "Module",
                column: "DescendantId",
                principalTable: "Descendant",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Module_Descendant_DescendantId",
                table: "Module");

            migrationBuilder.DropTable(
                name: "Descendant");

            migrationBuilder.DropIndex(
                name: "IX_Module_DescendantId",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "DescendantId",
                table: "Module");

            migrationBuilder.UpdateData(
                table: "Module",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Toxic Skill Power +81.2");
        }
    }
}
