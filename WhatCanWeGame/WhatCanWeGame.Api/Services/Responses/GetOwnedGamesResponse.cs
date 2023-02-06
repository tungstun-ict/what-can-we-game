using WhatCanWeGame.Api.Domain;

namespace WhatCanWeGame.Api.Services.Responses;

public class GetOwnedGamesResponse : ISteamResponse
{
    public int GameCount { get; set; }
    public IEnumerable<Game> Games { get; set; }
}