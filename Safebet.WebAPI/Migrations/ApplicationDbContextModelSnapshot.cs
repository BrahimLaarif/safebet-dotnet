﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Safebet.WebAPI.Data;

namespace Safebet.WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Safebet.WebAPI.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("EventName")
                        .IsRequired();

                    b.Property<string>("Hash");

                    b.Property<int?>("LastPredictionId");

                    b.Property<string>("LastTimePointHash");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("Processed");

                    b.Property<string>("Result");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("LastPredictionId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Safebet.WebAPI.Models.Prediction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("A1");

                    b.Property<float>("A2");

                    b.Property<float>("A3");

                    b.Property<float>("A4");

                    b.Property<float>("A5");

                    b.Property<int>("AccuratePrediction");

                    b.Property<float>("AwayDropIndex");

                    b.Property<float>("AwayMovementIndex");

                    b.Property<float>("AwayOdds");

                    b.Property<float>("AwayOddsGain");

                    b.Property<int>("BalancedOdds");

                    b.Property<DateTime>("CreationDate");

                    b.Property<float>("D1");

                    b.Property<float>("D2");

                    b.Property<float>("D3");

                    b.Property<float>("D4");

                    b.Property<float>("D5");

                    b.Property<float>("DrawDropIndex");

                    b.Property<float>("DrawMovementIndex");

                    b.Property<float>("DrawOdds");

                    b.Property<float>("DrawOddsGain");

                    b.Property<string>("FavoriteResult")
                        .IsRequired();

                    b.Property<string>("Gemstone");

                    b.Property<float>("H1");

                    b.Property<float>("H2");

                    b.Property<float>("H3");

                    b.Property<float>("H4");

                    b.Property<float>("H5");

                    b.Property<int>("HomeAdvantage");

                    b.Property<float>("HomeDropIndex");

                    b.Property<float>("HomeMovementIndex");

                    b.Property<float>("HomeOdds");

                    b.Property<float>("HomeOddsGain");

                    b.Property<int>("MatchId");

                    b.Property<int>("OtherResultsGainsAndDropsIsGoingUp");

                    b.Property<float>("PredictedAwayProba");

                    b.Property<float>("PredictedDrawProba");

                    b.Property<float>("PredictedHomeProba");

                    b.Property<string>("PredictedResult")
                        .IsRequired();

                    b.Property<float>("PredictedResultDropIndex");

                    b.Property<int>("PredictedResultGainsAndDropsIsGoingDown");

                    b.Property<int>("PredictedResultGraphIsChaotic");

                    b.Property<int>("PredictedResultGraphIsGoingDown");

                    b.Property<int>("PredictedResultGraphTailIsGoingDown");

                    b.Property<float>("PredictedResultMovementIndex");

                    b.Property<float>("PredictedResultOdds");

                    b.Property<float>("PredictedResultOddsGain");

                    b.Property<int>("PredictedResultOddsIsSafe");

                    b.Property<float>("PredictedResultProba");

                    b.Property<int>("PredictedResultProbaIsSafe");

                    b.Property<float>("PredictedSafeProba");

                    b.Property<int>("PredictedSafetyLevel");

                    b.Property<float>("PredictedSafetyLevelProba");

                    b.Property<float>("PredictedUnsafeProba");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("Predictions");
                });

            modelBuilder.Entity("Safebet.WebAPI.Models.TimePoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("AwayOdds");

                    b.Property<DateTime>("CreationDate");

                    b.Property<float>("DrawOdds");

                    b.Property<string>("Hash");

                    b.Property<float>("HomeOdds");

                    b.Property<int>("MatchId");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("TimePoints");
                });

            modelBuilder.Entity("Safebet.WebAPI.Models.Match", b =>
                {
                    b.HasOne("Safebet.WebAPI.Models.Prediction", "LastPrediction")
                        .WithMany()
                        .HasForeignKey("LastPredictionId");
                });

            modelBuilder.Entity("Safebet.WebAPI.Models.Prediction", b =>
                {
                    b.HasOne("Safebet.WebAPI.Models.Match")
                        .WithMany("Predictions")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Safebet.WebAPI.Models.TimePoint", b =>
                {
                    b.HasOne("Safebet.WebAPI.Models.Match")
                        .WithMany("TimePoints")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
