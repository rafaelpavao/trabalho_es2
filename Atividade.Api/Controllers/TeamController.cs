// using Microsoft.AspNetCore.Mvc;
// using Atividade.Api.Entities;
// using Atividade.Api.Repositories;

// namespace Atividade.Api.Controllers;

// [ApiController]
// [Route("api/teams")]
// public class TeamController : ControllerBase
// {
//     private readonly IStudentRepository _repository;

//     public TeamController(IStudentRepository repository)
//     {
//         _repository = repository;
//     }
//     [HttpPost]
//     public async Task<ActionResult<Team>> CreateTeam(
//         [FromBody] Team team
//     )
//     {
//         await _repository.AddTeamAsync(team);

//         return CreatedAtRoute
//         (
//             "GetTeamById",
//             new { teamId = team.Id },
//             team
//         );
//     }

//     [HttpGet]
//     public async Task<ActionResult<Team>> GetTeamById(int teamId)
//     {
//         return await _repository.GetTeamByIdAsync(teamId);
//     }

//     [HttpPost("JoinTeamsAndStudent")]
//     public async Task<ActionResult<StudentTeam>> AssociateTeamStudent(int teamId, int studentId)
//     {
//         var studentTeamEntity = await _repository.JoinTeamAndStudent(studentId, teamId);
//         return Ok(studentTeamEntity);
//     }
// }
