using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Shop.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrilogies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameTrilogie",
                table: "Trilogies",
                newName: "TrilogieName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrilogieName",
                table: "Trilogies",
                newName: "NameTrilogie");
        }
    }
}
