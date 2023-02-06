using WhatCanWeGame.Api.Services;

namespace WhatCanWeGame.Api.Domain;

public class GetPlayersSummaryResponse : ISteamResponse
{
    public IEnumerable<PlayerSummary> Players { get; set; }
}