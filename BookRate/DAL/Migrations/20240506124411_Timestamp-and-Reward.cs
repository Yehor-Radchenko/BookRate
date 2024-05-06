using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookRate.DAL.Migrations
{
    /// <inheritdoc />
    public partial class TimestampandReward : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NarrativeRevards");

            migrationBuilder.DropTable(
                name: "Revards");

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Users",
                type: "timestamp",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Reviews",
                type: "timestamp",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Rates",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFollowed",
                table: "Follows",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NarrativeRewards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarrativeId = table.Column<int>(type: "int", nullable: false),
                    RevardId = table.Column<int>(type: "int", nullable: false),
                    DateRevarded = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarrativeRewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NarrativeRewards_Narratives_NarrativeId",
                        column: x => x.NarrativeId,
                        principalTable: "Narratives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarrativeRewards_Rewards_RevardId",
                        column: x => x.RevardId,
                        principalTable: "Rewards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NarrativeRewards_NarrativeId",
                table: "NarrativeRewards",
                column: "NarrativeId");

            migrationBuilder.CreateIndex(
                name: "IX_NarrativeRewards_RevardId",
                table: "NarrativeRewards",
                column: "RevardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NarrativeRewards");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Rates");

            migrationBuilder.DropColumn(
                name: "DateFollowed",
                table: "Follows");

            migrationBuilder.CreateTable(
                name: "Revards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NarrativeRevards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarrativeId = table.Column<int>(type: "int", nullable: false),
                    RevardId = table.Column<int>(type: "int", nullable: false),
                    DateRevarded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarrativeRevards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NarrativeRevards_Narratives_NarrativeId",
                        column: x => x.NarrativeId,
                        principalTable: "Narratives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarrativeRevards_Revards_RevardId",
                        column: x => x.RevardId,
                        principalTable: "Revards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NarrativeRevards_NarrativeId",
                table: "NarrativeRevards",
                column: "NarrativeId");

            migrationBuilder.CreateIndex(
                name: "IX_NarrativeRevards_RevardId",
                table: "NarrativeRevards",
                column: "RevardId");
        }
    }
}
