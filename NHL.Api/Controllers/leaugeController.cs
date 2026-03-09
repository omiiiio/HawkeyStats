using Microsoft.AspNetCore.Mvc;
using NHL.Api.Services;
using NHL.Api.Models.Players;


namespace NHL.Api.Controllers;

[ApiController]
[Route("api/nhl")]
public class leagueController : ControllerBase
{
    private readonly leagueService _league;

    public leagueController(leagueService league)
    {
        _league = league;
    }


    /*
    * =========================
    * League related information
    * =========================
    */

    [HttpGet("standings")]
    public async Task<IActionResult> getStandingsNow() => Ok(await _league.getStandingsNowAsync());


    [HttpGet("schedule/{date}")]
    public async Task<IActionResult> getSchedule(string date)
    {
        if (!DateTime.TryParse(date, out var parsedDate))
            return BadRequest("Invalid date format. Use yyyy-MM-dd");

        return Ok(await _league.getScheduleAsync(parsedDate));
    }




}