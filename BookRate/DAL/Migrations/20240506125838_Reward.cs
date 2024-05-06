using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookRate.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Reward : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NarrativeRewards_Rewards_RevardId",
                table: "NarrativeRewards");

            migrationBuilder.RenameColumn(
                name: "RevardId",
                table: "NarrativeRewards",
                newName: "RewardId");

            migrationBuilder.RenameColumn(
                name: "DateRevarded",
                table: "NarrativeRewards",
                newName: "DateRewarded");

            migrationBuilder.RenameIndex(
                name: "IX_NarrativeRewards_RevardId",
                table: "NarrativeRewards",
                newName: "IX_NarrativeRewards_RewardId");

            migrationBuilder.AddForeignKey(
                name: "FK_NarrativeRewards_Rewards_RewardId",
                table: "NarrativeRewards",
                column: "RewardId",
                principalTable: "Rewards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NarrativeRewards_Rewards_RewardId",
                table: "NarrativeRewards");

            migrationBuilder.RenameColumn(
                name: "RewardId",
                table: "NarrativeRewards",
                newName: "RevardId");

            migrationBuilder.RenameColumn(
                name: "DateRewarded",
                table: "NarrativeRewards",
                newName: "DateRevarded");

            migrationBuilder.RenameIndex(
                name: "IX_NarrativeRewards_RewardId",
                table: "NarrativeRewards",
                newName: "IX_NarrativeRewards_RevardId");

            migrationBuilder.AddForeignKey(
                name: "FK_NarrativeRewards_Rewards_RevardId",
                table: "NarrativeRewards",
                column: "RevardId",
                principalTable: "Rewards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
