namespace Mobile_Service_Distribution.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.aboutButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.generalSettingsButton = new System.Windows.Forms.Button();
            this.generalSettingsPanel = new System.Windows.Forms.Panel();
            this.seriesURLCollectionButton = new System.Windows.Forms.Button();
            this.addURLButton = new System.Windows.Forms.Button();
            this.musicURLCollectionButton = new System.Windows.Forms.Button();
            this.blackColor = new System.Windows.Forms.PictureBox();
            this.darkBlueColor = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.redColor = new System.Windows.Forms.PictureBox();
            this.movieURLCollectionButton = new System.Windows.Forms.Button();
            this.greenColor = new System.Windows.Forms.PictureBox();
            this.urlPathListBox = new System.Windows.Forms.ListBox();
            this.defaultColor = new System.Windows.Forms.PictureBox();
            this.selected = new System.Windows.Forms.PictureBox();
            this.notificationSettingCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.aboutPanel = new System.Windows.Forms.Panel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.helpPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.themeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.priceSettingLabel = new System.Windows.Forms.Label();
            this.priceOption = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.generalSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blackColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkBlueColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selected)).BeginInit();
            this.aboutPanel.SuspendLayout();
            this.helpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceOption)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.aboutButton);
            this.splitContainer1.Panel1.Controls.Add(this.helpButton);
            this.splitContainer1.Panel1.Controls.Add(this.generalSettingsButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.generalSettingsPanel);
            this.splitContainer1.Panel2.Controls.Add(this.aboutPanel);
            this.splitContainer1.Panel2.Controls.Add(this.helpPanel);
            this.splitContainer1.Size = new System.Drawing.Size(567, 452);
            this.splitContainer1.SplitterDistance = 118;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // aboutButton
            // 
            this.aboutButton.FlatAppearance.BorderSize = 0;
            this.aboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aboutButton.Location = new System.Drawing.Point(0, 327);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(117, 124);
            this.aboutButton.TabIndex = 2;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.FlatAppearance.BorderSize = 0;
            this.helpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpButton.Location = new System.Drawing.Point(0, 148);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(117, 181);
            this.helpButton.TabIndex = 1;
            this.helpButton.Text = "Help/Tutorial";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // generalSettingsButton
            // 
            this.generalSettingsButton.FlatAppearance.BorderSize = 0;
            this.generalSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generalSettingsButton.Location = new System.Drawing.Point(0, 0);
            this.generalSettingsButton.Name = "generalSettingsButton";
            this.generalSettingsButton.Size = new System.Drawing.Size(117, 150);
            this.generalSettingsButton.TabIndex = 0;
            this.generalSettingsButton.Text = "General Settings";
            this.generalSettingsButton.UseVisualStyleBackColor = true;
            this.generalSettingsButton.Click += new System.EventHandler(this.generalSettingsButton_Click);
            // 
            // generalSettingsPanel
            // 
            this.generalSettingsPanel.Controls.Add(this.priceOption);
            this.generalSettingsPanel.Controls.Add(this.priceSettingLabel);
            this.generalSettingsPanel.Controls.Add(this.seriesURLCollectionButton);
            this.generalSettingsPanel.Controls.Add(this.addURLButton);
            this.generalSettingsPanel.Controls.Add(this.musicURLCollectionButton);
            this.generalSettingsPanel.Controls.Add(this.blackColor);
            this.generalSettingsPanel.Controls.Add(this.darkBlueColor);
            this.generalSettingsPanel.Controls.Add(this.label2);
            this.generalSettingsPanel.Controls.Add(this.redColor);
            this.generalSettingsPanel.Controls.Add(this.movieURLCollectionButton);
            this.generalSettingsPanel.Controls.Add(this.greenColor);
            this.generalSettingsPanel.Controls.Add(this.urlPathListBox);
            this.generalSettingsPanel.Controls.Add(this.defaultColor);
            this.generalSettingsPanel.Controls.Add(this.selected);
            this.generalSettingsPanel.Controls.Add(this.notificationSettingCheckBox);
            this.generalSettingsPanel.Controls.Add(this.label3);
            this.generalSettingsPanel.Controls.Add(this.label1);
            this.generalSettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.generalSettingsPanel.Name = "generalSettingsPanel";
            this.generalSettingsPanel.Size = new System.Drawing.Size(447, 451);
            this.generalSettingsPanel.TabIndex = 14;
            // 
            // seriesURLCollectionButton
            // 
            this.seriesURLCollectionButton.Location = new System.Drawing.Point(13, 281);
            this.seriesURLCollectionButton.Name = "seriesURLCollectionButton";
            this.seriesURLCollectionButton.Size = new System.Drawing.Size(75, 48);
            this.seriesURLCollectionButton.TabIndex = 5;
            this.seriesURLCollectionButton.Text = "Series";
            this.seriesURLCollectionButton.UseVisualStyleBackColor = true;
            this.seriesURLCollectionButton.Click += new System.EventHandler(this.seriesURLCollectionButton_Click);
            // 
            // addURLButton
            // 
            this.addURLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addURLButton.FlatAppearance.BorderSize = 0;
            this.addURLButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addURLButton.Location = new System.Drawing.Point(383, 172);
            this.addURLButton.Name = "addURLButton";
            this.addURLButton.Size = new System.Drawing.Size(36, 23);
            this.addURLButton.TabIndex = 7;
            this.addURLButton.Text = "Add";
            this.addURLButton.UseVisualStyleBackColor = true;
            this.addURLButton.Click += new System.EventHandler(this.addURLButton_Click);
            // 
            // musicURLCollectionButton
            // 
            this.musicURLCollectionButton.Location = new System.Drawing.Point(13, 227);
            this.musicURLCollectionButton.Name = "musicURLCollectionButton";
            this.musicURLCollectionButton.Size = new System.Drawing.Size(75, 48);
            this.musicURLCollectionButton.TabIndex = 4;
            this.musicURLCollectionButton.Text = "Music";
            this.musicURLCollectionButton.UseVisualStyleBackColor = true;
            this.musicURLCollectionButton.Click += new System.EventHandler(this.musicURLCollectionButton_Click);
            // 
            // blackColor
            // 
            this.blackColor.Image = ((System.Drawing.Image)(resources.GetObject("blackColor.Image")));
            this.blackColor.Location = new System.Drawing.Point(217, 52);
            this.blackColor.Name = "blackColor";
            this.blackColor.Size = new System.Drawing.Size(45, 45);
            this.blackColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blackColor.TabIndex = 11;
            this.blackColor.TabStop = false;
            this.themeToolTip.SetToolTip(this.blackColor, "Dark");
            this.blackColor.Click += new System.EventHandler(this.blackColor_Click);
            // 
            // darkBlueColor
            // 
            this.darkBlueColor.Image = ((System.Drawing.Image)(resources.GetObject("darkBlueColor.Image")));
            this.darkBlueColor.Location = new System.Drawing.Point(166, 52);
            this.darkBlueColor.Name = "darkBlueColor";
            this.darkBlueColor.Size = new System.Drawing.Size(45, 45);
            this.darkBlueColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.darkBlueColor.TabIndex = 10;
            this.darkBlueColor.TabStop = false;
            this.themeToolTip.SetToolTip(this.darkBlueColor, "Twilight");
            this.darkBlueColor.Click += new System.EventHandler(this.darkBlueColor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(10, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Media Configuration";
            // 
            // redColor
            // 
            this.redColor.Image = global::Media_Distro.Properties.Resources.Red;
            this.redColor.Location = new System.Drawing.Point(115, 52);
            this.redColor.Name = "redColor";
            this.redColor.Size = new System.Drawing.Size(45, 45);
            this.redColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redColor.TabIndex = 9;
            this.redColor.TabStop = false;
            this.themeToolTip.SetToolTip(this.redColor, "Fire");
            this.redColor.Click += new System.EventHandler(this.redColor_Click);
            // 
            // movieURLCollectionButton
            // 
            this.movieURLCollectionButton.Location = new System.Drawing.Point(13, 172);
            this.movieURLCollectionButton.Name = "movieURLCollectionButton";
            this.movieURLCollectionButton.Size = new System.Drawing.Size(75, 48);
            this.movieURLCollectionButton.TabIndex = 3;
            this.movieURLCollectionButton.Text = "Movie";
            this.movieURLCollectionButton.UseVisualStyleBackColor = true;
            this.movieURLCollectionButton.Click += new System.EventHandler(this.movieURLCollectionButton_Click);
            // 
            // greenColor
            // 
            this.greenColor.Image = global::Media_Distro.Properties.Resources.Green;
            this.greenColor.Location = new System.Drawing.Point(64, 52);
            this.greenColor.Name = "greenColor";
            this.greenColor.Size = new System.Drawing.Size(45, 45);
            this.greenColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.greenColor.TabIndex = 8;
            this.greenColor.TabStop = false;
            this.themeToolTip.SetToolTip(this.greenColor, "Meadow");
            this.greenColor.Click += new System.EventHandler(this.greenColor_Click);
            // 
            // urlPathListBox
            // 
            this.urlPathListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlPathListBox.Font = new System.Drawing.Font("Microsoft JhengHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlPathListBox.FormattingEnabled = true;
            this.urlPathListBox.ItemHeight = 17;
            this.urlPathListBox.Location = new System.Drawing.Point(94, 195);
            this.urlPathListBox.Name = "urlPathListBox";
            this.urlPathListBox.Size = new System.Drawing.Size(330, 89);
            this.urlPathListBox.TabIndex = 6;
            // 
            // defaultColor
            // 
            this.defaultColor.Image = global::Media_Distro.Properties.Resources.Default;
            this.defaultColor.Location = new System.Drawing.Point(13, 52);
            this.defaultColor.Name = "defaultColor";
            this.defaultColor.Size = new System.Drawing.Size(45, 45);
            this.defaultColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.defaultColor.TabIndex = 7;
            this.defaultColor.TabStop = false;
            this.themeToolTip.SetToolTip(this.defaultColor, "Default");
            this.defaultColor.Click += new System.EventHandler(this.defaultColor_Click);
            // 
            // selected
            // 
            this.selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.selected.Location = new System.Drawing.Point(13, 51);
            this.selected.Name = "selected";
            this.selected.Size = new System.Drawing.Size(45, 47);
            this.selected.TabIndex = 12;
            this.selected.TabStop = false;
            // 
            // notificationSettingCheckBox
            // 
            this.notificationSettingCheckBox.AutoSize = true;
            this.notificationSettingCheckBox.Checked = true;
            this.notificationSettingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.notificationSettingCheckBox.Location = new System.Drawing.Point(13, 364);
            this.notificationSettingCheckBox.Name = "notificationSettingCheckBox";
            this.notificationSettingCheckBox.Size = new System.Drawing.Size(290, 17);
            this.notificationSettingCheckBox.TabIndex = 5;
            this.notificationSettingCheckBox.Text = "Show notifications when a transfer progress is complete.";
            this.notificationSettingCheckBox.UseVisualStyleBackColor = true;
            this.notificationSettingCheckBox.CheckStateChanged += new System.EventHandler(this.notificationSettingCheckBox_CheckStateChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Theme Preference";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose your theme preference for the interface:";
            // 
            // aboutPanel
            // 
            this.aboutPanel.Controls.Add(this.linkLabel2);
            this.aboutPanel.Location = new System.Drawing.Point(0, 0);
            this.aboutPanel.Name = "aboutPanel";
            this.aboutPanel.Size = new System.Drawing.Size(447, 451);
            this.aboutPanel.TabIndex = 14;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(227, 94);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(55, 13);
            this.linkLabel2.TabIndex = 0;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "linkLabel2";
            // 
            // helpPanel
            // 
            this.helpPanel.Controls.Add(this.label4);
            this.helpPanel.Location = new System.Drawing.Point(0, 0);
            this.helpPanel.Name = "helpPanel";
            this.helpPanel.Size = new System.Drawing.Size(446, 451);
            this.helpPanel.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sample";
            // 
            // priceSettingLabel
            // 
            this.priceSettingLabel.AutoSize = true;
            this.priceSettingLabel.Location = new System.Drawing.Point(293, 311);
            this.priceSettingLabel.Name = "priceSettingLabel";
            this.priceSettingLabel.Size = new System.Drawing.Size(84, 13);
            this.priceSettingLabel.TabIndex = 13;
            this.priceSettingLabel.Text = "Price per Movie:";
            // 
            // priceOption
            // 
            this.priceOption.Location = new System.Drawing.Point(383, 309);
            this.priceOption.Name = "priceOption";
            this.priceOption.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.priceOption.Size = new System.Drawing.Size(41, 20);
            this.priceOption.TabIndex = 14;
            this.priceOption.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.priceOption.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.priceOption.ValueChanged += new System.EventHandler(this.priceOption_ValueChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(567, 452);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "settingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.generalSettingsPanel.ResumeLayout(false);
            this.generalSettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blackColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkBlueColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selected)).EndInit();
            this.aboutPanel.ResumeLayout(false);
            this.aboutPanel.PerformLayout();
            this.helpPanel.ResumeLayout(false);
            this.helpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceOption)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button generalSettingsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addURLButton;
        private System.Windows.Forms.ListBox urlPathListBox;
        private System.Windows.Forms.Button seriesURLCollectionButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button musicURLCollectionButton;
        private System.Windows.Forms.Button movieURLCollectionButton;
        public System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox notificationSettingCheckBox;
        private System.Windows.Forms.PictureBox defaultColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox blackColor;
        private System.Windows.Forms.PictureBox darkBlueColor;
        private System.Windows.Forms.PictureBox redColor;
        private System.Windows.Forms.PictureBox greenColor;
        private System.Windows.Forms.ToolTip themeToolTip;
        private System.Windows.Forms.PictureBox selected;
        private System.Windows.Forms.Panel generalSettingsPanel;
        private System.Windows.Forms.Panel aboutPanel;
        private System.Windows.Forms.Panel helpPanel;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown priceOption;
        private System.Windows.Forms.Label priceSettingLabel;
    }
}