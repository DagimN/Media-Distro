namespace Mobile_Service_Distribution.Forms
{
    partial class StatsForm
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
            this.summaryChart = new LiveCharts.WinForms.CartesianChart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cartPaidExt = new System.Windows.Forms.Label();
            this.cartDateExt = new System.Windows.Forms.Label();
            this.cartSeriesExt = new System.Windows.Forms.Label();
            this.cartMusicExt = new System.Windows.Forms.Label();
            this.cartMoviesExt = new System.Windows.Forms.Label();
            this.cartPaidLabel = new System.Windows.Forms.Label();
            this.cartSentDateLabel = new System.Windows.Forms.Label();
            this.cartSeriesLabel = new System.Windows.Forms.Label();
            this.cartMusicLabel = new System.Windows.Forms.Label();
            this.cartMovieLabel = new System.Windows.Forms.Label();
            this.cartInfoLabel = new System.Windows.Forms.Label();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.cartSentLabel = new System.Windows.Forms.Label();
            this.mediaSentLabel = new System.Windows.Forms.Label();
            this.summaryPieChart = new LiveCharts.WinForms.PieChart();
            this.formTitle = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.zoomInButton1 = new Guna.UI2.WinForms.Guna2Button();
            this.zoomOutButton1 = new Guna.UI2.WinForms.Guna2Button();
            this.nxtButton = new Guna.UI2.WinForms.Guna2Button();
            this.previousButton = new Guna.UI2.WinForms.Guna2Button();
            this.resetChartButton = new Guna.UI2.WinForms.Guna2Button();
            this.mediaAmountChart = new LiveCharts.WinForms.CartesianChart();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // summaryChart
            // 
            this.summaryChart.Location = new System.Drawing.Point(12, 115);
            this.summaryChart.Name = "summaryChart";
            this.summaryChart.Size = new System.Drawing.Size(356, 314);
            this.summaryChart.TabIndex = 0;
            this.summaryChart.Text = "cartesianChart1";
            this.summaryChart.DataClick += new LiveCharts.Events.DataClickHandler(this.cartesianChart1_DataClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.mediaAmountChart);
            this.panel1.Controls.Add(this.cartPaidExt);
            this.panel1.Controls.Add(this.cartDateExt);
            this.panel1.Controls.Add(this.cartSeriesExt);
            this.panel1.Controls.Add(this.cartMusicExt);
            this.panel1.Controls.Add(this.cartMoviesExt);
            this.panel1.Controls.Add(this.cartPaidLabel);
            this.panel1.Controls.Add(this.cartSentDateLabel);
            this.panel1.Controls.Add(this.cartSeriesLabel);
            this.panel1.Controls.Add(this.cartMusicLabel);
            this.panel1.Controls.Add(this.cartMovieLabel);
            this.panel1.Controls.Add(this.cartInfoLabel);
            this.panel1.Controls.Add(this.detailsLabel);
            this.panel1.Controls.Add(this.cartSentLabel);
            this.panel1.Controls.Add(this.mediaSentLabel);
            this.panel1.Controls.Add(this.summaryPieChart);
            this.panel1.Location = new System.Drawing.Point(374, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 452);
            this.panel1.TabIndex = 1;
            // 
            // cartPaidExt
            // 
            this.cartPaidExt.AutoSize = true;
            this.cartPaidExt.Location = new System.Drawing.Point(145, 430);
            this.cartPaidExt.Name = "cartPaidExt";
            this.cartPaidExt.Size = new System.Drawing.Size(0, 13);
            this.cartPaidExt.TabIndex = 19;
            // 
            // cartDateExt
            // 
            this.cartDateExt.AutoSize = true;
            this.cartDateExt.Location = new System.Drawing.Point(100, 393);
            this.cartDateExt.Name = "cartDateExt";
            this.cartDateExt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cartDateExt.Size = new System.Drawing.Size(0, 13);
            this.cartDateExt.TabIndex = 18;
            // 
            // cartSeriesExt
            // 
            this.cartSeriesExt.AutoSize = true;
            this.cartSeriesExt.Location = new System.Drawing.Point(165, 367);
            this.cartSeriesExt.Name = "cartSeriesExt";
            this.cartSeriesExt.Size = new System.Drawing.Size(0, 13);
            this.cartSeriesExt.TabIndex = 17;
            // 
            // cartMusicExt
            // 
            this.cartMusicExt.AutoSize = true;
            this.cartMusicExt.Location = new System.Drawing.Point(165, 341);
            this.cartMusicExt.Name = "cartMusicExt";
            this.cartMusicExt.Size = new System.Drawing.Size(0, 13);
            this.cartMusicExt.TabIndex = 16;
            // 
            // cartMoviesExt
            // 
            this.cartMoviesExt.AutoSize = true;
            this.cartMoviesExt.Location = new System.Drawing.Point(165, 315);
            this.cartMoviesExt.Name = "cartMoviesExt";
            this.cartMoviesExt.Size = new System.Drawing.Size(0, 13);
            this.cartMoviesExt.TabIndex = 15;
            // 
            // cartPaidLabel
            // 
            this.cartPaidLabel.AutoSize = true;
            this.cartPaidLabel.Location = new System.Drawing.Point(6, 430);
            this.cartPaidLabel.Name = "cartPaidLabel";
            this.cartPaidLabel.Size = new System.Drawing.Size(28, 13);
            this.cartPaidLabel.TabIndex = 14;
            this.cartPaidLabel.Text = "Paid";
            // 
            // cartSentDateLabel
            // 
            this.cartSentDateLabel.AutoSize = true;
            this.cartSentDateLabel.Location = new System.Drawing.Point(6, 393);
            this.cartSentDateLabel.Name = "cartSentDateLabel";
            this.cartSentDateLabel.Size = new System.Drawing.Size(55, 13);
            this.cartSentDateLabel.TabIndex = 13;
            this.cartSentDateLabel.Text = "Date Sent";
            // 
            // cartSeriesLabel
            // 
            this.cartSeriesLabel.AutoSize = true;
            this.cartSeriesLabel.Location = new System.Drawing.Point(6, 367);
            this.cartSeriesLabel.Name = "cartSeriesLabel";
            this.cartSeriesLabel.Size = new System.Drawing.Size(36, 13);
            this.cartSeriesLabel.TabIndex = 12;
            this.cartSeriesLabel.Text = "Series";
            // 
            // cartMusicLabel
            // 
            this.cartMusicLabel.AutoSize = true;
            this.cartMusicLabel.Location = new System.Drawing.Point(6, 341);
            this.cartMusicLabel.Name = "cartMusicLabel";
            this.cartMusicLabel.Size = new System.Drawing.Size(35, 13);
            this.cartMusicLabel.TabIndex = 11;
            this.cartMusicLabel.Text = "Music";
            // 
            // cartMovieLabel
            // 
            this.cartMovieLabel.AutoSize = true;
            this.cartMovieLabel.Location = new System.Drawing.Point(6, 315);
            this.cartMovieLabel.Name = "cartMovieLabel";
            this.cartMovieLabel.Size = new System.Drawing.Size(41, 13);
            this.cartMovieLabel.TabIndex = 10;
            this.cartMovieLabel.Text = "Movies";
            // 
            // cartInfoLabel
            // 
            this.cartInfoLabel.AutoSize = true;
            this.cartInfoLabel.Location = new System.Drawing.Point(6, 293);
            this.cartInfoLabel.Name = "cartInfoLabel";
            this.cartInfoLabel.Size = new System.Drawing.Size(47, 13);
            this.cartInfoLabel.TabIndex = 9;
            this.cartInfoLabel.Text = "Cart Info";
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = true;
            this.detailsLabel.Font = new System.Drawing.Font("Microsoft JhengHei Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsLabel.Location = new System.Drawing.Point(6, 9);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(50, 18);
            this.detailsLabel.TabIndex = 8;
            this.detailsLabel.Text = "Details";
            // 
            // cartSentLabel
            // 
            this.cartSentLabel.AutoSize = true;
            this.cartSentLabel.Font = new System.Drawing.Font("Microsoft JhengHei Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartSentLabel.Location = new System.Drawing.Point(14, 55);
            this.cartSentLabel.Name = "cartSentLabel";
            this.cartSentLabel.Size = new System.Drawing.Size(58, 15);
            this.cartSentLabel.TabIndex = 7;
            this.cartSentLabel.Text = "Carts Sent";
            // 
            // mediaSentLabel
            // 
            this.mediaSentLabel.AutoSize = true;
            this.mediaSentLabel.Font = new System.Drawing.Font("Microsoft JhengHei Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediaSentLabel.Location = new System.Drawing.Point(14, 35);
            this.mediaSentLabel.Name = "mediaSentLabel";
            this.mediaSentLabel.Size = new System.Drawing.Size(93, 15);
            this.mediaSentLabel.TabIndex = 6;
            this.mediaSentLabel.Text = "Total Media Sent ";
            // 
            // summaryPieChart
            // 
            this.summaryPieChart.Location = new System.Drawing.Point(17, 88);
            this.summaryPieChart.Name = "summaryPieChart";
            this.summaryPieChart.Size = new System.Drawing.Size(164, 141);
            this.summaryPieChart.TabIndex = 4;
            this.summaryPieChart.Text = "pieChart1";
            // 
            // formTitle
            // 
            this.formTitle.AutoSize = true;
            this.formTitle.Font = new System.Drawing.Font("Microsoft JhengHei Light", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formTitle.Location = new System.Drawing.Point(13, 10);
            this.formTitle.Name = "formTitle";
            this.formTitle.Size = new System.Drawing.Size(166, 25);
            this.formTitle.TabIndex = 5;
            this.formTitle.Text = "Summary Report";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft JhengHei Light", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(27, 40);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(353, 35);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "This page helps you keep the record of the data and transactions necessary for th" +
    "e interface.";
            // 
            // monthComboBox
            // 
            this.monthComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June ",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.monthComboBox.Location = new System.Drawing.Point(209, 88);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(109, 21);
            this.monthComboBox.TabIndex = 8;
            this.monthComboBox.Text = "Pick a month";
            this.monthComboBox.TextChanged += new System.EventHandler(this.monthComboBox_TextChanged);
            // 
            // yearComboBox
            // 
            this.yearComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(318, 88);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(50, 21);
            this.yearComboBox.TabIndex = 9;
            // 
            // zoomInButton1
            // 
            this.zoomInButton1.AutoRoundedCorners = true;
            this.zoomInButton1.BorderRadius = 7;
            this.zoomInButton1.CheckedState.Parent = this.zoomInButton1;
            this.zoomInButton1.CustomImages.Parent = this.zoomInButton1;
            this.zoomInButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.zoomInButton1.ForeColor = System.Drawing.Color.White;
            this.zoomInButton1.HoverState.Parent = this.zoomInButton1;
            this.zoomInButton1.Location = new System.Drawing.Point(17, 80);
            this.zoomInButton1.Name = "zoomInButton1";
            this.zoomInButton1.ShadowDecoration.Parent = this.zoomInButton1;
            this.zoomInButton1.Size = new System.Drawing.Size(30, 17);
            this.zoomInButton1.TabIndex = 12;
            this.zoomInButton1.Text = "+";
            this.zoomInButton1.Click += new System.EventHandler(this.zoomInButton1_Click);
            // 
            // zoomOutButton1
            // 
            this.zoomOutButton1.AutoRoundedCorners = true;
            this.zoomOutButton1.BorderRadius = 7;
            this.zoomOutButton1.CheckedState.Parent = this.zoomOutButton1;
            this.zoomOutButton1.CustomImages.Parent = this.zoomOutButton1;
            this.zoomOutButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.zoomOutButton1.ForeColor = System.Drawing.Color.White;
            this.zoomOutButton1.HoverState.Parent = this.zoomOutButton1;
            this.zoomOutButton1.Location = new System.Drawing.Point(53, 80);
            this.zoomOutButton1.Name = "zoomOutButton1";
            this.zoomOutButton1.ShadowDecoration.Parent = this.zoomOutButton1;
            this.zoomOutButton1.Size = new System.Drawing.Size(30, 17);
            this.zoomOutButton1.TabIndex = 13;
            this.zoomOutButton1.Text = "-";
            this.zoomOutButton1.Click += new System.EventHandler(this.zoomOutButton1_Click);
            // 
            // nxtButton
            // 
            this.nxtButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nxtButton.AutoRoundedCorners = true;
            this.nxtButton.BorderRadius = 11;
            this.nxtButton.CheckedState.Parent = this.nxtButton;
            this.nxtButton.CustomImages.Parent = this.nxtButton;
            this.nxtButton.CustomizableEdges.BottomLeft = false;
            this.nxtButton.CustomizableEdges.TopLeft = false;
            this.nxtButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nxtButton.ForeColor = System.Drawing.Color.White;
            this.nxtButton.HoverState.Parent = this.nxtButton;
            this.nxtButton.Location = new System.Drawing.Point(343, 57);
            this.nxtButton.Name = "nxtButton";
            this.nxtButton.ShadowDecoration.Parent = this.nxtButton;
            this.nxtButton.Size = new System.Drawing.Size(25, 25);
            this.nxtButton.TabIndex = 14;
            this.nxtButton.Text = ">";
            this.nxtButton.Click += new System.EventHandler(this.nxtButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.previousButton.AutoRoundedCorners = true;
            this.previousButton.BorderRadius = 11;
            this.previousButton.CheckedState.Parent = this.previousButton;
            this.previousButton.CustomImages.Parent = this.previousButton;
            this.previousButton.CustomizableEdges.BottomRight = false;
            this.previousButton.CustomizableEdges.TopRight = false;
            this.previousButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.previousButton.ForeColor = System.Drawing.Color.White;
            this.previousButton.HoverState.Parent = this.previousButton;
            this.previousButton.Location = new System.Drawing.Point(312, 57);
            this.previousButton.Name = "previousButton";
            this.previousButton.ShadowDecoration.Parent = this.previousButton;
            this.previousButton.Size = new System.Drawing.Size(25, 25);
            this.previousButton.TabIndex = 15;
            this.previousButton.Text = "<";
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // resetChartButton
            // 
            this.resetChartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resetChartButton.AutoRoundedCorners = true;
            this.resetChartButton.BorderRadius = 13;
            this.resetChartButton.CheckedState.Parent = this.resetChartButton;
            this.resetChartButton.CustomImages.Parent = this.resetChartButton;
            this.resetChartButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.resetChartButton.ForeColor = System.Drawing.Color.White;
            this.resetChartButton.HoverState.Parent = this.resetChartButton;
            this.resetChartButton.Location = new System.Drawing.Point(276, 57);
            this.resetChartButton.Name = "resetChartButton";
            this.resetChartButton.ShadowDecoration.Parent = this.resetChartButton;
            this.resetChartButton.Size = new System.Drawing.Size(30, 28);
            this.resetChartButton.TabIndex = 16;
            this.resetChartButton.Text = "R";
            this.resetChartButton.Click += new System.EventHandler(this.resetChartButton_Click);
            // 
            // mediaAmountChart
            // 
            this.mediaAmountChart.Location = new System.Drawing.Point(0, 173);
            this.mediaAmountChart.Name = "mediaAmountChart";
            this.mediaAmountChart.Size = new System.Drawing.Size(193, 117);
            this.mediaAmountChart.TabIndex = 20;
            this.mediaAmountChart.Text = "cartesianChart1";
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(567, 452);
            this.Controls.Add(this.resetChartButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.nxtButton);
            this.Controls.Add(this.zoomOutButton1);
            this.Controls.Add(this.zoomInButton1);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.formTitle);
            this.Controls.Add(this.summaryChart);
            this.Controls.Add(this.descriptionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "statsForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public LiveCharts.WinForms.CartesianChart summaryChart;
        private System.Windows.Forms.Label formTitle;
        public LiveCharts.WinForms.PieChart summaryPieChart;
        public System.Windows.Forms.Label mediaSentLabel;
        public System.Windows.Forms.Label cartSentLabel;
        public System.Windows.Forms.Label detailsLabel;
        private System.Windows.Forms.Label cartPaidLabel;
        private System.Windows.Forms.Label cartSentDateLabel;
        private System.Windows.Forms.Label cartSeriesLabel;
        private System.Windows.Forms.Label cartMusicLabel;
        private System.Windows.Forms.Label cartMovieLabel;
        private System.Windows.Forms.Label cartInfoLabel;
        private System.Windows.Forms.Label cartPaidExt;
        private System.Windows.Forms.Label cartDateExt;
        private System.Windows.Forms.Label cartSeriesExt;
        private System.Windows.Forms.Label cartMusicExt;
        private System.Windows.Forms.Label cartMoviesExt;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.ComboBox yearComboBox;
        private Guna.UI2.WinForms.Guna2Button zoomInButton1;
        private Guna.UI2.WinForms.Guna2Button zoomOutButton1;
        private Guna.UI2.WinForms.Guna2Button nxtButton;
        private Guna.UI2.WinForms.Guna2Button previousButton;
        private Guna.UI2.WinForms.Guna2Button resetChartButton;
        private LiveCharts.WinForms.CartesianChart mediaAmountChart;
    }
}