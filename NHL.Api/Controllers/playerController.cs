using Microsoft.AspNetCore.Mvc;
using NHL.Api.Services;
using NHL.Api.Models.Players;


namespace NHL.Api.Controllers;

[ApiController]
[Route("api/playerController")]
public class playerController : ControllerBase
{
    private readonly playerService _player;

    public playerController(playerService player)
    {
        _player = player;
    }
    /*
    * =========================
    * Player related information
    * =========================
    */




    /*
* Function: Gets player info
* Input: playerId (int)
*/

    [HttpGet("players/{playerId}/info")]
    public async Task<IActionResult> GetPlayerInfo(int playerId)
    {
        var player = await _player.GetPlayerInfoAsync(playerId);
        if (player == null) return NotFound();
        return Ok(player);
    }

    /*
* Function: Gets player Carreer Stats (season)
* Input: playerId (int)
*/

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlayer(int id)
    {
        var info = await _player.GetPlayerInfoAsync(id);
        var stats = await _player.GetPlayerCareerStatsAsync(id);

        if (info == null)
            return NotFound();

        return Ok(new
        {
            Info = info,
            Stats = stats
        });
    }

    /*
* Function: Gets player Carreer Stats (Playoffs)
* Input: playerId (int)
*/

    [HttpGet("{id}/playoffs")]
    public async Task<IActionResult> GetPlayerPlayoffStats(int id)
    {
        var info = await _player.GetPlayerInfoAsync(id);
        var stats = await _player.GetPlayerCareerPlayoffStatsAsync(id);

        if (info == null)
            return NotFound();

        return Ok(new
        {
            Info = info,
            Stats = stats
        });
    }

}