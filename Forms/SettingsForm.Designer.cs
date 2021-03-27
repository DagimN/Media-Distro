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
            this.notificationSettingCheckBox = new System.Windows.Forms.CheckBox();
            this.themeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.redColor = new System.Windows.Forms.PictureBox();
            this.greenColor = new System.Windows.Forms.PictureBox();
            this.darkBlueColor = new System.Windows.Forms.PictureBox();
            this.defaultColor = new System.Windows.Forms.PictureBox();
            this.blackColor = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileLoadLabel = new System.Windows.Forms.Label();
            this.mediaDistroLabel = new System.Windows.Forms.Label();
            this.bonusButton = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.urlAddingInfo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.movieURLCollectionButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.urlPathListBox = new System.Windows.Forms.ListBox();
            this.removeURLContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priceSetting = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.musicURLCollectionButton = new System.Windows.Forms.Button();
            this.seriesURLCollectionButton = new System.Windows.Forms.Button();
            this.addURLButton = new System.Windows.Forms.Button();
            this.priceSettingLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.selected = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.redColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkBlueColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blackColor)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.removeURLContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceSetting)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selected)).BeginInit();
            this.SuspendLayout();
            // 
            // notificationSettingCheckBox
            // 
            this.notificationSettingCheckBox.AutoSize = true;
            this.notificationSettingCheckBox.Checked = true;
            this.notificationSettingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.notificationSettingCheckBox.Location = new System.Drawing.Point(22, 381);
            this.notificationSettingCheckBox.Name = "notificationSettingCheckBox";
            this.notificationSettingCheckBox.Size = new System.Drawing.Size(290, 17);
            this.notificationSettingCheckBox.TabIndex = 5;
            this.notificationSettingCheckBox.Text = "Show notifications when a transfer progress is complete.";
            this.notificationSettingCheckBox.UseVisualStyleBackColor = true;
            this.notificationSettingCheckBox.CheckStateChanged += new System.EventHandler(this.notificationSettingCheckBox_CheckStateChanged);
            // 
            // redColor
            // 
            this.redColor.Image = global::Media_Distro.Properties.Resources.Red;
            this.redColor.Location = new System.Drawing.Point(141, 51);
            this.redColor.Name = "redColor";
            this.redColor.Size = new System.Drawing.Size(45, 45);
            this.redColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redColor.TabIndex = 9;
            this.redColor.TabStop = false;
            this.themeToolTip.SetToolTip(this.redColor, "Fire");
            this.redColor.Click += new System.EventHandler(this.redColor_Click);
            // 
            // greenColor
            // 
            this.greenColor.Image = global::Media_Distro.Properties.Resources.Green;
            this.greenColor.Location = new System.Drawing.Point(90, 51);
            this.greenColor.Name = "greenColor";
            this.greenColor.Size = new System.Drawing.Size(45, 45);
            this.greenColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.greenColor.TabIndex = 8;
            this.greenColor.TabStop = false;
            this.themeToolTip.SetToolTip(this.greenColor, "Meadow");
            this.greenColor.Click += new System.EventHandler(this.greenColor_Click);
            // 
            // darkBlueColor
            // 
            this.darkBlueColor.Image = global::Media_Distro.Properties.Resources.Twilight;
            this.darkBlueColor.Location = new System.Drawing.Point(192, 51);
            this.darkBlueColor.Name = "darkBlueColor";
            this.darkBlueColor.Size = new System.Drawing.Size(45, 45);
            this.darkBlueColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.darkBlueColor.TabIndex = 10;
            this.darkBlueColor.TabStop = false;
            this.themeToolTip.SetToolTip(this.darkBlueColor, "Twilight");
            this.darkBlueColor.Click += new System.EventHandler(this.darkBlueColor_Click);
            // 
            // defaultColor
            // 
            this.defaultColor.Image = global::Media_Distro.Properties.Resources.Default;
            this.defaultColor.Location = new System.Drawing.Point(39, 51);
            this.defaultColor.Name = "defaultColor";
            this.defaultColor.Size = new System.Drawing.Size(45, 45);
            this.defaultColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.defaultColor.TabIndex = 7;
            this.defaultColor.TabStop = false;
            this.themeToolTip.SetToolTip(this.defaultColor, "Default");
            this.defaultColor.Click += new System.EventHandler(this.defaultColor_Click);
            // 
            // blackColor
            // 
            this.blackColor.Image = global::Media_Distro.Properties.Resources.Night;
            this.blackColor.Location = new System.Drawing.Point(243, 51);
            this.blackColor.Name = "blackColor";
            this.blackColor.Size = new System.Drawing.Size(45, 45);
            this.blackColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blackColor.TabIndex = 11;
            this.blackColor.TabStop = false;
            this.themeToolTip.SetToolTip(this.blackColor, "Dark");
            this.blackColor.Click += new System.EventHandler(this.blackColor_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.fileLoadLabel);
            this.panel1.Controls.Add(this.mediaDistroLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 417);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 35);
            this.panel1.TabIndex = 18;
            // 
            // fileLoadLabel
            // 
            this.fileLoadLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileLoadLabel.AutoSize = true;
            this.fileLoadLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLoadLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fileLoadLabel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.fileLoadLabel.Location = new System.Drawing.Point(3, 9);
            this.fileLoadLabel.Name = "fileLoadLabel";
            this.fileLoadLabel.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.fileLoadLabel.Size = new System.Drawing.Size(215, 16);
            this.fileLoadLabel.TabIndex = 22;
            this.fileLoadLabel.Text = "Files will be loaded after restarting the app.";
            this.fileLoadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fileLoadLabel.Visible = false;
            // 
            // mediaDistroLabel
            // 
            this.mediaDistroLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaDistroLabel.AutoSize = true;
            this.mediaDistroLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediaDistroLabel.Location = new System.Drawing.Point(471, 10);
            this.mediaDistroLabel.Name = "mediaDistroLabel";
            this.mediaDistroLabel.Size = new System.Drawing.Size(77, 15);
            this.mediaDistroLabel.TabIndex = 19;
            this.mediaDistroLabel.Text = "Media Distro";
            // 
            // bonusButton
            // 
            this.bonusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bonusButton.BackColor = System.Drawing.Color.Transparent;
            this.bonusButton.BorderColor = System.Drawing.Color.Gray;
            this.bonusButton.BorderRadius = 5;
            this.bonusButton.BorderThickness = 1;
            this.bonusButton.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.bonusButton.CheckedState.Parent = this.bonusButton;
            this.bonusButton.CustomImages.Parent = this.bonusButton;
            this.bonusButton.FillColor = System.Drawing.Color.Transparent;
            this.bonusButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bonusButton.ForeColor = System.Drawing.Color.DimGray;
            this.bonusButton.HoverState.Parent = this.bonusButton;
            this.bonusButton.Location = new System.Drawing.Point(469, 12);
            this.bonusButton.Name = "bonusButton";
            this.bonusButton.ShadowDecoration.Parent = this.bonusButton;
            this.bonusButton.Size = new System.Drawing.Size(86, 23);
            this.bonusButton.TabIndex = 23;
            this.bonusButton.Text = "Get Bonus";
            this.bonusButton.UseTransparentBackground = true;
            this.bonusButton.Visible = false;
            this.bonusButton.Click += new System.EventHandler(this.bonusButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::Media_Distro.Properties.Resources.configBackground_2;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.urlAddingInfo);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.movieURLCollectionButton);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.urlPathListBox);
            this.panel3.Controls.Add(this.priceSetting);
            this.panel3.Controls.Add(this.musicURLCollectionButton);
            this.panel3.Controls.Add(this.seriesURLCollectionButton);
            this.panel3.Controls.Add(this.addURLButton);
            this.panel3.Controls.Add(this.priceSettingLabel);
            this.panel3.Location = new System.Drawing.Point(12, 159);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(543, 216);
            this.panel3.TabIndex = 22;
            // 
            // urlAddingInfo
            // 
            this.urlAddingInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlAddingInfo.Font = new System.Drawing.Font("Microsoft JhengHei", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlAddingInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.urlAddingInfo.Image = global::Media_Distro.Properties.Resources.info_icon_3;
            this.urlAddingInfo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.urlAddingInfo.Location = new System.Drawing.Point(125, 164);
            this.urlAddingInfo.Name = "urlAddingInfo";
            this.urlAddingInfo.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.urlAddingInfo.Size = new System.Drawing.Size(211, 36);
            this.urlAddingInfo.TabIndex = 21;
            this.urlAddingInfo.Text = "Select root folder where all the media exists for each media type.";
            this.urlAddingInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(20, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(346, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Manage where all your media files are kept and configured. ";
            // 
            // movieURLCollectionButton
            // 
            this.movieURLCollectionButton.FlatAppearance.BorderSize = 0;
            this.movieURLCollectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.movieURLCollectionButton.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieURLCollectionButton.Image = global::Media_Distro.Properties.Resources.Movie_Icon;
            this.movieURLCollectionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.movieURLCollectionButton.Location = new System.Drawing.Point(11, 60);
            this.movieURLCollectionButton.Name = "movieURLCollectionButton";
            this.movieURLCollectionButton.Size = new System.Drawing.Size(108, 48);
            this.movieURLCollectionButton.TabIndex = 3;
            this.movieURLCollectionButton.Text = "Movie";
            this.movieURLCollectionButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.movieURLCollectionButton.UseVisualStyleBackColor = true;
            this.movieURLCollectionButton.Click += new System.EventHandler(this.movieURLCollectionButton_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.label6.Location = new System.Drawing.Point(460, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "ETB";
            // 
            // urlPathListBox
            // 
            this.urlPathListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlPathListBox.BackColor = System.Drawing.Color.White;
            this.urlPathListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.urlPathListBox.ContextMenuStrip = this.removeURLContextMenuStrip;
            this.urlPathListBox.Font = new System.Drawing.Font("Microsoft JhengHei", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.urlPathListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.urlPathListBox.FormattingEnabled = true;
            this.urlPathListBox.ItemHeight = 17;
            this.urlPathListBox.Location = new System.Drawing.Point(121, 60);
            this.urlPathListBox.Name = "urlPathListBox";
            this.urlPathListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.urlPathListBox.Size = new System.Drawing.Size(406, 87);
            this.urlPathListBox.TabIndex = 6;
            // 
            // removeURLContextMenuStrip
            // 
            this.removeURLContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeURLToolStripMenuItem});
            this.removeURLContextMenuStrip.Name = "removeURLContextMenuStrip";
            this.removeURLContextMenuStrip.Size = new System.Drawing.Size(142, 26);
            // 
            // removeURLToolStripMenuItem
            // 
            this.removeURLToolStripMenuItem.Name = "removeURLToolStripMenuItem";
            this.removeURLToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.removeURLToolStripMenuItem.Text = "Remove URL";
            this.removeURLToolStripMenuItem.Click += new System.EventHandler(this.removeURLToolStripMenuItem_Click);
            // 
            // priceSetting
            // 
            this.priceSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.priceSetting.Location = new System.Drawing.Point(438, 164);
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
            // musicURLCollectionButton
            // 
            this.musicURLCollectionButton.FlatAppearance.BorderSize = 0;
            this.musicURLCollectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.musicURLCollectionButton.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicURLCollectionButton.Image = global::Media_Distro.Properties.Resources.Music_Icon;
            this.musicURLCollectionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.musicURLCollectionButton.Location = new System.Drawing.Point(11, 107);
            this.musicURLCollectionButton.Name = "musicURLCollectionButton";
            this.musicURLCollectionButton.Size = new System.Drawing.Size(108, 48);
            this.musicURLCollectionButton.TabIndex = 4;
            this.musicURLCollectionButton.Text = "Music";
            this.musicURLCollectionButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.musicURLCollectionButton.UseVisualStyleBackColor = true;
            this.musicURLCollectionButton.Click += new System.EventHandler(this.musicURLCollectionButton_Click);
            // 
            // seriesURLCollectionButton
            // 
            this.seriesURLCollectionButton.FlatAppearance.BorderSize = 0;
            this.seriesURLCollectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seriesURLCollectionButton.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seriesURLCollectionButton.Image = global::Media_Distro.Properties.Resources.Series_Icon;
            this.seriesURLCollectionButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.seriesURLCollectionButton.Location = new System.Drawing.Point(11, 154);
            this.seriesURLCollectionButton.Name = "seriesURLCollectionButton";
            this.seriesURLCollectionButton.Size = new System.Drawing.Size(108, 48);
            this.seriesURLCollectionButton.TabIndex = 5;
            this.seriesURLCollectionButton.Text = "Series";
            this.seriesURLCollectionButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.seriesURLCollectionButton.UseVisualStyleBackColor = true;
            this.seriesURLCollectionButton.Click += new System.EventHandler(this.seriesURLCollectionButton_Click);
            // 
            // addURLButton
            // 
            this.addURLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addURLButton.FlatAppearance.BorderSize = 0;
            this.addURLButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addURLButton.Font = new System.Drawing.Font("Microsoft JhengHei", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addURLButton.Location = new System.Drawing.Point(486, 36);
            this.addURLButton.Name = "addURLButton";
            this.addURLButton.Size = new System.Drawing.Size(36, 23);
            this.addURLButton.TabIndex = 7;
            this.addURLButton.Text = "Add";
            this.addURLButton.UseVisualStyleBackColor = true;
            this.addURLButton.Click += new System.EventHandler(this.addURLButton_Click);
            // 
            // priceSettingLabel
            // 
            this.priceSettingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.priceSettingLabel.AutoSize = true;
            this.priceSettingLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceSettingLabel.Location = new System.Drawing.Point(342, 171);
            this.priceSettingLabel.Name = "priceSettingLabel";
            this.priceSettingLabel.Size = new System.Drawing.Size(88, 15);
            this.priceSettingLabel.TabIndex = 13;
            this.priceSettingLabel.Text = "Price Per Movie";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = global::Media_Distro.Properties.Resources.themeBackGround_2;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.redColor);
            this.panel2.Controls.Add(this.greenColor);
            this.panel2.Controls.Add(this.darkBlueColor);
            this.panel2.Controls.Add(this.defaultColor);
            this.panel2.Controls.Add(this.blackColor);
            this.panel2.Controls.Add(this.selected);
            this.panel2.Location = new System.Drawing.Point(12, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(543, 112);
            this.panel2.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose the theme preference you prefer for the interface.";
            // 
            // selected
            // 
            this.selected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.selected.Location = new System.Drawing.Point(39, 50);
            this.selected.Name = "selected";
            this.selected.Size = new System.Drawing.Size(45, 47);
            this.selected.TabIndex = 12;
            this.selected.TabStop = false;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(567, 452);
            this.Controls.Add(this.bonusButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.notificationSettingCheckBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "settingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.Leave += new System.EventHandler(this.SettingsForm_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.redColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkBlueColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blackColor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.removeURLContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.priceSetting)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox notificationSettingCheckBox;
        private System.Windows.Forms.PictureBox defaultColor;
        private System.Windows.Forms.PictureBox blackColor;
        private System.Windows.Forms.PictureBox darkBlueColor;
        private System.Windows.Forms.PictureBox redColor;
        private System.Windows.Forms.PictureBox greenColor;
        private System.Windows.Forms.ToolTip themeToolTip;
        private System.Windows.Forms.PictureBox selected;
        private System.Windows.Forms.Label priceSettingLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label mediaDistroLabel;
        private System.Windows.Forms.Label label6;
        public Guna.UI2.WinForms.Guna2NumericUpDown priceSetting;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.ListBox urlPathListBox;
        public System.Windows.Forms.Button addURLButton;
        public System.Windows.Forms.Button seriesURLCollectionButton;
        public System.Windows.Forms.Button musicURLCollectionButton;
        public System.Windows.Forms.Button movieURLCollectionButton;
        public System.Windows.Forms.Label urlAddingInfo;
        public System.Windows.Forms.Label fileLoadLabel;
        private System.Windows.Forms.ContextMenuStrip removeURLContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeURLToolStripMenuItem;
        public Guna.UI2.WinForms.Guna2Button bonusButton;
    }
}