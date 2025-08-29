using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Shop.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostPrice",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "YearOfPublication",
                table: "Books",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "SellingPrice",
                table: "Books",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "PublishingHouseName",
                table: "Books",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Published by Allen & Unwin");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Published by Allen & Unwin");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Published by Allen & Unwin");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Published by Bloomsbury");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Published by Bloomsbury");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Books",
                newName: "YearOfPublication");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Books",
                newName: "SellingPrice");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Books",
                newName: "PublishingHouseName");

            migrationBuilder.AddColumn<int>(
                name: "CostPrice",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CostPrice", "PublishingHouseName" },
                values: new object[] { 10, "Allen & Unwin" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CostPrice", "PublishingHouseName" },
                values: new object[] { 7, "Allen & Unwin" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CostPrice", "PublishingHouseName" },
                values: new object[] { 12, "Allen & Unwin" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CostPrice", "PublishingHouseName" },
                values: new object[] { 9, "Bloomsbury" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CostPrice", "PublishingHouseName" },
                values: new object[] { 10, "Bloomsbury" });
        }
    }
}
