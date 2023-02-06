using System.Text;
using Flurl.Http;
using WhatCanWeGame.Api.Domain;
using WhatCanWeGame.Api.Services.Responses;

namespace WhatCanWeGame.Api.Services;

public class SteamService : ISteamService
{
    private const string BaseUrl = "http://api.steampowered.com";
    private const string SteamKey = "A32F409FD094001786BCA34C90DB0B55";

    private readonly ILogger<SteamService> _logger;

    public SteamService(ILogger<SteamService> logger)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<PlayerSummary>> GetPlayersSummary(string steamIds)
    {
        var url = BaseUrl + $"/ISteamUser/GetPlayerSummaries/v0002/?key={SteamKey}&steamids={steamIds}";
        var result = await url.GetJsonAsync<SteamResponse<GetPlayersSummaryResponse>>();

        return result.Response.Players;
    }

    public async Task<GetOwnedGamesResponse> GetOwnedgamesOfPlayer(string steamId)
    {
        var url = BaseUrl + $"/IPlayerService/GetOwnedGames/v0001/?key={SteamKey}&steamid={steamId}&include_appinfo=true";
        
        _logger.LogCritical(url);

        var result = await url.GetJsonAsync<SteamResponse<GetOwnedGamesResponse>>();

        return result.Response;
    }

    public async Task<IEnumerable<Game>> GetGamesInCommonWithPlayers(string steamId, IEnumerable<string> friends)
    {
        var myProfile = (await GetPlayersSummary(steamId)).First();
        myProfile.Games = (await GetOwnedgamesOfPlayer(steamId)).Games;

        var builder = new StringBuilder();

        foreach (var friend in friends)
        {
            builder.Append($"{friend},");
        }

        builder.Remove(builder.Length - 1, 1);
        
        var players = await GetPlayersSummary(builder.ToString());

        foreach (var friend in players)
        {
            friend.Games = (await GetOwnedgamesOfPlayer(friend.SteamId)).Games;
        }

        var games = new List<Game>();
        
        myProfile.Friends = players;
        foreach (var game in myProfile.Games)
        {
            var allHas = true;
            
            foreach (var friend in myProfile.Friends)
            {
                if (!friend.Games.Any(found => game.AppId == found.AppId))
                {
                    allHas = false;
                }
            }

            if (allHas)
            {
                games.Add(game);
            }
        }

        return games;
    }

    public async Task<IEnumerable<PlayerSummary>> GetFriendsListOfPlayer(string steamId)
    {
        var url = BaseUrl + $"/ISteamUser/GetFriendList/v0001/?key={SteamKey}&steamid={steamId}&relationship=friend";
        
        _logger.LogCritical(url);
        
        var result = await url.GetJsonAsync<GetFriendsListResponse>();

        if (result == null)
        {
            return null;
        }
        
        var builder = new StringBuilder();

        foreach (var friend in result.FriendsList.Friends)
        {
            builder.Append($"{friend.SteamId},");
        }

        builder.Remove(builder.Length - 1, 1);

        var friends = await GetPlayersSummary(builder.ToString());

        return friends;
    }
}