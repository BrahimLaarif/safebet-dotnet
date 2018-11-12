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
                name: "Predictions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: false),
                    HomeOdds = table.Column<float>(nullable: false),
                    DrawOdds = table.Column<float>(nullable: false),
                    AwayOdds = table.Column<float>(nullable: false),
                    FavoriteResult = table.Column<string>(nullable: false),
                    HomeOddsGain = table.Column<float>(nullable: false),
                    DrawOddsGain = table.Column<float>(nullable: false),
                    AwayOddsGain = table.Column<float>(nullable: false),
                    H1 = table.Column<float>(nullable: false),
                    H2 = table.Column<float>(nullable: false),
                    H3 = table.Column<float>(nullable: false),
                    H4 = table.Column<float>(nullable: false),
                    H5 = table.Column<float>(nullable: false),
                    D1 = table.Column<float>(nullable: false),
                    D2 = table.Column<float>(nullable: false),
                    D3 = table.Column<float>(nullable: false),
                    D4 = table.Column<float>(nullable: false),
                    D5 = table.Column<float>(nullable: false),
                    A1 = table.Column<float>(nullable: false),
                    A2 = table.Column<float>(nullable: false),
                    A3 = table.Column<float>(nullable: false),
                    A4 = table.Column<float>(nullable: false),
                    A5 = table.Column<float>(nullable: false),
                    HomeDropIndex = table.Column<float>(nullable: false),
                    DrawDropIndex = table.Column<float>(nullable: false),
                    AwayDropIndex = table.Column<float>(nullable: false),
                    HomeMovementIndex = table.Column<float>(nullable: false),
                    DrawMovementIndex = table.Column<float>(nullable: false),
                    AwayMovementIndex = table.Column<float>(nullable: false),
                    PredictedResult = table.Column<string>(nullable: false),
                    PredictedHomeProba = table.Column<float>(nullable: false),
                    PredictedDrawProba = table.Column<float>(nullable: false),
                    PredictedAwayProba = table.Column<float>(nullable: false),
                    PredictedResultProba = table.Column<float>(nullable: false),
                    PredictedResultOdds = table.Column<float>(nullable: false),
                    PredictedResultOddsGain = table.Column<float>(nullable: false),
                    PredictedResultDropIndex = table.Column<float>(nullable: false),
                    PredictedResultMovementIndex = table.Column<float>(nullable: false),
                    AccuratePrediction = table.Column<int>(nullable: false),
                    BalancedOdds = table.Column<int>(nullable: false),
                    HomeAdvantage = table.Column<int>(nullable: false),
                    PredictedResultProbaIsSafe = table.Column<int>(nullable: false),
                    PredictedResultOddsIsSafe = table.Column<int>(nullable: false),
                    PredictedResultGainsAndDropsIsGoingDown = table.Column<int>(nullable: false),
                    OtherResultsGainsAndDropsIsGoingUp = table.Column<int>(nullable: false),
                    PredictedResultGraphIsChaotic = table.Column<int>(nullable: false),
                    PredictedResultGraphIsGoingDown = table.Column<int>(nullable: false),
                    PredictedResultGraphTailIsGoingDown = table.Column<int>(nullable: false),
                    PredictedSafetyLevel = table.Column<int>(nullable: false),
                    PredictedUnsafeProba = table.Column<float>(nullable: false),
                    PredictedSafeProba = table.Column<float>(nullable: false),
                    PredictedSafetyLevelProba = table.Column<float>(nullable: false),
                    Gemstone = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predictions", x => x.Id);
                });

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
                    LastPredictionId = table.Column<int>(nullable: true),
                    Processed = table.Column<bool>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Predictions_LastPredictionId",
                        column: x => x.LastPredictionId,
                        principalTable: "Predictions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimePoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: false),
                    Hash = table.Column<string>(nullable: true),
                    HomeOdds = table.Column<float>(nullable: false),
                    DrawOdds = table.Column<float>(nullable: false),
                    AwayOdds = table.Column<float>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimePoints_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LastPredictionId",
                table: "Matches",
                column: "LastPredictionId");

            migrationBuilder.CreateIndex(
                name: "IX_Predictions_MatchId",
                table: "Predictions",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TimePoints_MatchId",
                table: "TimePoints",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Predictions_Matches_MatchId",
                table: "Predictions",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Predictions_LastPredictionId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "TimePoints");

            migrationBuilder.DropTable(
                name: "Predictions");

            migrationBuilder.DropTable(
                name: "Matches");
        }
    }
}
