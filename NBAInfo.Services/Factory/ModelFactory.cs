using System;
using System.Collections.Generic;
using System.Text;
//IMport your view models
using NBAInfo.Services.ViewModels;
//Import your Domain models
using NBAInfo.Domain.Player;
using NBAInfo.Domain.Team;
using NBAInfo.Domain.Coach;

namespace NBAInfo.Services.Factory
{
    //Define your factory which would static, and contain only class methods .
    public static class ModelFactory
    {
        //Have your create domain model methods that accept a viewmodel as a argument.
        //Used for creating data.
        internal static Player CreateDomainModel(PlayerViewModel newPlayer)
        {
            return new Player(
                name: newPlayer.Name,
                age: newPlayer.Age,
                team_id: newPlayer.TeamId,
                lastAllstarAppearance: newPlayer.LastAllstarAppearance,
                wonMVP: newPlayer.WonMVP,
                wonChampionship: newPlayer.WonChampionship
            );
        }
        internal static Team CreateDomainModel(TeamViewModel newTeam)
        {
            return new Team(
                name: newTeam.Name,
                city: newTeam.City,
                bestPlayerId: newTeam.BestPlayerId,
                bestPlayerOfAllTime: newTeam.BestPlayerOfAllTime,
                lastPlayoffAppearance: newTeam.LastPlayoffAppearance,
                championships: newTeam.Championships,
                lastChampionship: newTeam.LastChampionship
            );
        }
        internal static Coach CreateDomainModel(CoachViewModel newCoach)
        {
            return new Coach(
                name: newCoach.Name,
                team_id: newCoach.TeamId,
                lastPlayoffAppearance: newCoach.LastPlayoffAppearance,
                wonChampionship: newCoach.WonChampionship,
                championships: newCoach.Championships
            );
        }
        //Now define your createviewmodel method  that will create a view model, used for creating data.
        internal static PlayerViewModel CreateViewModel(Player player)
        {
            return new PlayerViewModel()
            {
                Id = player.Id,
                Name = player.Name,
                Age = player.Age,
                TeamId = (int) player.Team_Id,
                LastAllstarAppearance = player.LastAllstarAppearance,
                WonMVP = player.WonMVP,
                WonChampionship = player.WonChampionship
            };
        }
        internal static TeamViewModel CreateViewModel(Team team)
        {
            return new TeamViewModel()
            {
                Id = team.Id,
                Name = team.Name,
                City = team.City,
                BestPlayerId = team.BestPlayerId,
                BestPlayerOfAllTime = team.BestPlayerOfAllTime,
                Championships = team.Championships,
                LastPlayoffAppearance = team.LastPlayoffAppearance,
                LastChampionship = team.LastChampionship
            };
        }
        internal static CoachViewModel CreateViewModel(Coach coach)
        {
            return new CoachViewModel()
            {
                Id = coach.Id,
                Name = coach.Name,
                TeamId = coach.Team_Id,
                LastPlayoffAppearance = coach.LastPlayoffAppearance,
                WonChampionship = coach.WonChampionship,
                Championships = coach.Championships
            };
        }
    }
}
