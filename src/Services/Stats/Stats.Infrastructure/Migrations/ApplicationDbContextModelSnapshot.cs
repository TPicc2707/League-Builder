﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stats.Infrastructure.Data;

#nullable disable

namespace Stats.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Stats.Domain.Models.BaseballStats", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LeagueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.ComplexProperty<Dictionary<string, object>>("HittingStats", "Stats.Domain.Models.BaseballStats.HittingStats#BaseballHittingStats", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("AtBats")
                                .HasColumnType("int");

                            b1.Property<decimal>("Average")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("Doubles")
                                .HasColumnType("int");

                            b1.Property<int>("HitByPitch")
                                .HasColumnType("int");

                            b1.Property<int>("Hits")
                                .HasColumnType("int");

                            b1.Property<int>("HomeRuns")
                                .HasColumnType("int");

                            b1.Property<decimal>("OnBasePercentage")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<decimal>("OnBasePlusSlugging")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("Runs")
                                .HasColumnType("int");

                            b1.Property<int>("RunsBattedIn")
                                .HasColumnType("int");

                            b1.Property<int>("SacrificeFly")
                                .HasColumnType("int");

                            b1.Property<decimal>("Slugging")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("StolenBases")
                                .HasColumnType("int");

                            b1.Property<int>("Strikeouts")
                                .HasColumnType("int");

                            b1.Property<int>("TotalBases")
                                .HasColumnType("int");

                            b1.Property<int>("Triples")
                                .HasColumnType("int");

                            b1.Property<int>("Walks")
                                .HasColumnType("int");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PitchingStats", "Stats.Domain.Models.BaseballStats.PitchingStats#BaseballPitchingStats", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("HitsAllowed")
                                .HasColumnType("int");

                            b1.Property<decimal>("Innings")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("Losses")
                                .HasColumnType("int");

                            b1.Property<int>("PitchingStrikeouts")
                                .HasColumnType("int");

                            b1.Property<int>("Saves")
                                .HasColumnType("int");

                            b1.Property<bool>("Start")
                                .HasColumnType("bit");

                            b1.Property<int>("WalksAllowed")
                                .HasColumnType("int");

                            b1.Property<decimal>("WalksHitsPerInning")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("Wins")
                                .HasColumnType("int");
                        });

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TeamId");

                    b.ToTable("BaseballStats");
                });

            modelBuilder.Entity("Stats.Domain.Models.BasketballStats", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LeagueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.ComplexProperty<Dictionary<string, object>>("Stats", "Stats.Domain.Models.BasketballStats.Stats#BasketballPlayerStats", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Assists")
                                .HasColumnType("int");

                            b1.Property<int>("Blocks")
                                .HasColumnType("int");

                            b1.Property<decimal>("FieldGoalPercentage")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("FieldGoalsAttempted")
                                .HasColumnType("int");

                            b1.Property<int>("FieldGoalsMade")
                                .HasColumnType("int");

                            b1.Property<decimal>("FreeThrowPercentage")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("FreeThrowsAttempted")
                                .HasColumnType("int");

                            b1.Property<int>("FreeThrowsMade")
                                .HasColumnType("int");

                            b1.Property<int>("Minutes")
                                .HasColumnType("int");

                            b1.Property<int>("Points")
                                .HasColumnType("int");

                            b1.Property<int>("Rebounds")
                                .HasColumnType("int");

                            b1.Property<bool>("Start")
                                .HasColumnType("bit");

                            b1.Property<int>("Steals")
                                .HasColumnType("int");

                            b1.Property<decimal>("ThreePointPercentage")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("ThreePointersAttempted")
                                .HasColumnType("int");

                            b1.Property<int>("ThreePointersMade")
                                .HasColumnType("int");

                            b1.Property<int>("Turnovers")
                                .HasColumnType("int");
                        });

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TeamId");

                    b.ToTable("BasketballStats");
                });

            modelBuilder.Entity("Stats.Domain.Models.FootballStats", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LeagueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.ComplexProperty<Dictionary<string, object>>("DefensiveStats", "Stats.Domain.Models.FootballStats.DefensiveStats#FootballDefensiveStats", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("DefensiveInterceptionYards")
                                .HasColumnType("int");

                            b1.Property<int>("DefensiveInterceptions")
                                .HasColumnType("int");

                            b1.Property<int>("DefensiveTouchdowns")
                                .HasColumnType("int");

                            b1.Property<int>("ForcedFumbles")
                                .HasColumnType("int");

                            b1.Property<int>("LongestDefensiveInterceptionPlay")
                                .HasColumnType("int");

                            b1.Property<int>("PassesDefended")
                                .HasColumnType("int");

                            b1.Property<int>("RecoveredFumbles")
                                .HasColumnType("int");

                            b1.Property<int>("Sacks")
                                .HasColumnType("int");

                            b1.Property<int>("Tackles")
                                .HasColumnType("int");

                            b1.Property<int>("TacklesForLoss")
                                .HasColumnType("int");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("KickingStats", "Stats.Domain.Models.FootballStats.KickingStats#FootballKickingStats", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<decimal>("ExtraPointPercentage")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("ExtraPointsAttempted")
                                .HasColumnType("int");

                            b1.Property<int>("ExtraPointsMade")
                                .HasColumnType("int");

                            b1.Property<decimal>("FieldGoalPercentage")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("FieldGoalsAttempted")
                                .HasColumnType("int");

                            b1.Property<int>("FieldGoalsMade")
                                .HasColumnType("int");

                            b1.Property<int>("LongestPunt")
                                .HasColumnType("int");

                            b1.Property<int>("PuntingYards")
                                .HasColumnType("int");

                            b1.Property<int>("Punts")
                                .HasColumnType("int");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("OffensiveStats", "Stats.Domain.Models.FootballStats.OffensiveStats#FootballOffensiveStats", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("LongestPassingPlay")
                                .HasColumnType("int");

                            b1.Property<int>("LongestRushingPlay")
                                .HasColumnType("int");

                            b1.Property<decimal>("PasserRating")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("PassingAttempts")
                                .HasColumnType("int");

                            b1.Property<decimal>("PassingCompletionPercentage")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("PassingCompletions")
                                .HasColumnType("int");

                            b1.Property<int>("PassingInterceptions")
                                .HasColumnType("int");

                            b1.Property<int>("PassingTouchdowns")
                                .HasColumnType("int");

                            b1.Property<int>("PassingYards")
                                .HasColumnType("int");

                            b1.Property<decimal>("PassingYardsPerPlay")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("ReceivingFumbles")
                                .HasColumnType("int");

                            b1.Property<int>("ReceivingFumblesLost")
                                .HasColumnType("int");

                            b1.Property<int>("ReceivingTouchdowns")
                                .HasColumnType("int");

                            b1.Property<int>("ReceivingYards")
                                .HasColumnType("int");

                            b1.Property<decimal>("ReceivingYardsPerPlay")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("Receptions")
                                .HasColumnType("int");

                            b1.Property<int>("RushingAttempts")
                                .HasColumnType("int");

                            b1.Property<int>("RushingFumbles")
                                .HasColumnType("int");

                            b1.Property<int>("RushingFumblesLost")
                                .HasColumnType("int");

                            b1.Property<int>("RushingTouchdowns")
                                .HasColumnType("int");

                            b1.Property<int>("RushingYards")
                                .HasColumnType("int");

                            b1.Property<decimal>("RushingYardsAverage")
                                .HasColumnType("decimal(18,2)");

                            b1.Property<int>("Sacks")
                                .HasColumnType("int");

                            b1.Property<int>("Targets")
                                .HasColumnType("int");

                            b1.Property<int>("YardsAfterCatch")
                                .HasColumnType("int");
                        });

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("LeagueId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TeamId");

                    b.ToTable("FootballStats");
                });

            modelBuilder.Entity("Stats.Domain.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Stats.Domain.Models.League", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("Stats.Domain.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Stats.Domain.Models.Season", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("Stats.Domain.Models.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Stats.Domain.Models.BaseballStats", b =>
                {
                    b.HasOne("Stats.Domain.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stats.Domain.Models.League", null)
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stats.Domain.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stats.Domain.Models.Season", null)
                        .WithMany()
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stats.Domain.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Stats.Domain.Models.BasketballStats", b =>
                {
                    b.HasOne("Stats.Domain.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stats.Domain.Models.League", null)
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stats.Domain.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stats.Domain.Models.Season", null)
                        .WithMany()
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stats.Domain.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Stats.Domain.Models.FootballStats", b =>
                {
                    b.HasOne("Stats.Domain.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stats.Domain.Models.League", null)
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stats.Domain.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stats.Domain.Models.Season", null)
                        .WithMany()
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stats.Domain.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
