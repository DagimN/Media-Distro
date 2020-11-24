using System;
using System.IO;
using static System.IO.Path;
using static System.Environment;
using static Mobile_Service_Distribution.LibraryManager;
using Mobile_Service_Distribution.Managers;
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

        private mediaDistroFrame reference;
        private Button addToCartButton = new Button {
            Size = new Size(116, 30),
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.White
        };

        public HomeForm(mediaDistroFrame reference)
        {
            InitializeComponent();

            popularNowPanel.HorizontalScroll.SmallChange = 130;

            this.reference = reference;

            addToCartButton.Click += new EventHandler(addToCartButton_Click);

            int initial1 = 3;
            foreach (LibraryManager media in SortPRS())
            {
                PictureBox coverArtPictureBox = new PictureBox
                {
                    //Image = (media.CoverArtDirectory != "") ? Image.FromFile(media.CoverArtDirectory) : Image.FromFile(Combine(GetFolderPath(SpecialFolder.UserProfile), "Documents", "Euphoria Games", "Form Designs", "Sample Pictures", "20200624_141949.jpg")),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(116, 140),
                    Location = new Point(initial1, 10),
                    Tag = media
                };

                coverArtPictureBox.MouseEnter += new EventHandler(PRSItem_MouseEnter);

                initial1 += 121;

                popularNowPanel.Controls.Add(coverArtPictureBox);
            }

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

            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            float totalSize = 0, availableSize = 0, driveSize, driveFreeSpace, i = 370, initial = 352, iter = 0;
            Brush[] brushes = new Brush[] { Brushes.DodgerBlue, Brushes.Red };
            List<DriveInfo> hardDrives = new List<DriveInfo>();

            using (Graphics graphics = e.Graphics)
            {
                foreach(DriveInfo hardDrive in DriveInfo.GetDrives())
                {
                    if(hardDrive.DriveType == DriveType.Fixed && hardDrive.IsReady)
                    {
                        hardDrives.Add(hardDrive);

                        totalSize += hardDrive.TotalSize;
                        availableSize += hardDrive.AvailableFreeSpace;
                    }
                }

                if(reference.sideMenuPanel.Width == 235)
                {
                    foreach (DriveInfo hardDrive in hardDrives)
                    {
                        driveFreeSpace = hardDrive.AvailableFreeSpace;
                        driveSize = hardDrive.TotalSize;

                        graphics.FillRectangle(brushes[(int)iter], initial, 147, ((driveSize - driveFreeSpace) / driveSize) * ((totalSize - availableSize) / totalSize * 204), 14);
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        graphics.FillEllipse(brushes[(int)iter++], i, 175, 15, 15);
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                        graphics.DrawString(hardDrive.Name, new Font("Microsoft JhengHei", 10), Brushes.Black, new PointF(i + 20, 175));
                        graphics.DrawString(String.Format("{0:F2}", (driveSize - driveFreeSpace) / 1000000000), new Font("Microsoft JhengHei", 8), Brushes.Black, new PointF(initial + 4, 147));
                        i += 60;
                        initial = (driveSize - driveFreeSpace) / driveSize * ((totalSize - availableSize) / totalSize * 204);

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

                        graphics.FillRectangle(brushes[(int)iter], initial, 147, ((driveSize - driveFreeSpace) / driveSize) * ((totalSize - availableSize) / totalSize * 204), 14);
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        graphics.FillEllipse(brushes[(int)iter++], i, 175, 15, 15);
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
                        graphics.DrawString(hardDrive.Name, new Font("Microsoft JhengHei", 10), Brushes.Black, new PointF(i + 20, 175));
                        graphics.DrawString(String.Format("{0:F2}", (driveSize - driveFreeSpace) / 1000000000), new Font("Microsoft JhengHei", 8), Brushes.Black, new PointF(initial + 4, 148));
                        i += 60;
                        initial = (driveSize - driveFreeSpace) / driveSize * ((totalSize - availableSize) / totalSize * 204);

                    }


                    graphics.DrawRectangle(Pens.Black, 534, 145, 207, 17);
                    graphics.DrawString("GB", new Font("Microsoft JhengHei", 7), Brushes.Black, new PointF(724, 148));
                }
                
            }
        }

        private void PRSItem_MouseEnter(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;

            addToCartButton.Location = new Point(box.Location.X, 150);
            addToCartButton.Tag = box.Tag;
            popularNowPanel.Controls.Add(addToCartButton);
        }

        private void popularNowPanel_MouseLeave(object sender, EventArgs e)
        {
            popularNowPanel.Controls.Remove(addToCartButton);
        }

        private void addToCartButton_Click(object sender, EventArgs e)
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
    }
}
