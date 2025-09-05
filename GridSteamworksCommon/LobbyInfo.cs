using GridSteamworksCommon.Enums;
using Steamworks;
using System.Collections.Generic;

namespace GridSteamworksCommon
{
    public class LobbyInfo
    {
        public ulong Id { get; set; }
        public bool IsGroup { get; set; }
        public bool IsPlaylist { get; set; }
        public ulong OwnerId { get; set; }
        public string OwnerName { get; set; }
        public int OwnerHostilityRating { get; set; }
        public int OwnerLevel { get; set; }
        public PlaylistType PlaylistType { get; set; }
        public RaceType RaceType { get; set; }
        public Tier Tier { get; set; }
        public bool DlcEnabled { get; set; }
        public int MemberCount { get; set; }
        public int OpenSlots { get; set; }
        public bool CurrentlyInRace { get; set; }
        public int TracksTotal { get; set; }
        public int TracksComplete { get; set; }
        public int TrackId { get; set; }
        public int LapCount { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
        public int FinishCountdown { get; set; }
        public bool CollisionDisabled { get; set; }
        public DamageType DamageType { get; set; }
        public int FlashbackCount { get; set; }
        public bool ForceManualGearbox { get; set; }
        public bool RatingRestictionsDisabled { get; set; }
        public Dictionary<string, string> OtherValues { get; set; }

        public const int AllDlcFlags = 16376;

        public static LobbyInfo Read(int index, bool includeRaw)
        {
            var lobbyId = SteamMatchmaking.GetLobbyByIndex(index);
            string Read(string key) => SteamMatchmaking.GetLobbyData(lobbyId, key);
            bool TryReadInt(string key, out int v) => int.TryParse(Read(key), out v);

            Dictionary<string, string> otherValues = null;
            if (includeRaw)
            {
                otherValues = [];
                var dataCount = SteamMatchmaking.GetLobbyDataCount(lobbyId);
                if (dataCount == 0)
                {
                    return null;
                }


                for (int dj = 0; dj < dataCount; dj++)
                {
                    if (SteamMatchmaking.GetLobbyDataByIndex(lobbyId, dj, out string key, 256, out string value, 256))
                    {
                        //if (KnownKeys.All.Contains(key))
                        //{
                        //    continue;
                        //}
                        otherValues[key] = value;
                    }
                }
            }

            var ownerName = Read(KnownKeys.OwnerName);
            if (string.IsNullOrEmpty(ownerName))
            {
                return null;
            }
            if (!ulong.TryParse(Read(KnownKeys.OwnerId), out var ownerId))
            {
                return null;
            }
            var memberCount = SteamMatchmaking.GetNumLobbyMembers(lobbyId);
            if (memberCount == 0)
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.OpenSlots, out var openSlots))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.GameMode, out var gameMode))
            {
                return null;
            }
            if (gameMode == 0)
            {
                return new LobbyInfo
                {
                    Id = lobbyId.m_SteamID,
                    IsGroup = true,
                    OwnerName = ownerName,
                    OwnerId = ownerId,
                    MemberCount = memberCount,
                    OpenSlots = openSlots,
                    OtherValues = otherValues
                };
            }
            if (!TryReadInt(KnownKeys.GameType, out var gameType))
            {
                return null;
            }
            //var limit = SteamMatchmaking.GetLobbyMemberLimit(lobbyId); // always 12
            if (!TryReadInt(KnownKeys.RaceType, out var raceType))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.HostilityRating, out var hostilityRating))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.InRace, out var inRace))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.DlcFlags, out var dlcFlags))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.TracksTotal, out var tracksTotal))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.CarTier, out var tier))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.CurrentLapCount, out var lapCount))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.TimeOfDay, out var timeOfDay))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.TimeAfterFinish, out var timeAfterFinish))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.NoCollision, out var noCollision))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.DamageType, out var damageType))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.FlashbackCount, out var flashbackCount))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.ManualGearbox, out var manualGearbox))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.RatingCheckDisabled, out var ratingCheckDisabled))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.TracksComplete, out var tracksComplete))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.PlaylistType, out var playlistType))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.OwnerLevel, out var ownerLevel))
            {
                return null;
            }
            if (!TryReadInt(KnownKeys.TrackId, out var mapId))
            {
                return null;
            }

            return new LobbyInfo
            {
                Id = lobbyId.m_SteamID,
                IsPlaylist = gameType == 1,
                OwnerName = ownerName,
                OwnerId = ownerId,
                MemberCount = memberCount,
                OpenSlots = openSlots,
                RaceType = (RaceType)raceType,
                Tier = (Tier)tier,
                OwnerLevel = ownerLevel,
                OwnerHostilityRating = hostilityRating,
                CurrentlyInRace = inRace == 1,
                DlcEnabled = dlcFlags > 0,
                TracksTotal = tracksTotal,
                LapCount = lapCount,
                TracksComplete = tracksComplete,
                TimeOfDay = (TimeOfDay)timeOfDay,
                FinishCountdown = 15 * (1 + timeAfterFinish),
                CollisionDisabled = noCollision == 1,
                DamageType = (DamageType)damageType,
                FlashbackCount = flashbackCount,
                ForceManualGearbox = manualGearbox == 1,
                RatingRestictionsDisabled = ratingCheckDisabled == 1,
                PlaylistType = (PlaylistType)playlistType,
                OtherValues = otherValues,
                TrackId = mapId
            };
        }
    }

}
