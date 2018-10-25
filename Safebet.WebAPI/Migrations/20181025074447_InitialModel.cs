using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Safebet.WebAPI.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Hash = table.Column<string>(nullable: true),
                    EventName = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LastTimePointHash = table.Column<string>(nullable: true),
                    Processed = table.Column<bool>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Predictions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HomeOdds = table.Column<double>(nullable: false),
                    DrawOdds = table.Column<double>(nullable: false),
                    AwayOdds = table.Column<double>(nullable: false),
                    FavoriteResult = table.Column<string>(nullable: false),
                    HomeOddsGain = table.Column<double>(nullable: false),
                    DrawOddsGain = table.Column<double>(nullable: false),
                    AwayOddsGain = table.Column<double>(nullable: false),
                    H1 = table.Column<double>(nullable: false),
                    H2 = table.Column<double>(nullable: false),
                    H3 = table.Column<double>(nullable: false),
                    H4 = table.Column<double>(nullable: false),
                    H5 = table.Column<double>(nullable: false),
                    D1 = table.Column<double>(nullable: false),
                    D2 = table.Column<double>(nullable: false),
                    D3 = table.Column<double>(nullable: false),
                    D4 = table.Column<double>(nullable: false),
                    D5 = table.Column<double>(nullable: false),
                    A1 = table.Column<double>(nullable: false),
                    A2 = table.Column<double>(nullable: false),
                    A3 = table.Column<double>(nullable: false),
                    A4 = table.Column<double>(nullable: false),
                    A5 = table.Column<double>(nullable: false),
                    HomeDropIndex = table.Column<double>(nullable: false),
                    DrawDropIndex = table.Column<double>(nullable: false),
                    AwayDropIndex = table.Column<double>(nullable: false),
                    HomeMovementIndex = table.Column<double>(nullable: false),
                    DrawMovementIndex = table.Column<double>(nullable: false),
                    AwayMovementIndex = table.Column<double>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    MatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predictions_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimePoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Hash = table.Column<string>(nullable: true),
                    HomeOdds = table.Column<double>(nullable: false),
                    DrawOdds = table.Column<double>(nullable: false),
                    AwayOdds = table.Column<double>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    MatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimePoints_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Predictions_MatchId",
                table: "Predictions",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TimePoints_MatchId",
                table: "TimePoints",
                column: "MatchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Predictions");

            migrationBuilder.DropTable(
                name: "TimePoints");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
