using System;
using System.Collections.Generic;
using System.Text;
//import your Linq to perform database method to retrieve data form your perisistance layer(repositories.)
using System.Linq;
using System.Threading.Tasks;
//Import your player repository
using NBAInfo.Data.Repositories.PlayerRepo;
//import your PlayerViewModel
using NBAInfo.Services.ViewModels;
//import your model factory for create PlayerViewModels
using NBAInfo.Services.Factory;

namespace NBAInfo.Services.Services.Player.Impl
{
    public class PlayerService : IPlayerService
    {
        //Define  a private of a type of your IPlayerRepository interface, which is your persistance layer for retrieving data to your database.
        private IPlayerRepository _repository;
        public PlayerService(IPlayerRepository repository)
        {
            _repository = repository;
        }
        //Now Define your GetPlayers method that will be public and retrieve data from persistance layer, and will loop thorugh it, and create a new view model for each value.\
        public IEnumerable<PlayerViewModel> GetPlayers()
        {
            var players = _repository.GetPlayers().Where(player => player.Name != null).Select(player => ModelFactory.CreateViewModel(player));
            return players;
        }
        public PlayerViewModel GetPlayer(Guid playerId)
        {
            var playerToReturn = _repository.GetPlayer(playerId);
            return ModelFactory.CreateViewModel(playerToReturn);
        }
        public PlayerViewModel CreatePlayer(PlayerViewModel createdPlayer)
        {
            var playerToCreate = ModelFactory.CreateDomainModel(createdPlayer);
            _repository.CreatePlayer(playerToCreate);
            return createdPlayer;
        }
        public void UpdatePlayer(PlayerViewModel updatedPlayer)
        {
            var playerToUpdate = ModelFactory.CreateDomainModel(updatedPlayer);
            _repository.UpdatePlayer(playerToUpdate);
            return;
        }
        public void DeletePlayer(Guid playerId)
        {
            _repository.DeletePlayer(playerId);
            return;
        }
    }
}
