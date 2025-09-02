using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSharpHerryWijayaMVC.Migrations
{
    /// <inheritdoc />
    public partial class mvcinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Research",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Research", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItem_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryItem_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchRequirement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResearchId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchRequirement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchRequirement_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResearchRequirement_Research_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Research",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Inventory",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Murky Energy Residue" },
                    { 2, "Mixed Energy Residue" },
                    { 3, "Macromolecule Biogel" },
                    { 4, "Advanced Neural Circuit" },
                    { 5, "Crystallization Catalyst Blueprint" },
                    { 6, "Superalloy" },
                    { 7, "Liquid Metal" },
                    { 8, "High Precision Exchange Components" }
                });

            migrationBuilder.InsertData(
                table: "Research",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 1, 40, 0), "Crystallization Catalyst" },
                    { 2, new TimeSpan(0, 0, 0, 10, 0), "Phase Exchanger" },
                    { 3, new TimeSpan(0, 0, 0, 40, 0), "Precision Phase Exchanger" },
                    { 4, new TimeSpan(0, 0, 0, 40, 0), "Precision Phase Exchanger" }
                });

            migrationBuilder.InsertData(
                table: "InventoryItem",
                columns: new[] { "Id", "InventoryId", "ItemId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 200 },
                    { 2, 1, 2, 200 },
                    { 3, 1, 3, 200 },
                    { 4, 1, 4, 200 },
                    { 5, 1, 5, 200 },
                    { 6, 1, 6, 200 },
                    { 7, 1, 7, 200 }
                });

            migrationBuilder.InsertData(
                table: "ResearchRequirement",
                columns: new[] { "Id", "ItemId", "Quantity", "ResearchId" },
                values: new object[,]
                {
                    { 1, 1, 8, 1 },
                    { 2, 2, 8, 1 },
                    { 3, 3, 22, 1 },
                    { 4, 4, 18, 1 },
                    { 5, 5, 1, 1 },
                    { 6, 6, 50, 2 },
                    { 7, 7, 250, 3 },
                    { 8, 8, 250, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_InventoryId",
                table: "InventoryItem",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItem_ItemId",
                table: "InventoryItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchRequirement_ItemId",
                table: "ResearchRequirement",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchRequirement_ResearchId",
                table: "ResearchRequirement",
                column: "ResearchId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItem");

            migrationBuilder.DropTable(
                name: "ResearchRequirement");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Research");
        }
    }
}
