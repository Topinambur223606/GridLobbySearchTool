using GridSteamworksCommon;
using GridSteamworksCommon.Enums;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LobbyManagement
{
    public partial class GroupDisplayControl : UserControl
    {
        public ulong LobbyId { get; private set; }

        public bool IsSettingsControl { get; set; }

        public event EventHandler<bool> MemberCountChange;

        public GroupDisplayControl()
        {
            InitializeComponent();
            ApplyFA(userIconLabel, FontAwesomeIcons.User, 16);
        }

        protected void ApplyFA(Control c, string icon, float fontSize)
        {
            if (Program.FontAwesome is null)
            {
                return;
            }
            c.Font = new Font(Program.FontAwesome, fontSize);
            c.Text = icon;
        }

        protected bool writable = true;

        public virtual void SetWritable(bool writable)
        {
            if (this.writable == writable)
            {
                return;
            }
            SetNumUpDownWritable(memberLimitNumericUpDown, writable);
            usernameTextBox.ReadOnly = !writable;
            SetComboBoxWritable(playlistTypeComboBox, writable);
            this.writable = writable;
        }

        protected void SetComboBoxWritable(ComboBox cb, bool writable)
        {
            if (writable)
            {
                if (cb.Tag is Control c)
                {
                    c.Visible = false;
                }
                cb.Enabled = true;
                cb.Visible = true;
            }
            else
            {
                if (!cb.Visible)
                {
                    return;
                }
                if (cb.Tag is not Control c)
                {
                    var tb = new TextBox
                    {
                        Text = cb.Text,
                        Font = cb.Font,
                        Location = new Point(cb.Location.X, cb.Location.Y + 1),
                        Size = cb.Size,
                        TabIndex = cb.TabIndex,
                        Name = cb.Name + "_replacingTextbox"
                    };
                    cb.TextChanged += (o, e) => tb.Text = cb.Text;
                    tb.ReadOnly = true;
                    cb.Parent.Controls.Add(tb);
                    c = tb;
                }
                c.Visible = true;
                cb.Enabled = false;
                cb.Visible = false;
            }
        }

        protected void SetNumUpDownWritable(NumericUpDown nud, bool writable)
        {
            nud.ReadOnly = !writable;
            nud.Increment = writable ? 1 : 0;
            nud.InterceptArrowKeys = writable;
            nud.Controls[0].Enabled = writable;
        }

        private void ClearSelection(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                tb.SelectionLength = 0;
            }
        }

        protected void OnMemberCountChange(bool changeIsPositive)
        {
            MemberCountChange?.Invoke(this, changeIsPositive);
        }

        private int memberCount;

        public void Reset() => memberCount = 0;


        public virtual void UpdateLobbyInfo(LobbyInfo lobbyInfo)
        {
            LobbyId = lobbyInfo.Id;
            if (!IsSettingsControl && Program.UserId == lobbyInfo.OwnerId)
            {
                playlistTypeComboBox.Visible = false;
                mainPanel.BackColor = Color.LightGreen;
            }
            if (lobbyInfo.IsGroup)
            {
                lobbyTypeLabel.Text = "Group";
                playlistTypeComboBox.Visible = false;
                if (playlistTypeComboBox.Tag is Control c)
                {
                    c.Visible = false;
                }
            }
            else
            {
                if (lobbyInfo.IsPlaylist || IsSettingsControl)
                {
                    playlistTypeComboBox.DataSource ??= Enum.GetValues(typeof(PlaylistType));
                    playlistTypeComboBox.SelectedItem = lobbyInfo.PlaylistType;
                }
                else
                {
                    lobbyTypeLabel.Text = "Lobby";
                }
            }
            usernameTextBox.Text = lobbyInfo.OwnerName;
            memberCountLabel.Text = lobbyInfo.MemberCount.ToString();
            memberLimitNumericUpDown.Value = lobbyInfo.OpenSlots + lobbyInfo.MemberCount;

            int prevMC = memberCount;
            memberCount = lobbyInfo.MemberCount;
            if (prevMC == 0 || memberCount == prevMC)
            {
                return;
            }
            OnMemberCountChange(memberCount > prevMC);
        }

        /// <summary>
        /// Only update readonly properties, currently member count is the only one<br/>
        /// Intended for use when editable controls define pushed info
        /// </summary>
        public void UpdateLobbyInfoReadonlyPart(LobbyInfo lobbyInfo)
        {
            memberCountLabel.Text = lobbyInfo.MemberCount.ToString();
        }

        private void PlaylistTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            lobbyTypeLabel.Text = playlistTypeComboBox.SelectedItem is PlaylistType pt && pt != PlaylistType.None ? "Playlist" : "Lobby";
        }
    }
}