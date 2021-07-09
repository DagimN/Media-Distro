using System;
using System.Collections.Generic;
using Mobile_Service_Distribution.Managers;
using System.IO;
using static System.IO.Path;
using static System.IO.Directory;
using static System.Environment;
using System.Threading;
using System.Collections;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts.WinForms;
using Mobile_Service_Distribution;
using static Mobile_Service_Distribution.Forms.StatsForm;
using static Mobile_Service_Distribution.LibraryManager;
using static Mobile_Service_Distribution.Managers.CartManager;
using Media_Distro.Managers;
using LiveCharts;

namespace Media_Distro
{
    public partial class ProgressListView : UserControl
    {
        public List<ProgressListViewItem> Items;
        public static Mobile_Service_Distribution.Forms.ShareForm notifyComp;
        public static Mobile_Service_Distribution.Forms.HomeForm pieChart;
        public static Mobile_Service_Distribution.Forms.StatsForm lineChart;
        public static Mobile_Service_Distribution.mediaDistroFrame completedTasks;
        public bool showNotification = true;
        private static string adFolder = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Ads");

        public ProgressListView()
        {
            InitializeComponent();
            Items = new List<ProgressListViewItem>();
        }

        public void Add(CartManager cart, string customer, DriveInfo destination)
        {
            ProgressListViewItem newItem = new ProgressListViewItem(this, cart ,customer, destination.RootDirectory.ToString(), destination.VolumeLabel);
            
            if (this.Items.Count > 0)
                notifyComp.progressLabel.Visible = false;
        }

        public void Link(Mobile_Service_Distribution.Forms.ShareForm form, Mobile_Service_Distribution.Forms.HomeForm pChart, Mobile_Service_Distribution.Forms.StatsForm lChart, Mobile_Service_Distribution.mediaDistroFrame cTasks)
        {
            notifyComp = form;
            pieChart = pChart;
            lineChart = lChart;
            completedTasks = cTasks;
        }

        public class ProgressListViewItem : Control
        {
            private Panel itemViewPanel;
            private Button closeButton;
            private Button startButton;
            private Button stopButton;
            private Button pauseButton;
            private Label progressLabel;
            public Label customerLabel;
            private Label amountOfMedia;
            private SolidGauge progressGauge;
            private ProgressListView list;
            private bool paused = false, stopped = false, started = true;
            private string dest;
            private static int onGoing = 0, completed = 0, pausedTasks = 0;
            private string currentMedia;
            private static string statsFileURL = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Stats Record.txt");
            private float totalDSize = 0, totalSSize = 0;

            public ProgressListViewItem(ProgressListView list, CartManager cart, string customer, string destination, string volumeLabel)
            {
                this.list = list;
                this.dest = destination; 
                bool exist = false;

                foreach(ProgressListViewItem item in this.list.Items)
                    if ((CartManager)item.Tag == cart && item.dest == destination) 
                        exist = true;

                if (!exist)
                {
                    itemViewPanel = new Panel();
                    if (list.Items.Count == 0)
                        itemViewPanel.Location = new Point(0, 0);
                    else
                        itemViewPanel.Location = new Point(list.Items.Count * 187, 0);
                    itemViewPanel.Size = new Size(187, 205);
                    itemViewPanel.SuspendLayout();

                    closeButton = new Button
                    {
                        Location = new Point(160, 0),
                        Size = new Size(27, 23),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.Transparent,
                        Image = Media_Distro.Properties.Resources.Close_2_Icon,
                        ImageAlign = ContentAlignment.MiddleCenter
                    };
                    itemViewPanel.Controls.Add(closeButton);
                    closeButton.FlatAppearance.BorderSize = 0;
                    closeButton.FlatAppearance.MouseOverBackColor = Color.Silver;
                    closeButton.Click += new EventHandler(closeButton_Click);

                    startButton = new Button
                    {
                        Location = new Point(45, 170),
                        Size = new Size(27, 23),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.Transparent,
                        Image = Media_Distro.Properties.Resources.Play_Icon,
                        ImageAlign = ContentAlignment.MiddleCenter,
                        Enabled = false
                    };
                    itemViewPanel.Controls.Add(startButton);
                    startButton.FlatAppearance.BorderSize = 0;
                    startButton.FlatAppearance.MouseOverBackColor = Color.Silver;
                    startButton.Click += new EventHandler(startButton_Click);

                    stopButton = new Button
                    {
                        Location = new Point(111, 170),
                        Size = new Size(27, 23),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.Transparent,
                        Image = Media_Distro.Properties.Resources.Stop_Icon,
                        ImageAlign = ContentAlignment.MiddleCenter,
                        Padding = new Padding(0, 0, 2, 0)
                    };
                    itemViewPanel.Controls.Add(stopButton);
                    stopButton.FlatAppearance.BorderSize = 0;
                    stopButton.FlatAppearance.MouseOverBackColor = Color.Silver;
                    stopButton.Click += new EventHandler(stopButton_Click);

                    pauseButton = new Button
                    {
                        Location = new Point(78, 170),
                        Size = new Size(27, 23),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.Transparent,
                        Image = Media_Distro.Properties.Resources.Pause_Icon,
                        ImageAlign = ContentAlignment.MiddleCenter
                    };
                    pauseButton.FlatAppearance.BorderSize = 0;
                    pauseButton.FlatAppearance.MouseOverBackColor = Color.Silver;
                    pauseButton.Click += new EventHandler(pauseButton_Click);
                    itemViewPanel.Controls.Add(pauseButton);

                    amountOfMedia = new Label
                    {
                        Text = "0/" + cart.cartList.Count,
                        Location = new Point(83, 35),
                        Font = new Font("Microsoft JhengHei", 8.25f),
                        ForeColor = Color.Black,
                        AutoSize = true
                    };
                    amountOfMedia.BringToFront();
                    itemViewPanel.Controls.Add(amountOfMedia);

                    progressGauge = new SolidGauge
                    {
                        Location = new Point(45, 20),
                        Size = new Size(99, 99),
                        TabIndex = 0,
                        BackColor = Color.Transparent,
                        Uses360Mode = true,
                        To = 100,
                        InnerRadius = 45
                    };
                    progressGauge.SendToBack();
                    itemViewPanel.Controls.Add(progressGauge);

                    progressLabel = new Label
                    {
                        Location = new Point(5, 120),
                        Text = "Copying to " + destination,
                        Font = new Font("Microsoft JhengHei", 7.5f),
                        Size = new Size(157, 50),
                        ForeColor = Color.DarkGray
                    };
                    itemViewPanel.Controls.Add(progressLabel);
                    progressLabel.SendToBack();

                    customerLabel = new Label
                    {
                        Location = new Point(3, 3),
                        Text = customer + " - " + volumeLabel + " " + destination,
                        Font = new Font("Microsoft JhengHei", 7, FontStyle.Bold),
                        ForeColor = Color.SlateGray,
                        AutoSize = true
                    };
                    itemViewPanel.Controls.Add(customerLabel);
                    customerLabel.SendToBack();

                    this.Tag = cart;
                    itemViewPanel.ResumeLayout(false);
                    this.list.Controls.Add(itemViewPanel);
                    this.list.Items.Add(this);

                    Task copyTask = new Task(() => StartCopy(cart, destination));
                    copyTask.Start();
                }
                else
                    MessageBox.Show("This cart is already in progress.", "Cart in Progress", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            public void Copy(FileStream source, string dest)
            {
                const int final = 7 * 1024 * 1024;
                FileStream destination = new FileStream(Combine(dest, GetFileName(source.Name)), FileMode.CreateNew, FileAccess.Write); ;
                float destSize = destination.Length;

                while (true)
                {
                    if (started)
                    {
                        byte[] buffer = new byte[final];
                        int bufferSize = source.Read(buffer, 0, final);

                        try
                        {
                            destination.Write(buffer, 0, bufferSize);
                        }
                        catch (Exception ex)
                        {
                            this.progressLabel.Invoke((MethodInvoker)delegate { progressLabel.Text = ex.Message; });
                            destination.Close();
                            this.stopped = true;
                            this.paused = false;
                            this.started = false;
                            this.stopButton.Invoke((MethodInvoker)delegate { stopButton.Enabled = false; });
                            this.pauseButton.Invoke((MethodInvoker)delegate { pauseButton.Enabled = false; });
                            MessageBox.Show("Copy Interrupted: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            break;
                        }
                       
                        destSize = destination.Length;
                        this.progressGauge.Invoke((MethodInvoker)delegate { progressGauge.Value = (int)((destSize + totalDSize) / totalSSize * 100); });

                        if (bufferSize == 0)
                        {
                            totalDSize += destSize;
                            this.progressGauge.Invoke((MethodInvoker)delegate { progressGauge.Value = (int)((totalDSize / totalSSize) * 100); });
                            destination.Close();

                            break;
                        }
                            
                        GC.Collect();
                    }

                    if (stopped)
                    {
                        destination.Close();
                        Delete(destination.Name.Remove(destination.Name.LastIndexOf("\\")), true);
                        this.progressLabel.Invoke((MethodInvoker)delegate { progressLabel.Text = "Stopped"; });
                        break;
                    }
                }
            }

            public void StartCopy(CartManager cart, string destination)
            {
                LibraryManager[] medias = cart.ShowList();
                ListViewItem removeItem = new ListViewItem();
                totalSSize = cart.cartSize;
                int iter = 0;
                string distroFolder = Combine(destination, "Your Media Files"), adName = "NULL";
                string[] ads = GetDirectories(adFolder);

                CreateDirectory(distroFolder);

                if(onGoing == 0)
                {
                    pieChart.Invoke((MethodInvoker)delegate { pieChart.tempPieChart.Visible = false; });
                    pieChart.Invoke((MethodInvoker)delegate { pieChart.onGoingTask.Values = new ChartValues<int> { ++onGoing }; });
                }
                
                foreach(LibraryManager media in medias)
                {
                    if (!stopped)
                    {
                        currentMedia = media.Title;
                        this.progressLabel.Invoke((MethodInvoker)delegate { progressLabel.Text = "Copying - " + media.Title; });

                        if (media.Type == LibraryManager.MediaType.Movie)
                        {
                            if (!File.Exists(Combine(distroFolder, GetFileName(media.OriginalDirectory))))
                            {
                                Copy(new FileStream(media.OriginalDirectory, FileMode.Open, FileAccess.Read), distroFolder);
                                media.PRS += 0.5f;
                                AppendMediaInfo(media.thisDirectory, media.PRS.ToString(), MediaProperty.PRS);
                            }
                            else
                            {
                                totalDSize += new FileStream(media.OriginalDirectory, FileMode.Open, FileAccess.Read).Length;
                                this.progressGauge.Invoke((MethodInvoker)delegate { progressGauge.Value = (int)(totalDSize / totalSSize) * 100; });
                            }
                        }
                        else if (media.Type == LibraryManager.MediaType.Music)
                        {
                            if (media.AlbumList == null)
                            {
                                string directory = Combine(distroFolder, GetFileName(media.OriginalDirectory));

                                if (!File.Exists(directory))
                                {
                                    Copy(new FileStream(media.OriginalDirectory, FileMode.Open, FileAccess.Read), distroFolder);
                                    media.PRS += 0.5f;
                                    AppendMediaInfo(media.thisDirectory, media.PRS.ToString(), MediaProperty.PRS);
                                }
                                else
                                {
                                    totalDSize += new FileStream(media.OriginalDirectory, FileMode.Open, FileAccess.Read).Length;
                                    this.progressGauge.Invoke((MethodInvoker)delegate { progressGauge.Value = (int)(totalDSize / totalSSize) * 100; });
                                }
                            }
                            else
                            {
                                string directory = Combine(distroFolder, GetFileName(media.OriginalDirectory));

                                if (!Exists(directory))
                                {
                                    CreateDirectory(directory);
                                    foreach (string dir in GetFiles(media.OriginalDirectory))
                                    {
                                        Copy(new FileStream(dir, FileMode.Open, FileAccess.Read), directory);

                                        if (stopped)
                                        {
                                            Delete(directory, true);
                                            break;
                                        }
                                    }

                                    media.PRS += 0.1f;
                                    AppendMediaInfo(media.thisDirectory, media.PRS.ToString(), MediaProperty.PRS);
                                }
                                else
                                {
                                    foreach (string dir in GetFiles(media.OriginalDirectory))
                                        totalDSize += new FileStream(dir, FileMode.Open, FileAccess.Read).Length;

                                    media.PRS += 0.5f;

                                    this.progressGauge.Invoke((MethodInvoker)delegate { progressGauge.Value = (int)(totalDSize / totalSSize) * 100; });
                                }
                            }
                        }
                        else
                        {
                            if (media.SeriesList == null)
                            {
                                string directory = Combine(distroFolder, GetFileName(File.ReadAllLines(media.thisDirectory)[6]));

                                if (GetExtension(directory) != "")
                                {
                                    if (!File.Exists(directory))
                                    {
                                        Copy(new FileStream(media.OriginalDirectory, FileMode.Open, FileAccess.Read), distroFolder);
                                        media.PRS += 0.5f;
                                        AppendMediaInfo(media.thisDirectory, media.PRS.ToString(), MediaProperty.PRS);
                                    }
                                    else
                                    {
                                        totalDSize += new FileStream(media.OriginalDirectory, FileMode.Open, FileAccess.Read).Length;
                                        this.progressGauge.Invoke((MethodInvoker)delegate { progressGauge.Value = (int)(totalDSize / totalSSize) * 100; });
                                    }
                                }
                                else
                                {
                                    if (!Exists(directory))
                                    {
                                        string rootDir = CreateDirectory((Combine(distroFolder, media.Title))).FullName;
                                        CreateDirectory(Combine(rootDir, GetFileName(media.OriginalDirectory)));

                                        foreach (string dir in GetFiles(media.OriginalDirectory))
                                        {
                                            Copy(new FileStream(dir, FileMode.Open, FileAccess.Read), Combine(rootDir, GetFileName(media.OriginalDirectory)));

                                            if (stopped)
                                            {
                                                Delete(directory, true);
                                                break;
                                            }
                                        }

                                        media.PRS += 0.5f;
                                        AppendMediaInfo(media.thisDirectory, media.PRS.ToString(), MediaProperty.PRS);
                                    }
                                    else
                                    {
                                        foreach (string dir in GetFiles(media.OriginalDirectory))
                                            totalDSize += new FileStream(dir, FileMode.Open, FileAccess.Read).Length;

                                        this.progressGauge.Invoke((MethodInvoker)delegate { progressGauge.Value = (int)(totalDSize / totalSSize) * 100; });
                                    }
                                }
                            }
                            else
                            {
                                string directory = Combine(distroFolder, GetFileName(media.OriginalDirectory));

                                if (!Exists(directory))
                                {
                                    CreateDirectory(directory);
                                    foreach (ArrayList seasons in media.SeriesList)
                                    {
                                        CreateDirectory(Combine(directory, GetFileNameWithoutExtension((string)seasons[0]).Substring(5)));

                                        for (int i = 1; i < seasons.Count; i++)
                                        {
                                            Copy(new FileStream(File.ReadAllLines((string)seasons[i])[6].Substring(11), FileMode.Open, FileAccess.Read), Combine(directory, GetFileNameWithoutExtension((string)seasons[0]).Substring(5)));

                                            if (stopped)
                                            {
                                                Delete(directory, true);
                                                break;
                                            }
                                        }

                                        media.PRS += 0.5f;
                                        AppendMediaInfo(media.thisDirectory, media.PRS.ToString(), MediaProperty.PRS);
                                    }
                                }

                                else
                                {
                                    foreach (ArrayList seasons in media.SeriesList)
                                    {
                                        for (int i = 1; i < seasons.Count; i++)
                                            totalDSize += new FileStream(File.ReadAllLines((string)seasons[i])[6].Substring(11), FileMode.Open, FileAccess.Read).Length;
                                    }

                                    this.progressGauge.Invoke((MethodInvoker)delegate { progressGauge.Value = (int)(totalDSize / totalSSize) * 100; });
                                }
                            }
                        }

                        this.amountOfMedia.Invoke((MethodInvoker)delegate { amountOfMedia.Text = ++iter + "/" + cart.cartList.Count; });
                    }
                    else
                        break;
                }

                carts.Remove(cart);
                foreach (ToolStripItem item in completedTasks.cartsToolStripSplitButton.DropDownItems)
                {
                    if (item.Tag == cart)
                    {
                        completedTasks.cartToolStrip.Invoke((MethodInvoker)delegate { completedTasks.cartsToolStripSplitButton.DropDownItems.Remove(item); });
                        break;
                    }
                }

                notifyComp.tasks--;
                completedTasks.customers--;
                if (completedTasks.cartLabel.Tag == cart) completedTasks.cartToolStrip.Invoke((MethodInvoker)delegate { completedTasks.cartLabel.Text = null; });
                notifyComp.sharePanel.Invoke((MethodInvoker)delegate { notifyComp.sharePanel.Refresh(); });
                    
                notifyComp.cartsListView.Invoke((MethodInvoker)delegate 
                { 
                    foreach (ListViewItem item in notifyComp.cartsListView.Items)
                        if (item.Tag == cart)
                            removeItem = item;

                    notifyComp.cartsListView.Items.Remove(removeItem);
                });

                if (completedTasks.cartsToolStripSplitButton.DropDownItems.Count == 0)
                {
                    completedTasks.Invoke((MethodInvoker)delegate { completedTasks.cartsToolStripSplitButton.ToolTipText = "No Carts"; });
                    if(notifyComp.cartsListView.Visible) notifyComp.noCartLabel.Invoke((MethodInvoker)delegate { notifyComp.noCartLabel.Visible = true; }); 
                }

                int p = notifyComp.iter - 1;
                for (int i = p; i > 0; i--)
                    notifyComp.detailListView.Invoke((MethodInvoker)delegate { notifyComp.detailListView.LargeImageList.Images.RemoveAt(i); });
                notifyComp.iter = 1;

                if (!stopped)
                {
                    if (ads.Length > 0)
                    {
                        while (true)
                        {
                            Random index = new Random();
                            int i = index.Next() % ads.Length;

                            if (!File.Exists(Combine(ads[i], "Ad Info.txt")))
                            {
                                foreach (string adFile in GetFiles(ads[i]))
                                {
                                    if (GetFileName(adFile) == "Ad Info.txt" || GetFileName(adFile) == "Date Info.txt")
                                        continue;

                                    if (!File.Exists(Combine(distroFolder, GetFileName(adFile))))
                                        File.Copy(adFile, Combine(distroFolder, GetFileName(adFile)));
                                }

                                adName = GetFileName(ads[i]);

                                File.CreateText(Combine(ads[i], "Ad Info.txt"));
                                break;
                            }
                            else
                            {
                                try
                                {
                                    File.Delete(Combine(ads[i], "Ad Info.txt"));
                                    i = index.Next() % ads.Length;
                                }
                                catch (Exception) { }
                            }
                        }
                    }

                    this.progressLabel.Invoke((MethodInvoker)delegate { progressLabel.Text = "Finished"; });

                    USBManager device;

                    if (USBManager.Exists(destination, out device))
                    {
                        if (device.Count < 3)
                        {
                            File.AppendAllLines(statsFileURL, new string[] {$"Date Time: {DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt")}",
                                                                String.Format("Value: {0:F}", (totalSSize / (1024 * 1024 * 1024))),
                                                                $"Movie Sent: {cart.movieNum}",
                                                                $"Music Sent: {cart.musicNum}",
                                                                $"Series Sent: {cart.seriesNum}",
                                                                $"Price of Cart: {cart.cartPrice}",
                                                                $"Ad: {adName}",
                                                                " "});

                            device.Count++;
                        }
                    }

                    pieChart.Invoke((MethodInvoker)delegate
                    {
                        pieChart.onGoingTask.Values = new ChartValues<int> { --onGoing };
                        pieChart.taskCompleted.Values = new ChartValues<int> { ++completed };
                    });

                    completedTasks.Invoke((MethodInvoker)delegate { completedTasks.completedTasks = completed; });
                    completedTasks.Invoke((MethodInvoker)delegate { completedTasks.sharesubMenu.Refresh(); });
                }
                    
                if (list.showNotification && !stopped)
                {
                    notifyComp.transferCompNotifyIcon.Visible = true;
                    notifyComp.transferCompNotifyIcon.BalloonTipText = this.customerLabel.Text + "'s cart transfer completed successfully. ";
                    notifyComp.transferCompNotifyIcon.ShowBalloonTip(5);
                    stopped = true;
                }

                lineChart.Invoke((MethodInvoker)delegate
                {
                    lineChart.cartSeries.Values.Add(new DateModel
                    {
                        DateTime = System.DateTime.Now,
                        Value = double.Parse(String.Format("{0:F}", totalSSize / (1024 * 1024 * 1024))),
                        MoSent = cart.movieNum,
                        MuSent = cart.musicNum,
                        SeSent = cart.seriesNum,
                        Price = (double)cart.cartPrice
                    }) ;

                    lineChart.priceSeries.Values.Add(new DateModel
                    {
                        DateTime = System.DateTime.Now,
                        Value = (double)cart.cartPrice
                    }) ;

                    lineChart.moviesSent += cart.movieNum;
                    lineChart.musicSent += cart.musicNum;
                    lineChart.seriesSent += cart.seriesNum;

                    lineChart.summaryPieChart.Series[0].Values = new ChartValues<int> { lineChart.moviesSent };
                    lineChart.summaryPieChart.Series[1].Values = new ChartValues<int> { lineChart.musicSent };
                    lineChart.summaryPieChart.Series[2].Values = new ChartValues<int> { lineChart.seriesSent };

                    lineChart.mediaSentLabel.Text = "Total No of Media Sent  " + (lineChart.moviesSent + lineChart.musicSent + lineChart.seriesSent);
                    lineChart.cartSentLabel.Text = "Carts Sent  " + ++lineChart.cartsSent;
                });

                this.stopButton.Invoke((MethodInvoker)delegate { stopButton.Enabled = false; });
                this.pauseButton.Invoke((MethodInvoker)delegate { pauseButton.Enabled = false; });

                GC.Collect();
            }

            private void startButton_Click(object sender, EventArgs e)
            {
                this.progressLabel.Text = "Copying - " + currentMedia;
                this.paused = false;
                this.started = true;
                this.progressGauge.FromColor = System.Windows.Media.Color.FromRgb(100, 180, 245);
                this.progressGauge.ToColor = System.Windows.Media.Color.FromRgb(21, 101, 191);
                startButton.Enabled = false;
                pieChart.pausedTasks.Values = new ChartValues<int> { --pausedTasks };
                this.itemViewPanel.Focus();
                
            }

            private void stopButton_Click(object sender, EventArgs e)
            {
                this.itemViewPanel.Focus();
                DialogResult result = MessageBox.Show("Are you sure you want stop? Stopping will delete the file and remove any progress.", "Stop Send", MessageBoxButtons.OKCancel, MessageBoxIcon.Information); ;
                if(result == DialogResult.OK)
                {
                    this.paused = false;
                    this.stopped = true;
                    this.started = false;
                    if (!paused) this.progressLabel.Text = "Stopping...";
                    else this.progressLabel.Text = "Stopped";
                    this.progressGauge.FromColor = System.Windows.Media.Color.FromRgb(255, 0, 0);
                    this.progressGauge.ToColor = System.Windows.Media.Color.FromRgb(255, 0, 0);
                    this.stopButton.Enabled = false;
                    this.pauseButton.Enabled = false;
                    this.startButton.Enabled = false;
                    pieChart.onGoingTask.Values = new ChartValues<int> { --onGoing };
                    if (onGoing == 0) pieChart.tempPieChart.Visible = true;
                }
            }

            private void pauseButton_Click(object sender, EventArgs e)
            {
                this.started = false;
                this.paused = true;
                this.progressGauge.ToColor = System.Windows.Media.Color.FromRgb(255, 255, 0);
                this.progressGauge.FromColor = System.Windows.Media.Color.FromRgb(255, 255, 0);
                startButton.Enabled = true;
                pieChart.pausedTasks.Values = new ChartValues<int> { ++pausedTasks };
                Thread.Sleep(2000);
                this.progressLabel.Text = "Paused";
                this.itemViewPanel.Focus();
            }

            private void closeButton_Click(object sender, EventArgs e)
            {
                itemViewPanel.Focus();

                try
                {
                    if (stopped)
                    {
                        foreach (ProgressListViewItem item in this.list.Items)
                        {
                            if (this.itemViewPanel.Location.X < item.itemViewPanel.Location.X)
                            {
                                int x = item.itemViewPanel.Location.X - 187;
                                item.itemViewPanel.Location = new Point(x, item.Location.Y);
                            }
                        }
                        this.list.Controls.Remove(this.itemViewPanel);
                        this.list.Items.Remove(this);
                        this.list.Focus();

                        completedTasks.completedTasks = --completed;
                        completedTasks.sharesubMenu.Refresh();
                        if (completed == 0) pieChart.tempPieChart.Visible = true;
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("There are media files currently being transferred. Do you want to stop this task?",
                            "Transfer in progress", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (result == DialogResult.Yes)
                        {
                            this.paused = false;
                            this.stopped = true;
                            this.started = false;
                            if (!paused) this.progressLabel.Text = "Stopping...";
                            else this.progressLabel.Text = "Stopped";
                            this.progressGauge.FromColor = System.Windows.Media.Color.FromRgb(255, 0, 0);
                            this.progressGauge.ToColor = System.Windows.Media.Color.FromRgb(255, 0, 0);
                            this.stopButton.Enabled = false;
                            this.pauseButton.Enabled = false;
                            this.startButton.Enabled = false;

                            foreach (ProgressListViewItem item in this.list.Items)
                            {
                                if (this.itemViewPanel.Location.X < item.itemViewPanel.Location.X)
                                {
                                    int x = item.itemViewPanel.Location.X - 187;
                                    item.itemViewPanel.Location = new Point(x, item.Location.Y);
                                }

                            }
                            this.list.Controls.Remove(this.itemViewPanel);
                            this.list.Items.Remove(this);
                            this.list.Focus();

                            pieChart.taskCompleted.Values = new ChartValues<int> { completed };
                            completedTasks.completedTasks = --completed;
                            completedTasks.sharesubMenu.Refresh();
                            if (completed == 0) pieChart.tempPieChart.Visible = true;

                            notifyComp.tasks--;
                            notifyComp.sharePanel.Refresh();
                        }
                    }
                }
                catch (Exception)
                {

                }


                if (list.Items.Count == 0)
                    notifyComp.progressLabel.Visible = true;
            }
        }
    }
}
