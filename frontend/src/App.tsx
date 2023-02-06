import { useEffect, useState } from "react";
import reactLogo from "./assets/react.svg";
import "./app.scss";
import ISteamUserService from "./api/Steam/ISteamUserService";

function App() {
  useEffect(() => {
    ISteamUserService.getPlayerSummaries().then((response) => {
      console.log(response);
    });
  });
  return <div className="App"></div>;
}

export default App;
