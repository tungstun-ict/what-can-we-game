## Steam API
GetPlayerSummaries (v0002)
 - steamid
 - personaname
 - avatar
 - profileurl
 - personastate
 - lastlogoff (unix time)

GetFriendList (v0001)
 - steamid
 - relationship

GetOwnedGames (v0001)
 - game_count
 - games[
    appid
    name
    playtime_2weeks
    playtime_forever
    img_icon_url, img_logo_url
    has_community_cisible_stats
 ]