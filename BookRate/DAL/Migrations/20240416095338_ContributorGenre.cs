using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookRate.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ContributorGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContributorGenre",
                columns: table => new
                {
                    ContributorsId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributorGenre", x => new { x.ContributorsId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_ContributorGenre_Contributors_ContributorsId",
                        column: x => x.ContributorsId,
                        principalTable: "Contributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContributorGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContributorGenre_GenresId",
                table: "ContributorGenre",
                column: "GenresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContributorGenre");
        }
    }
}
