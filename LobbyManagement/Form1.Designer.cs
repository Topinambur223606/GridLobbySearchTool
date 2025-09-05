namespace LobbyManagement
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            listUpdateTimer.Stop();
            myLobbyPushUpdateTimer.Stop();
            listUpdateTimer.Dispose();
            myLobbyPushUpdateTimer.Dispose();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.updateIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.performUpdatesCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.showLobbiesCheckBox = new System.Windows.Forms.CheckBox();
            this.showPlaylistsCheckBox = new System.Windows.Forms.CheckBox();
            this.showGroupsCheckBox = new System.Windows.Forms.CheckBox();
            this.updateMyLobbyCheckBox = new System.Windows.Forms.CheckBox();
            this.setMyLobbyCheckBox = new System.Windows.Forms.CheckBox();
            this.showPersonalCheckBox = new System.Windows.Forms.CheckBox();
            this.onlineCounterLabel = new System.Windows.Forms.Label();
            this.myLobbyMgmtControl = new LobbyManagement.LobbyMgmtControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1004, 582);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.updateIntervalNumericUpDown);
            this.panel1.Controls.Add(this.performUpdatesCheckBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.showLobbiesCheckBox);
            this.panel1.Controls.Add(this.showPlaylistsCheckBox);
            this.panel1.Controls.Add(this.showGroupsCheckBox);
            this.panel1.Controls.Add(this.updateMyLobbyCheckBox);
            this.panel1.Controls.Add(this.setMyLobbyCheckBox);
            this.panel1.Controls.Add(this.showPersonalCheckBox);
            this.panel1.Controls.Add(this.onlineCounterLabel);
            this.panel1.Controls.Add(this.myLobbyMgmtControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 582);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 144);
            this.panel1.TabIndex = 1;
            // 
            // updateIntervalNumericUpDown
            // 
            this.updateIntervalNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.updateIntervalNumericUpDown.Dock = System.Windows.Forms.DockStyle.Left;
            this.updateIntervalNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateIntervalNumericUpDown.Location = new System.Drawing.Point(653, 0);
            this.updateIntervalNumericUpDown.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.updateIntervalNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updateIntervalNumericUpDown.Name = "updateIntervalNumericUpDown";
            this.updateIntervalNumericUpDown.Size = new System.Drawing.Size(58, 42);
            this.updateIntervalNumericUpDown.TabIndex = 5;
            this.updateIntervalNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.updateIntervalNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.updateIntervalNumericUpDown.ValueChanged += new System.EventHandler(this.UpdateIntervalNumericUpDown_ValueChanged);
            // 
            // performUpdatesCheckBox
            // 
            this.performUpdatesCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.performUpdatesCheckBox.Checked = true;
            this.performUpdatesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.performUpdatesCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.performUpdatesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.performUpdatesCheckBox.Location = new System.Drawing.Point(464, 0);
            this.performUpdatesCheckBox.Name = "performUpdatesCheckBox";
            this.performUpdatesCheckBox.Size = new System.Drawing.Size(189, 42);
            this.performUpdatesCheckBox.TabIndex = 4;
            this.performUpdatesCheckBox.Text = "Fetch updates once in";
            this.performUpdatesCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.performUpdatesCheckBox.UseVisualStyleBackColor = true;
            this.performUpdatesCheckBox.CheckedChanged += new System.EventHandler(this.PerformUpdatesCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(714, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 41);
            this.label2.TabIndex = 2;
            this.label2.Text = "seconds";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(870, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Online";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // showLobbiesCheckBox
            // 
            this.showLobbiesCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.showLobbiesCheckBox.Checked = true;
            this.showLobbiesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showLobbiesCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.showLobbiesCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showLobbiesCheckBox.Location = new System.Drawing.Point(348, 0);
            this.showLobbiesCheckBox.Name = "showLobbiesCheckBox";
            this.showLobbiesCheckBox.Size = new System.Drawing.Size(116, 42);
            this.showLobbiesCheckBox.TabIndex = 1;
            this.showLobbiesCheckBox.Text = "Lobbies";
            this.showLobbiesCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showLobbiesCheckBox.UseVisualStyleBackColor = true;
            // 
            // showPlaylistsCheckBox
            // 
            this.showPlaylistsCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.showPlaylistsCheckBox.Checked = true;
            this.showPlaylistsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPlaylistsCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.showPlaylistsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showPlaylistsCheckBox.Location = new System.Drawing.Point(232, 0);
            this.showPlaylistsCheckBox.Name = "showPlaylistsCheckBox";
            this.showPlaylistsCheckBox.Size = new System.Drawing.Size(116, 42);
            this.showPlaylistsCheckBox.TabIndex = 1;
            this.showPlaylistsCheckBox.Text = "Playlists";
            this.showPlaylistsCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showPlaylistsCheckBox.UseVisualStyleBackColor = true;
            // 
            // showGroupsCheckBox
            // 
            this.showGroupsCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.showGroupsCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.showGroupsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showGroupsCheckBox.Location = new System.Drawing.Point(116, 0);
            this.showGroupsCheckBox.Name = "showGroupsCheckBox";
            this.showGroupsCheckBox.Size = new System.Drawing.Size(116, 42);
            this.showGroupsCheckBox.TabIndex = 1;
            this.showGroupsCheckBox.Text = "Groups";
            this.showGroupsCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showGroupsCheckBox.UseVisualStyleBackColor = true;
            // 
            // updateMyLobbyCheckBox
            // 
            this.updateMyLobbyCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.updateMyLobbyCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.updateMyLobbyCheckBox.Location = new System.Drawing.Point(791, 90);
            this.updateMyLobbyCheckBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.updateMyLobbyCheckBox.Name = "updateMyLobbyCheckBox";
            this.updateMyLobbyCheckBox.Size = new System.Drawing.Size(97, 42);
            this.updateMyLobbyCheckBox.TabIndex = 1;
            this.updateMyLobbyCheckBox.Text = "Update mode";
            this.updateMyLobbyCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.updateMyLobbyCheckBox.UseVisualStyleBackColor = true;
            this.updateMyLobbyCheckBox.CheckedChanged += new System.EventHandler(this.MyLobbyCheckBox_CheckedChanged);
            // 
            // setMyLobbyCheckBox
            // 
            this.setMyLobbyCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.setMyLobbyCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setMyLobbyCheckBox.Location = new System.Drawing.Point(894, 90);
            this.setMyLobbyCheckBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.setMyLobbyCheckBox.Name = "setMyLobbyCheckBox";
            this.setMyLobbyCheckBox.Size = new System.Drawing.Size(97, 42);
            this.setMyLobbyCheckBox.TabIndex = 1;
            this.setMyLobbyCheckBox.Text = "Set values mode";
            this.setMyLobbyCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.setMyLobbyCheckBox.UseVisualStyleBackColor = true;
            this.setMyLobbyCheckBox.CheckedChanged += new System.EventHandler(this.MyLobbyCheckBox_CheckedChanged);
            // 
            // showPersonalCheckBox
            // 
            this.showPersonalCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.showPersonalCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.showPersonalCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showPersonalCheckBox.Location = new System.Drawing.Point(0, 0);
            this.showPersonalCheckBox.Name = "showPersonalCheckBox";
            this.showPersonalCheckBox.Size = new System.Drawing.Size(116, 42);
            this.showPersonalCheckBox.TabIndex = 3;
            this.showPersonalCheckBox.Text = "Personal";
            this.showPersonalCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.showPersonalCheckBox.UseVisualStyleBackColor = true;
            // 
            // onlineCounterLabel
            // 
            this.onlineCounterLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.onlineCounterLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.onlineCounterLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.onlineCounterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.onlineCounterLabel.Location = new System.Drawing.Point(951, 0);
            this.onlineCounterLabel.Name = "onlineCounterLabel";
            this.onlineCounterLabel.Size = new System.Drawing.Size(51, 42);
            this.onlineCounterLabel.TabIndex = 2;
            this.onlineCounterLabel.Text = "0";
            this.onlineCounterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // myLobbyMgmtControl
            // 
            this.myLobbyMgmtControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myLobbyMgmtControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.myLobbyMgmtControl.IsSettingsControl = true;
            this.myLobbyMgmtControl.Location = new System.Drawing.Point(0, 42);
            this.myLobbyMgmtControl.Margin = new System.Windows.Forms.Padding(1);
            this.myLobbyMgmtControl.Name = "myLobbyMgmtControl";
            this.myLobbyMgmtControl.Size = new System.Drawing.Size(1002, 100);
            this.myLobbyMgmtControl.TabIndex = 0;
            this.myLobbyMgmtControl.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 726);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1020, 2000);
            this.MinimumSize = new System.Drawing.Size(1020, 500);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Grid 2 online monitoring tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private LobbyMgmtControl myLobbyMgmtControl;
        private System.Windows.Forms.CheckBox setMyLobbyCheckBox;
        private System.Windows.Forms.Label onlineCounterLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox showLobbiesCheckBox;
        private System.Windows.Forms.CheckBox showPlaylistsCheckBox;
        private System.Windows.Forms.CheckBox showGroupsCheckBox;
        private System.Windows.Forms.CheckBox showPersonalCheckBox;
        private System.Windows.Forms.CheckBox updateMyLobbyCheckBox;
        private System.Windows.Forms.CheckBox performUpdatesCheckBox;
        private System.Windows.Forms.NumericUpDown updateIntervalNumericUpDown;
        private System.Windows.Forms.Label label2;
    }
}