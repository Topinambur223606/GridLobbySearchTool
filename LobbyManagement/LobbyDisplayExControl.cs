using GridSteamworksCommon;
using GridSteamworksCommon.Enums;
using System.Drawing;

namespace LobbyManagement
{
    public partial class LobbyDisplayExControl : LobbyMgmtControl
    {
        public LobbyDisplayExControl()
        {
            InitializeComponent();
            ApplyFA(collisionIconLabel, FontAwesomeIcons.Car + FontAwesomeIcons.CarBurst, 20);
            ApplyFA(damageTypeIconLabel, FontAwesomeIcons.Burst, 20);
            ApplyFA(flashbackIconLabel, FontAwesomeIcons.ArrowsRotate, 20);
            ApplyFA(timeIconLabel, FontAwesomeIcons.Stopwatch, 20);
        }

        const string infinity = "\u221E";

        public override void UpdateLobbyInfo(LobbyInfo lobbyInfo)
        {
            base.UpdateLobbyInfo(lobbyInfo);
            timeOfDayLabel.Text = lobbyInfo.TimeOfDay.ToString();
            SetEnabled(collisionIconLabel, !lobbyInfo.CollisionDisabled);
            SetEnabled(manualGearboxLabel, lobbyInfo.ForceManualGearbox);
            manualGearboxLabel.Text = lobbyInfo.ForceManualGearbox ? "Manual gearbox" : "No manual gearbox";
            damageTypeIconLabel.ForeColor = lobbyInfo.DamageType switch
            {
                DamageType.Visual => Color.LightBlue,
                DamageType.Full => Color.Firebrick,
                _ => SystemColors.ControlDark
            };
            SetEnabled(flashbackIconLabel, lobbyInfo.FlashbackCount > 0);
            flashbackLabel.Text = lobbyInfo.FlashbackCount == 6 ? infinity : lobbyInfo.FlashbackCount.ToString();
            timeLabel.Text = lobbyInfo.FinishCountdown.ToString();
        }
    }
}