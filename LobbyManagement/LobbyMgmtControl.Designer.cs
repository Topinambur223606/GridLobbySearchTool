namespace LobbyManagement
{
    partial class LobbyMgmtControl
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
            this.trackNameComboBox = new System.Windows.Forms.ComboBox();
            this.lengthUnitLabel = new System.Windows.Forms.Label();
            this.trackLabel = new System.Windows.Forms.Label();
            this.lengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lengthComboBox = new System.Windows.Forms.ComboBox();
            this.tracksTotalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.trackCurrentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.inRaceLabel = new System.Windows.Forms.Label();
            this.dlcLabel = new System.Windows.Forms.Label();
            this.tierComboBox = new System.Windows.Forms.ComboBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.trackSlashLabel = new System.Windows.Forms.Label();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberLimitNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tracksTotalNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCurrentNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.trackNameComboBox);
            this.mainPanel.Controls.Add(this.lengthUnitLabel);
            this.mainPanel.Controls.Add(this.trackLabel);
            this.mainPanel.Controls.Add(this.lengthNumericUpDown);
            this.mainPanel.Controls.Add(this.tracksTotalNumericUpDown);
            this.mainPanel.Controls.Add(this.trackCurrentNumericUpDown);
            this.mainPanel.Controls.Add(this.inRaceLabel);
            this.mainPanel.Controls.Add(this.dlcLabel);
            this.mainPanel.Controls.Add(this.tierComboBox);
            this.mainPanel.Controls.Add(this.typeComboBox);
            this.mainPanel.Controls.Add(this.trackSlashLabel);
            this.mainPanel.Controls.Add(this.ratingLabel);
            this.mainPanel.Controls.Add(this.lengthComboBox);
            this.mainPanel.Size = new System.Drawing.Size(985, 100);
            this.mainPanel.TabIndex = 0;
            this.mainPanel.Controls.SetChildIndex(this.usernameTextBox, 0);
            this.mainPanel.Controls.SetChildIndex(this.playlistTypeComboBox, 0);
            this.mainPanel.Controls.SetChildIndex(this.memberLimitNumericUpDown, 0);
            this.mainPanel.Controls.SetChildIndex(this.lengthComboBox, 0);
            this.mainPanel.Controls.SetChildIndex(this.ratingLabel, 0);
            this.mainPanel.Controls.SetChildIndex(this.trackSlashLabel, 0);
            this.mainPanel.Controls.SetChildIndex(this.typeComboBox, 0);
            this.mainPanel.Controls.SetChildIndex(this.tierComboBox, 0);
            this.mainPanel.Controls.SetChildIndex(this.dlcLabel, 0);
            this.mainPanel.Controls.SetChildIndex(this.inRaceLabel, 0);
            this.mainPanel.Controls.SetChildIndex(this.trackCurrentNumericUpDown, 0);
            this.mainPanel.Controls.SetChildIndex(this.tracksTotalNumericUpDown, 0);
            this.mainPanel.Controls.SetChildIndex(this.lengthNumericUpDown, 0);
            this.mainPanel.Controls.SetChildIndex(this.trackLabel, 0);
            this.mainPanel.Controls.SetChildIndex(this.lengthUnitLabel, 0);
            this.mainPanel.Controls.SetChildIndex(this.trackNameComboBox, 0);
            // 
            // trackNameComboBox
            // 
            this.trackNameComboBox.DisplayMember = "FullName";
            this.trackNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trackNameComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackNameComboBox.FormattingEnabled = true;
            this.trackNameComboBox.Location = new System.Drawing.Point(218, 55);
            this.trackNameComboBox.Name = "trackNameComboBox";
            this.trackNameComboBox.Size = new System.Drawing.Size(372, 26);
            this.trackNameComboBox.TabIndex = 8;
            this.trackNameComboBox.SelectedIndexChanged += new System.EventHandler(this.TrackNameComboBox_SelectedIndexChanged);
            // 
            // lengthUnitLabel
            // 
            this.lengthUnitLabel.AutoSize = true;
            this.lengthUnitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lengthUnitLabel.Location = new System.Drawing.Point(665, 57);
            this.lengthUnitLabel.Name = "lengthUnitLabel";
            this.lengthUnitLabel.Size = new System.Drawing.Size(38, 20);
            this.lengthUnitLabel.TabIndex = 7;
            this.lengthUnitLabel.Text = "laps";
            // 
            // trackLabel
            // 
            this.trackLabel.AutoSize = true;
            this.trackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trackLabel.Location = new System.Drawing.Point(45, 57);
            this.trackLabel.Name = "trackLabel";
            this.trackLabel.Size = new System.Drawing.Size(48, 20);
            this.trackLabel.TabIndex = 7;
            this.trackLabel.Text = "Track";
            // 
            // lengthNumericUpDown
            // 
            this.lengthNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lengthNumericUpDown.Location = new System.Drawing.Point(599, 55);
            this.lengthNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.lengthNumericUpDown.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.lengthNumericUpDown.Name = "lengthNumericUpDown";
            this.lengthNumericUpDown.Size = new System.Drawing.Size(60, 26);
            this.lengthNumericUpDown.TabIndex = 9;
            this.lengthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lengthNumericUpDown.ValueChanged += new System.EventHandler(this.LengthNumericUpDown_ValueChanged);
            // 
            // lengthComboBox
            // 
            this.lengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lengthComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lengthComboBox.Location = new System.Drawing.Point(599, 55);
            this.lengthComboBox.Name = "lengthComboBox";
            this.lengthComboBox.Size = new System.Drawing.Size(48, 26);
            this.lengthComboBox.TabIndex = 5;
            this.lengthComboBox.SelectedIndexChanged += new System.EventHandler(this.LengthComboBox_SelectedIndexChanged);
            // 
            // tracksTotalNumericUpDown
            // 
            this.tracksTotalNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tracksTotalNumericUpDown.Location = new System.Drawing.Point(164, 55);
            this.tracksTotalNumericUpDown.Name = "tracksTotalNumericUpDown";
            this.tracksTotalNumericUpDown.Size = new System.Drawing.Size(48, 26);
            this.tracksTotalNumericUpDown.TabIndex = 7;
            // 
            // trackCurrentNumericUpDown
            // 
            this.trackCurrentNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.trackCurrentNumericUpDown.Location = new System.Drawing.Point(99, 55);
            this.trackCurrentNumericUpDown.Name = "trackCurrentNumericUpDown";
            this.trackCurrentNumericUpDown.Size = new System.Drawing.Size(48, 26);
            this.trackCurrentNumericUpDown.TabIndex = 6;
            this.trackCurrentNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // inRaceLabel
            // 
            this.inRaceLabel.AutoSize = true;
            this.inRaceLabel.Location = new System.Drawing.Point(3, 53);
            this.inRaceLabel.Name = "inRaceLabel";
            this.inRaceLabel.Size = new System.Drawing.Size(42, 13);
            this.inRaceLabel.TabIndex = 4;
            this.inRaceLabel.Text = "[inrace]";
            this.inRaceLabel.Click += new System.EventHandler(this.InRaceLabel_Click);
            // 
            // dlcLabel
            // 
            this.dlcLabel.AutoSize = true;
            this.dlcLabel.Location = new System.Drawing.Point(620, 9);
            this.dlcLabel.Name = "dlcLabel";
            this.dlcLabel.Size = new System.Drawing.Size(27, 13);
            this.dlcLabel.TabIndex = 4;
            this.dlcLabel.Text = "[dlc]";
            this.dlcLabel.Click += new System.EventHandler(this.DlcLabel_Click);
            // 
            // tierComboBox
            // 
            this.tierComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tierComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tierComboBox.FormattingEnabled = true;
            this.tierComboBox.ItemHeight = 24;
            this.tierComboBox.Location = new System.Drawing.Point(532, 9);
            this.tierComboBox.Name = "tierComboBox";
            this.tierComboBox.Size = new System.Drawing.Size(86, 32);
            this.tierComboBox.TabIndex = 3;
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.ItemHeight = 24;
            this.typeComboBox.Location = new System.Drawing.Point(405, 9);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(121, 32);
            this.typeComboBox.TabIndex = 2;
            // 
            // trackSlashLabel
            // 
            this.trackSlashLabel.AutoSize = true;
            this.trackSlashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.trackSlashLabel.Location = new System.Drawing.Point(148, 54);
            this.trackSlashLabel.Name = "trackSlashLabel";
            this.trackSlashLabel.Size = new System.Drawing.Size(15, 24);
            this.trackSlashLabel.TabIndex = 6;
            this.trackSlashLabel.Text = "/";
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ratingLabel.Location = new System.Drawing.Point(3, 9);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Padding = new System.Windows.Forms.Padding(2, 5, 0, 5);
            this.ratingLabel.Size = new System.Drawing.Size(23, 23);
            this.ratingLabel.TabIndex = 0;
            this.ratingLabel.Text = "[R]";
            this.ratingLabel.Click += new System.EventHandler(this.RatingLabel_Click);
            // 
            // LobbyMgmtControl
            // 
            this.Name = "LobbyMgmtControl";
            this.Size = new System.Drawing.Size(985, 100);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberLimitNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tracksTotalNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackCurrentNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ratingLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label dlcLabel;
        private System.Windows.Forms.ComboBox tierComboBox;
        private System.Windows.Forms.Label trackLabel;
        private System.Windows.Forms.NumericUpDown tracksTotalNumericUpDown;
        private System.Windows.Forms.NumericUpDown trackCurrentNumericUpDown;
        private System.Windows.Forms.Label trackSlashLabel;
        private System.Windows.Forms.ComboBox trackNameComboBox;
        private System.Windows.Forms.Label lengthUnitLabel;
        private System.Windows.Forms.NumericUpDown lengthNumericUpDown;
        private System.Windows.Forms.ComboBox lengthComboBox;
        private System.Windows.Forms.Label inRaceLabel;
    }
}