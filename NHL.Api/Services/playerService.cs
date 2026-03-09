using System.Net.Http.Json;
using System.Text.Json;
using NHL.Api.Models.Players;

namespace NHL.Api.Services;

public class playerService
{
    private readonly HttpClient _http;
    private readonly ILogger<playerService> _logger;

    // ✅ Correct base URL for the NHL API
    private const string BaseUrl = "https://api-web.nhle.com/v1";

    public playerService(HttpClient http, ILogger<playerService> logger)
    {
        _http = http;
        _logger = logger;
    }

    /*
    * =========================
    * Player related information
    * =========================
    */


    /*
    * Function: Gets player info (Name/team/postion, bio info, draft info
    * Input: playerId (int)
    */

    public async Task<PlayerInfoDto?> GetPlayerInfoAsync(int playerId)
    {
        var json = await _http.GetStringAsync(
            $"{BaseUrl}/player/{playerId}/landing"
        );

        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;
        var draftExists = root.TryGetProperty("draftDetails", out var draft);

        return new PlayerInfoDto
        {

            //Basic Info
            PlayerId = root.GetProperty("playerId").GetInt32(),
            FullName =
                $"{root.GetProperty("firstName").GetProperty("default").GetString()} " +
                $"{root.GetProperty("lastName").GetProperty("default").GetString()}",
            Position = root.GetProperty("position").GetString() ?? "",
            Shoots = root.GetProperty("shootsCatches").GetString() ?? "",
            Team = root.GetProperty("currentTeamAbbrev").GetString() ?? "",

            //Bio info
            HeightInInches = root.GetProperty("heightInInches").GetInt32(),
            WeightInPounds = root.GetProperty("weightInPounds").GetInt32(),
            BirthDate = DateOnly.Parse(root.GetProperty("birthDate").GetString()!),
            BirthPlace =
                $"{root.GetProperty("birthCity").GetProperty("default").GetString()}, " +
                $"{root.GetProperty("birthCountry").GetString()}",
            HeadshotUrl = root.GetProperty("headshot").GetString() ?? "",


            // Draft Info
            DraftYear = draftExists ? draft.GetProperty("year").GetInt32() : null,
            DraftRound = draftExists ? draft.GetProperty("round").GetInt32() : null,
            DraftOverallPick = draftExists ? draft.GetProperty("overallPick").GetInt32() : null,
            DraftedBy = draftExists ? draft.GetProperty("teamAbbrev").GetString() ?? "" : ""
        };
    }


    /*
    * Function: Gets player Carreer Stats (Season)
    * Input: playerId (int)
    */

    public async Task<PlayerStatsDto?> GetPlayerCareerStatsAsync(int playerId)
    {
        var url = $"https://api-web.nhle.com/v1/player/{playerId}/stats";
        using var response = await _http.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return null;

        using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());

        var stats = doc.RootElement
            .GetProperty("careerTotals")
            .GetProperty("regularSeason");

        return new PlayerStatsDto
        {
            GamesPlayed = stats.GetProperty("gamesPlayed").GetInt32(),
            Goals = stats.GetProperty("goals").GetInt32(),
            Assists = stats.GetProperty("assists").GetInt32(),
            Points = stats.GetProperty("points").GetInt32(),

            Shots = stats.GetProperty("shots").GetInt32(),
            PlusMinus = stats.GetProperty("plusMinus").GetInt32(),
            Pim = stats.GetProperty("pim").GetInt32(),

            PowerPlayGoals = stats.GetProperty("powerPlayGoals").GetInt32(),
            PowerPlayPoints = stats.GetProperty("powerPlayPoints").GetInt32(),

            ShorthandedGoals = stats.GetProperty("shortHandedGoals").GetInt32(),
            ShorthandedPoints = stats.GetProperty("shortHandedPoints").GetInt32(),

            ShootingPercentage = stats.GetProperty("shootingPct").GetDouble()
        };
    }

    /*
    * Function: Gets player Carreer Stats (Playoffs)
    * Input: playerId (int)
    */
    public async Task<PlayerStatsDto?> GetPlayerCareerPlayoffStatsAsync(int playerId)
    {
        var url = $"{BaseUrl}player/{playerId}/stats";
        using var response = await _http.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return null;

        using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());

        var stats = doc.RootElement
            .GetProperty("careerTotals")
            .GetProperty("playoffs");

        return new PlayerStatsDto
        {
            GamesPlayed = stats.GetProperty("gamesPlayed").GetInt32(),
            Goals = stats.GetProperty("goals").GetInt32(),
            Assists = stats.GetProperty("assists").GetInt32(),
            Points = stats.GetProperty("points").GetInt32(),

            Shots = stats.GetProperty("shots").GetInt32(),
            PlusMinus = stats.GetProperty("plusMinus").GetInt32(),
            Pim = stats.GetProperty("pim").GetInt32(),

            PowerPlayGoals = stats.GetProperty("powerPlayGoals").GetInt32(),
            PowerPlayPoints = stats.GetProperty("powerPlayPoints").GetInt32(),

            ShorthandedGoals = stats.GetProperty("shortHandedGoals").GetInt32(),
            ShorthandedPoints = stats.GetProperty("shortHandedPoints").GetInt32(),

            ShootingPercentage = stats.GetProperty("shootingPct").GetDouble()
        };
    }


    /*
    * Function: Prevents errors on empty stats
    */

    private static int GetInt(JsonElement element, string property)
    {
        return element.TryGetProperty(property, out var value) && value.ValueKind == JsonValueKind.Number
            ? value.GetInt32()
            : 0;
    }
    /*
    * Function: Prevents errors on empty stats
    */
    private static double GetDouble(JsonElement element, string property)
    {
        return element.TryGetProperty(property, out var value) && value.ValueKind == JsonValueKind.Number
            ? value.GetDouble()
            : 0.0;
    }
}