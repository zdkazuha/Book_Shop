using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Book_Shop.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trilogies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTrilogie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilogies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishingHouseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    YearOfPublication = table.Column<int>(type: "int", nullable: false),
                    SellingPrice = table.Column<int>(type: "int", nullable: false),
                    CostPrice = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    TrilogiesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Trilogies_TrilogiesId",
                        column: x => x.TrilogiesId,
                        principalTable: "Trilogies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "John", "Tolkien" },
                    { 2, "Joanne", "Rowling" },
                    { 3, "George", "Martin" },
                    { 4, "J.R.R.", "Martin" },
                    { 5, "J.K.", "Rowling" }
                });

            migrationBuilder.InsertData(
                table: "Trilogies",
                columns: new[] { "Id", "NameTrilogie" },
                values: new object[,]
                {
                    { 1, "The Lord of the Rings" },
                    { 2, "Harry Potter" },
                    { 3, "A Song of Ice and Fire" },
                    { 4, "The Chronicles of Narnia" },
                    { 5, "The Hunger Games" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CostPrice", "Genre", "NumberOfPages", "PublishingHouseName", "SellingPrice", "Title", "TrilogiesId", "YearOfPublication" },
                values: new object[,]
                {
                    { 1, 1, 10, "Fantasy", 1178, "Allen & Unwin", 20, "The Lord of the Rings", 1, 1954 },
                    { 2, 1, 7, "Fantasy", 310, "Allen & Unwin", 15, "The Hobbit", 1, 1937 },
                    { 3, 1, 12, "Fantasy", 365, "Allen & Unwin", 25, "The Silmarillion", 1, 1977 },
                    { 4, 2, 9, "Fantasy", 223, "Bloomsbury", 18, "Harry Potter and the Philosopher's Stone", 2, 1997 },
                    { 5, 2, 10, "Fantasy", 251, "Bloomsbury", 20, "Harry Potter and the Chamber of Secrets", 2, 1998 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_TrilogiesId",
                table: "Books",
                column: "TrilogiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Trilogies");
        }
    }
}
