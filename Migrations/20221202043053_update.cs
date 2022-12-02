using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPi.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_Quantity",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestItems_Accounts_UserId",
                table: "RequestItems");

            migrationBuilder.DropIndex(
                name: "IX_Items_Quantity",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RequestItems",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestItems_UserId",
                table: "RequestItems",
                newName: "IX_RequestItems_AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItems_Accounts_AccountId",
                table: "RequestItems",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestItems_Accounts_AccountId",
                table: "RequestItems");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "RequestItems",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestItems_AccountId",
                table: "RequestItems",
                newName: "IX_RequestItems_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Quantity",
                table: "Items",
                column: "Quantity");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_Quantity",
                table: "Items",
                column: "Quantity",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestItems_Accounts_UserId",
                table: "RequestItems",
                column: "UserId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
