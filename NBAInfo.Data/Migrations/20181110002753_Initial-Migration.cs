using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NBAInfo.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Team_Id = table.Column<int>(nullable: false),
                    LastPlayoffAppearance = table.Column<int>(nullable: false),
                    WonChampionship = table.Column<bool>(nullable: false),
                    Championships = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Team_Id = table.Column<int>(nullable: true),
                    LastAllstarAppearance = table.Column<int>(nullable: false),
                    WonMVP = table.Column<bool>(nullable: false),
                    WonChampionship = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    BestPlayerId = table.Column<int>(nullable: false),
                    BestPlayerOfAllTime = table.Column<string>(nullable: true),
                    LastPlayoffAppearance = table.Column<int>(nullable: false),
                    Championships = table.Column<int>(nullable: false),
                    LastChampionship = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
