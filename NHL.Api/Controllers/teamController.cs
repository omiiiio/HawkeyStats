using Microsoft.AspNetCore.Mvc;
using NHL.Api.Services;
using NHL.Api.Models.Players;


namespace NHL.Api.Controllers;

[ApiController]
[Route("api/nhl")]
public class teamController : ControllerBase
{
    private readonly teamService _team;

    public teamController(teamService team)
    {
        _team = team;
    }


    /*
    * =========================
    * Team related information
    * =========================
    */


    [HttpGet("teamScheduleNowWeek")]
    public async Task<IActionResult> getTeamScheudleNowWeek(string teamId) => Ok(await _team.getTeamScheduleNowWeekAsync(teamId));

    [HttpGet("teams")]
    public async Task<IActionResult> getTeams() => Ok(await _team.getTeamsAsync());


    [HttpGet("Team_Stats_Current")]
    public async Task<IActionResult> getTeamStatsSeason(string teamId) => Ok(await _team.getTeamStatsSeasonAsync(teamId));



    [HttpGet("Team_Roster")]
    public async Task<IActionResult> getTeamRoster(string teamId) => Ok(await _team.getTeamRosterAsync(teamId));




}