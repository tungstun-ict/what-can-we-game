using Microsoft.AspNetCore.Mvc;
using WhatCanWeGame.Api.Domain;
using WhatCanWeGame.Api.Services;

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

    [HttpGet("/{steamId}/summary")]
    public async Task<IEnumerable<PlayerSummary>> GetPlayerSummary([FromRoute] string steamId)
    {
        var result = await _service.GetPlayersSummary(steamId);

        return result;
    }
}