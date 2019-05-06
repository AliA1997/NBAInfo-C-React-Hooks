using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBAInfo.Services.Services.Coach;
using NBAInfo.Services.ViewModels;

namespace NBAInfo.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/coaches")]
    public class CoachController : ControllerBase
    {
        private ICoachService _coachService;
        public CoachController(ICoachService coachService)
        {
            _coachService = coachService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<CoachViewModel> coaches = _coachService.GetCoaches();
            return Ok(coaches);
        }
        [HttpGet("{id}")]
        public IActionResult GetCoach(Guid id)
        {
            CoachViewModel coach = _coachService.GetCoach(id);
            return Ok(coach);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CoachViewModel coachForm)
        {
            CoachViewModel coach = _coachService.CreateCoach(coachForm);
            return Created("createcoach", coach);
        }
        [HttpPut]
        public IActionResult Update([FromBody] CoachViewModel coachForm)
        {
            _coachService.UpdateCoach(coachForm);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _coachService.DeleteCoach(id);
            return NoContent();
        }
    }
}