using System.Net.Http.Json;
using System.Text.Json;
using NHL.Api.Models.Players;

namespace NHL.Api.Services;

public class leagueService
{
    private readonly HttpClient _http;
    private readonly ILogger<leagueService> _logger;

    // ✅ Correct base URL for the NHL API
    private const string BaseUrl = "https://api-web.nhle.com/v1";

    public leagueService(HttpClient http, ILogger<leagueService> logger)
    {
        _http = http;
        _logger = logger;
    }

    /*
    * =========================
    * League related information
    * =========================
    */

    /*
* Function: Gets current standings
* Input: None
*/


    public async Task<object?> getStandingsNowAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<object?>($"{BaseUrl}/standings/now");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching current standings");
            return null;
        }
    }

    public async Task<object?> getScheduleAsync(DateTime date)
    {
        try
        {
            var dateStr = date.ToString("yyyy-MM-dd");
            return await _http.GetFromJsonAsync<object?>($"{BaseUrl}/schedule?date={dateStr}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching schedule");
            return null;
        }
    }

}