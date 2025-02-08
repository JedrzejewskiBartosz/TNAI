using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class shoppingcartids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingCart_ShoppingCartModelId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingCartModelId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShoppingCartModelId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductsID",
                table: "ShoppingCart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductsID",
                table: "ShoppingCart");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartModelId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShoppingCartModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShoppingCartModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShoppingCartModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ShoppingCartModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ShoppingCartModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ShoppingCartModelId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingCartModelId",
                table: "Products",
                column: "ShoppingCartModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingCart_ShoppingCartModelId",
                table: "Products",
                column: "ShoppingCartModelId",
                principalTable: "ShoppingCart",
                principalColumn: "Id");
        }
    }
}
