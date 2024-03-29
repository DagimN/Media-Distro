﻿namespace Mobile_Service_Distribution.Forms
{
    partial class LibraryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryForm));
            this.libraryPanel = new System.Windows.Forms.Panel();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.genreListView = new System.Windows.Forms.ListView();
            this.genreCoverArtImageList = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.musicTabButton = new System.Windows.Forms.Button();
            this.seriesTabButton = new System.Windows.Forms.Button();
            this.moviesTabButton = new System.Windows.Forms.Button();
            this.moviesSelected = new System.Windows.Forms.PictureBox();
            this.seriesSelected = new System.Windows.Forms.PictureBox();
            this.musicSelected = new System.Windows.Forms.PictureBox();
            this.movieList = new System.Windows.Forms.ListView();
            this.movieTitleColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.movieCoverArtImageList = new System.Windows.Forms.ImageList(this.components);
            this.musicList = new System.Windows.Forms.ListView();
            this.musicTitleColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.musicCoverArtImageList = new System.Windows.Forms.ImageList(this.components);
            this.seriesList = new System.Windows.Forms.ListView();
            this.seriesTitleColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.seriesCoverArtImageList = new System.Windows.Forms.ImageList(this.components);
            this.arrangementToolStrip = new System.Windows.Forms.ToolStrip();
            this.genreDescriptionLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.genreToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.sortToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.durationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ratingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ascendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMultiButton = new System.Windows.Forms.ToolStripButton();
            this.selectedItemsLabel = new System.Windows.Forms.ToolStripLabel();
            this.titleToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.coverPictureBox = new System.Windows.Forms.PictureBox();
            this.removeCoverArtContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeCoverArtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.addSTCart = new Guna.UI2.WinForms.Guna2Button();
            this.hideInfoButton = new Guna.UI2.WinForms.Guna2Button();
            this.albumTreeView = new System.Windows.Forms.TreeView();
            this.durationLabelExt = new System.Windows.Forms.Label();
            this.moreInfoLinkLabel = new System.Windows.Forms.LinkLabel();
            this.saveInfoButton = new System.Windows.Forms.Button();
            this.cartButton = new System.Windows.Forms.Button();
            this.ratingTextBox = new System.Windows.Forms.RichTextBox();
            this.yearTextBox = new System.Windows.Forms.RichTextBox();
            this.genreTextBox = new System.Windows.Forms.RichTextBox();
            this.titleTextBox = new System.Windows.Forms.RichTextBox();
            this.yearLabel = new System.Windows.Forms.Label();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.spinnerPictureBox = new System.Windows.Forms.PictureBox();
            this.libraryPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moviesSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicSelected)).BeginInit();
            this.arrangementToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).BeginInit();
            this.removeCoverArtContextMenuStrip.SuspendLayout();
            this.infoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // libraryPanel
            // 
            this.libraryPanel.Controls.Add(this.loadingLabel);
            this.libraryPanel.Controls.Add(this.genreListView);
            this.libraryPanel.Controls.Add(this.pictureBox2);
            this.libraryPanel.Controls.Add(this.musicTabButton);
            this.libraryPanel.Controls.Add(this.seriesTabButton);
            this.libraryPanel.Controls.Add(this.moviesTabButton);
            this.libraryPanel.Controls.Add(this.moviesSelected);
            this.libraryPanel.Controls.Add(this.seriesSelected);
            this.libraryPanel.Controls.Add(this.musicSelected);
            this.libraryPanel.Controls.Add(this.movieList);
            this.libraryPanel.Controls.Add(this.musicList);
            this.libraryPanel.Controls.Add(this.seriesList);
            this.libraryPanel.Controls.Add(this.arrangementToolStrip);
            this.libraryPanel.Controls.Add(this.spinnerPictureBox);
            this.libraryPanel.Location = new System.Drawing.Point(12, 12);
            this.libraryPanel.Name = "libraryPanel";
            this.libraryPanel.Size = new System.Drawing.Size(546, 428);
            this.libraryPanel.TabIndex = 0;
            this.libraryPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LibraryForm_MouseClick);
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Location = new System.Drawing.Point(209, 73);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(110, 13);
            this.loadingLabel.TabIndex = 13;
            this.loadingLabel.Text = "Loading Media Files...";
            // 
            // genreListView
            // 
            this.genreListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.genreListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.genreListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.genreListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.genreListView.CheckBoxes = true;
            this.genreListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.genreListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genreListView.HideSelection = false;
            this.genreListView.LargeImageList = this.genreCoverArtImageList;
            this.genreListView.Location = new System.Drawing.Point(0, 41);
            this.genreListView.Name = "genreListView";
            this.genreListView.Size = new System.Drawing.Size(546, 384);
            this.genreListView.TabIndex = 12;
            this.genreListView.UseCompatibleStateImageBehavior = false;
            this.genreListView.Visible = false;
            this.genreListView.ItemActivate += new System.EventHandler(this.genreList_ItemActivate);
            // 
            // genreCoverArtImageList
            // 
            this.genreCoverArtImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("genreCoverArtImageList.ImageStream")));
            this.genreCoverArtImageList.Tag = "No";
            this.genreCoverArtImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.genreCoverArtImageList.Images.SetKeyName(0, "coverart sample 2.png");
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Location = new System.Drawing.Point(290, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(255, 10);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // musicTabButton
            // 
            this.musicTabButton.FlatAppearance.BorderSize = 0;
            this.musicTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.musicTabButton.Font = new System.Drawing.Font("Microsoft JhengHei", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicTabButton.ForeColor = System.Drawing.Color.DimGray;
            this.musicTabButton.Location = new System.Drawing.Point(192, 0);
            this.musicTabButton.Name = "musicTabButton";
            this.musicTabButton.Size = new System.Drawing.Size(90, 27);
            this.musicTabButton.TabIndex = 2;
            this.musicTabButton.Text = "Music";
            this.musicTabButton.UseVisualStyleBackColor = true;
            this.musicTabButton.Click += new System.EventHandler(this.musicTabButton_Click);
            // 
            // seriesTabButton
            // 
            this.seriesTabButton.FlatAppearance.BorderSize = 0;
            this.seriesTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.seriesTabButton.Font = new System.Drawing.Font("Microsoft JhengHei", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seriesTabButton.ForeColor = System.Drawing.Color.DimGray;
            this.seriesTabButton.Location = new System.Drawing.Point(96, 0);
            this.seriesTabButton.Name = "seriesTabButton";
            this.seriesTabButton.Size = new System.Drawing.Size(90, 27);
            this.seriesTabButton.TabIndex = 1;
            this.seriesTabButton.Text = "Series";
            this.seriesTabButton.UseVisualStyleBackColor = true;
            this.seriesTabButton.Click += new System.EventHandler(this.seriesTabButton_Click);
            // 
            // moviesTabButton
            // 
            this.moviesTabButton.FlatAppearance.BorderSize = 0;
            this.moviesTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moviesTabButton.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moviesTabButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(32)))), ((int)(((byte)(86)))));
            this.moviesTabButton.Location = new System.Drawing.Point(0, 0);
            this.moviesTabButton.Name = "moviesTabButton";
            this.moviesTabButton.Size = new System.Drawing.Size(90, 27);
            this.moviesTabButton.TabIndex = 0;
            this.moviesTabButton.Text = "Movies";
            this.moviesTabButton.UseVisualStyleBackColor = true;
            this.moviesTabButton.Click += new System.EventHandler(this.moviesTabButton_Click);
            // 
            // moviesSelected
            // 
            this.moviesSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(32)))), ((int)(((byte)(86)))));
            this.moviesSelected.Location = new System.Drawing.Point(0, 0);
            this.moviesSelected.Name = "moviesSelected";
            this.moviesSelected.Size = new System.Drawing.Size(90, 31);
            this.moviesSelected.TabIndex = 3;
            this.moviesSelected.TabStop = false;
            // 
            // seriesSelected
            // 
            this.seriesSelected.BackColor = System.Drawing.Color.Transparent;
            this.seriesSelected.Location = new System.Drawing.Point(96, 0);
            this.seriesSelected.Name = "seriesSelected";
            this.seriesSelected.Size = new System.Drawing.Size(90, 31);
            this.seriesSelected.TabIndex = 5;
            this.seriesSelected.TabStop = false;
            // 
            // musicSelected
            // 
            this.musicSelected.BackColor = System.Drawing.Color.Transparent;
            this.musicSelected.Location = new System.Drawing.Point(192, 0);
            this.musicSelected.Name = "musicSelected";
            this.musicSelected.Size = new System.Drawing.Size(90, 31);
            this.musicSelected.TabIndex = 4;
            this.musicSelected.TabStop = false;
            // 
            // movieList
            // 
            this.movieList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.movieList.AllowColumnReorder = true;
            this.movieList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.movieList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.movieList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.movieList.CheckBoxes = true;
            this.movieList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.movieTitleColumnHeader});
            this.movieList.Font = new System.Drawing.Font("Microsoft JhengHei", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.movieList.HideSelection = false;
            this.movieList.LargeImageList = this.movieCoverArtImageList;
            this.movieList.Location = new System.Drawing.Point(0, 41);
            this.movieList.Name = "movieList";
            this.movieList.Size = new System.Drawing.Size(546, 384);
            this.movieList.TabIndex = 6;
            this.movieList.Tag = "00";
            this.movieList.UseCompatibleStateImageBehavior = false;
            this.movieList.ItemActivate += new System.EventHandler(this.movieList_ItemActivate);
            this.movieList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.movieList_ItemCheck);
            this.movieList.VisibleChanged += new System.EventHandler(this.movieList_VisibleChanged);
            this.movieList.Leave += new System.EventHandler(this.List_Leave);
            // 
            // movieTitleColumnHeader
            // 
            this.movieTitleColumnHeader.Text = "Title";
            this.movieTitleColumnHeader.Width = 500;
            // 
            // movieCoverArtImageList
            // 
            this.movieCoverArtImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("movieCoverArtImageList.ImageStream")));
            this.movieCoverArtImageList.Tag = "No";
            this.movieCoverArtImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.movieCoverArtImageList.Images.SetKeyName(0, "coverart sample 2.png");
            // 
            // musicList
            // 
            this.musicList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.musicList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.musicList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.musicList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.musicList.CheckBoxes = true;
            this.musicList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.musicTitleColumnHeader});
            this.musicList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.musicList.HideSelection = false;
            this.musicList.LargeImageList = this.musicCoverArtImageList;
            this.musicList.Location = new System.Drawing.Point(0, 41);
            this.musicList.Name = "musicList";
            this.musicList.Size = new System.Drawing.Size(546, 384);
            this.musicList.TabIndex = 8;
            this.musicList.Tag = "00";
            this.musicList.UseCompatibleStateImageBehavior = false;
            this.musicList.Visible = false;
            this.musicList.ItemActivate += new System.EventHandler(this.musicList_ItemActivate);
            this.musicList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.musicList_ItemCheck);
            this.musicList.VisibleChanged += new System.EventHandler(this.musicList_VisibleChanged);
            this.musicList.Leave += new System.EventHandler(this.List_Leave);
            // 
            // musicTitleColumnHeader
            // 
            this.musicTitleColumnHeader.Text = "Title";
            this.musicTitleColumnHeader.Width = 500;
            // 
            // musicCoverArtImageList
            // 
            this.musicCoverArtImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("musicCoverArtImageList.ImageStream")));
            this.musicCoverArtImageList.Tag = "No";
            this.musicCoverArtImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.musicCoverArtImageList.Images.SetKeyName(0, "coverart sample 2.png");
            // 
            // seriesList
            // 
            this.seriesList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.seriesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seriesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.seriesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seriesList.CheckBoxes = true;
            this.seriesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.seriesTitleColumnHeader});
            this.seriesList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seriesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.seriesList.HideSelection = false;
            this.seriesList.LargeImageList = this.seriesCoverArtImageList;
            this.seriesList.Location = new System.Drawing.Point(0, 41);
            this.seriesList.Name = "seriesList";
            this.seriesList.Size = new System.Drawing.Size(546, 384);
            this.seriesList.TabIndex = 7;
            this.seriesList.Tag = "00";
            this.seriesList.UseCompatibleStateImageBehavior = false;
            this.seriesList.Visible = false;
            this.seriesList.ItemActivate += new System.EventHandler(this.seriesList_ItemActivate);
            this.seriesList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.seriesList_ItemCheck);
            this.seriesList.VisibleChanged += new System.EventHandler(this.seriesList_VisibleChanged);
            this.seriesList.Leave += new System.EventHandler(this.List_Leave);
            // 
            // seriesTitleColumnHeader
            // 
            this.seriesTitleColumnHeader.Text = "Title";
            this.seriesTitleColumnHeader.Width = 500;
            // 
            // seriesCoverArtImageList
            // 
            this.seriesCoverArtImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("seriesCoverArtImageList.ImageStream")));
            this.seriesCoverArtImageList.Tag = "No";
            this.seriesCoverArtImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.seriesCoverArtImageList.Images.SetKeyName(0, "coverart sample 2.png");
            // 
            // arrangementToolStrip
            // 
            this.arrangementToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.arrangementToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.arrangementToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.arrangementToolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.arrangementToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.arrangementToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.genreDescriptionLabel,
            this.toolStripSeparator1,
            this.genreToolStripDropDownButton,
            this.sortToolStripDropDownButton,
            this.sendMultiButton,
            this.selectedItemsLabel});
            this.arrangementToolStrip.Location = new System.Drawing.Point(360, 0);
            this.arrangementToolStrip.Name = "arrangementToolStrip";
            this.arrangementToolStrip.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.arrangementToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.arrangementToolStrip.Size = new System.Drawing.Size(184, 34);
            this.arrangementToolStrip.TabIndex = 9;
            // 
            // genreDescriptionLabel
            // 
            this.genreDescriptionLabel.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F);
            this.genreDescriptionLabel.Name = "genreDescriptionLabel";
            this.genreDescriptionLabel.Size = new System.Drawing.Size(21, 25);
            this.genreDescriptionLabel.Text = "All";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // genreToolStripDropDownButton
            // 
            this.genreToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.genreToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.toolStripMenuItem2});
            this.genreToolStripDropDownButton.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F);
            this.genreToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("genreToolStripDropDownButton.Image")));
            this.genreToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.genreToolStripDropDownButton.Name = "genreToolStripDropDownButton";
            this.genreToolStripDropDownButton.Size = new System.Drawing.Size(51, 25);
            this.genreToolStripDropDownButton.Text = "Genre";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(85, 6);
            // 
            // sortToolStripDropDownButton
            // 
            this.sortToolStripDropDownButton.BackColor = System.Drawing.Color.Transparent;
            this.sortToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sortToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem,
            this.durationToolStripMenuItem,
            this.yearToolStripMenuItem,
            this.ratingToolStripMenuItem,
            this.toolStripMenuItem1,
            this.orderToolStripMenuItem});
            this.sortToolStripDropDownButton.Font = new System.Drawing.Font("Nirmala UI Semilight", 9F);
            this.sortToolStripDropDownButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sortToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("sortToolStripDropDownButton.Image")));
            this.sortToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortToolStripDropDownButton.Name = "sortToolStripDropDownButton";
            this.sortToolStripDropDownButton.Size = new System.Drawing.Size(41, 25);
            this.sortToolStripDropDownButton.Text = "Sort";
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.nameToolStripMenuItem.CheckOnClick = true;
            this.nameToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.nameToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.nameToolStripMenuItem.Text = "Name";
            this.nameToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.nameToolStripMenuItem_Click);
            // 
            // durationToolStripMenuItem
            // 
            this.durationToolStripMenuItem.CheckOnClick = true;
            this.durationToolStripMenuItem.Name = "durationToolStripMenuItem";
            this.durationToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.durationToolStripMenuItem.Text = "Duration";
            this.durationToolStripMenuItem.Click += new System.EventHandler(this.durationToolStripMenuItem_Click);
            // 
            // yearToolStripMenuItem
            // 
            this.yearToolStripMenuItem.CheckOnClick = true;
            this.yearToolStripMenuItem.Name = "yearToolStripMenuItem";
            this.yearToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.yearToolStripMenuItem.Text = "Year";
            this.yearToolStripMenuItem.Click += new System.EventHandler(this.yearToolStripMenuItem_Click);
            // 
            // ratingToolStripMenuItem
            // 
            this.ratingToolStripMenuItem.CheckOnClick = true;
            this.ratingToolStripMenuItem.Name = "ratingToolStripMenuItem";
            this.ratingToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ratingToolStripMenuItem.Text = "Rating";
            this.ratingToolStripMenuItem.Click += new System.EventHandler(this.ratingToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(117, 6);
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.orderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ascendingToolStripMenuItem,
            this.descendingToolStripMenuItem});
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.orderToolStripMenuItem.Text = "Order";
            // 
            // ascendingToolStripMenuItem
            // 
            this.ascendingToolStripMenuItem.CheckOnClick = true;
            this.ascendingToolStripMenuItem.Name = "ascendingToolStripMenuItem";
            this.ascendingToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.ascendingToolStripMenuItem.Text = "Ascending";
            this.ascendingToolStripMenuItem.Click += new System.EventHandler(this.ascendingToolStripMenuItem_Click);
            // 
            // descendingToolStripMenuItem
            // 
            this.descendingToolStripMenuItem.CheckOnClick = true;
            this.descendingToolStripMenuItem.Name = "descendingToolStripMenuItem";
            this.descendingToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.descendingToolStripMenuItem.Text = "Descending";
            this.descendingToolStripMenuItem.Click += new System.EventHandler(this.descendingToolStripMenuItem_Click);
            // 
            // sendMultiButton
            // 
            this.sendMultiButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sendMultiButton.Enabled = false;
            this.sendMultiButton.Image = global::Media_Distro.Properties.Resources.arrow_symbolic_link_15730;
            this.sendMultiButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sendMultiButton.Name = "sendMultiButton";
            this.sendMultiButton.Size = new System.Drawing.Size(23, 25);
            this.sendMultiButton.Click += new System.EventHandler(this.sendMultiButton_Click);
            // 
            // selectedItemsLabel
            // 
            this.selectedItemsLabel.AutoSize = false;
            this.selectedItemsLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectedItemsLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.selectedItemsLabel.ForeColor = System.Drawing.Color.DimGray;
            this.selectedItemsLabel.Name = "selectedItemsLabel";
            this.selectedItemsLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.selectedItemsLabel.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.selectedItemsLabel.Size = new System.Drawing.Size(30, 25);
            // 
            // titleToolTip
            // 
            this.titleToolTip.BackColor = System.Drawing.SystemColors.Control;
            // 
            // coverPictureBox
            // 
            this.coverPictureBox.BackgroundImage = global::Media_Distro.Properties.Resources.coverart_sample_2;
            this.coverPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.coverPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coverPictureBox.ContextMenuStrip = this.removeCoverArtContextMenuStrip;
            this.coverPictureBox.Location = new System.Drawing.Point(-1, -1);
            this.coverPictureBox.Name = "coverPictureBox";
            this.coverPictureBox.Size = new System.Drawing.Size(110, 146);
            this.coverPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coverPictureBox.TabIndex = 0;
            this.coverPictureBox.TabStop = false;
            this.titleToolTip.SetToolTip(this.coverPictureBox, "Click to change cover art");
            this.coverPictureBox.Click += new System.EventHandler(this.coverPictureBox_Click);
            // 
            // removeCoverArtContextMenuStrip
            // 
            this.removeCoverArtContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeCoverArtToolStripMenuItem});
            this.removeCoverArtContextMenuStrip.Name = "removeCoverArtContextMenuStrip";
            this.removeCoverArtContextMenuStrip.Size = new System.Drawing.Size(171, 26);
            // 
            // removeCoverArtToolStripMenuItem
            // 
            this.removeCoverArtToolStripMenuItem.Name = "removeCoverArtToolStripMenuItem";
            this.removeCoverArtToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.removeCoverArtToolStripMenuItem.Text = "Remove Cover Art";
            this.removeCoverArtToolStripMenuItem.Click += new System.EventHandler(this.removeCoverArtToolStripMenuItem_Click);
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(75)))), ((int)(((byte)(165)))));
            this.infoPanel.BackgroundImage = global::Media_Distro.Properties.Resources.infoPanel_Background;
            this.infoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.infoPanel.Controls.Add(this.addSTCart);
            this.infoPanel.Controls.Add(this.hideInfoButton);
            this.infoPanel.Controls.Add(this.albumTreeView);
            this.infoPanel.Controls.Add(this.durationLabelExt);
            this.infoPanel.Controls.Add(this.moreInfoLinkLabel);
            this.infoPanel.Controls.Add(this.saveInfoButton);
            this.infoPanel.Controls.Add(this.cartButton);
            this.infoPanel.Controls.Add(this.ratingTextBox);
            this.infoPanel.Controls.Add(this.yearTextBox);
            this.infoPanel.Controls.Add(this.genreTextBox);
            this.infoPanel.Controls.Add(this.titleTextBox);
            this.infoPanel.Controls.Add(this.yearLabel);
            this.infoPanel.Controls.Add(this.ratingLabel);
            this.infoPanel.Controls.Add(this.genreLabel);
            this.infoPanel.Controls.Add(this.durationLabel);
            this.infoPanel.Controls.Add(this.coverPictureBox);
            this.infoPanel.Controls.Add(this.pictureBox1);
            this.infoPanel.Location = new System.Drawing.Point(0, 306);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(567, 146);
            this.infoPanel.TabIndex = 1;
            this.infoPanel.Visible = false;
            this.infoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.infoPanel_Paint);
            this.infoPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxLoseFocus_MouseClick);
            // 
            // addSTCart
            // 
            this.addSTCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addSTCart.BorderRadius = 10;
            this.addSTCart.CheckedState.Parent = this.addSTCart;
            this.addSTCart.CustomImages.Parent = this.addSTCart;
            this.addSTCart.CustomizableEdges.BottomRight = false;
            this.addSTCart.CustomizableEdges.TopRight = false;
            this.addSTCart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addSTCart.ForeColor = System.Drawing.Color.White;
            this.addSTCart.HoverState.Parent = this.addSTCart;
            this.addSTCart.Location = new System.Drawing.Point(511, 42);
            this.addSTCart.Name = "addSTCart";
            this.addSTCart.ShadowDecoration.Parent = this.addSTCart;
            this.addSTCart.Size = new System.Drawing.Size(56, 23);
            this.addSTCart.TabIndex = 13;
            this.addSTCart.Text = "Add";
            this.addSTCart.Click += new System.EventHandler(this.addSTCart_Click);
            // 
            // hideInfoButton
            // 
            this.hideInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hideInfoButton.AutoRoundedCorners = true;
            this.hideInfoButton.BorderRadius = 5;
            this.hideInfoButton.CheckedState.Parent = this.hideInfoButton;
            this.hideInfoButton.CustomImages.Parent = this.hideInfoButton;
            this.hideInfoButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hideInfoButton.ForeColor = System.Drawing.Color.White;
            this.hideInfoButton.HoverState.Parent = this.hideInfoButton;
            this.hideInfoButton.Image = global::Media_Distro.Properties.Resources.Hide_Info_Icon;
            this.hideInfoButton.Location = new System.Drawing.Point(269, -1);
            this.hideInfoButton.Name = "hideInfoButton";
            this.hideInfoButton.ShadowDecoration.Parent = this.hideInfoButton;
            this.hideInfoButton.Size = new System.Drawing.Size(62, 13);
            this.hideInfoButton.TabIndex = 13;
            this.hideInfoButton.Click += new System.EventHandler(this.hideInfoButton_Click);
            // 
            // albumTreeView
            // 
            this.albumTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.albumTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(110)))), ((int)(((byte)(200)))));
            this.albumTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.albumTreeView.CheckBoxes = true;
            this.albumTreeView.Location = new System.Drawing.Point(380, 65);
            this.albumTreeView.Name = "albumTreeView";
            this.albumTreeView.Size = new System.Drawing.Size(204, 82);
            this.albumTreeView.TabIndex = 12;
            this.albumTreeView.Visible = false;
            this.albumTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.albumTreeView_AfterCheck);
            // 
            // durationLabelExt
            // 
            this.durationLabelExt.AutoSize = true;
            this.durationLabelExt.BackColor = System.Drawing.Color.Transparent;
            this.durationLabelExt.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.durationLabelExt.ForeColor = System.Drawing.Color.Black;
            this.durationLabelExt.Location = new System.Drawing.Point(203, 48);
            this.durationLabelExt.Name = "durationLabelExt";
            this.durationLabelExt.Size = new System.Drawing.Size(0, 14);
            this.durationLabelExt.TabIndex = 15;
            // 
            // moreInfoLinkLabel
            // 
            this.moreInfoLinkLabel.ActiveLinkColor = System.Drawing.Color.DeepSkyBlue;
            this.moreInfoLinkLabel.AutoSize = true;
            this.moreInfoLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.moreInfoLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.moreInfoLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(15)))), ((int)(((byte)(50)))));
            this.moreInfoLinkLabel.Location = new System.Drawing.Point(144, 124);
            this.moreInfoLinkLabel.Name = "moreInfoLinkLabel";
            this.moreInfoLinkLabel.Size = new System.Drawing.Size(52, 13);
            this.moreInfoLinkLabel.TabIndex = 14;
            this.moreInfoLinkLabel.TabStop = true;
            this.moreInfoLinkLabel.Text = "More Info";
            this.moreInfoLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.moreInfoLinkLabel_LinkClicked);
            // 
            // saveInfoButton
            // 
            this.saveInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveInfoButton.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.saveInfoButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.saveInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveInfoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saveInfoButton.Location = new System.Drawing.Point(520, 13);
            this.saveInfoButton.Name = "saveInfoButton";
            this.saveInfoButton.Size = new System.Drawing.Size(44, 23);
            this.saveInfoButton.TabIndex = 13;
            this.saveInfoButton.Text = "Save";
            this.saveInfoButton.UseVisualStyleBackColor = false;
            this.saveInfoButton.Visible = false;
            this.saveInfoButton.Click += new System.EventHandler(this.saveInfoButton_Click);
            // 
            // cartButton
            // 
            this.cartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cartButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.cartButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cartButton.ForeColor = System.Drawing.Color.White;
            this.cartButton.Location = new System.Drawing.Point(-1, 124);
            this.cartButton.Name = "cartButton";
            this.cartButton.Size = new System.Drawing.Size(110, 23);
            this.cartButton.TabIndex = 12;
            this.cartButton.Text = "Add to Cart";
            this.cartButton.UseVisualStyleBackColor = false;
            this.cartButton.Click += new System.EventHandler(this.cartButton_Click);
            // 
            // ratingTextBox
            // 
            this.ratingTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(145)))), ((int)(((byte)(225)))));
            this.ratingTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ratingTextBox.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ratingTextBox.ForeColor = System.Drawing.Color.Black;
            this.ratingTextBox.Location = new System.Drawing.Point(192, 99);
            this.ratingTextBox.Multiline = false;
            this.ratingTextBox.Name = "ratingTextBox";
            this.ratingTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.ratingTextBox.Size = new System.Drawing.Size(46, 16);
            this.ratingTextBox.TabIndex = 10;
            this.ratingTextBox.Text = "";
            this.ratingTextBox.WordWrap = false;
            this.ratingTextBox.Click += new System.EventHandler(this.ratingTextBox_Click);
            this.ratingTextBox.TextChanged += new System.EventHandler(this.ratingTextBox_TextChanged);
            this.ratingTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.ratingTextBox.Leave += new System.EventHandler(this.ratingTextBox_Leave);
            // 
            // yearTextBox
            // 
            this.yearTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(145)))), ((int)(((byte)(225)))));
            this.yearTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yearTextBox.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearTextBox.ForeColor = System.Drawing.Color.Black;
            this.yearTextBox.Location = new System.Drawing.Point(190, 82);
            this.yearTextBox.Multiline = false;
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.yearTextBox.Size = new System.Drawing.Size(48, 17);
            this.yearTextBox.TabIndex = 9;
            this.yearTextBox.Text = "";
            this.yearTextBox.WordWrap = false;
            this.yearTextBox.Click += new System.EventHandler(this.yearTextBox_Click);
            this.yearTextBox.TextChanged += new System.EventHandler(this.yearTextBox_TextChanged);
            this.yearTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.yearTextBox.Leave += new System.EventHandler(this.yearTextBox_Leave);
            // 
            // genreTextBox
            // 
            this.genreTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(145)))), ((int)(((byte)(225)))));
            this.genreTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.genreTextBox.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genreTextBox.ForeColor = System.Drawing.Color.Black;
            this.genreTextBox.Location = new System.Drawing.Point(190, 65);
            this.genreTextBox.Multiline = false;
            this.genreTextBox.Name = "genreTextBox";
            this.genreTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.genreTextBox.Size = new System.Drawing.Size(116, 17);
            this.genreTextBox.TabIndex = 8;
            this.genreTextBox.Text = "";
            this.genreTextBox.WordWrap = false;
            this.genreTextBox.Click += new System.EventHandler(this.genreTextBox_Click);
            this.genreTextBox.TextChanged += new System.EventHandler(this.genreTextBox_TextChanged);
            this.genreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.genreTextBox.Leave += new System.EventHandler(this.genreTextBox_Leave);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(75)))), ((int)(((byte)(165)))));
            this.titleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.titleTextBox.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.titleTextBox.Location = new System.Drawing.Point(115, 13);
            this.titleTextBox.Multiline = false;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.titleTextBox.Size = new System.Drawing.Size(399, 22);
            this.titleTextBox.TabIndex = 6;
            this.titleTextBox.Text = "Sample";
            this.titleTextBox.WordWrap = false;
            this.titleTextBox.Click += new System.EventHandler(this.titleTextBox_Click);
            this.titleTextBox.TextChanged += new System.EventHandler(this.titleTextBox_TextChanged);
            this.titleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            this.titleTextBox.Leave += new System.EventHandler(this.titleTextBox_Leave);
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.BackColor = System.Drawing.Color.Transparent;
            this.yearLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearLabel.Location = new System.Drawing.Point(144, 82);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.yearLabel.Size = new System.Drawing.Size(31, 17);
            this.yearLabel.TabIndex = 5;
            this.yearLabel.Text = "Year:";
            this.yearLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxLoseFocus_MouseClick);
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.BackColor = System.Drawing.Color.Transparent;
            this.ratingLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ratingLabel.Location = new System.Drawing.Point(144, 99);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ratingLabel.Size = new System.Drawing.Size(42, 17);
            this.ratingLabel.TabIndex = 4;
            this.ratingLabel.Text = "Rating:";
            this.ratingLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxLoseFocus_MouseClick);
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.BackColor = System.Drawing.Color.Transparent;
            this.genreLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genreLabel.Location = new System.Drawing.Point(144, 65);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.genreLabel.Size = new System.Drawing.Size(40, 17);
            this.genreLabel.TabIndex = 3;
            this.genreLabel.Text = "Genre:";
            this.genreLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxLoseFocus_MouseClick);
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.BackColor = System.Drawing.Color.Transparent;
            this.durationLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.durationLabel.Location = new System.Drawing.Point(144, 48);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.durationLabel.Size = new System.Drawing.Size(53, 17);
            this.durationLabel.TabIndex = 2;
            this.durationLabel.Text = "Duration:";
            this.durationLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxLoseFocus_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Media_Distro.Properties.Resources.seriesBackground;
            this.pictureBox1.Location = new System.Drawing.Point(377, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // spinnerPictureBox
            // 
            this.spinnerPictureBox.Image = global::Media_Distro.Properties.Resources.Spinner;
            this.spinnerPictureBox.Location = new System.Drawing.Point(288, -20);
            this.spinnerPictureBox.Name = "spinnerPictureBox";
            this.spinnerPictureBox.Size = new System.Drawing.Size(65, 65);
            this.spinnerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.spinnerPictureBox.TabIndex = 14;
            this.spinnerPictureBox.TabStop = false;
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(80)))), ((int)(((byte)(135)))));
            this.ClientSize = new System.Drawing.Size(567, 452);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.libraryPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LibraryForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "LibraryForm";
            this.Leave += new System.EventHandler(this.LibraryForm_Leave);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LibraryForm_MouseClick);
            this.libraryPanel.ResumeLayout(false);
            this.libraryPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moviesSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicSelected)).EndInit();
            this.arrangementToolStrip.ResumeLayout(false);
            this.arrangementToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverPictureBox)).EndInit();
            this.removeCoverArtContextMenuStrip.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel libraryPanel;
        public System.Windows.Forms.ListView musicList;
        public System.Windows.Forms.ListView seriesList;
        public System.Windows.Forms.ListView movieList;
        private System.Windows.Forms.ColumnHeader movieTitleColumnHeader;
        private System.Windows.Forms.ColumnHeader musicTitleColumnHeader;
        private System.Windows.Forms.ColumnHeader seriesTitleColumnHeader;
        public System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.PictureBox coverPictureBox;
        public System.Windows.Forms.Button cartButton;
        private System.Windows.Forms.ToolTip titleToolTip;
        private System.Windows.Forms.Button saveInfoButton;
        private System.Windows.Forms.ToolStripDropDownButton sortToolStripDropDownButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem durationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ratingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ascendingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem descendingToolStripMenuItem;
        public System.Windows.Forms.RichTextBox ratingTextBox;
        public System.Windows.Forms.RichTextBox yearTextBox;
        public System.Windows.Forms.RichTextBox genreTextBox;
        public System.Windows.Forms.RichTextBox titleTextBox;
        private System.Windows.Forms.ImageList movieCoverArtImageList;
        public System.Windows.Forms.Button moviesTabButton;
        public System.Windows.Forms.PictureBox moviesSelected;
        private System.Windows.Forms.ToolStripLabel selectedItemsLabel;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripLabel genreDescriptionLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ListView genreListView;
        public System.Windows.Forms.Label durationLabelExt;
        public System.Windows.Forms.Label durationLabel;
        public System.Windows.Forms.Label yearLabel;
        public System.Windows.Forms.Label ratingLabel;
        public System.Windows.Forms.Label genreLabel;
        public System.Windows.Forms.LinkLabel moreInfoLinkLabel;
        public System.Windows.Forms.Button musicTabButton;
        public System.Windows.Forms.Button seriesTabButton;
        public System.Windows.Forms.PictureBox seriesSelected;
        public System.Windows.Forms.PictureBox musicSelected;
        public Guna.UI2.WinForms.Guna2Button hideInfoButton;
        public Guna.UI2.WinForms.Guna2Button addSTCart;
        public System.Windows.Forms.TreeView albumTreeView;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton sendMultiButton;
        private System.Windows.Forms.ContextMenuStrip removeCoverArtContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeCoverArtToolStripMenuItem;
        public System.Windows.Forms.ToolStripDropDownButton genreToolStripDropDownButton;
        public System.Windows.Forms.ToolStrip arrangementToolStrip;
        public System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.ImageList musicCoverArtImageList;
        private System.Windows.Forms.ImageList seriesCoverArtImageList;
        private System.Windows.Forms.ImageList genreCoverArtImageList;
        public System.Windows.Forms.PictureBox spinnerPictureBox;
    }
}