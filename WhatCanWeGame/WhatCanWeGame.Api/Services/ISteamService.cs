using WhatCanWeGame.Api.Domain;
using WhatCanWeGame.Api.Services.Responses;

namespace WhatCanWeGame.Api.Services;

public interface ISteamService
{
    public Task<IEnumerable<PlayerSummary>> GetPlayersSummary(string steamIds);
    public Task<IEnumerable<PlayerSummary>> GetFriendsListOfPlayer(string steamId);
    public Task<GetOwnedGamesResponse> GetOwnedgamesOfPlayer(string steamId);

    public Task<IEnumerable<Game>> GetGamesInCommonWithPlayers(string steamId, IEnumerable<string> friends);
}