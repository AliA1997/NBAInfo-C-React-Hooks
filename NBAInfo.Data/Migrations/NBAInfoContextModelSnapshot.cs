﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBAInfo.Data.Database;

namespace NBAInfo.Data.Migrations
{
    [DbContext(typeof(NBAInfoContext))]
    partial class NBAInfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NBAInfo.Domain.Coach.Coach", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Championships");

                    b.Property<int>("LastPlayoffAppearance");

                    b.Property<string>("Name");

                    b.Property<int>("Team_Id");

                    b.Property<bool>("WonChampionship");

                    b.HasKey("Id");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("NBAInfo.Domain.Player.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<int>("LastAllstarAppearance");

                    b.Property<string>("Name");

                    b.Property<int?>("Team_Id");

                    b.Property<bool>("WonChampionship");

                    b.Property<bool>("WonMVP");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("NBAInfo.Domain.Team.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BestPlayerId");

                    b.Property<string>("BestPlayerOfAllTime");

                    b.Property<int>("Championships");

                    b.Property<string>("City");

                    b.Property<int>("LastChampionship");

                    b.Property<int>("LastPlayoffAppearance");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });
#pragma warning restore 612, 618
        }
    }
}
