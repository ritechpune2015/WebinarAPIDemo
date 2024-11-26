using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIDemo.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryID", "ProductCategoryName" },
                values: new object[,]
                {
                    { 1, "Electornics" },
                    { 2, "Books" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "MfgName", "Price", "ProductCategoryID", "ProductName" },
                values: new object[,]
                {
                    { 1, "Logitech", 550m, 1, "Mouse" },
                    { 2, "Kanetkar", 750m, 2, "Let us C" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "ProductCategoryID",
                keyValue: 2);
        }
    }
}
