using WhatCanWeGame.Api.Services;

namespace WhatCanWeGame.Api.Domain;

public class PlayerSummary : ISteamResponse
{
    public string SteamId { get; set; }
    public string PersonaName { get; set; }
    public string ProfileUrl { get; set; }
    public string AvatarFull { get; set; }
    public string PersonaState { get; set; }
    public string CommunityVisibilityState { get; set; }
    public string ProfileState { get; set; }
    public string LastLogoff { get; set; }
    public IEnumerable<PlayerSummary> Friends { get; set; }
    public IEnumerable<Game> Games { get; set; }
}