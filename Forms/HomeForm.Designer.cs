namespace Mobile_Service_Distribution.Forms
{
    partial class HomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeForm));
            this.taskPieChart = new LiveCharts.WinForms.PieChart();
            this.tempPieChart = new LiveCharts.WinForms.PieChart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.popularNowPanel = new System.Windows.Forms.Panel();
            this.adsPanel = new System.Windows.Forms.Panel();
            this.popularNowLabel = new System.Windows.Forms.Label();
            this.goLeftButton = new System.Windows.Forms.Button();
            this.goRightButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titleToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // taskPieChart
            // 
            this.taskPieChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.taskPieChart.Location = new System.Drawing.Point(360, 3);
            this.taskPieChart.Name = "taskPieChart";
            this.taskPieChart.Size = new System.Drawing.Size(200, 100);
            this.taskPieChart.TabIndex = 0;
            this.taskPieChart.Text = "pieChart1";
            // 
            // tempPieChart
            // 
            this.tempPieChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tempPieChart.Location = new System.Drawing.Point(360, 10);
            this.tempPieChart.Name = "tempPieChart";
            this.tempPieChart.Size = new System.Drawing.Size(200, 100);
            this.tempPieChart.TabIndex = 1;
            this.tempPieChart.Text = "pieChart2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.volumeLabel);
            this.panel1.Controls.Add(this.tempPieChart);
            this.panel1.Controls.Add(this.taskPieChart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 224);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // volumeLabel
            // 
            this.volumeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F);
            this.volumeLabel.Location = new System.Drawing.Point(424, 120);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(83, 15);
            this.volumeLabel.TabIndex = 3;
            this.volumeLabel.Text = "Volume Labels";
            // 
            // popularNowPanel
            // 
            this.popularNowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.popularNowPanel.AutoScroll = true;
            this.popularNowPanel.Location = new System.Drawing.Point(40, 257);
            this.popularNowPanel.Name = "popularNowPanel";
            this.popularNowPanel.Size = new System.Drawing.Size(347, 212);
            this.popularNowPanel.TabIndex = 3;
            this.popularNowPanel.MouseLeave += new System.EventHandler(this.popularNowPanel_MouseLeave);
            // 
            // adsPanel
            // 
            this.adsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.adsPanel.Location = new System.Drawing.Point(412, 230);
            this.adsPanel.Name = "adsPanel";
            this.adsPanel.Size = new System.Drawing.Size(143, 212);
            this.adsPanel.TabIndex = 4;
            // 
            // popularNowLabel
            // 
            this.popularNowLabel.AutoSize = true;
            this.popularNowLabel.Font = new System.Drawing.Font("Letter Gothic Std", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popularNowLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.popularNowLabel.Location = new System.Drawing.Point(47, 230);
            this.popularNowLabel.Name = "popularNowLabel";
            this.popularNowLabel.Size = new System.Drawing.Size(131, 24);
            this.popularNowLabel.TabIndex = 0;
            this.popularNowLabel.Text = "POPULAR NOW";
            this.popularNowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // goLeftButton
            // 
            this.goLeftButton.BackColor = System.Drawing.Color.Transparent;
            this.goLeftButton.FlatAppearance.BorderSize = 0;
            this.goLeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goLeftButton.Image = global::Media_Distro.Properties.Resources.Entypo_25c2_0__24;
            this.goLeftButton.Location = new System.Drawing.Point(21, 267);
            this.goLeftButton.Name = "goLeftButton";
            this.goLeftButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.goLeftButton.Size = new System.Drawing.Size(13, 140);
            this.goLeftButton.TabIndex = 2;
            this.goLeftButton.Text = "<";
            this.goLeftButton.UseVisualStyleBackColor = false;
            this.goLeftButton.Click += new System.EventHandler(this.goLeftButton_Click);
            this.goLeftButton.MouseEnter += new System.EventHandler(this.popularNowPanel_MouseLeave);
            // 
            // goRightButton
            // 
            this.goRightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goRightButton.BackColor = System.Drawing.Color.Transparent;
            this.goRightButton.FlatAppearance.BorderSize = 0;
            this.goRightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goRightButton.Image = global::Media_Distro.Properties.Resources.Entypo_25b8_0__24;
            this.goRightButton.Location = new System.Drawing.Point(393, 267);
            this.goRightButton.Name = "goRightButton";
            this.goRightButton.Size = new System.Drawing.Size(13, 140);
            this.goRightButton.TabIndex = 1;
            this.goRightButton.UseVisualStyleBackColor = false;
            this.goRightButton.Click += new System.EventHandler(this.goRightButton_Click);
            this.goRightButton.MouseEnter += new System.EventHandler(this.popularNowPanel_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 219);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(215)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(567, 452);
            this.Controls.Add(this.popularNowLabel);
            this.Controls.Add(this.goLeftButton);
            this.Controls.Add(this.adsPanel);
            this.Controls.Add(this.goRightButton);
            this.Controls.Add(this.popularNowPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "HomeForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public LiveCharts.WinForms.PieChart tempPieChart;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label popularNowLabel;
        public System.Windows.Forms.Panel popularNowPanel;
        public System.Windows.Forms.Panel adsPanel;
        public System.Windows.Forms.Button goRightButton;
        public LiveCharts.WinForms.PieChart taskPieChart;
        public System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button goLeftButton;
        private System.Windows.Forms.ToolTip titleToolTip;
    }
}