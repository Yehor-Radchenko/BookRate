using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookRate.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IsLiked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLiked",
                table: "ReviewLikes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLiked",
                table: "CommentaryLikes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLiked",
                table: "ReviewLikes");

            migrationBuilder.DropColumn(
                name: "IsLiked",
                table: "CommentaryLikes");
        }
    }
}
