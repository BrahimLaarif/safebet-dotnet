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

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("EventName")
                        .IsRequired();

                    b.Property<string>("Hash");

                    b.Property<DateTime>("LastModifiedDate");

                    b.Property<string>("LastTimePointHash");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("Processed");

                    b.Property<string>("Result");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Safebet.WebAPI.Models.TimePoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AwayOdds");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<double>("DrawOdds");

                    b.Property<string>("Hash");

                    b.Property<double>("HomeOdds");

                    b.Property<int?>("MatchId");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("TimePoints");
                });

            modelBuilder.Entity("Safebet.WebAPI.Models.TimePoint", b =>
                {
                    b.HasOne("Safebet.WebAPI.Models.Match")
                        .WithMany("TimePoints")
                        .HasForeignKey("MatchId");
                });
#pragma warning restore 612, 618
        }
    }
}
