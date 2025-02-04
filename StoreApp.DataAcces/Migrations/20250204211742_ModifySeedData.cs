using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class ModifySeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Telefony");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Słuchawki");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Telewizory");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "samsungGalaxyS25.jpg", "Samsung Galaxy S25 Ultra 12/512GB", 1580.0 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, "hisense65U6NQ.jpg", "Hisense 65U6NQ 65\" MINILED 4K VIDAA Dolby Vision Dolby Atmos", 739.79999999999995 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, "philips55PML9008.jpg", "Philips 55PML9008 55\" MINILED 4K", 740.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "OrderModelId", "Price", "WishListModelId" },
                values: new object[,]
                {
                    { 4, 2, "", "samsungGalaxyBuds3Pro.jpg", "Samsung Galaxy Buds3 Pro", null, 172.40000000000001, null },
                    { 5, 1, "", "redmiNote14Pro.jpg", "Xiaomi Redmi Note 14 Pro 8/256GB", null, 300.0, null },
                    { 6, 2, "", "logitechGProX.jpg", "Logitech G PRO X", null, 90.0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Category 1");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Category 2");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Category 3");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "", "Prod 1", 1.99 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "", "Prod 2", 2.9900000000000002 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "", "Prod 3", 3.9900000000000002 });
        }
    }
}
