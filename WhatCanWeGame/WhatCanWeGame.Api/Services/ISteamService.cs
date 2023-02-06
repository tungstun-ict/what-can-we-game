using WhatCanWeGame.Api.Domain;

namespace WhatCanWeGame.Api.Services;

public interface ISteamService
{
    public Task<IEnumerable<PlayerSummary>> GetPlayersSummary(string steamId);
}