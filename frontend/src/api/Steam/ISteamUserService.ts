import request from "../axiosUtils";

const base = "/ISteamUser/";
const key = import.meta.env.VITE_STEAM_KEY;
const testId = 76561198141357223;

export default class ISteamUserService {
  static getPlayerSummaries() {
    return request({
      url: `/GetPlayerSummaries/v0002/?key=${key}&steamids=${testId}`,
      method: "GET",
    });
  }
}
