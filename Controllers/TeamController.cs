using Microsoft.AspNetCore.Mvc;
using TaskTrack.Services.Contracts;
using TaskTrack.DAL.Entities;

namespace TaskTrack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            if (team == null)
                return NotFound($"Team with ID {id} not found.");

            return Ok(team); 
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam([FromBody] Team team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _teamService.AddTeamAsync(team);
            return CreatedAtAction(nameof(GetTeamById), new { id = team.TeamId }, team);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] Team team)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != team.TeamId)
                return BadRequest("Team ID mismatch.");

            await _teamService.UpdateTeamAsync(team);
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _teamService.DeleteTeamAsync(id);
            return NoContent(); 
        }
    }
}
