namespace LobbyManagement
{
    partial class LobbyDisplayExControl
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
            this.timeOfDayLabel = new System.Windows.Forms.Label();
            this.timeIconLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.collisionIconLabel = new System.Windows.Forms.Label();
            this.flashbackIconLabel = new System.Windows.Forms.Label();
            this.flashbackLabel = new System.Windows.Forms.Label();
            this.damageTypeIconLabel = new System.Windows.Forms.Label();
            this.manualGearboxLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberLimitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.manualGearboxLabel);
            this.mainPanel.Controls.Add(this.damageTypeIconLabel);
            this.mainPanel.Controls.Add(this.collisionIconLabel);
            this.mainPanel.Controls.Add(this.flashbackLabel);
            this.mainPanel.Controls.Add(this.timeLabel);
            this.mainPanel.Controls.Add(this.flashbackIconLabel);
            this.mainPanel.Controls.Add(this.timeIconLabel);
            this.mainPanel.Controls.Add(this.timeOfDayLabel);
            this.mainPanel.Size = new System.Drawing.Size(985, 125);
            this.mainPanel.Controls.SetChildIndex(this.usernameTextBox, 0);
            this.mainPanel.Controls.SetChildIndex(this.playlistTypeComboBox, 0);
            this.mainPanel.Controls.SetChildIndex(this.memberLimitNumericUpDown, 0);
            this.mainPanel.Controls.SetChildIndex(this.timeOfDayLabel, 0);
            this.mainPanel.Controls.SetChildIndex(this.timeIconLabel, 0);
            this.mainPanel.Controls.SetChildIndex(this.flashbackIconLabel, 0);
            this.mainPanel.Controls.SetChildIndex(this.timeLabel, 0);
            this.mainPanel.Controls.SetChildIndex(this.flashbackLabel, 0);
            this.mainPanel.Controls.SetChildIndex(this.collisionIconLabel, 0);
            this.mainPanel.Controls.SetChildIndex(this.damageTypeIconLabel, 0);
            this.mainPanel.Controls.SetChildIndex(this.manualGearboxLabel, 0);
            // 
            // timeOfDayLabel
            // 
            this.timeOfDayLabel.AutoSize = true;
            this.timeOfDayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.timeOfDayLabel.Location = new System.Drawing.Point(788, 58);
            this.timeOfDayLabel.Name = "timeOfDayLabel";
            this.timeOfDayLabel.Size = new System.Drawing.Size(37, 20);
            this.timeOfDayLabel.TabIndex = 9;
            this.timeOfDayLabel.Text = "Day";
            // 
            // timeIconLabel
            // 
            this.timeIconLabel.AutoSize = true;
            this.timeIconLabel.Location = new System.Drawing.Point(264, 89);
            this.timeIconLabel.Name = "timeIconLabel";
            this.timeIconLabel.Size = new System.Drawing.Size(32, 13);
            this.timeIconLabel.TabIndex = 12;
            this.timeIconLabel.Text = "[time]";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeLabel.Location = new System.Drawing.Point(305, 92);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(36, 26);
            this.timeLabel.TabIndex = 13;
            this.timeLabel.Text = "30";
            // 
            // collisionIconLabel
            // 
            this.collisionIconLabel.AutoSize = true;
            this.collisionIconLabel.Location = new System.Drawing.Point(3, 89);
            this.collisionIconLabel.Name = "collisionIconLabel";
            this.collisionIconLabel.Size = new System.Drawing.Size(32, 13);
            this.collisionIconLabel.TabIndex = 14;
            this.collisionIconLabel.Text = "[cls1]";
            // 
            // flashbackIconLabel
            // 
            this.flashbackIconLabel.AutoSize = true;
            this.flashbackIconLabel.Location = new System.Drawing.Point(170, 89);
            this.flashbackIconLabel.Name = "flashbackIconLabel";
            this.flashbackIconLabel.Size = new System.Drawing.Size(35, 13);
            this.flashbackIconLabel.TabIndex = 12;
            this.flashbackIconLabel.Text = "[flash]";
            // 
            // flashbackLabel
            // 
            this.flashbackLabel.AutoSize = true;
            this.flashbackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flashbackLabel.Location = new System.Drawing.Point(211, 92);
            this.flashbackLabel.Name = "flashbackLabel";
            this.flashbackLabel.Size = new System.Drawing.Size(24, 26);
            this.flashbackLabel.TabIndex = 13;
            this.flashbackLabel.Text = "5";
            // 
            // damageTypeIconLabel
            // 
            this.damageTypeIconLabel.AutoSize = true;
            this.damageTypeIconLabel.Location = new System.Drawing.Point(96, 89);
            this.damageTypeIconLabel.Name = "damageTypeIconLabel";
            this.damageTypeIconLabel.Size = new System.Drawing.Size(57, 13);
            this.damageTypeIconLabel.TabIndex = 14;
            this.damageTypeIconLabel.Text = "[dmgType]";
            // 
            // manualGearboxLabel
            // 
            this.manualGearboxLabel.AutoSize = true;
            this.manualGearboxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.manualGearboxLabel.Location = new System.Drawing.Point(368, 94);
            this.manualGearboxLabel.Name = "manualGearboxLabel";
            this.manualGearboxLabel.Size = new System.Drawing.Size(122, 20);
            this.manualGearboxLabel.TabIndex = 15;
            this.manualGearboxLabel.Text = "Manual gearbox";
            // 
            // LobbyDisplayExControl
            // 
            this.Name = "LobbyDisplayExControl";
            this.Size = new System.Drawing.Size(985, 125);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberLimitNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label timeOfDayLabel;
        private System.Windows.Forms.Label timeIconLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label collisionIconLabel;
        private System.Windows.Forms.Label flashbackLabel;
        private System.Windows.Forms.Label flashbackIconLabel;
        private System.Windows.Forms.Label manualGearboxLabel;
        private System.Windows.Forms.Label damageTypeIconLabel;
    }
}