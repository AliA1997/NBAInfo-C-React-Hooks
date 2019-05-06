using System;
using System.Collections.Generic;
using System.Text;
//import your domain models using a directive.
using NBAInfo.Domain.Player;

namespace NBAInfo.Data.Repositories.PlayerRepo
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetPlayers();
        Player GetPlayer(Guid playerId);
        Player CreatePlayer(Player createdPlayer);
        void UpdatePlayer(Player updatedPlayer);
        void DeletePlayer(Guid playerId);
    }
}
