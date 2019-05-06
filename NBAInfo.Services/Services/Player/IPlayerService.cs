using System;
using System.Collections.Generic;
using System.Text;
//import your view model from your ViewMOdels folder.
using NBAInfo.Services.ViewModels;

namespace NBAInfo.Services.Services.Player
{
    public interface IPlayerService
    {
        IEnumerable<PlayerViewModel> GetPlayers();
        PlayerViewModel GetPlayer(Guid playerId);
        PlayerViewModel CreatePlayer(PlayerViewModel createdPlayer);
        void UpdatePlayer(PlayerViewModel updatedPlayer);
        void DeletePlayer(Guid playerId);
    }
}
