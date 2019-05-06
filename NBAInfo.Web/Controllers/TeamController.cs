using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBAInfo.Services.Services.Team;
using NBAInfo.Services.ViewModels;

namespace NBAInfo.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/teams")]
    public class TeamController : ControllerBase
    {
        private ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<TeamViewModel> teams = _teamService.GetTeams();
            return Ok(teams);
        }
        [HttpGet("{id}")]
        public IActionResult GetTeam(Guid id)
        {
            TeamViewModel team = _teamService.GetTeam(id);
            return Ok(team);
        }
        [HttpPost]
        public IActionResult Post([FromBody] TeamViewModel teamForm)
        {
            TeamViewModel team = _teamService.CreateTeam(teamForm);
            return Created("createteam", team);
        }
        [HttpPut]
        public IActionResult Update([FromBody] TeamViewModel teamForm)
        {
            _teamService.UpdateTeam(teamForm);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _teamService.DeleteTeam(id);
            return NoContent();
        }
    }
}