using System.Windows.Forms.VisualStyles;

namespace LobbyManagement
{
    partial class GroupDisplayControl
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lobbyTypeLabel = new System.Windows.Forms.Label();
            this.userIconLabel = new System.Windows.Forms.Label();
            this.memberLimitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.playlistTypeComboBox = new System.Windows.Forms.ComboBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.memberSlashLabel = new System.Windows.Forms.Label();
            this.memberCountLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberLimitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mainPanel.Controls.Add(this.lobbyTypeLabel);
            this.mainPanel.Controls.Add(this.userIconLabel);
            this.mainPanel.Controls.Add(this.memberLimitNumericUpDown);
            this.mainPanel.Controls.Add(this.playlistTypeComboBox);
            this.mainPanel.Controls.Add(this.usernameTextBox);
            this.mainPanel.Controls.Add(this.memberSlashLabel);
            this.mainPanel.Controls.Add(this.memberCountLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(985, 50);
            this.mainPanel.TabIndex = 1;
            // 
            // lobbyTypeLabel
            // 
            this.lobbyTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lobbyTypeLabel.Location = new System.Drawing.Point(787, 13);
            this.lobbyTypeLabel.Name = "lobbyTypeLabel";
            this.lobbyTypeLabel.Size = new System.Drawing.Size(72, 24);
            this.lobbyTypeLabel.TabIndex = 11;
            this.lobbyTypeLabel.Text = "Playlist";
            this.lobbyTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // userIconLabel
            // 
            this.userIconLabel.AutoSize = true;
            this.userIconLabel.Location = new System.Drawing.Point(665, 13);
            this.userIconLabel.Name = "userIconLabel";
            this.userIconLabel.Size = new System.Drawing.Size(38, 13);
            this.userIconLabel.TabIndex = 4;
            this.userIconLabel.Text = "[users]";
            // 
            // memberLimitNumericUpDown
            // 
            this.memberLimitNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.memberLimitNumericUpDown.Location = new System.Drawing.Point(739, 9);
            this.memberLimitNumericUpDown.Name = "memberLimitNumericUpDown";
            this.memberLimitNumericUpDown.Size = new System.Drawing.Size(48, 32);
            this.memberLimitNumericUpDown.TabIndex = 4;
            // 
            // playlistTypeComboBox
            // 
            this.playlistTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playlistTypeComboBox.FormattingEnabled = true;
            this.playlistTypeComboBox.ItemHeight = 24;
            this.playlistTypeComboBox.Location = new System.Drawing.Point(861, 9);
            this.playlistTypeComboBox.Name = "playlistTypeComboBox";
            this.playlistTypeComboBox.Size = new System.Drawing.Size(121, 32);
            this.playlistTypeComboBox.TabIndex = 5;
            this.playlistTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.PlaylistTypeComboBox_SelectedIndexChanged);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usernameTextBox.Location = new System.Drawing.Point(42, 9);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(357, 32);
            this.usernameTextBox.TabIndex = 1;
            this.usernameTextBox.Enter += new System.EventHandler(this.ClearSelection);
            this.usernameTextBox.GotFocus += new System.EventHandler(this.ClearSelection);
            // 
            // memberSlashLabel
            // 
            this.memberSlashLabel.AutoSize = true;
            this.memberSlashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.memberSlashLabel.Location = new System.Drawing.Point(719, 6);
            this.memberSlashLabel.Name = "memberSlashLabel";
            this.memberSlashLabel.Size = new System.Drawing.Size(23, 36);
            this.memberSlashLabel.TabIndex = 6;
            this.memberSlashLabel.Text = "/";
            // 
            // memberCountLabel
            // 
            this.memberCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.memberCountLabel.Location = new System.Drawing.Point(687, 11);
            this.memberCountLabel.Name = "memberCountLabel";
            this.memberCountLabel.Size = new System.Drawing.Size(37, 25);
            this.memberCountLabel.TabIndex = 8;
            this.memberCountLabel.Text = "0";
            this.memberCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GroupDisplayControl
            // 
            this.Controls.Add(this.mainPanel);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "GroupDisplayControl";
            this.Size = new System.Drawing.Size(985, 50);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberLimitNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label userIconLabel;
        protected System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label memberSlashLabel;
        private System.Windows.Forms.Label memberCountLabel;
        private System.Windows.Forms.Label lobbyTypeLabel;
        protected System.Windows.Forms.ComboBox playlistTypeComboBox;
        protected System.Windows.Forms.TextBox usernameTextBox;
        protected System.Windows.Forms.NumericUpDown memberLimitNumericUpDown;
    }
}