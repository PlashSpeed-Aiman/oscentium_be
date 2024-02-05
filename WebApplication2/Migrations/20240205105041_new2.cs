using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class new2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Items_ItemId1",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_ItemId1",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ItemId1",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "Items",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_InventoryId",
                table: "Items",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Inventories_InventoryId",
                table: "Items",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Inventories_InventoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_InventoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Inventories",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemId1",
                table: "Inventories",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_ItemId1",
                table: "Inventories",
                column: "ItemId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Items_ItemId1",
                table: "Inventories",
                column: "ItemId1",
                principalTable: "Items",
                principalColumn: "Id");
        }
    }
}
