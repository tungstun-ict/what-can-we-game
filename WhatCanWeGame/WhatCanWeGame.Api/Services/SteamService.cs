using Flurl.Http;
using WhatCanWeGame.Api.Domain;

namespace WhatCanWeGame.Api.Services;

public class SteamService : ISteamService
{
    private const string BaseUrl = "http://api.steampowered.com/ISteamUser";
    private const string SteamKey = "A32F409FD094001786BCA34C90DB0B55";

    private readonly ILogger<SteamService> _logger;

    public SteamService(ILogger<SteamService> logger)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<PlayerSummary>> GetPlayersSummary(string steamId)
    {
        var url = BaseUrl + $"/GetPlayerSummaries/v0002/?key={SteamKey}&steamids={steamId}";
        var result = await url.GetJsonAsync<SteamResponse<GetPlayersSummaryResponse>>();

        return result.Response.Players;
    }
}