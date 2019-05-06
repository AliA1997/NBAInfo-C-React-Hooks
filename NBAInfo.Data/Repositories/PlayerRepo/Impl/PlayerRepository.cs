using System;
using System.Collections.Generic;
using System.Text;
//import linq to perform database methods.
using System.Linq;
using NBAInfo.Data.Database;
//import your domain models for retrieving data from database.
using NBAInfo.Domain.Player;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NBAInfo.Data.Repositories.PlayerRepo.Impl
{
    public class PlayerRepository : IPlayerRepository
    {
        //Define a private variable that would be a type of your context class which would access the database.
        private NBAInfoContext _context;
        //Define a constructor that will assign a context argument to private context variable.
        public PlayerRepository(NBAInfoContext context)
        {
            _context = context;
        }
        //Define a method that retrieve players, and your teams.
        public IEnumerable<Player> GetPlayers()
        {
            IEnumerable<Player> players =  _context.Players.ToList();
            return players;
        }
        public Player GetPlayer(Guid playerId)
        {
            Player playerToReturn = _context.Players.FirstOrDefault(player => player.Id == playerId);
            return playerToReturn;
        }
        public Player CreatePlayer(Player createdPlayer)
        {
            _context.Players.Add(createdPlayer);
            _context.SaveChanges();
            return createdPlayer;
        }
        public void UpdatePlayer(Player updatedPlayer)
        {
            _context.Players.Update(updatedPlayer);
            _context.SaveChanges();
            return;
        }
        public void DeletePlayer(Guid playerId)
        {
            Player playerToRemove = _context.Players.FirstOrDefault(player => player.Id == playerId);
            if (playerToRemove != null)
            {
                _context.Players.Remove(playerToRemove);
                _context.SaveChanges();
            }
             return;
        }
    }
}
