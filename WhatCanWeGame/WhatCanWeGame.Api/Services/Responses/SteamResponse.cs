using WhatCanWeGame.Api.Services;

namespace WhatCanWeGame.Api.Domain;

public class SteamResponse<TResponse> where TResponse : ISteamResponse
{
    public TResponse Response { get; set; }
}