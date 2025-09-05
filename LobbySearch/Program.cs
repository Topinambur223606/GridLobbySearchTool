using GridSteamworksCommon;
using GridSteamworksCommon.Enums;
using GridSteamworksCommon.Tracks;
using Steamworks;
using System;
using System.IO;
using System.Threading;

namespace LobbySearch
{

    internal class Program
    {

        const int gridAppId = 44350;

        [STAThread]
        static void Main()
        {
            if (!SteamAPI.IsSteamRunning())
            {
                return;
            }
            File.WriteAllText("steam_appid.txt", gridAppId.ToString());
            if (!SteamAPI.Init())
            {
                throw new Exception("steam api not initialized");
            }
            try
            {
                using var runner = new SteamCallbackRunner();
                var query = new SteamDataContinuousQuery<LobbyMatchList_t>(SteamMatchmaking.RequestLobbyList, runner);
                foreach (var result in query)
                {
                    DisplayLobbyDetails(result.m_nLobbiesMatching);
                    var input = Console.ReadLine();
                    if (input == "e")
                    {
                        break;
                    }
                    if (int.TryParse(input, out var index))
                    {
                        var id = SteamMatchmaking.GetLobbyByIndex(index);
                        var callId = SteamMatchmaking.JoinLobby(id);
                        LobbyDataUpdate_t res = default;
                        bool fail = false;
                        using var callback = CallResult<LobbyDataUpdate_t>.Create((u, f) =>
                        {
                            res = u;
                            fail = f;
                        });
                        callback.Set(callId);
                        Thread.Sleep(1000);
                        SteamAPI.RunCallbacks();
                    }
                }

            }
            finally
            {
                SteamAPI.Shutdown();
            }
        }

        private static void DisplayLobbyDetails(uint lobbyCount)
        {
            Console.Clear();
            //var userId = SteamUser.GetSteamID().m_SteamID;

            bool includeRaw = false;

            for (uint lj = 0; lj < lobbyCount; lj++)
            {
                var lobby = LobbyInfo.Read((int)lj, includeRaw);
                if (lobby is null)
                {
                    continue;
                }
                if (lobby.IsGroup)
                {
                    continue;
                }
                if (!lobby.IsPlaylist)
                {
                    //continue;
                }
                Console.WriteLine($"Lobby #{lj}, ID {lobby.Id}");
                if (lobby.IsPlaylist)
                {
                    Console.WriteLine($"Playlist type: {lobby.PlaylistType}");
                }
                Console.WriteLine($"Owner: {lobby.OwnerName} ({lobby.OwnerId}), lvl {lobby.OwnerLevel}, hostility {lobby.OwnerHostilityRating}");
                Console.WriteLine($"Members: {lobby.MemberCount}/{lobby.MemberCount + lobby.OpenSlots}");
                if (lobby.IsGroup)
                {
                    Console.WriteLine("Group");
                    Console.WriteLine();
                    Console.WriteLine();
                    continue;
                }
                Console.WriteLine($"{lobby.RaceType} {lobby.Tier} {(lobby.DlcEnabled ? null : "no")}DLC");
                Console.WriteLine($"In race: {lobby.CurrentlyInRace}");
                Console.WriteLine($"Track: {lobby.TracksComplete + 1}/{lobby.TracksTotal}");
                if (TrackInfo.GetDetails(lobby.TrackId, out var trackName, out var location, out var trackType))
                {
                    string distanceStr = trackType switch
                    {
                        TrackType.Sprint => $"{TrackInfo.GetSprintDistance(lobby.TrackId):F1} km",
                        TrackType.Loop => $"{lobby.LapCount} lap{(lobby.LapCount == 1 ? null : "s")}",
                        TrackType.Liveroutes => $"{TrackInfo.GetLiverouteDistance(lobby.LapCount)} km",
                        _ => "??? km"
                    };
                    Console.WriteLine($"Current map: {location}, {trackName} ({lobby.TimeOfDay}) - {distanceStr}");
                }
                Console.WriteLine($"Time after finish: {lobby.FinishCountdown}");
                Console.WriteLine($"Flashback count: {(lobby.FlashbackCount == 6 ? "Infinite" : lobby.FlashbackCount.ToString())}");
                Console.WriteLine($"Collision disabled: {lobby.CollisionDisabled}");
                Console.WriteLine($"Damage type: {lobby.DamageType}");
                Console.WriteLine($"Force manual gearbox: {lobby.ForceManualGearbox}");
                Console.WriteLine($"Rating restrictions disabled: {lobby.RatingRestictionsDisabled}");

                if (includeRaw)
                {
                    foreach (var v in lobby.OtherValues)
                    {
                        Console.WriteLine($"{v.Key}: {v.Value}");
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }

}
