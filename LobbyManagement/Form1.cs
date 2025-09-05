using GridSteamworksCommon;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace LobbyManagement
{
    public partial class Form1 : Form
    {
        private readonly IEnumerator<LobbyMatchList_t> queryEnumerator;
        private readonly Timer listUpdateTimer;
        private readonly Timer myLobbyPushUpdateTimer;

        public Form1(IEnumerator<LobbyMatchList_t> queryEnumerator)
        {
            myLobbyPushUpdateTimer = new(300);
            myLobbyPushUpdateTimer.Elapsed += MyLobbyUpdateTimer_Elapsed;
            listUpdateTimer = new();
            listUpdateTimer.Elapsed += ListUpdateTimer_Elapsed;
            this.queryEnumerator = queryEnumerator;
            InitializeComponent();
            UpdateIntervalNumericUpDown_ValueChanged(this, EventArgs.Empty);
        }

        private void ListUpdateTimer_Elapsed(object sender, EventArgs e)
        {
            if (!queryEnumerator.MoveNext())
            {
                return;
            }
            if (Disposing || IsDisposed)
            {
                return;
            }
            var existing = flowLayoutPanel1.Controls.OfType<GroupDisplayControl>().ToDictionary(c => c.LobbyId, c => c);

            List<LobbyInfo> allLobbies;
            do
            {
                allLobbies = Enumerable.Range(0, (int)queryEnumerator.Current.m_nLobbiesMatching)
                                                    .Select(i => LobbyInfo.Read(i, false))
                                                    .Where(l => l is not null)
                                                    .ToList();
            }
            while (allLobbies.Select(l => l.Id).Distinct().Count() != allLobbies.Count);
            var online = allLobbies.Where(l => l.IsGroup).Sum(g => g.MemberCount);
            var personalLobby = allLobbies.FirstOrDefault(l => l.OwnerId == Program.UserId && l.IsGroup == false);
            if (Disposing || IsDisposed)
            {
                return;
            }
            try
            {
                Invoke(() =>
                {
                    if (personalLobby is null)
                    {
                        myLobbyMgmtControl.Visible = false;
                        updateMyLobbyCheckBox.Visible = false;
                        setMyLobbyCheckBox.Visible = false;
                        if (updateMyLobbyCheckBox.Checked)
                        {
                            updateMyLobbyCheckBox.Checked = false;
                        }
                        if (setMyLobbyCheckBox.Checked)
                        {
                            setMyLobbyCheckBox.Checked = false;
                        }
                    }
                    else
                    {
                        if (!myLobbyMgmtControl.Visible)
                        {
                            myLobbyMgmtControl.Visible = true;
                            myLobbyMgmtControl.SetWritable(false);
                            myLobbyMgmtControl.Reset();
                            setMyLobbyCheckBox.Visible = true;
                            updateMyLobbyCheckBox.Visible = true;
                            updateMyLobbyCheckBox.Checked = true;
                        }
                        if (UpdateState == MyLobbyUpdateState.Fetching)
                        {
                            myLobbyMgmtControl.UpdateLobbyInfo(personalLobby);
                        }
                        else
                        {
                            myLobbyMgmtControl.UpdateLobbyInfoReadonlyPart(personalLobby);
                        }
                    }
                    onlineCounterLabel.Text = online.ToString();
                    flowLayoutPanel1.SuspendLayout();
                });
                foreach (var lobbyInfo in allLobbies.OrderBy(l => l.IsGroup)
                                                    .ThenBy(l => l.IsPlaylist))
                {
                    if (lobbyInfo.OwnerId == Program.UserId && !showPersonalCheckBox.Checked ||
                        lobbyInfo.IsGroup && !showGroupsCheckBox.Checked ||
                        lobbyInfo.IsPlaylist && !showPlaylistsCheckBox.Checked ||
                        !(lobbyInfo.IsGroup || lobbyInfo.IsPlaylist || showLobbiesCheckBox.Checked))
                    {
                        continue;
                    }

                    if (existing.TryGetValue(lobbyInfo.Id, out var control))
                    {
                        existing.Remove(lobbyInfo.Id);
                        Invoke(() => control.UpdateLobbyInfo(lobbyInfo));
                    }
                    else
                    {
                        Invoke(() =>
                        {
                            if (lobbyInfo.IsGroup)
                            {
                                control = new GroupDisplayControl();
                            }
                            else
                            {
                                control = new LobbyDisplayExControl();
                                if (lobbyInfo.OwnerId == Program.UserId)
                                {
                                    control.MemberCountChange += OnMyLobbyMemberCountChange;
                                }
                            }
                            control.SetWritable(false);
                            control.UpdateLobbyInfo(lobbyInfo);
                            flowLayoutPanel1.Controls.Add(control);
                        });
                    }
                    Invoke(control.SendToBack);
                }
                if (existing.Count > 0)
                {
                    Invoke(() =>
                    {
                        foreach (var notUpdated in existing.Values)
                        {
                            flowLayoutPanel1.Controls.Remove(notUpdated);
                            notUpdated.Dispose();
                        }
                    });
                }
                Invoke(new Action(flowLayoutPanel1.ResumeLayout));
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListUpdateTimer_Elapsed(sender, e);
            listUpdateTimer.Start();
        }

        enum MyLobbyUpdateState
        {
            None,
            Fetching,
            Pushing,
            Changing
        }

        private MyLobbyUpdateState updateState;
        private MyLobbyUpdateState UpdateState
        {
            get => updateState;
            set
            {
                updateState = value;
                myLobbyMgmtControl.SetWritable(value == MyLobbyUpdateState.None);
            }
        }
        private void OnMyLobbyMemberCountChange(object sender, bool changeIsPositive)
        {
            Task.Run(() => Console.Beep(changeIsPositive ? 1000 : 500, 250));
        }

        private void MyLobbyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdateState is MyLobbyUpdateState.Changing)
            {
                return;
            }
            if (UpdateState is MyLobbyUpdateState.None)
            {
                if (updateMyLobbyCheckBox.Checked)
                {
                    UpdateState = MyLobbyUpdateState.Fetching;
                }
                else
                {
                    StartPushing();
                }
            }
            else if (UpdateState is MyLobbyUpdateState.Fetching)
            {
                if (setMyLobbyCheckBox.Checked)
                {
                    UpdateState = MyLobbyUpdateState.Changing;
                    updateMyLobbyCheckBox.Checked = false;
                    StartPushing();
                }
                else
                {
                    UpdateState = MyLobbyUpdateState.None;
                }
            }
            else if (UpdateState is MyLobbyUpdateState.Pushing)
            {
                myLobbyPushUpdateTimer.Stop();

                if (updateMyLobbyCheckBox.Checked)
                {
                    UpdateState = MyLobbyUpdateState.Changing;
                    setMyLobbyCheckBox.Checked = false;
                    UpdateState = MyLobbyUpdateState.Fetching;
                }
                else
                {
                    UpdateState = MyLobbyUpdateState.None;
                }
            }
        }

        private void StartPushing()
        {
            UpdateState = MyLobbyUpdateState.Pushing;
            myLobbyMgmtControl.PushLobbyInfo(true);
            myLobbyPushUpdateTimer.Start();
        }

        private void MyLobbyUpdateTimer_Elapsed(object sender, EventArgs e)
        {
            myLobbyMgmtControl.PushLobbyInfo(false);
        }

        private void PerformUpdatesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            listUpdateTimer.Enabled = performUpdatesCheckBox.Checked;
        }

        private void UpdateIntervalNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            listUpdateTimer.Interval = 1000D * (double)updateIntervalNumericUpDown.Value;
        }
    }
}