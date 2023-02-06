using Microsoft.AspNetCore.Mvc;
using WhatCanWeGame.Api.Domain;
using WhatCanWeGame.Api.Services;
using WhatCanWeGame.Api.Services.Responses;

namespace WhatCanWeGame.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SteamUserController : ControllerBase
{
    private readonly ILogger<SteamUserController> _logger;
    private readonly ISteamService _service;

    public SteamUserController(ILogger<SteamUserController> logger, ISteamService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet("/players/summary")]
    public async Task<IEnumerable<PlayerSummary>> GetPlayerSummary([FromQuery] string steamIds)
    {
        var result = await _service.GetPlayersSummary(steamIds);

        return result;
    }

    [HttpGet("/players/{steamId}/friends")]
    public async Task<IEnumerable<PlayerSummary>> GetPlayersFriends([FromRoute] string steamId)
    {
        var result = await _service.GetFriendsListOfPlayer(steamId);

        return result;
    }
    
    [HttpGet("/players/{steamId}/games")]
    public async Task<GetOwnedGamesResponse> GetPlayersGames([FromRoute] string steamId)
    {
        var result = await _service.GetOwnedgamesOfPlayer(steamId);

        return result;
    }

    [HttpGet("/players/{steamId}/gamesInCommonWith")]
    public async Task<IEnumerable<Game>> GetPlayersGamesInCommonWithPlayers(
        [FromRoute] string steamId, 
        [FromQuery] string friends)
    {
        var ids = friends.Split(",");
        
        var result = await _service.GetGamesInCommonWithPlayers(steamId, ids);

        return result;
    }
}