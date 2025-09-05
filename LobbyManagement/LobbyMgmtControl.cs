using GridSteamworksCommon;
using GridSteamworksCommon.Enums;
using GridSteamworksCommon.Tracks;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LobbyManagement
{
    public partial class LobbyMgmtControl : GroupDisplayControl
    {
        private static readonly Dictionary<int, TrackInfo> allTracks = TrackInfo.GetAll().ToDictionary(n => (int)n.Id, n => n);
        private static readonly TrackInfo[] allTracksArray = allTracks.Values.OrderBy(t => t.Id).ToArray();

        public LobbyMgmtControl()
        {
            InitializeComponent();
            ApplyFA(ratingLabel, FontAwesomeIcons.CircleExclamation, 16);
            ApplyFA(dlcLabel, FontAwesomeIcons.Download, 24);
            ApplyFA(inRaceLabel, FontAwesomeIcons.FlagCheckered, 20);

            typeComboBox.DataSource = Enum.GetValues(typeof(RaceType));
            tierComboBox.DataSource = Enum.GetValues(typeof(Tier));
            trackNameComboBox.DataSource = allTracksArray;
            lengthComboBox.DataSource = TrackInfo.LiverouteDistance;
        }

        public override void SetWritable(bool writable)
        {
            if (this.writable == writable)
            {
                return;
            }
            base.SetWritable(writable);
            SetLabelClickable(ratingLabel, writable);
            SetLabelClickable(inRaceLabel, writable);
            SetLabelClickable(dlcLabel, writable);
            SetNumUpDownWritable(trackCurrentNumericUpDown, writable);
            SetNumUpDownWritable(tracksTotalNumericUpDown, writable);
            SetComboBoxWritable(lengthComboBox, writable);
            SetNumUpDownWritable(lengthNumericUpDown, writable && lengthNumericUpDown.DecimalPlaces == 0);
            SetComboBoxWritable(tierComboBox, writable);
            SetComboBoxWritable(typeComboBox, writable);
            SetComboBoxWritable(trackNameComboBox, writable);
        }

        protected static void SetLabelClickable(Label iconLabel, bool enabled)
        {
            iconLabel.Cursor = enabled ? Cursors.Hand : Cursors.Default;
        }

        protected static void SetEnabled(Label iconLabel, bool enabled)
        {
            iconLabel.ForeColor = enabled ? SystemColors.ControlText : SystemColors.ControlDark;
        }



        public override void UpdateLobbyInfo(LobbyInfo lobbyInfo)
        {
            base.UpdateLobbyInfo(lobbyInfo);
            SetRating(lobbyInfo.OwnerHostilityRating, lobbyInfo.RatingRestictionsDisabled);
            SetEnabled(dlcLabel, dlcEnabled = lobbyInfo.DlcEnabled);
            SetInRace(lobbyInfo.CurrentlyInRace);
            typeComboBox.SelectedItem = lobbyInfo.RaceType;
            tierComboBox.SelectedItem = lobbyInfo.Tier;
            trackCurrentNumericUpDown.Value = lobbyInfo.TracksComplete + 1;
            tracksTotalNumericUpDown.Value = lobbyInfo.TracksTotal;
            if (!allTracks.TryGetValue(lobbyInfo.TrackId, out var trackInfo))
            {
                return;
            }
            trackNameComboBox.SelectedItem = trackInfo;
            SetLength(trackInfo, lobbyInfo.LapCount);
        }

        private void SetLength(TrackInfo trackInfo, int lapCount)
        {
            if (trackInfo.Type == TrackType.Liveroutes)
            {
                lengthNumericUpDown.Visible = false;
                lengthComboBox.Visible = true;
                lengthComboBox.SelectedIndex = lapCount - 1;
                lengthUnitLabel.Text = "km";
            }
            else
            {
                lengthComboBox.Visible = false;
                lengthNumericUpDown.Visible = true;
                if (trackInfo.Type == TrackType.Sprint)
                {
                    SetNumUpDownWritable(lengthNumericUpDown, false);
                    lengthNumericUpDown.DecimalPlaces = 1;
                    lengthNumericUpDown.Value = trackInfo.Distance / 10M;
                    lengthUnitLabel.Text = "km";
                }
                else
                {
                    SetNumUpDownWritable(lengthNumericUpDown, writable);
                    lengthNumericUpDown.DecimalPlaces = 0;
                    lengthNumericUpDown.Value = lapCount;
                    lengthUnitLabel.Text = lapCount == 1 ? "lap" : "laps";
                }
            }
        }

        private void SetInRace(bool value)
        {
            inRace = value;
            SetEnabled(inRaceLabel, value);
            inRaceLabel.Text = value ? FontAwesomeIcons.FlagCheckered : FontAwesomeIcons.HourglassHalf;
        }

        private void SetRating(int rating, bool ignored)
        {
            if (ignored)
            {
                ratingLabel.Text = FontAwesomeIcons.CircleQuestion;
                this.rating = -1;
            }
            else
            {
                ratingLabel.Text = FontAwesomeIcons.CircleExclamation;
                this.rating = rating;
            }
            ratingLabel.ForeColor = this.rating switch
            {
                4 => Color.Firebrick,
                3 => Color.DarkOrange,
                2 => Color.Goldenrod,
                1 => Color.OliveDrab,
                _ => Color.White,
            };
        }

        private bool dlcEnabled;
        private bool inRace;
        private int rating;
        private int lapCount;

        internal void PushLobbyInfo(bool force)
        {
            const string flagValue = "100";
            var lobbyId = new CSteamID(LobbyId);
            if (!force)
            {
                var flagValueCurrent = SteamMatchmaking.GetLobbyData(lobbyId, KnownKeys.OwnerLevel);
                if (flagValueCurrent == flagValue)
                {
                    return;
                }
            }
            SteamMatchmaking.SetLobbyData(lobbyId, KnownKeys.OwnerLevel, flagValue);
            bool ignoreRating = rating == -1;
            int ratingToSend = ignoreRating ? 4 : rating;
            int type = 0, tier = 0, playlistType = 0, track = 0;
            Invoke(() =>
            {
                type = (int)(RaceType)typeComboBox.SelectedItem;
                tier = (int)(Tier)tierComboBox.SelectedItem;
                playlistType = (int)(PlaylistType)playlistTypeComboBox.SelectedItem;
                track = (int)(trackNameComboBox.SelectedItem as TrackInfo).Id;
            });
            bool isPlaylist = playlistType > 0;
            int tracksComplete = (int)(trackCurrentNumericUpDown.Value - 1);
            int tracksTotal = (int)tracksTotalNumericUpDown.Value;
            var memberCount = SteamMatchmaking.GetNumLobbyMembers(lobbyId);
            int openSlots = (int)(memberLimitNumericUpDown.Value - memberCount);

            void Set<T>(string key, T value) => SteamMatchmaking.SetLobbyData(lobbyId, key, value.ToString());
            void SetB(string key, bool value) => Set(key, value ? 1 : 0);

            Set(KnownKeys.OwnerName, usernameTextBox.Text);
            Set(KnownKeys.OpenSlots, openSlots);
            Set(KnownKeys.RaceType, type);
            Set(KnownKeys.CarTier, tier);
            Set(KnownKeys.HostilityRating, ratingToSend);
            SetB(KnownKeys.InRace, inRace);
            Set(KnownKeys.DlcFlags, dlcEnabled ? LobbyInfo.AllDlcFlags : 0);
            Set(KnownKeys.TracksTotal, tracksTotal);
            Set(KnownKeys.TracksComplete, tracksComplete);
            Set(KnownKeys.CurrentLapCount, lapCount);
            SetB(KnownKeys.GameType, isPlaylist);
            Set(KnownKeys.PlaylistType, playlistType);
            SetB(KnownKeys.RatingCheckDisabled, ignoreRating);
            Set(KnownKeys.TrackId, track);
            if (isPlaylist)
            {
                if ((PlaylistType)playlistType == PlaylistType.Hardcore)
                {
                    Set(KnownKeys.DamageType, (int)DamageType.Full);
                    Set(KnownKeys.FlashbackCount, 0);
                }
                else
                {
                    Set(KnownKeys.DamageType, (int)DamageType.Visual);
                    Set(KnownKeys.FlashbackCount, 5);
                }
            }
        }

        private void LengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!IsSettingsControl)
            {
                return;
            }
            if (!lengthNumericUpDown.Visible)
            {
                return;
            }
            lapCount = lengthNumericUpDown.DecimalPlaces == 0 ? (int)lengthNumericUpDown.Value : 1;
        }

        private void LengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsSettingsControl)
            {
                return;
            }
            if (!lengthComboBox.Visible)
            {
                return;
            }
            lapCount = lengthComboBox.SelectedIndex;
        }

        private void InRaceLabel_Click(object sender, EventArgs e)
        {
            if (!IsSettingsControl)
            {
                return;
            }
            if (!writable)
            {
                return;
            }
            SetInRace(inRace = !inRace);
        }

        private void TrackNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsSettingsControl)
            {
                return;
            }
            if (!writable)
            {
                return;
            }
            SetLength(trackNameComboBox.SelectedItem as TrackInfo, 1);
        }

        private void DlcLabel_Click(object sender, EventArgs e)
        {
            if (!IsSettingsControl)
            {
                return;
            }
            if (!writable)
            {
                return;
            }
            SetEnabled(dlcLabel, dlcEnabled = !dlcEnabled);
        }

        private void RatingLabel_Click(object sender, EventArgs e)
        {
            if (!IsSettingsControl)
            {
                return;
            }
            if (!writable)
            {
                return;
            }
            SetRating(rating + 1, rating == 4);
        }
    }
}