## GRID 2 lobby search tool
So you can see everything without in-game search.

<img width="503" height="379" alt="image" src="https://github.com/user-attachments/assets/b4c296ad-382a-498a-ba5d-2819832b30ec" />

No need for setup or authorization of any kind (after it's built): start it with Steam running and tool should work.
### Features
- Lobby/playlist/group listing, online counter - rough estimation calculated as sum of all groups player count;
- If "personal" lobby listing is enabled and you create one, tool will make sounds when player count changes in it. With this, you can alt-tab and get notified if anyone joins;
- Setting properties on lobby: you may overwrite many properties which people see in search results - only visually, it won't affect gameplay. Disable updates on personal lobby control, set desired values and enable "set values" mode for that. It is possible to mimick a playlist lobby or mark it as something non-existent (like indycar derby), not sure if it will work well though.
### Limitations
- Steam treats tool as game: you launch tool = you launch GRID 2. If you want to start both, game should be started first;
- Currently there's no way to update a single property if you want to overwrite;
- If tool makes search request in nearly same time as you start search in game, due to how Steam API works, search in game may fail. If that happens, game will wait for a 30s or so and then will tell "no lobbies found". Repeat search if that happens; also, disabling "fetch update" temporarily or increasing interval may help with that.
### How to build
- You may need Visual Studio and .NET desktop development workload or any similar toolset;
- Download [Steamworks.NET](https://github.com/rlabrecque/Steamworks.NET/releases) standalone build and unpack it to directory of same name under solution base directory - present in repo, can't miss it;
- Should be buildable already; LobbyManagement is the main one and LobbySearch is "everything in one place" example console app.
