namespace Mobile_Service_Distribution.Forms
{
    partial class ShareForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShareForm));
            this.shareImageList = new System.Windows.Forms.ImageList(this.components);
            this.cartsListView = new System.Windows.Forms.ListView();
            this.cartNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cartsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cartsButton = new System.Windows.Forms.Button();
            this.progressButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.attentionLabel = new System.Windows.Forms.Label();
            this.sharePanel = new System.Windows.Forms.Panel();
            this.noCartLabel = new System.Windows.Forms.Label();
            this.detailPanel = new System.Windows.Forms.Panel();
            this.emptyCartLabel = new System.Windows.Forms.Label();
            this.priceExtLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.cartSizeExtLabel = new System.Windows.Forms.Label();
            this.cartSizeLabel = new System.Windows.Forms.Label();
            this.seriesExtLabel = new System.Windows.Forms.Label();
            this.seriesLabel = new System.Windows.Forms.Label();
            this.musicExtLabel = new System.Windows.Forms.Label();
            this.musicLabel = new System.Windows.Forms.Label();
            this.movieExtLabel = new System.Windows.Forms.Label();
            this.movieLabel = new System.Windows.Forms.Label();
            this.detailListView = new System.Windows.Forms.ListView();
            this.coverArtImageList = new System.Windows.Forms.ImageList(this.components);
            this.transferCompNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.removeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.progressSelected = new System.Windows.Forms.PictureBox();
            this.cartsSelected = new System.Windows.Forms.PictureBox();
            this.devicePanel = new System.Windows.Forms.Panel();
            this.deviceList = new System.Windows.Forms.ListView();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressListView = new Media_Distro.ProgressListView();
            this.deviceLabel = new System.Windows.Forms.Label();
            this.cartsContextMenuStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.sharePanel.SuspendLayout();
            this.detailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartsSelected)).BeginInit();
            this.devicePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // shareImageList
            // 
            this.shareImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("shareImageList.ImageStream")));
            this.shareImageList.TransparentColor = System.Drawing.Color.Empty;
            this.shareImageList.Images.SetKeyName(0, "cart list view 3.png");
            this.shareImageList.Images.SetKeyName(1, "cart list view 2.png");
            this.shareImageList.Images.SetKeyName(2, "USB Icon.png");
            // 
            // cartsListView
            // 
            this.cartsListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.cartsListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.cartsListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cartsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cartNameColumn});
            this.cartsListView.ContextMenuStrip = this.cartsContextMenuStrip;
            this.cartsListView.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.cartsListView.HideSelection = false;
            this.cartsListView.LargeImageList = this.shareImageList;
            this.cartsListView.Location = new System.Drawing.Point(0, 31);
            this.cartsListView.MaximumSize = new System.Drawing.Size(550, 214);
            this.cartsListView.MultiSelect = false;
            this.cartsListView.Name = "cartsListView";
            this.cartsListView.Size = new System.Drawing.Size(226, 214);
            this.cartsListView.SmallImageList = this.shareImageList;
            this.cartsListView.TabIndex = 3;
            this.cartsListView.UseCompatibleStateImageBehavior = false;
            this.cartsListView.View = System.Windows.Forms.View.SmallIcon;
            this.cartsListView.ItemActivate += new System.EventHandler(this.cartsListView_ItemActivate);
            this.cartsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.cartsListView_ItemSelectionChanged);
            this.cartsListView.VisibleChanged += new System.EventHandler(this.cartsListView_VisibleChanged);
            this.cartsListView.DoubleClick += new System.EventHandler(this.cartsListView_DoubleClick);
            this.cartsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cartsListView_KeyDown);
            this.cartsListView.Leave += new System.EventHandler(this.cartsListView_Leave);
            // 
            // cartNameColumn
            // 
            this.cartNameColumn.Text = "";
            this.cartNameColumn.Width = 250;
            // 
            // cartsContextMenuStrip
            // 
            this.cartsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToToolStripMenuItem,
            this.clearCartToolStripMenuItem,
            this.removeCartToolStripMenuItem});
            this.cartsContextMenuStrip.Name = "cartsContextMenuStrip";
            this.cartsContextMenuStrip.Size = new System.Drawing.Size(143, 70);
            this.cartsContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.cartsContextMenuStrip_Opening);
            // 
            // sendToToolStripMenuItem
            // 
            this.sendToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.sendToToolStripMenuItem.Enabled = false;
            this.sendToToolStripMenuItem.Name = "sendToToolStripMenuItem";
            this.sendToToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.sendToToolStripMenuItem.Text = "Send To";
            this.sendToToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.sendToToolStripMenuItem_DropDownItemClicked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(80, 22);
            this.toolStripMenuItem2.Text = "0";
            // 
            // clearCartToolStripMenuItem
            // 
            this.clearCartToolStripMenuItem.Name = "clearCartToolStripMenuItem";
            this.clearCartToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.clearCartToolStripMenuItem.Text = "Clear";
            this.clearCartToolStripMenuItem.Click += new System.EventHandler(this.clearCartToolStripMenuItem_Click);
            // 
            // removeCartToolStripMenuItem
            // 
            this.removeCartToolStripMenuItem.Name = "removeCartToolStripMenuItem";
            this.removeCartToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.removeCartToolStripMenuItem.Text = "Remove Cart";
            this.removeCartToolStripMenuItem.Click += new System.EventHandler(this.removeCartToolStripMenuItem_Click);
            // 
            // cartsButton
            // 
            this.cartsButton.FlatAppearance.BorderSize = 0;
            this.cartsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cartsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(32)))), ((int)(((byte)(86)))));
            this.cartsButton.Location = new System.Drawing.Point(0, 0);
            this.cartsButton.Name = "cartsButton";
            this.cartsButton.Size = new System.Drawing.Size(90, 25);
            this.cartsButton.TabIndex = 4;
            this.cartsButton.Text = "Carts";
            this.cartsButton.UseVisualStyleBackColor = true;
            this.cartsButton.Click += new System.EventHandler(this.cartsButton_Click);
            // 
            // progressButton
            // 
            this.progressButton.FlatAppearance.BorderSize = 0;
            this.progressButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.progressButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressButton.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.progressButton.Location = new System.Drawing.Point(96, 0);
            this.progressButton.Name = "progressButton";
            this.progressButton.Size = new System.Drawing.Size(90, 25);
            this.progressButton.TabIndex = 5;
            this.progressButton.Text = "Progress";
            this.progressButton.UseVisualStyleBackColor = true;
            this.progressButton.Click += new System.EventHandler(this.progressButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(32)))), ((int)(((byte)(86)))));
            this.panel1.Controls.Add(this.attentionLabel);
            this.panel1.Location = new System.Drawing.Point(232, 176);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 69);
            this.panel1.TabIndex = 11;
            // 
            // attentionLabel
            // 
            this.attentionLabel.AutoSize = true;
            this.attentionLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attentionLabel.ForeColor = System.Drawing.Color.LightGray;
            this.attentionLabel.Location = new System.Drawing.Point(37, 25);
            this.attentionLabel.Name = "attentionLabel";
            this.attentionLabel.Size = new System.Drawing.Size(251, 25);
            this.attentionLabel.TabIndex = 0;
            this.attentionLabel.Text = "Select Cart to Show Detail";
            // 
            // sharePanel
            // 
            this.sharePanel.Controls.Add(this.progressLabel);
            this.sharePanel.Controls.Add(this.noCartLabel);
            this.sharePanel.Controls.Add(this.panel1);
            this.sharePanel.Controls.Add(this.detailPanel);
            this.sharePanel.Controls.Add(this.cartsListView);
            this.sharePanel.Controls.Add(this.progressButton);
            this.sharePanel.Controls.Add(this.progressSelected);
            this.sharePanel.Controls.Add(this.cartsButton);
            this.sharePanel.Controls.Add(this.cartsSelected);
            this.sharePanel.Controls.Add(this.progressListView);
            this.sharePanel.Location = new System.Drawing.Point(10, 195);
            this.sharePanel.Name = "sharePanel";
            this.sharePanel.Size = new System.Drawing.Size(545, 245);
            this.sharePanel.TabIndex = 10;
            this.sharePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sharePanel_MouseClick);
            // 
            // noCartLabel
            // 
            this.noCartLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.noCartLabel.AutoSize = true;
            this.noCartLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.noCartLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noCartLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.noCartLabel.Location = new System.Drawing.Point(66, 51);
            this.noCartLabel.Name = "noCartLabel";
            this.noCartLabel.Size = new System.Drawing.Size(87, 14);
            this.noCartLabel.TabIndex = 12;
            this.noCartLabel.Text = "No Cart Created";
            // 
            // detailPanel
            // 
            this.detailPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.detailPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(32)))), ((int)(((byte)(86)))));
            this.detailPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.detailPanel.Controls.Add(this.emptyCartLabel);
            this.detailPanel.Controls.Add(this.removeButton);
            this.detailPanel.Controls.Add(this.priceExtLabel);
            this.detailPanel.Controls.Add(this.priceLabel);
            this.detailPanel.Controls.Add(this.cartSizeExtLabel);
            this.detailPanel.Controls.Add(this.cartSizeLabel);
            this.detailPanel.Controls.Add(this.seriesExtLabel);
            this.detailPanel.Controls.Add(this.seriesLabel);
            this.detailPanel.Controls.Add(this.musicExtLabel);
            this.detailPanel.Controls.Add(this.musicLabel);
            this.detailPanel.Controls.Add(this.movieExtLabel);
            this.detailPanel.Controls.Add(this.movieLabel);
            this.detailPanel.Controls.Add(this.label1);
            this.detailPanel.Controls.Add(this.detailListView);
            this.detailPanel.Location = new System.Drawing.Point(232, 31);
            this.detailPanel.Name = "detailPanel";
            this.detailPanel.Size = new System.Drawing.Size(313, 214);
            this.detailPanel.TabIndex = 9;
            // 
            // emptyCartLabel
            // 
            this.emptyCartLabel.AutoSize = true;
            this.emptyCartLabel.BackColor = System.Drawing.Color.Transparent;
            this.emptyCartLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emptyCartLabel.ForeColor = System.Drawing.Color.Gray;
            this.emptyCartLabel.Location = new System.Drawing.Point(105, 34);
            this.emptyCartLabel.Name = "emptyCartLabel";
            this.emptyCartLabel.Size = new System.Drawing.Size(95, 15);
            this.emptyCartLabel.TabIndex = 16;
            this.emptyCartLabel.Text = "The cart is empty";
            this.emptyCartLabel.Visible = false;
            // 
            // priceExtLabel
            // 
            this.priceExtLabel.AutoSize = true;
            this.priceExtLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 13.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceExtLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.priceExtLabel.Location = new System.Drawing.Point(56, 166);
            this.priceExtLabel.Name = "priceExtLabel";
            this.priceExtLabel.Size = new System.Drawing.Size(21, 23);
            this.priceExtLabel.TabIndex = 10;
            this.priceExtLabel.Text = "0";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.Location = new System.Drawing.Point(4, 168);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(46, 20);
            this.priceLabel.TabIndex = 9;
            this.priceLabel.Text = "Price";
            // 
            // cartSizeExtLabel
            // 
            this.cartSizeExtLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartSizeExtLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.cartSizeExtLabel.Location = new System.Drawing.Point(85, 189);
            this.cartSizeExtLabel.MaximumSize = new System.Drawing.Size(100, 25);
            this.cartSizeExtLabel.Name = "cartSizeExtLabel";
            this.cartSizeExtLabel.Size = new System.Drawing.Size(100, 23);
            this.cartSizeExtLabel.TabIndex = 8;
            this.cartSizeExtLabel.Text = "0";
            // 
            // cartSizeLabel
            // 
            this.cartSizeLabel.AutoSize = true;
            this.cartSizeLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartSizeLabel.Location = new System.Drawing.Point(4, 191);
            this.cartSizeLabel.Name = "cartSizeLabel";
            this.cartSizeLabel.Size = new System.Drawing.Size(75, 20);
            this.cartSizeLabel.TabIndex = 7;
            this.cartSizeLabel.Text = "Cart Size";
            // 
            // seriesExtLabel
            // 
            this.seriesExtLabel.AutoSize = true;
            this.seriesExtLabel.BackColor = System.Drawing.Color.Transparent;
            this.seriesExtLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seriesExtLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.seriesExtLabel.Location = new System.Drawing.Point(262, 4);
            this.seriesExtLabel.Name = "seriesExtLabel";
            this.seriesExtLabel.Size = new System.Drawing.Size(0, 16);
            this.seriesExtLabel.TabIndex = 6;
            // 
            // seriesLabel
            // 
            this.seriesLabel.AutoSize = true;
            this.seriesLabel.BackColor = System.Drawing.Color.Transparent;
            this.seriesLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seriesLabel.Location = new System.Drawing.Point(219, 5);
            this.seriesLabel.Name = "seriesLabel";
            this.seriesLabel.Size = new System.Drawing.Size(37, 15);
            this.seriesLabel.TabIndex = 5;
            this.seriesLabel.Text = "Series";
            // 
            // musicExtLabel
            // 
            this.musicExtLabel.AutoSize = true;
            this.musicExtLabel.BackColor = System.Drawing.Color.Transparent;
            this.musicExtLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicExtLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.musicExtLabel.Location = new System.Drawing.Point(160, 4);
            this.musicExtLabel.Name = "musicExtLabel";
            this.musicExtLabel.Size = new System.Drawing.Size(0, 16);
            this.musicExtLabel.TabIndex = 4;
            // 
            // musicLabel
            // 
            this.musicLabel.AutoSize = true;
            this.musicLabel.BackColor = System.Drawing.Color.Transparent;
            this.musicLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicLabel.Location = new System.Drawing.Point(116, 5);
            this.musicLabel.Name = "musicLabel";
            this.musicLabel.Size = new System.Drawing.Size(39, 15);
            this.musicLabel.TabIndex = 3;
            this.musicLabel.Text = "Music";
            // 
            // movieExtLabel
            // 
            this.movieExtLabel.AutoSize = true;
            this.movieExtLabel.BackColor = System.Drawing.Color.Transparent;
            this.movieExtLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieExtLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.movieExtLabel.Location = new System.Drawing.Point(51, 4);
            this.movieExtLabel.Name = "movieExtLabel";
            this.movieExtLabel.Size = new System.Drawing.Size(0, 16);
            this.movieExtLabel.TabIndex = 2;
            // 
            // movieLabel
            // 
            this.movieLabel.AutoSize = true;
            this.movieLabel.BackColor = System.Drawing.Color.Transparent;
            this.movieLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieLabel.Location = new System.Drawing.Point(5, 5);
            this.movieLabel.Name = "movieLabel";
            this.movieLabel.Size = new System.Drawing.Size(40, 15);
            this.movieLabel.TabIndex = 1;
            this.movieLabel.Text = "Movie";
            // 
            // detailListView
            // 
            this.detailListView.BackColor = System.Drawing.Color.White;
            this.detailListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.detailListView.HideSelection = false;
            this.detailListView.LargeImageList = this.coverArtImageList;
            this.detailListView.Location = new System.Drawing.Point(2, 22);
            this.detailListView.Name = "detailListView";
            this.detailListView.ShowItemToolTips = true;
            this.detailListView.Size = new System.Drawing.Size(309, 122);
            this.detailListView.TabIndex = 13;
            this.detailListView.UseCompatibleStateImageBehavior = false;
            this.detailListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.detailListView_ItemSelectionChanged);
            // 
            // coverArtImageList
            // 
            this.coverArtImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("coverArtImageList.ImageStream")));
            this.coverArtImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.coverArtImageList.Images.SetKeyName(0, "20200624_141917.jpg");
            // 
            // transferCompNotifyIcon
            // 
            this.transferCompNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.transferCompNotifyIcon.BalloonTipTitle = "Transfer Completed";
            this.transferCompNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("transferCompNotifyIcon.Icon")));
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.FlatAppearance.BorderSize = 0;
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeButton.Font = new System.Drawing.Font("Microsoft JhengHei", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.ForeColor = System.Drawing.Color.Gray;
            this.removeButton.Image = ((System.Drawing.Image)(resources.GetObject("removeButton.Image")));
            this.removeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.removeButton.Location = new System.Drawing.Point(255, 150);
            this.removeButton.Name = "removeButton";
            this.removeButton.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.removeButton.Size = new System.Drawing.Size(55, 57);
            this.removeButton.TabIndex = 14;
            this.removeButton.Text = "Remove";
            this.removeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(0, 149);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(288, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "To remove unwanted item, select it and click the remove button.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressSelected
            // 
            this.progressSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(32)))), ((int)(((byte)(86)))));
            this.progressSelected.Location = new System.Drawing.Point(96, 0);
            this.progressSelected.Name = "progressSelected";
            this.progressSelected.Size = new System.Drawing.Size(90, 31);
            this.progressSelected.TabIndex = 7;
            this.progressSelected.TabStop = false;
            this.progressSelected.Visible = false;
            // 
            // cartsSelected
            // 
            this.cartsSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(32)))), ((int)(((byte)(86)))));
            this.cartsSelected.Location = new System.Drawing.Point(0, 0);
            this.cartsSelected.Name = "cartsSelected";
            this.cartsSelected.Size = new System.Drawing.Size(90, 31);
            this.cartsSelected.TabIndex = 6;
            this.cartsSelected.TabStop = false;
            // 
            // devicePanel
            // 
            this.devicePanel.BackgroundImage = global::Media_Distro.Properties.Resources.deviceList_BackGround_2;
            this.devicePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.devicePanel.Controls.Add(this.deviceLabel);
            this.devicePanel.Controls.Add(this.deviceList);
            this.devicePanel.Location = new System.Drawing.Point(10, 12);
            this.devicePanel.Name = "devicePanel";
            this.devicePanel.Size = new System.Drawing.Size(545, 177);
            this.devicePanel.TabIndex = 9;
            // 
            // deviceList
            // 
            this.deviceList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.deviceList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.deviceList.HideSelection = false;
            this.deviceList.LargeImageList = this.shareImageList;
            this.deviceList.Location = new System.Drawing.Point(12, 33);
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(521, 132);
            this.deviceList.TabIndex = 2;
            this.deviceList.UseCompatibleStateImageBehavior = false;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.progressLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.progressLabel.Location = new System.Drawing.Point(158, 65);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(229, 14);
            this.progressLabel.TabIndex = 17;
            this.progressLabel.Text = "There are currently no transfers in the queue.";
            this.progressLabel.Visible = false;
            // 
            // progressListView
            // 
            this.progressListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressListView.AutoScroll = true;
            this.progressListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.progressListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.progressListView.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressListView.Location = new System.Drawing.Point(0, 31);
            this.progressListView.Name = "progressListView";
            this.progressListView.Size = new System.Drawing.Size(545, 214);
            this.progressListView.TabIndex = 4;
            this.progressListView.Visible = false;
            // 
            // deviceLabel
            // 
            this.deviceLabel.AutoSize = true;
            this.deviceLabel.BackColor = System.Drawing.Color.Transparent;
            this.deviceLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deviceLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.deviceLabel.Location = new System.Drawing.Point(189, 46);
            this.deviceLabel.Name = "deviceLabel";
            this.deviceLabel.Size = new System.Drawing.Size(144, 14);
            this.deviceLabel.TabIndex = 18;
            this.deviceLabel.Text = "No USB Devices Connected";
            // 
            // ShareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(567, 452);
            this.Controls.Add(this.sharePanel);
            this.Controls.Add(this.devicePanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShareForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "shareForm";
            this.Leave += new System.EventHandler(this.ShareForm_Leave);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShareForm_MouseClick);
            this.cartsContextMenuStrip.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.sharePanel.ResumeLayout(false);
            this.sharePanel.PerformLayout();
            this.detailPanel.ResumeLayout(false);
            this.detailPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartsSelected)).EndInit();
            this.devicePanel.ResumeLayout(false);
            this.devicePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button progressButton;
        public System.Windows.Forms.Panel devicePanel;
        public System.Windows.Forms.Panel sharePanel;
        public System.Windows.Forms.ListView cartsListView;
        private System.Windows.Forms.ColumnHeader cartNameColumn;
        private System.Windows.Forms.Label cartSizeExtLabel;
        private System.Windows.Forms.Label cartSizeLabel;
        private System.Windows.Forms.Label seriesExtLabel;
        private System.Windows.Forms.Label seriesLabel;
        private System.Windows.Forms.Label musicExtLabel;
        private System.Windows.Forms.Label musicLabel;
        private System.Windows.Forms.Label movieExtLabel;
        private System.Windows.Forms.Label movieLabel;
        private System.Windows.Forms.Label priceExtLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label attentionLabel;
        public System.Windows.Forms.ListView deviceList;
        private System.Windows.Forms.ContextMenuStrip cartsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem clearCartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCartToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem sendToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        public Media_Distro.ProgressListView progressListView;
        public System.Windows.Forms.Label noCartLabel;
        public System.Windows.Forms.NotifyIcon transferCompNotifyIcon;
        public System.Windows.Forms.PictureBox cartsSelected;
        public System.Windows.Forms.Button cartsButton;
        public System.Windows.Forms.PictureBox progressSelected;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ImageList shareImageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList coverArtImageList;
        public System.Windows.Forms.Panel detailPanel;
        public System.Windows.Forms.ListView detailListView;
        private System.Windows.Forms.Label emptyCartLabel;
        public System.Windows.Forms.Label progressLabel;
        public System.Windows.Forms.Label deviceLabel;
    }
}