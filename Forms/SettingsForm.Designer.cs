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
            this.priceSettingLabel = new System.Windows.Forms.Label();
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
            this.themeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.accountSettingsButton = new Guna.UI2.WinForms.Guna2Button();
            this.helpButton = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.priceSetting = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.blackColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkBlueColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selected)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // priceSettingLabel
            // 
            this.priceSettingLabel.AutoSize = true;
            this.priceSettingLabel.Location = new System.Drawing.Point(297, 312);
            this.priceSettingLabel.Name = "priceSettingLabel";
            this.priceSettingLabel.Size = new System.Drawing.Size(81, 13);
            this.priceSettingLabel.TabIndex = 13;
            this.priceSettingLabel.Text = "Price per Movie";
            // 
            // seriesURLCollectionButton
            // 
            this.seriesURLCollectionButton.Location = new System.Drawing.Point(30, 295);
            this.seriesURLCollectionButton.Name = "seriesURLCollectionButton";
            this.seriesURLCollectionButton.Size = new System.Drawing.Size(108, 48);
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
            this.addURLButton.Location = new System.Drawing.Point(433, 183);
            this.addURLButton.Name = "addURLButton";
            this.addURLButton.Size = new System.Drawing.Size(36, 23);
            this.addURLButton.TabIndex = 7;
            this.addURLButton.Text = "Add";
            this.addURLButton.UseVisualStyleBackColor = true;
            this.addURLButton.Click += new System.EventHandler(this.addURLButton_Click);
            // 
            // musicURLCollectionButton
            // 
            this.musicURLCollectionButton.Location = new System.Drawing.Point(30, 251);
            this.musicURLCollectionButton.Name = "musicURLCollectionButton";
            this.musicURLCollectionButton.Size = new System.Drawing.Size(108, 48);
            this.musicURLCollectionButton.TabIndex = 4;
            this.musicURLCollectionButton.Text = "Music";
            this.musicURLCollectionButton.UseVisualStyleBackColor = true;
            this.musicURLCollectionButton.Click += new System.EventHandler(this.musicURLCollectionButton_Click);
            // 
            // blackColor
            // 
            this.blackColor.Image = ((System.Drawing.Image)(resources.GetObject("blackColor.Image")));
            this.blackColor.Location = new System.Drawing.Point(267, 90);
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
            this.darkBlueColor.Location = new System.Drawing.Point(216, 90);
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
            this.label2.Location = new System.Drawing.Point(50, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Media Configuration";
            // 
            // redColor
            // 
            this.redColor.Image = global::Media_Distro.Properties.Resources.Red;
            this.redColor.Location = new System.Drawing.Point(165, 90);
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
            this.movieURLCollectionButton.Location = new System.Drawing.Point(30, 206);
            this.movieURLCollectionButton.Name = "movieURLCollectionButton";
            this.movieURLCollectionButton.Size = new System.Drawing.Size(108, 48);
            this.movieURLCollectionButton.TabIndex = 3;
            this.movieURLCollectionButton.Text = "Movie";
            this.movieURLCollectionButton.UseVisualStyleBackColor = true;
            this.movieURLCollectionButton.Click += new System.EventHandler(this.movieURLCollectionButton_Click);
            // 
            // greenColor
            // 
            this.greenColor.Image = global::Media_Distro.Properties.Resources.Green;
            this.greenColor.Location = new System.Drawing.Point(114, 90);
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
            this.urlPathListBox.Location = new System.Drawing.Point(144, 206);
            this.urlPathListBox.Name = "urlPathListBox";
            this.urlPathListBox.Size = new System.Drawing.Size(330, 89);
            this.urlPathListBox.TabIndex = 6;
            // 
            // defaultColor
            // 
            this.defaultColor.Image = global::Media_Distro.Properties.Resources.Default;
            this.defaultColor.Location = new System.Drawing.Point(63, 90);
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
            this.selected.Location = new System.Drawing.Point(63, 89);
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
            this.notificationSettingCheckBox.Location = new System.Drawing.Point(30, 359);
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
            this.label3.Location = new System.Drawing.Point(50, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Theme Preference";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose your theme preference for the interface.";
            // 
            // accountSettingsButton
            // 
            this.accountSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.accountSettingsButton.AutoRoundedCorners = true;
            this.accountSettingsButton.BorderRadius = 11;
            this.accountSettingsButton.BorderThickness = 3;
            this.accountSettingsButton.CheckedState.Parent = this.accountSettingsButton;
            this.accountSettingsButton.CustomImages.Parent = this.accountSettingsButton;
            this.accountSettingsButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(80)))), ((int)(((byte)(135)))));
            this.accountSettingsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.accountSettingsButton.ForeColor = System.Drawing.Color.Navy;
            this.accountSettingsButton.HoverState.Parent = this.accountSettingsButton;
            this.accountSettingsButton.Location = new System.Drawing.Point(324, 10);
            this.accountSettingsButton.Name = "accountSettingsButton";
            this.accountSettingsButton.ShadowDecoration.Parent = this.accountSettingsButton;
            this.accountSettingsButton.Size = new System.Drawing.Size(145, 25);
            this.accountSettingsButton.TabIndex = 15;
            this.accountSettingsButton.Text = "Account Settings";
            // 
            // helpButton
            // 
            this.helpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.helpButton.AutoRoundedCorners = true;
            this.helpButton.BorderRadius = 11;
            this.helpButton.BorderThickness = 3;
            this.helpButton.CheckedState.Parent = this.helpButton;
            this.helpButton.CustomImages.Parent = this.helpButton;
            this.helpButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(80)))), ((int)(((byte)(135)))));
            this.helpButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.helpButton.ForeColor = System.Drawing.Color.Navy;
            this.helpButton.HoverState.Parent = this.helpButton;
            this.helpButton.Location = new System.Drawing.Point(477, 10);
            this.helpButton.Name = "helpButton";
            this.helpButton.ShadowDecoration.Parent = this.helpButton;
            this.helpButton.Size = new System.Drawing.Size(78, 25);
            this.helpButton.TabIndex = 16;
            this.helpButton.Text = "Help";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Manage where all your media files are kept and configured. ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Location = new System.Drawing.Point(-5, 407);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(577, 53);
            this.panel1.TabIndex = 18;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(318, 18);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(109, 13);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Terms and Conditions";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(242, 18);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(73, 13);
            this.linkLabel2.TabIndex = 1;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Privacy Policy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(433, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "© Media Distro by Kitly";
            // 
            // priceSetting
            // 
            this.priceSetting.BackColor = System.Drawing.Color.Transparent;
            this.priceSetting.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.priceSetting.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.priceSetting.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.priceSetting.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.priceSetting.DisabledState.Parent = this.priceSetting;
            this.priceSetting.DisabledState.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(177)))), ((int)(((byte)(177)))));
            this.priceSetting.DisabledState.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.priceSetting.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.priceSetting.FocusedState.Parent = this.priceSetting;
            this.priceSetting.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.priceSetting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.priceSetting.Location = new System.Drawing.Point(387, 305);
            this.priceSetting.Name = "priceSetting";
            this.priceSetting.ShadowDecoration.Parent = this.priceSetting;
            this.priceSetting.Size = new System.Drawing.Size(88, 30);
            this.priceSetting.TabIndex = 19;
            this.priceSetting.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.priceSetting.ValueChanged += new System.EventHandler(this.priceSetting_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.label6.Location = new System.Drawing.Point(417, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "ETB";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(567, 452);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.priceSetting);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.accountSettingsButton);
            this.Controls.Add(this.priceSettingLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.seriesURLCollectionButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addURLButton);
            this.Controls.Add(this.notificationSettingCheckBox);
            this.Controls.Add(this.musicURLCollectionButton);
            this.Controls.Add(this.blackColor);
            this.Controls.Add(this.defaultColor);
            this.Controls.Add(this.darkBlueColor);
            this.Controls.Add(this.urlPathListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.greenColor);
            this.Controls.Add(this.redColor);
            this.Controls.Add(this.movieURLCollectionButton);
            this.Controls.Add(this.selected);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "settingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.blackColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkBlueColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selected)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceSetting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addURLButton;
        private System.Windows.Forms.ListBox urlPathListBox;
        private System.Windows.Forms.Button seriesURLCollectionButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button musicURLCollectionButton;
        private System.Windows.Forms.Button movieURLCollectionButton;
        private System.Windows.Forms.CheckBox notificationSettingCheckBox;
        private System.Windows.Forms.PictureBox defaultColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox blackColor;
        private System.Windows.Forms.PictureBox darkBlueColor;
        private System.Windows.Forms.PictureBox redColor;
        private System.Windows.Forms.PictureBox greenColor;
        private System.Windows.Forms.ToolTip themeToolTip;
        private System.Windows.Forms.PictureBox selected;
        private System.Windows.Forms.Label priceSettingLabel;
        private Guna.UI2.WinForms.Guna2Button accountSettingsButton;
        private Guna.UI2.WinForms.Guna2Button helpButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Guna.UI2.WinForms.Guna2NumericUpDown priceSetting;
        private System.Windows.Forms.Label label6;
    }
}