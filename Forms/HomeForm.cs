using System;
using System.IO;
using System.IO.Compression;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using Mobile_Service_Distribution.Managers;
using static Mobile_Service_Distribution.mediaDistroFrame;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace Mobile_Service_Distribution.Forms
{
    public partial class HomeForm : Form
    {
        public PieSeries taskCompleted;
        public PieSeries onGoingTask;
        public PieSeries pausedTasks;

        private static string adFolder = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Ads");
        private mediaDistroFrame reference;
        public Button addToCartButton = new Button {
            Size = new Size(116, 30),
            FlatStyle = FlatStyle.Flat,
            BackColor = (Media_Distro.Properties.Settings.Default.Active_Theme_Preference == Media_Distro.Properties.Settings.Default.Dark_Theme_Preference) 
                        ? Media_Distro.Properties.Settings.Default.Dark_Theme_SearchBar : Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar,
            Text = "Add to Cart",
            ForeColor = SystemColors.InactiveCaption
        };
        DateTime checkDate;

        public HomeForm(mediaDistroFrame reference)
        {
            InitializeComponent();

            popularNowPanel.HorizontalScroll.SmallChange = 130;

            this.reference = reference;

            addToCartButton.Click += new EventHandler(addToCartButton_Click);
            addToCartButton.MouseLeave += new EventHandler(addToCartButton_MouseLeave);
            addToCartButton.FlatAppearance.BorderSize = 0;

            taskPieChart.InnerRadius = 20; 
            taskPieChart.LegendLocation = LegendLocation.Right;
            taskPieChart.Font = new Font("Microsoft JhengHei", 8.25f);

            tempPieChart.InnerRadius = 30;
            tempPieChart.LegendLocation = LegendLocation.Right;
            tempPieChart.Series.Add(new PieSeries { Title = "No Tasks", Values = new ChartValues<int> { 1 }, Fill = System.Windows.Media.Brushes.LightGray });
            tempPieChart.Enabled = false;
            tempPieChart.Font = new Font("Microsoft JhengHei", 8.25f);

            taskCompleted = new PieSeries { Title = "Task Completed" };
            onGoingTask = new PieSeries { Title = "Tasks On-Going" };
            pausedTasks = new PieSeries { Title = "Paused Tasks" };

            taskCompleted.Values = new ChartValues<int> { 0 };
            onGoingTask.Values = new ChartValues<int> { 0 };
            pausedTasks.Values = new ChartValues<int> { 0 };

            taskPieChart.Series.Add(taskCompleted);
            taskPieChart.Series.Add(onGoingTask);
            taskPieChart.Series.Add(pausedTasks);

            dashBoardPanel.Refresh();

            foreach (string adDir in GetDirectories(adFolder))
            {
                checkDate = DateTime.Parse(File.ReadAllLines(Combine(adDir, "Date Info.txt"))[0]);

                if (checkDate.Month != DateTime.Now.Month)
                    if (DateTime.Now.DayOfYear - checkDate.DayOfYear > 30)
                        Delete(adDir, true);
            }
        }

        private void PRSItem_MouseEnter(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;

            addToCartButton.Visible = true;
            addToCartButton.Location = new Point(box.Location.X, 148);
            addToCartButton.Tag = box.Tag;
            popularNowPanel.Controls.Add(addToCartButton);
        }

        private void popularNowPanel_MouseLeave(object sender, EventArgs e)
        {
            popularNowPanel.Controls.Remove(addToCartButton);
        }

        public void addToCartButton_Click(object sender, EventArgs e)
        {
            CartManager cart;
            LibraryManager media;

            try
            {
                if (reference.customers == 0) throw new Exception();
                else
                {
                    cart = (CartManager)reference.cartLabel.Tag;

                    media = (LibraryManager)addToCartButton.Tag;

                    if (!cart.ContainsMedia(media))
                        cart.AddMedia(media);
                }
            }
            catch (Exception)
            {
                DialogResult result = MessageBox.Show("There are currently no active carts available. Click OK to add to a cart.", "Empty Slot", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    reference.newCartToolStripButton.PerformClick();
                    addToCartButton.PerformClick();
                }
            }
        }

        public void addToCartButton_MouseLeave(object sender, EventArgs e)
        {
            addToCartButton.Visible = false;
        }

        private void goLeftButton_Click(object sender, EventArgs e)
        {
            int value = popularNowPanel.HorizontalScroll.Value;

            for (int i = 0; i < 2; i++)
            {
                if (value > popularNowPanel.HorizontalScroll.Minimum)
                        popularNowPanel.HorizontalScroll.Value = (value > 130) ? value - 130 : popularNowPanel.HorizontalScroll.Minimum;
            }

            popularNowPanel.Focus();
        }

        private void goRightButton_Click(object sender, EventArgs e)
        {
            if (popularNowPanel.HorizontalScroll.Value < popularNowPanel.HorizontalScroll.Maximum)            
            {
                for (int i = 0; i < 2; i++)
                    popularNowPanel.HorizontalScroll.Value += 130;
            }

            popularNowPanel.Focus();
        }

        private void dashBoardPanel_Paint(object sender, PaintEventArgs e)
        {
            float totalSize = 0, availableSize = 0, driveSize, driveFreeSpace, i = 370, initial = 352, iter = 0;

            Brush[] brushes = new Brush[] { Brushes.DodgerBlue, Brushes.Firebrick, Brushes.LimeGreen, Brushes.DarkOrchid, Brushes.DarkSlateGray };
            List<DriveInfo> hardDrives = new List<DriveInfo>();

            using (Graphics graphics = e.Graphics)
            {
                foreach (DriveInfo hardDrive in DriveInfo.GetDrives())
                {
                    if ((hardDrive.DriveType == DriveType.Fixed) && hardDrive.IsReady)
                    {
                        hardDrives.Add(hardDrive);

                        totalSize += hardDrive.TotalSize;
                        availableSize += hardDrive.TotalFreeSpace;
                    }
                }

                if (reference.sideMenuPanel.Width == 235)
                {
                    foreach (DriveInfo hardDrive in hardDrives)
                    {
                        driveFreeSpace = hardDrive.AvailableFreeSpace;
                        driveSize = hardDrive.TotalSize;

                        graphics.FillRectangle(brushes[(int)iter % 6], initial, 147, ((driveSize - driveFreeSpace) / driveSize) * ((totalSize - availableSize) / totalSize * 204), 14);
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        graphics.FillEllipse(brushes[(int)iter++ % 6], i, 175, 15, 15);
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                        graphics.DrawString(hardDrive.Name, new Font("Microsoft JhengHei", 10), Brushes.Black, new PointF(i + 20, 175));
                        graphics.DrawString(String.Format("{0:F2}", (driveSize - driveFreeSpace) / 1000000000), new Font("Microsoft JhengHei", 8), Brushes.Black, new PointF(initial + 4, 147));
                        i += 60;
                        initial += (driveSize - driveFreeSpace) / driveSize * ((totalSize - availableSize) / totalSize * 204);
                    }


                    graphics.DrawRectangle(Pens.Black, 350, 145, 207, 17);
                    graphics.DrawString("GB", new Font("Microsoft JhengHei", 7), Brushes.Black, new PointF(540, 148));
                }
                else
                {
                    initial += 184;
                    i += 184;

                    foreach (DriveInfo hardDrive in hardDrives)
                    {
                        driveFreeSpace = hardDrive.AvailableFreeSpace;
                        driveSize = hardDrive.TotalSize;

                        graphics.FillRectangle(brushes[(int)iter % 6], initial, 147, ((driveSize - driveFreeSpace) / driveSize) * ((totalSize - availableSize) / totalSize * 204), 14);
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        graphics.FillEllipse(brushes[(int)iter++ % 6], i, 175, 15, 15);
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                        graphics.DrawString(hardDrive.Name, new Font("Microsoft JhengHei", 10), Brushes.Black, new PointF(i + 20, 175));
                        graphics.DrawString(String.Format("{0:F2}", (driveSize - driveFreeSpace) / 1000000000), new Font("Microsoft JhengHei", 8), Brushes.Black, new PointF(initial + 4, 148));
                        i += 60;
                        initial += (driveSize - driveFreeSpace) / driveSize * ((totalSize - availableSize) / totalSize * 204);
                    }


                    graphics.DrawRectangle(Pens.Black, 534, 145, 207, 17);
                    graphics.DrawString("GB", new Font("Microsoft JhengHei", 7), Brushes.Black, new PointF(724, 148));
                }
            }
        }

        private void locateZipButton_Click(object sender, EventArgs e)
        {
            string zipPath;
            StreamWriter dateFile, verifyFile;
            OpenFileDialog zipFile = new OpenFileDialog
            {
                Title = "Locate Distro Package",
                Filter = "All Files (*.*)| *.*"
            };
            FolderBrowserDialog verifyKeyFileLocation;
            DialogResult result;

            try
            {
                if(File.Exists(Combine(GetCurrentDirectory(), "Verification File")))
                {
                    result = MessageBox.Show("Before you proceed first send the verfication file to the telegram bot.", "Verify Package", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    verifyKeyFileLocation = new FolderBrowserDialog();

                    if (result == DialogResult.OK)
                        if (verifyKeyFileLocation.ShowDialog() == DialogResult.OK)
                            File.Move(Combine(GetCurrentDirectory(), "Verification File"), Combine(verifyKeyFileLocation.SelectedPath, "Verification File"));
                }
                else
                {
                    if (zipFile.ShowDialog() == DialogResult.OK)
                    {
                        zipPath = zipFile.FileName;
                        foreach (string adDir in GetDirectories(adFolder))
                            Delete(adDir, true);

                        ZipFile.ExtractToDirectory(zipPath, adFolder);

                        foreach (string adDir in GetDirectories(adFolder))
                        {
                            dateFile = File.CreateText(Combine(adDir, "Date Info.txt"));
                            dateFile.WriteLine(DateTime.Now.ToString());
                            dateFile.Close();
                        }

                        verifyKeyFileLocation = new FolderBrowserDialog();
                        result = MessageBox.Show("ZIP File Located. To proceed, send this key file into the telegram bot for verificatiion. Click OK to copy the file to your desired location.", "Distro Package Received", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        verifyFile = File.CreateText(Combine(GetCurrentDirectory(), "Verification File"));
                        verifyFile.WriteLine(GenerateKeyAlgorithm());
                        verifyFile.Close();

                        if (result == DialogResult.OK)
                            if (verifyKeyFileLocation.ShowDialog() == DialogResult.OK)
                                File.Move(Combine(GetCurrentDirectory(), "Verification File"), Combine(verifyKeyFileLocation.SelectedPath, "Verification File"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
        }
    }
}
