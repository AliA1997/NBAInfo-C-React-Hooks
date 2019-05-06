using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//import your Service for your player repository
using NBAInfo.Services.Services.Player;
//import your Service for your Team repository
using NBAInfo.Services.Services.Team;
//import your Service for your Coach repository
using NBAInfo.Services.Services.Coach;
//import your viewmodels for your services, to specify each endpoint return value.
using NBAInfo.Services.ViewModels;

namespace NBAInfo.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/players")]
    public class PlayerController : ControllerBase
    {
        //Now define a private variable that will hold a service for each table which will follow the interface.
        private IPlayerService _playerService;
        //Now define a constructor that will take each service as a argument, and assign each argument to each private variable.
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PlayerViewModel> players = _playerService.GetPlayers();
            //Return a Ok status code with your data.
            return Ok(players);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            PlayerViewModel player = _playerService.GetPlayer(id);
            return Ok(player);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] PlayerViewModel playerForm)
        {
            PlayerViewModel createdPlayer = _playerService.CreatePlayer(playerForm);
            return Created("createplayer", createdPlayer);
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] PlayerViewModel playerForm)
        {
            _playerService.UpdatePlayer(playerForm);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _playerService.DeletePlayer(id);
            return NoContent();
        }
    }
}
