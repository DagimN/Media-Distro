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
using LiveCharts;
using LiveCharts.Wpf;

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

        public ProgressListView()
        {
            InitializeComponent();
            Items = new List<ProgressListViewItem>();
        }

        public void Add(CartManager cart, string customer, DriveInfo destination)
        {
            ProgressListViewItem newItem = new ProgressListViewItem(this, cart ,customer, destination.RootDirectory.ToString(), destination.VolumeLabel);
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

                    closeButton = new Button();
                    itemViewPanel.Controls.Add(closeButton);
                    closeButton.Location = new Point(160, 0);
                    closeButton.Size = new Size(27, 23);
                    closeButton.FlatStyle = FlatStyle.Flat;
                    closeButton.FlatAppearance.BorderSize = 0;
                    closeButton.BackColor = Color.FromArgb(235, 235, 235);
                    closeButton.FlatAppearance.MouseOverBackColor = Color.DodgerBlue;
                    closeButton.Image = Media_Distro.Properties.Resources.Close_2_Icon;
                    closeButton.ImageAlign = ContentAlignment.MiddleCenter;
                    closeButton.Click += new EventHandler(closeButton_Click);

                    startButton = new Button();
                    itemViewPanel.Controls.Add(startButton);
                    startButton.Location = new Point(45, 170);
                    startButton.Size = new Size(27, 23);
                    startButton.FlatStyle = FlatStyle.Flat;
                    startButton.FlatAppearance.BorderSize = 0;
                    startButton.BackColor = Color.FromArgb(235, 235, 235);
                    startButton.Image = Media_Distro.Properties.Resources.Play_Icon;
                    startButton.ImageAlign = ContentAlignment.MiddleCenter;
                    startButton.Click += new EventHandler(startButton_Click);
                    startButton.Enabled = false;

                    stopButton = new Button();
                    itemViewPanel.Controls.Add(stopButton);
                    stopButton.Location = new Point(111, 170);
                    stopButton.Size = new Size(27, 23);
                    stopButton.FlatStyle = FlatStyle.Flat;
                    stopButton.FlatAppearance.BorderSize = 0;
                    stopButton.BackColor = Color.FromArgb(235, 235, 235);
                    stopButton.Image = Media_Distro.Properties.Resources.Stop_Icon;
                    stopButton.ImageAlign = ContentAlignment.MiddleCenter;
                    stopButton.Padding = new Padding(0, 0, 2, 0);
                    stopButton.Click += new EventHandler(stopButton_Click);

                    pauseButton = new Button();
                    itemViewPanel.Controls.Add(pauseButton);
                    pauseButton.Location = new Point(78, 170);
                    pauseButton.Size = new Size(27, 23);
                    pauseButton.FlatStyle = FlatStyle.Flat;
                    pauseButton.FlatAppearance.BorderSize = 0;
                    pauseButton.BackColor = Color.FromArgb(235, 235, 235);
                    pauseButton.Image = Media_Distro.Properties.Resources.Pause_Icon;
                    pauseButton.ImageAlign = ContentAlignment.MiddleCenter;
                    pauseButton.Click += new EventHandler(pauseButton_Click);

                    progressGauge = new SolidGauge();
                    progressGauge.Location = new Point(45, 14);
                    progressGauge.Size = new Size(99, 99);
                    progressGauge.TabIndex = 0;
                    progressGauge.BackColor = Color.Transparent;
                    progressGauge.Uses360Mode = true;
                    progressGauge.To = 100;
                    progressGauge.InnerRadius = 45;
                    progressGauge.SendToBack();
                    itemViewPanel.Controls.Add(progressGauge);

                    progressLabel = new Label();
                    itemViewPanel.Controls.Add(progressLabel);
                    progressLabel.Location = new Point(5, 120);
                    progressLabel.Text = "Copying to " + volumeLabel + " " + destination;
                    progressLabel.Font = new Font("Microsoft JhengHei", 7.5F);
                    progressLabel.Size = new Size(157, 50);
                    progressLabel.ForeColor = Color.DarkGray;
                    progressLabel.SendToBack();

                    customerLabel = new Label();
                    itemViewPanel.Controls.Add(customerLabel);
                    customerLabel.Location = new Point(3, 3);
                    customerLabel.Text = customer;
                    customerLabel.Font = new Font("Microsoft JhengHei", 7, FontStyle.Bold);
                    customerLabel.ForeColor = Color.SlateGray;

                    this.Tag = cart;
                    itemViewPanel.ResumeLayout(false);

                    this.list.Controls.Add(itemViewPanel);
                    this.list.Items.Add(this);
                    Task copyTask = new Task(() => StartCopy(cart, destination));
                    copyTask.Start();
                }
                

            }

            public void Copy(FileStream source, string dest)
            {
                const int final = 10 * 1024 * 1024;
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
                            this.progressLabel.Invoke((MethodInvoker)delegate { progressLabel.Text = null; });
                            destination.Close();
                            this.stopped = true;
                            this.paused = false;
                            this.started = false;
                            this.stopButton.Invoke((MethodInvoker)delegate { stopButton.Enabled = false; });
                            this.pauseButton.Invoke((MethodInvoker)delegate { pauseButton.Enabled = false; });
                            MessageBox.Show("Copy Interrupted: " + ex.Message);
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
                        File.Delete(destination.Name);
                        this.progressLabel.Invoke((MethodInvoker)delegate { progressLabel.Text = "Stopped"; });
                        break;
                    }
                }
            }

            public void StartCopy(CartManager cart, string destination)
            {
                LibraryManager[] medias = cart.ShowList();
                totalSSize = cart.cartSize;

                if(onGoing == 0)
                {
                    pieChart.Invoke((MethodInvoker)delegate { pieChart.tempPieChart.Visible = false; });
                    pieChart.Invoke((MethodInvoker)delegate { pieChart.onGoingTask.Values = new ChartValues<int> { ++onGoing }; });
                }
                
                foreach(LibraryManager media in medias)
                {
                    currentMedia = media.Title;
                    this.progressLabel.Invoke((MethodInvoker)delegate { progressLabel.Text = "Copying - " + media.Title; });

                    if(media.Type == LibraryManager.MediaType.Movie)
                    {
                        if (!File.Exists(Combine(destination, GetFileName(media.OriginalDirectory))))
                            Copy(new FileStream(media.OriginalDirectory, FileMode.Open, FileAccess.Read), destination);
                        else
                        {
                            totalDSize += new FileStream(media.OriginalDirectory, FileMode.Open).Length;
                            this.progressGauge.Invoke((MethodInvoker)delegate { progressGauge.Value = (int)(totalDSize / totalSSize) * 100; });
                        }

                        media.PRS += 0.1f;
                    }
                    else if(media.Type == LibraryManager.MediaType.Music)
                    {
                        if (media.AlbumList == null)
                        {
                            string directory = Combine(destination, GetFileName(media.OriginalDirectory));

                            if (!File.Exists(directory))
                                Copy(new FileStream(media.OriginalDirectory, FileMode.Open, FileAccess.Read), destination);
                            else
                            {
                                totalDSize += new FileStream(media.OriginalDirectory, FileMode.Open).Length;
                                this.progressGauge.Invoke((MethodInvoker)delegate { progressGauge.Value = (int)(totalDSize / totalSSize) * 100; });
                            }

                            media.PRS += 0.1f;
                        }
                        else
                        {
                            string directory = Combine(destination, GetFileName(media.OriginalDirectory));

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

                                    media.PRS += 0.1f;
                                }
                            }

                            else
                            {
                                foreach(string dir in GetFiles(media.OriginalDirectory))
                                {
                                    totalDSize += new FileStream(dir, FileMode.Open).Length;
                                    media.PRS += 0.1f;
                                }
                                    
                                this.progressGauge.Invoke((MethodInvoker)delegate { progressGauge.Value = (int)(totalDSize / totalSSize) * 100; });
                            }
                        }
                    }
                    else 
                    {
                        if(media.SeriesList == null)
                        {
                            string directory = Combine(destination, GetFileName(File.ReadAllLines(media.thisDirectory)[8]));

                            if (!Exists(directory))
                            {
                                CreateDirectory(directory);
                                CreateDirectory(Combine(directory, GetFileName(media.OriginalDirectory)));
                                foreach (string dir in GetFiles(media.OriginalDirectory))
                                {
                                    Copy(new FileStream(dir, FileMode.Open, FileAccess.Read), Combine(directory, GetFileName(media.OriginalDirectory)));

                                    if (stopped)
                                    {
                                        Delete(directory, true);
                                        break;
                                    }

                                    media.PRS += 0.1f;
                                }
                            }
                            else if(Exists(directory))
                            {
                                foreach (string dir in GetFiles(media.OriginalDirectory))
                                {
                                    totalDSize += new FileStream(dir, FileMode.Open, FileAccess.Read).Length;
                                    media.PRS += 0.1f;
                                }
                                   
                                this.progressGauge.Invoke((MethodInvoker)delegate { progressGauge.Value = (int)(totalDSize / totalSSize) * 100; });
                            }
                            else if (!File.Exists(directory))
                            {
                                Copy(new FileStream(media.OriginalDirectory, FileMode.Open, FileAccess.Read), destination);
                                media.PRS += 0.1f;
                            }
                            else
                            { 
                                totalDSize += new FileStream(media.OriginalDirectory, FileMode.Open).Length;
                                media.PRS += 0.1f;

                                this.progressGauge.Invoke((MethodInvoker)delegate { progressGauge.Value = (int)(totalDSize / totalSSize) * 100; });
                            }
                        }
                        else
                        {
                            string directory = Combine(destination, GetFileName(media.OriginalDirectory));

                            if (!Exists(directory))
                            {
                                CreateDirectory(directory);
                                foreach(ArrayList seasons in media.SeriesList)
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

                                        media.PRS += 0.1f;
                                    }
                                }
                            }
                                
                            else
                            {
                                foreach(ArrayList seasons in media.SeriesList)
                                {
                                    for(int i = 1; i < seasons.Count; i++)
                                    {
                                        totalDSize += new FileStream(File.ReadAllLines((string)seasons[i])[6].Substring(11), FileMode.Open).Length;
                                        media.PRS += 0.1f;
                                    }
                                }

                                this.progressGauge.Invoke((MethodInvoker)delegate { progressGauge.Value = (int)(totalDSize / totalSSize) * 100; });
                            }
                        }   
                    }
                }

                this.progressLabel.Invoke((MethodInvoker)delegate { progressLabel.Text = "Finished"; });
                pieChart.Invoke((MethodInvoker)delegate
                {
                    pieChart.onGoingTask.Values = new ChartValues<int> { --onGoing };
                    pieChart.taskCompleted.Values = new ChartValues<int> { ++completed };
                });

                completedTasks.Invoke((MethodInvoker)delegate { completedTasks.completedTasks = completed; });
                completedTasks.Invoke((MethodInvoker)delegate { completedTasks.sharesubMenu.Refresh(); });
                

                if (list.showNotification && !stopped)
                {
                    notifyComp.transferCompNotifyIcon.Visible = true;
                    notifyComp.transferCompNotifyIcon.BalloonTipText = this.customerLabel.Text + "'s cart transfer completed successfully. ";
                    notifyComp.transferCompNotifyIcon.ShowBalloonTip(5);
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

                if (!stopped)
                {
                    File.AppendAllLines(statsFileURL, new string[] {$"Date Time: {System.DateTime.Now.ToString()}",
                                                                String.Format("Value: {0:F}", (totalSSize / (1024 * 1024 * 1024))),
                                                                $"Movie Sent: {cart.movieNum}",
                                                                $"Music Sent: {cart.musicNum}",
                                                                $"Series Sent: {cart.seriesNum}",
                                                                $"Price of Cart: {cart.cartPrice}",
                                                                " "});
                }


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
                foreach(ProgressListViewItem item in this.list.Items)
                {
                    if(this.itemViewPanel.Location.X < item.itemViewPanel.Location.X)
                    {
                        int x = item.itemViewPanel.Location.X - 187;
                        item.itemViewPanel.Location = new Point(x, item.Location.Y);
                    }
                    
                }
                this.list.Controls.Remove(this.itemViewPanel);
                this.list.Items.Remove(this);
                this.list.Focus();

                pieChart.taskCompleted.Values = new ChartValues<int> { --completed };
                completedTasks.completedTasks = completed;
                completedTasks.sharesubMenu.Refresh();
                if (completed == 0) pieChart.tempPieChart.Visible = true;
            }

        }
    }
}
