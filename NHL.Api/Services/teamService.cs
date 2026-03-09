using System.Net.Http.Json;
using System.Text.Json;
using NHL.Api.Models.Players;

namespace NHL.Api.Services;

public class teamService
{
    private readonly HttpClient _http;
    private readonly ILogger<teamService> _logger;

    private const string BaseUrl = "https://api-web.nhle.com/v1";

    public teamService(HttpClient http, ILogger<teamService> logger)
    {
        _http = http;
        _logger = logger;
    }
    /*
     * =========================
     * Team related information
     * =========================
     */

    /*
    * Function: Gets ids of all season played by team
     * Input: Team ID (string)
     */
    public async Task<object?> getTeamSeasonsAsync(string teamId)
    {
        try
        {
            return await _http.GetFromJsonAsync<object?>($"{BaseUrl}/roster-season/{teamId}/");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching seasons for team {teamId}", teamId);
            return null;
        }
    }



    public async Task<object?> getTeamsAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<object?>($"{BaseUrl}api/v1/teams");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching teams");
            return null;
        }
    }

    /*
     * Function: Gets team Roster
     * Input: Team ID (string)
     */
    public async Task<object?> getTeamRosterAsync(string teamId)
    {
        try
        {
            return await _http.GetFromJsonAsync<object?>($"{BaseUrl}/roster/{teamId}/current");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching roster for team {teamId}", teamId);
            return null;
        }
    }

    /*
    * Function: Gets team schedule for the week
    * Input: Team ID (string)
    */
    public async Task<object?> getTeamScheduleNowWeekAsync(string teamId)
    {
        try
        {
            return await _http.GetFromJsonAsync<object?>($"{BaseUrl}/club-schedule/{teamId}/week/now");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching schedule");
            return null;
        }
    }

    /*
    * Function: Gets team stats for the season
    * Input: Team ID (string)
    */
    public async Task<object?> getTeamStatsSeasonAsync(string teamId)
    {
        try
        {
            return await _http.GetFromJsonAsync<object?>($"{BaseUrl}/club-stats/{teamId}/week/now");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching schedule");
            return null;
        }
    }

}