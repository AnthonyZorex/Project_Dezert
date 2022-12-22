using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDezert.Migrations
{
    /// <inheritdoc />
    public partial class CorektedFriedns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "yourID",
                table: "Friends",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "yourID",
                table: "Friends");
        }
    }
}
