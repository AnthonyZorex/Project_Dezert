using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDezert.Migrations
{
    /// <inheritdoc />
    public partial class ApdateFriends : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Friends");

            migrationBuilder.AddColumn<string>(
                name: "Messager",
                table: "Friends",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Messager",
                table: "Friends");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Friends",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
