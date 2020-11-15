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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
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
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.cartPaidExt.Location = new System.Drawing.Point(140, 423);
            this.cartPaidExt.Name = "cartPaidExt";
            this.cartPaidExt.Size = new System.Drawing.Size(0, 13);
            this.cartPaidExt.TabIndex = 19;
            // 
            // cartDateExt
            // 
            this.cartDateExt.AutoSize = true;
            this.cartDateExt.Location = new System.Drawing.Point(80, 397);
            this.cartDateExt.Name = "cartDateExt";
            this.cartDateExt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cartDateExt.Size = new System.Drawing.Size(0, 13);
            this.cartDateExt.TabIndex = 18;
            // 
            // cartSeriesExt
            // 
            this.cartSeriesExt.AutoSize = true;
            this.cartSeriesExt.Location = new System.Drawing.Point(139, 371);
            this.cartSeriesExt.Name = "cartSeriesExt";
            this.cartSeriesExt.Size = new System.Drawing.Size(0, 13);
            this.cartSeriesExt.TabIndex = 17;
            // 
            // cartMusicExt
            // 
            this.cartMusicExt.AutoSize = true;
            this.cartMusicExt.Location = new System.Drawing.Point(139, 345);
            this.cartMusicExt.Name = "cartMusicExt";
            this.cartMusicExt.Size = new System.Drawing.Size(0, 13);
            this.cartMusicExt.TabIndex = 16;
            // 
            // cartMoviesExt
            // 
            this.cartMoviesExt.AutoSize = true;
            this.cartMoviesExt.Location = new System.Drawing.Point(139, 319);
            this.cartMoviesExt.Name = "cartMoviesExt";
            this.cartMoviesExt.Size = new System.Drawing.Size(0, 13);
            this.cartMoviesExt.TabIndex = 15;
            // 
            // cartPaidLabel
            // 
            this.cartPaidLabel.AutoSize = true;
            this.cartPaidLabel.Location = new System.Drawing.Point(25, 420);
            this.cartPaidLabel.Name = "cartPaidLabel";
            this.cartPaidLabel.Size = new System.Drawing.Size(28, 13);
            this.cartPaidLabel.TabIndex = 14;
            this.cartPaidLabel.Text = "Paid";
            // 
            // cartSentDateLabel
            // 
            this.cartSentDateLabel.Location = new System.Drawing.Point(26, 385);
            this.cartSentDateLabel.Name = "cartSentDateLabel";
            this.cartSentDateLabel.Size = new System.Drawing.Size(154, 26);
            this.cartSentDateLabel.TabIndex = 13;
            this.cartSentDateLabel.Text = "Date Sent";
            // 
            // cartSeriesLabel
            // 
            this.cartSeriesLabel.AutoSize = true;
            this.cartSeriesLabel.Location = new System.Drawing.Point(25, 363);
            this.cartSeriesLabel.Name = "cartSeriesLabel";
            this.cartSeriesLabel.Size = new System.Drawing.Size(36, 13);
            this.cartSeriesLabel.TabIndex = 12;
            this.cartSeriesLabel.Text = "Series";
            // 
            // cartMusicLabel
            // 
            this.cartMusicLabel.AutoSize = true;
            this.cartMusicLabel.Location = new System.Drawing.Point(25, 341);
            this.cartMusicLabel.Name = "cartMusicLabel";
            this.cartMusicLabel.Size = new System.Drawing.Size(35, 13);
            this.cartMusicLabel.TabIndex = 11;
            this.cartMusicLabel.Text = "Music";
            // 
            // cartMovieLabel
            // 
            this.cartMovieLabel.AutoSize = true;
            this.cartMovieLabel.Location = new System.Drawing.Point(25, 319);
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
            this.cartSentLabel.Location = new System.Drawing.Point(14, 265);
            this.cartSentLabel.Name = "cartSentLabel";
            this.cartSentLabel.Size = new System.Drawing.Size(58, 15);
            this.cartSentLabel.TabIndex = 7;
            this.cartSentLabel.Text = "Carts Sent";
            // 
            // mediaSentLabel
            // 
            this.mediaSentLabel.AutoSize = true;
            this.mediaSentLabel.Font = new System.Drawing.Font("Microsoft JhengHei Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediaSentLabel.Location = new System.Drawing.Point(14, 237);
            this.mediaSentLabel.Name = "mediaSentLabel";
            this.mediaSentLabel.Size = new System.Drawing.Size(93, 15);
            this.mediaSentLabel.TabIndex = 6;
            this.mediaSentLabel.Text = "Total Media Sent ";
            // 
            // summaryPieChart
            // 
            this.summaryPieChart.Location = new System.Drawing.Point(17, 30);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(42, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 25);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
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
            this.comboBox1.Location = new System.Drawing.Point(259, 90);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(109, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = "Pick a month...";
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(310, 63);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(58, 21);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.Text = "Year...";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(78, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 15);
            this.button3.TabIndex = 10;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(78, 96);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 15);
            this.button4.TabIndex = 11;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(567, 452);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}