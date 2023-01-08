using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodosList.Migrations
{
    /// <inheritdoc />
    public partial class RenameFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "Todos",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "desc",
                table: "Todos",
                newName: "Desc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Todos",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Todos",
                newName: "desc");
        }
    }
}
