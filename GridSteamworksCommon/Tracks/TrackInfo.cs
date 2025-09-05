using GridSteamworksCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GridSteamworksCommon.Tracks
{
    public class TrackInfo
    {
        public Track Id { get; private set; }

        public Location LocationId { get; private set; }

        public string TrackName { get; private set; }

        public string FullName { get => fullNameLazy.Value; }

        public TrackType Type { get; private set; }

        public int Distance { get; private set; }

        private readonly Lazy<string> fullNameLazy;
        public TrackInfo() => fullNameLazy = new Lazy<string>(() => Id == default ? string.Empty : $"{locationNames[LocationId]} - {TrackName}");

        public static IEnumerable<TrackInfo> GetAll() => trackInfo.Select(p => new TrackInfo
        {
            Id = p.Key,
            LocationId = p.Value.Item1,
            Type = GetTrackType(p.Key),
            TrackName = p.Value.Item2,
            Distance = sprintDistance.TryGetValue(p.Key, out var d) ? d : 0,
        });

        public static bool GetDetails(int trackId, out string trackName, out string locationName, out TrackType type)
        {
            if (!Enum.IsDefined(typeof(Track), trackId))
            {
                trackName = default;
                locationName = default;
                type = default;
                return false;
            }
            var track = (Track)trackId;
            (var location, trackName) = trackInfo[track];
            locationName = locationNames[location];
            type = GetTrackType(track);

            return true;
        }

        private static TrackType GetTrackType(Track track)
        {
            if (liveroutes.Contains(track))
            {
                return TrackType.Liveroutes;
            }
            else if (sprintDistance.ContainsKey(track))
            {
                return TrackType.Sprint;
            }
            else
            {
                return TrackType.Loop;
            }
        }

        public static double GetSprintDistance(int trackId)
        {
            return sprintDistance.TryGetValue((Track)trackId, out var distance) ? distance / 10D : -1D;
        }

        public static int GetLiverouteDistance(int lapCount)
        {
            return lapCount >= 0 && lapCount < LiverouteDistance.Length ? LiverouteDistance[lapCount] : -1;
        }

        private static readonly Track[] liveroutes =
        [
            Track.Barcelona_Liveroutes,
            Track.Chicago_Liveroutes,
            Track.Dubai_Liveroutes,
            Track.Miami_Liveroutes,
            Track.Paris_Liveroutes
        ];

        public static readonly int[] LiverouteDistance = [5, 10, 20, 30];
        private static readonly Dictionary<Track, int> sprintDistance = new()
        {
            [Track.Okutama_MizuMountain] = 104,
            [Track.Okutama_TenshiWay] = 104,
            [Track.Okutama_ShintoShrine] = 70,
            [Track.Okutama_ToriiRush] = 69,
            [Track.Okutama_SakuraPass] = 40,
            [Track.Okutama_TatsuValley] = 55,

            [Track.California_BigSur] = 96,
            [Track.California_PebbleBeachDrive] = 96,
            [Track.California_RedwoodApproach] = 46,
            [Track.California_PacificWay] = 46,
            [Track.California_BixbyPass] = 50,
            [Track.California_CabrilloHighway] = 50,

            [Track.HongKong_PeakRoadDescent] = 95,
            [Track.HongKong_KowloonClimb] = 84,
            [Track.HongKong_MagazineGap] = 42,
            [Track.HongKong_PokFuLam] = 45,
            [Track.HongKong_WanChaiGap] = 51,
            [Track.HongKong_ApLeiChau] = 40,

            [Track.CoteDAzur_RouteDAzur] = 100,
            [Track.CoteDAzur_SaintLaurent] = 100,
            [Track.CoteDAzur_LaTurbie] = 48,
            [Track.CoteDAzur_RoutedeCorniche] = 48,
            [Track.CoteDAzur_Leopolda] = 53,
            [Track.CoteDAzur_VillefrancheSurMer] = 53,
        };

        private static readonly Dictionary<Location, string> locationNames = new()
        {
            [Location.Barcelona] = "Barcelona",
            [Location.Chicago] = "Chicago",
            [Location.Dubai] = "Dubai",
            [Location.Miami] = "Miami",
            [Location.Paris] = "Paris",
            [Location.Algavre] = "Algavre",
            [Location.BrandsHatch] = "Brands Hatch",
            [Location.Indianapolis] = "Indianapolis",
            [Location.Okutama] = "Okutama",
            [Location.California] = "California",
            [Location.HongKong] = "Hong Kong",
            [Location.CoteDAzur] = "Cote d'Azur",
            [Location.YasMarina] = "Yas Marina",
            [Location.RedBullRing] = "Red Bull Ring",
            [Location.SpaFrancorchamps] = "Spa-Francorchamps",
            [Location.MountPanorama] = "Mount Panorama",
            [Location.Detroit] = "Detroit"
        };

        private static readonly Dictionary<Track, (Location, string)> trackInfo = new()
        {
            [Track.Barcelona_MemorialRun] = (Location.Barcelona, "Memorial Run"),
            [Track.Barcelona_MarineGate] = (Location.Barcelona, "Marine Gate"),
            [Track.Barcelona_ColumbusBay] = (Location.Barcelona, "Columbus Bay"),
            [Track.Barcelona_CathedralPass] = (Location.Barcelona, "Cathedral Pass"),
            [Track.Barcelona_FountainLoop] = (Location.Barcelona, "Fountain Loop"),
            [Track.Barcelona_HighStreet] = (Location.Barcelona, "High Street"),
            [Track.Barcelona_Liveroutes] = (Location.Barcelona, "Liveroutes"),

            [Track.Chicago_TheLoop] = (Location.Chicago, "The Loop"),
            [Track.Chicago_UnderpassRing] = (Location.Chicago, "Underpass Ring"),
            [Track.Chicago_WabashRun] = (Location.Chicago, "Wabash Run"),
            [Track.Chicago_Riverside] = (Location.Chicago, "Riverside"),
            [Track.Chicago_MarinaCity] = (Location.Chicago, "Marina City"),
            [Track.Chicago_LakeShorePoint] = (Location.Chicago, "Lake Shore Point"),
            [Track.Chicago_Liveroutes] = (Location.Chicago, "Liveroutes"),

            [Track.Dubai_AlSufouhStrip] = (Location.Dubai, "Al Sufouh Strip"),
            [Track.Dubai_JumeirahBeach] = (Location.Dubai, "Jumeirah Beach"),
            [Track.Dubai_NakheelVista] = (Location.Dubai, "Nakheel Vista"),
            [Track.Dubai_NattanWay] = (Location.Dubai, "Nattan Way"),
            [Track.Dubai_OrraQuayLoop] = (Location.Dubai, "Orra Quay Loop"),
            [Track.Dubai_GulfApproach] = (Location.Dubai, "Gulf Approach"),
            [Track.Dubai_Liveroutes] = (Location.Dubai, "Liveroutes"),

            [Track.Miami_CollinsParkRing] = (Location.Miami, "Collins Park Ring"),
            [Track.Miami_OceanDrive] = (Location.Miami, "Ocean Drive"),
            [Track.Miami_ArtDecoLoop] = (Location.Miami, "Art Deco Loop"),
            [Track.Miami_DowntownSpeedway] = (Location.Miami, "Downtown Speedway"),
            [Track.Miami_SouthPointBay] = (Location.Miami, "South Point Bay"),
            [Track.Miami_CausewayApproach] = (Location.Miami, "Causeway Approach"),
            [Track.Miami_Liveroutes] = (Location.Miami, "Liveroutes"),

            [Track.Paris_ArcDeTriomphe] = (Location.Paris, "Arc de Triomphe"),
            [Track.Paris_AvenueDeNewYork] = (Location.Paris, "Avenue de New-York"),
            [Track.Paris_CircuitDeLaSeine] = (Location.Paris, "Circuit de la Seine"),
            [Track.Paris_ChampsElysees] = (Location.Paris, "Champs Élysées"),
            [Track.Paris_PontDelAlma] = (Location.Paris, "Pont de l'Alma"),
            [Track.Paris_LeTrocadero] = (Location.Paris, "le Trocadero"),
            [Track.Paris_Liveroutes] = (Location.Paris, "Liveroutes"),

            [Track.Algavre_SportCircuit] = (Location.Algavre, "Sport Circuit"),
            [Track.Algavre_GPCircuit] = (Location.Algavre, "GP Circuit"),
            [Track.Algavre_NationalCircuit] = (Location.Algavre, "National Circuit"),
            [Track.Algavre_ClubCircuit] = (Location.Algavre, "Club Circuit"),

            [Track.BrandsHatch_GPCircuit] = (Location.BrandsHatch, "GP Circuit"),
            [Track.BrandsHatch_GPCircuitReversed] = (Location.BrandsHatch, "GP Circuit Reversed"),
            [Track.BrandsHatch_IndyCircuit] = (Location.BrandsHatch, "Indy Circuit"),
            [Track.BrandsHatch_IndyCircuitReversed] = (Location.BrandsHatch, "Indy Circuit Reversed"),

            [Track.Indianapolis_SportCircuit] = (Location.Indianapolis, "Sport Circuit"),
            [Track.Indianapolis_GPCircuit] = (Location.Indianapolis, "GP Circuit"),
            [Track.Indianapolis_OvalCircuit] = (Location.Indianapolis, "Oval Circuit"),
            [Track.Indianapolis_InfieldCircuit] = (Location.Indianapolis, "Infield Circuit"),
            [Track.Indianapolis_NorthCircuit] = (Location.Indianapolis, "North Circuit"),

            [Track.Okutama_MizuMountain] = (Location.Okutama, "Mizu Mountain"),
            [Track.Okutama_TenshiWay] = (Location.Okutama, "Tenshi Way"),
            [Track.Okutama_ShintoShrine] = (Location.Okutama, "Shinto Shrine"),
            [Track.Okutama_ToriiRush] = (Location.Okutama, "Torii Rush"),
            [Track.Okutama_SakuraPass] = (Location.Okutama, "Sakura Pass"),
            [Track.Okutama_TatsuValley] = (Location.Okutama, "Tatsu Valley"),

            [Track.California_BigSur] = (Location.California, "Big Sur"),
            [Track.California_PebbleBeachDrive] = (Location.California, "Pebble Beach Drive"),
            [Track.California_RedwoodApproach] = (Location.California, "Redwood Approach"),
            [Track.California_PacificWay] = (Location.California, "Pacific Way"),
            [Track.California_BixbyPass] = (Location.California, "Bixby Pass"),
            [Track.California_CabrilloHighway] = (Location.California, "Cabrillo Highway"),

            [Track.HongKong_PeakRoadDescent] = (Location.HongKong, "Peak Road Descent"),
            [Track.HongKong_KowloonClimb] = (Location.HongKong, "Kowloon Climb"),
            [Track.HongKong_MagazineGap] = (Location.HongKong, "Magazine Gap"),
            [Track.HongKong_PokFuLam] = (Location.HongKong, "Pok Fu Lam"),
            [Track.HongKong_WanChaiGap] = (Location.HongKong, "Wan Chai Gap"),
            [Track.HongKong_ApLeiChau] = (Location.HongKong, "Ap Lei Chau"),

            [Track.CoteDAzur_RouteDAzur] = (Location.CoteDAzur, "Route d'Azur"),
            [Track.CoteDAzur_SaintLaurent] = (Location.CoteDAzur, "Saint-Laurent"),
            [Track.CoteDAzur_LaTurbie] = (Location.CoteDAzur, "La Turbie"),
            [Track.CoteDAzur_RoutedeCorniche] = (Location.CoteDAzur, "Route de Corniche"),
            [Track.CoteDAzur_Leopolda] = (Location.CoteDAzur, "Leopolda"),
            [Track.CoteDAzur_VillefrancheSurMer] = (Location.CoteDAzur, "Villefranche-sur-Mer"),

            [Track.YasMarina_GPCircuit] = (Location.YasMarina, "GP Circuit"),
            [Track.YasMarina_ChampionshipCircuit] = (Location.YasMarina, "Championship Circuit"),
            [Track.YasMarina_InternationalCircuit] = (Location.YasMarina, "International Circuit"),
            [Track.YasMarina_SouthCircuit] = (Location.YasMarina, "South Circuit"),
            [Track.YasMarina_PaddockCircuit] = (Location.YasMarina, "Paddock Circuit"),

            [Track.RedBullRing_GPCircuit] = (Location.RedBullRing, "GP Circuit"),
            [Track.RedBullRing_GPCircuitReversed] = (Location.RedBullRing, "GP Circuit Reversed"),
            [Track.RedBullRing_SouthCircuit] = (Location.RedBullRing, "South Circuit"),
            [Track.RedBullRing_SouthCircuitReversed] = (Location.RedBullRing, "South Circuit Reversed"),
            [Track.RedBullRing_NorthCircuit] = (Location.RedBullRing, "North Circuit"),
            [Track.RedBullRing_NorthCircuitReversed] = (Location.RedBullRing, "North Circuit Reversed"),

            [Track.SpaFrancorchamps_GPCircuit] = (Location.SpaFrancorchamps, "GP Circuit"),
            [Track.SpaFrancorchamps_Sportscar] = (Location.SpaFrancorchamps, "Sportscar"),
            [Track.SpaFrancorchamps_GPCircuitReversed] = (Location.SpaFrancorchamps, "GP Circuit Reversed"),
            [Track.SpaFrancorchamps_SportscarReversed] = (Location.SpaFrancorchamps, "Sportscar Reversed"),

            [Track.MountPanorama_MotorRacingCircuit] = (Location.MountPanorama, "Motor Racing Circuit"),
            [Track.MountPanorama_MotorRacingCircuitReversed] = (Location.MountPanorama, "Motor Racing Circuit Reversed"),

            [Track.Detroit_StadiumLong] = (Location.Detroit, "Stadium Long"),
            [Track.Detroit_StadiumShort] = (Location.Detroit, "Stadium Short"),
        };
    }
}