using System;
using System.IO;
using System.IO.Compression;
using static System.IO.Path;
using static System.IO.Directory;
using static System.Environment;
using static Mobile_Service_Distribution.LibraryManager;
using Mobile_Service_Distribution.Managers;
using Media_Distro;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mobile_Service_Distribution.Forms;
using System.Reflection;
using LiveCharts;
using LiveCharts.Wpf;
using Guna.UI2.WinForms;
using System.Diagnostics;


namespace Mobile_Service_Distribution
{
    public partial class mediaDistroFrame : Form
    {
        private readonly FormWindowState state = FormWindowState.Normal;
        private Point startPoint = new Point(0, 0);
        private Task searchTask;
        public Task manageMediaTask;
        private Button activeButton;
        public ListViewItem activeItem = null;

        private bool IsExpired = false;
        private bool drag = false;
        public bool IsUpdating = false;
      
        private LibraryForm libraryForm;
        private HomeForm homeForm;
        private ShareForm shareForm;
        private StatsForm statsForm;
        private SettingsForm settingsForm;
        private Form activeForm = null;

        private static string mediaFolder = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro");
        private static string movieFolder = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Movies");
        private static string musicFolder = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Music");
        private static string seriesFolder = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Series");
        private static string statsFileURL = Combine(mediaFolder, "Stats Record.txt");
        private static string adFolder = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Ads");
        private static FileStream statsFile;

        public ArrayList movieDir = new ArrayList();
        public ArrayList musicDir = new ArrayList();
        public ArrayList seriesDir = new ArrayList();
        private ArrayList catalogues = new ArrayList(3);

        private const int WM_DEVICECHANGE = 0x219;
        private const int DBT_DEVICEARRIVAL = 0x8000;
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        public int customers = 0;
        public int completedTasks = 0;
      
        public mediaDistroFrame()
        {
            if (!Media_Distro.Properties.Settings.Default.fInitialize)
            {
                Media_Distro.Properties.Settings.Default.Movie_Media_Location = new System.Collections.Specialized.StringCollection();
                Media_Distro.Properties.Settings.Default.Music_Media_Location = new System.Collections.Specialized.StringCollection();
                Media_Distro.Properties.Settings.Default.Series_Media_Location = new System.Collections.Specialized.StringCollection();

                if (!Exists(mediaFolder)) CreateDirectory(mediaFolder).Attributes = FileAttributes.Hidden;
                if (!Exists(movieFolder)) CreateDirectory(movieFolder);
                if (!Exists(seriesFolder)) CreateDirectory(seriesFolder);
                if (!Exists(musicFolder)) CreateDirectory(musicFolder);
                if (!Exists(adFolder)) CreateDirectory(adFolder);
                if (!File.Exists(statsFileURL))
                {
                    statsFile = new FileStream(statsFileURL, FileMode.Create, FileAccess.ReadWrite);
                    statsFile.Close();
                }

                using (Form introForm = new Form())
                {
                    introForm.SuspendLayout();

                    //Labels

                    PictureBox logoLabel = new PictureBox
                    {
                        Location = new Point(9, 3),
                        Size = new Size(350, 60),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = Media_Distro.Properties.Resources.logo_1
                    };

                    Label descriptionLabel = new Label
                    {
                        Location = new Point(9, 83),
                        Text = "Fill in the corresponding media type's URL location. Choose the main folder where the media files are all located.",
                        Font = new Font("Microsoft JhengHei", 9),
                        Size = new Size(300, 15)
                    };

                    Label movieLabel = new Label
                    {
                        Location = new Point(30, 115),
                        Size = new Size(56, 21),
                        Text = "Movies",
                        Font = new Font("Microsoft JhengHei", 9)
                    };

                    Label musicLabel = new Label
                    {
                        Location = new Point(30, 152),
                        Size = new Size(56, 21),
                        Text = "Music",
                        Font = new Font("Microsoft JhengHei", 9)
                    };

                    Label seriesLabel = new Label
                    {
                        Location = new Point(30, 189),
                        Size = new Size(56, 21),
                        Text = "Series",
                        Font = new Font("Microsoft JhengHei", 9)
                    };

                    //TextBoxes

                    Guna2TextBox movieURL = new Guna2TextBox
                    {
                        Location = new Point(85, 97),
                        Size = new Size(250, 25),
                        Font = new Font("Microsoft JhengHei", 10),
                        ReadOnly = true,
                        BorderRadius = 12,
                        CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges
                        {
                            BottomLeft = true,
                            BottomRight = false,
                            TopLeft = true,
                            TopRight = false
                        }
                    };

                    Guna2TextBox musicURL = new Guna2TextBox
                    {
                        Location = new Point(85, 132),
                        Size = new Size(250, 25),
                        Font = new Font("Microsoft JhengHei", 10),
                        ReadOnly = true,
                        BorderRadius = 12,
                        CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges
                        {
                            BottomLeft = true,
                            BottomRight = false,
                            TopLeft = true,
                            TopRight = false
                        }
                    };

                    Guna2TextBox seriesURL = new Guna2TextBox
                    {
                        Location = new Point(85, 167),
                        Size = new Size(250, 25),
                        Font = new Font("Microsoft JhengHei", 10),
                        ReadOnly = true,
                        BorderRadius = 12,
                        CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges
                        {
                            BottomLeft = true,
                            BottomRight = false,
                            TopLeft = true,
                            TopRight = false
                        }
                    };

                    //Buttons

                    Guna2Button movieBrowseButton = new Guna2Button
                    {
                        Location = new Point(385, 113),
                        Size = new Size(70, 21),
                        Text = "Browse",
                        BorderRadius = 8,
                        CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges
                        {
                            BottomLeft = false,
                            BottomRight = true,
                            TopLeft = false,
                            TopRight = true
                        }
                    };
                    
                    Guna2Button musicBrowseButton = new Guna2Button
                    {
                        Location = new Point(385, 152),
                        Size = new Size(70, 21),
                        Text = "Browse",
                        BorderRadius = 8,
                        CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges
                        {
                            BottomLeft = false,
                            BottomRight = true,
                            TopLeft = false,
                            TopRight = true
                        }
                    };
                    
                    Guna2Button seriesBrowseButton = new Guna2Button
                    {
                        Location = new Point(385, 192),
                        Size = new Size(70, 20),
                        Text = "Browse",
                        BorderRadius = 8,
                        CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges
                        {
                            BottomLeft = false,
                            BottomRight = true,
                            TopLeft = false,
                            TopRight = true
                        }
                    };

                    Guna2Button continueButton = new Guna2Button
                    {
                        Location = new Point(541, 294),
                        Size = new Size(78, 23),
                        Text = "Continue",
                        Enabled = false,
                        AutoRoundedCorners = true,
                        BackColor = Color.FromArgb(20, 200, 254)
                    };

                    Guna2Button closeButton = new Guna2Button
                    {
                        Location = new Point(594, 0),
                        Size = new Size(36, 34),
                        Font = new Font("Microsoft Sans Serif", 18),
                        Text = "×"
                    };

                    //CheckBox

                    Guna2CheckBox musicSkipCheck = new Guna2CheckBox
                    {
                        Animated = true,
                        Text = "Skip",
                        Location = new Point(470, 154),
                        Appearance = Appearance.Normal,
                        AutoSize = true,
                        Font = new Font("Microsoft JhengHei", 9)
                    };
                    musicSkipCheck.UncheckedState.BorderColor = Color.Gray;
                    musicSkipCheck.UncheckedState.BorderRadius = 2;
                    musicSkipCheck.UncheckedState.BorderThickness = 1;
                    musicSkipCheck.UncheckedState.FillColor = Color.White;
                    musicSkipCheck.CheckedState.BorderRadius = 2;
                    musicSkipCheck.CheckedState.BorderThickness = 1;

                    Guna2CheckBox seriesSkipCheck = new Guna2CheckBox
                    {
                        Animated = true,
                        Text = "Skip",
                        Location = new Point(470, 194),
                        Appearance = Appearance.Normal,
                        AutoSize = true,
                        Font = new Font("Microsoft JhengHei", 9)
                    };
                    seriesSkipCheck.UncheckedState.BorderColor = Color.Gray;
                    seriesSkipCheck.UncheckedState.BorderRadius = 2;
                    seriesSkipCheck.UncheckedState.BorderThickness = 1;
                    seriesSkipCheck.UncheckedState.FillColor = Color.White;
                    seriesSkipCheck.CheckedState.BorderRadius = 2;
                    seriesSkipCheck.CheckedState.BorderThickness = 1;

                    movieBrowseButton.Click += browseButton_Click;
                    musicBrowseButton.Click += browseButton_Click;
                    seriesBrowseButton.Click += browseButton_Click;
                    continueButton.Click += continueButton_Click;
                    closeButton.Click += closeButton_Click;

                    musicSkipCheck.CheckedChanged += skipChecked;
                    seriesSkipCheck.CheckedChanged += skipChecked;

                    //Form

                    introForm.Size = new Size(630, 330);
                    introForm.BackColor = Color.FromArgb(235, 250, 250);
                    introForm.FormBorderStyle = FormBorderStyle.None;
                    introForm.BackgroundImage = Media_Distro.Properties.Resources.introBackground;
                    introForm.Icon = Media_Distro.Properties.Resources.logo_ico;
                    introForm.StartPosition = FormStartPosition.CenterScreen;

                    introForm.Controls.Add(logoLabel);
                    introForm.Controls.Add(descriptionLabel);
                    introForm.Controls.Add(movieLabel);
                    introForm.Controls.Add(musicLabel);
                    introForm.Controls.Add(seriesLabel);
                    introForm.Controls.Add(movieURL);
                    introForm.Controls.Add(musicURL);
                    introForm.Controls.Add(seriesURL);
                    introForm.Controls.Add(closeButton);
                    introForm.Controls.Add(movieBrowseButton);
                    introForm.Controls.Add(musicBrowseButton);
                    introForm.Controls.Add(seriesBrowseButton);
                    introForm.Controls.Add(continueButton);
                    introForm.Controls.Add(seriesSkipCheck);
                    introForm.Controls.Add(musicSkipCheck);
                    
                    introForm.ResumeLayout();
                    Application.Run(introForm);

                    void skipChecked(object sender, EventArgs e)
                    {
                        if (movieURL.Lines.Length > 0 && (musicSkipCheck.Checked && seriesSkipCheck.Checked))
                            continueButton.Enabled = true;
                        else
                            continueButton.Enabled = false;
                    }

                    void browseButton_Click(object sender, EventArgs e)
                    {
                        FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                        folderBrowser.RootFolder = SpecialFolder.MyComputer;

                        DialogResult result = folderBrowser.ShowDialog();

                        if (sender.Equals(movieBrowseButton) && result == DialogResult.OK)
                        {
                            Media_Distro.Properties.Settings.Default.Movie_Media_Location.Add(folderBrowser.SelectedPath);
                            movieURL.Text = folderBrowser.SelectedPath;
                        }
                        else if (sender.Equals(musicBrowseButton) && result == DialogResult.OK)
                        {
                            Media_Distro.Properties.Settings.Default.Music_Media_Location.Add(folderBrowser.SelectedPath);
                            musicURL.Text = folderBrowser.SelectedPath;
                        }
                        else if (sender.Equals(seriesBrowseButton) && result == DialogResult.OK)
                        {
                            Media_Distro.Properties.Settings.Default.Series_Media_Location.Add(folderBrowser.SelectedPath);
                            seriesURL.Text = folderBrowser.SelectedPath;
                        }

                        folderBrowser.Dispose();

                        if ((movieURL.Lines.Length > 0 && musicURL.Lines.Length > 0 && seriesURL.Lines.Length > 0) ||
                            (movieURL.Lines.Length > 0 && (seriesSkipCheck.Checked && musicSkipCheck.Checked)))
                            continueButton.Enabled = true;
                        else
                            continueButton.Enabled = false;
                    }

                    void continueButton_Click(object sender, EventArgs e)
                    {
                        StreamWriter dateCheckFile = File.CreateText(Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "akf"));
                        continueButton.Enabled = false;
                 
                        Media_Distro.Properties.Settings.Default.fInitialize = true;
                        Media_Distro.Properties.Settings.Default.activationKey = GenerateKeyAlgorithm();
                        Media_Distro.Properties.Settings.Default.expirationDate = DateTime.Now.AddDays(7);
                        Media_Distro.Properties.Settings.Default.Save();
                        
                        dateCheckFile.WriteLine(Media_Distro.Properties.Settings.Default.expirationDate.ToString());
                        dateCheckFile.Close();
                       
                        introForm.Close();
                    }
                }
            }

            if(Media_Distro.Properties.Settings.Default.fInitialize)
            {
                InitializeComponent();

                if (!Exists(mediaFolder)) CreateDirectory(mediaFolder).Attributes = FileAttributes.Hidden;
                if (!Exists(movieFolder)) CreateDirectory(movieFolder);
                if (!Exists(seriesFolder)) CreateDirectory(seriesFolder);
                if (!Exists(musicFolder)) CreateDirectory(musicFolder);

                if (!File.Exists(statsFileURL))
                {
                    statsFile = new FileStream(statsFileURL, FileMode.Create, FileAccess.ReadWrite);
                    statsFile.Close();
                }

                if (File.Exists(Combine(GetCurrentDirectory(), "Media Distro.bat")))
                    File.Delete(Combine(GetCurrentDirectory(), "Media Distro.bat"));

                homeForm = new HomeForm(this);
                libraryForm = new LibraryForm(this);
                statsForm = new StatsForm();
                shareForm = new ShareForm(this, homeForm, statsForm);
                settingsForm = new SettingsForm(shareForm.progressListView, this, homeForm, libraryForm, shareForm, statsForm);

                PropertyInfo workPanelType = workPanel.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                workPanelType.SetValue(workPanel, true, null);
                PropertyInfo sidePanelType = sideMenuPanel.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                sidePanelType.SetValue(sideMenuPanel, true, null);

                openChildForm(settingsForm);
                openChildForm(shareForm);
                openChildForm(statsForm);
                openChildForm(libraryForm);
                openChildForm(homeForm);

                activeButton = homeSubMenu;
                activeButton.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;

                string expDate;
                if (File.Exists(Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "akf")))
                    expDate = File.ReadAllLines(Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "akf"))[0];
                else expDate = "";

                if (Media_Distro.Properties.Settings.Default.activationKey == "")
                    IsExpired = true;
                if (Media_Distro.Properties.Settings.Default.expirationDate < DateTime.Now)
                    IsExpired = true;
                if (expDate == "")
                    IsExpired = true;
                if (DateTime.Parse(expDate) < DateTime.Now)
                    IsExpired = true;

                if (IsExpired)
                {
                    newCartToolStripButton.Enabled = false;
                    cartsToolStripSplitButton.Enabled = false;
                    activationPanel.Visible = true;
                    sharesubMenu.Enabled = false;
                }

                manageMediaTask = new Task(() => ManageMedia());
                manageMediaTask.Start();
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    switch ((int)m.WParam)
                    {
                        case DBT_DEVICEARRIVAL:
                            
                            foreach (DriveInfo usbStorage in DriveInfo.GetDrives())
                            {
                                if (usbStorage.IsReady && usbStorage.DriveType == DriveType.Removable)
                                {
                                    ListViewItem usbDrive;

                                    if(File.Exists(Combine(usbStorage.Name, "Distro List")))
                                    {
                                        usbDrive = new ListViewItem
                                        {
                                            Text = usbStorage.VolumeLabel + " " + usbStorage.Name,
                                            Tag = usbStorage.Name,
                                            ImageIndex = 3
                                        };
                                    }
                                    else
                                    {
                                        usbDrive = new ListViewItem
                                        {
                                            Text = usbStorage.VolumeLabel + " " + usbStorage.Name,
                                            Tag = usbStorage.Name,
                                            ImageIndex = 2
                                        };
                                    }
                                   
                                    if(shareForm.deviceList.Items.Count == 0)
                                    {
                                        shareForm.sendToToolStripMenuItem.Enabled = true;
                                        shareForm.sendToToolStripMenuItem.DropDownItems.Add(usbStorage.Name).Tag = usbStorage.Name;
                                        shareForm.deviceList.Items.Add(usbDrive);
                                        shareToolStripSplitButton.DropDownItems.Add(usbDrive.Text).Tag = usbDrive.Tag;
                                    }  
                                    else
                                    {
                                        bool exist = false;

                                        foreach (ListViewItem usbName in shareForm.deviceList.Items)
                                        {
                                            if (usbName.Text != usbStorage.VolumeLabel + " " + usbStorage.Name)
                                            {
                                                exist = false;
                                                continue;
                                            }
                                            else
                                            {
                                                exist = true;
                                                break;
                                            } 
                                        }
                                        
                                        if(!exist)
                                        {
                                            shareForm.deviceList.Items.Add(usbDrive);
                                            shareForm.sendToToolStripMenuItem.DropDownItems.Add(usbStorage.Name).Tag = usbStorage.Name;
                                            shareToolStripSplitButton.DropDownItems.Add(usbDrive.Text).Tag = usbDrive.Tag;
                                        }
                                    }
                                }
                            }

                            if (shareToolStripSplitButton.DropDownItems.Count > 0) shareToolStripSplitButton.ToolTipText = null;

                            if (shareForm.deviceList.Items.Count > 0)
                                shareForm.deviceLabel.Visible = false;

                            break;
                        case DBT_DEVICEREMOVECOMPLETE:

                            if (shareForm.deviceList.Items.Count == 1)
                            {
                                shareForm.deviceList.Items.Clear();
                                shareForm.sendToToolStripMenuItem.DropDownItems.Clear();
                                shareForm.sendToToolStripMenuItem.DropDownItems.Add("0");
                                shareForm.sendToToolStripMenuItem.Enabled = false;

                                shareToolStripSplitButton.DropDownItems.Clear();
                                shareToolStripSplitButton.ToolTipText = "No Devices Connected";
                            }
                            else
                            {
                                foreach (DriveInfo usbStorage in DriveInfo.GetDrives())
                                {
                                    if (usbStorage.IsReady && usbStorage.DriveType == DriveType.Removable)
                                    {
                                        foreach (ListViewItem usbName in shareForm.deviceList.Items)
                                        {
                                            if (usbName.Text == usbStorage.VolumeLabel + " " + usbStorage.Name) continue;
                                            else
                                            {
                                                shareForm.deviceList.Items.Remove(usbName);
                                                break;
                                            } 
                                        }

                                        foreach (ToolStripItem usbName in shareForm.sendToToolStripMenuItem.DropDownItems)
                                        {
                                            if (usbName.Text == usbStorage.VolumeLabel + " " + usbStorage.Name) continue;
                                            else
                                            {
                                                shareForm.sendToToolStripMenuItem.DropDownItems.Remove(usbName);
                                                break;
                                            }
                                        }

                                        foreach (ToolStripItem usbName in shareToolStripSplitButton.DropDownItems)
                                        {
                                            if (usbName.Text == usbStorage.VolumeLabel + " " + usbStorage.Name) continue;
                                            else
                                            {
                                                shareToolStripSplitButton.DropDownItems.Remove(usbName);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                            if (shareForm.deviceList.Items.Count == 0)
                                shareForm.deviceLabel.Visible = true;

                            break;
                    }

                    break;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if(Media_Distro.Properties.Settings.Default.fInitialize)
                titleBarPanel.Focus();

            Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            if (state == FormWindowState.Normal)
                for (int i = 0; i < Application.OpenForms.Count; i++)
                    if(Application.OpenForms[i].TopLevel) Application.OpenForms[i].WindowState = FormWindowState.Minimized;
        }

        private void menushowButton_Click(object sender, EventArgs e)
        {
            if (this.sideMenuPanel.Width == 235)
            {
                this.sideMenuPanel.Size = new Size(52, 482);
                this.activeForm.SetBounds(0, 0, 750, 452);
                this.workPanel.SetBounds(52, 30, 750, 452);
                this.workPanel.BackColor = Color.Black;
                this.searchPanel.Location = new Point(367, -3);
                if (this.activationPanel.Visible)
                    this.activationTextBox.Visible = false;
                
                this.cartToolStrip.Location = new Point(58, 5);
                this.pictureBox1.Location = new Point(58, 27);
                
                this.homeForm.dashBoardPanel.Refresh();
                this.homeForm.Size = new Size(751, 452);
                this.homeForm.popularNowPanel.Width = 684;
                this.homeForm.goRightButton.Location = new Point(730, 267);
                this.homeForm.adsPanel.Size = new Size(521, 212);
                this.homeForm.taskPieChart.Location = new Point(544, 58);
                this.homeForm.tempPieChart.Location = new Point(544, 58);
                this.homeForm.volumeLabel.Location = new Point(608, 106);
                this.homeForm.mainGetLabel.Location = new Point(272, 20);
                this.homeForm.subGetLabel.Location = new Point(308, 55);
                this.homeForm.subGetLabel.Size = new Size(202, 52);
                this.homeForm.pictureBox2.Location = new Point(15, 30);
                this.homeForm.pictureBox2.Size = new Size(240, 150);

                if (this.libraryForm.infoPanel.Visible) this.libraryForm.infoPanel.Visible = false;
                this.libraryForm.Size = new Size(751, 452);
                this.libraryForm.libraryPanel.SetBounds(12, 12, 725, 431);
                this.libraryForm.infoPanel.SetBounds(0, 306, 750, 146);
                this.libraryForm.durationLabel.Location = new Point(184, 48);
                this.libraryForm.durationLabelExt.Location = new Point(243, 48);
                this.libraryForm.genreLabel.Location = new Point(184, 65);
                this.libraryForm.genreTextBox.Location = new Point(230, 65);
                this.libraryForm.yearLabel.Location = new Point(184, 82);
                this.libraryForm.yearTextBox.Location = new Point(230, 82);
                this.libraryForm.ratingLabel.Location = new Point(184, 99);
                this.libraryForm.ratingTextBox.Location = new Point(232, 99);
                this.libraryForm.moreInfoLinkLabel.Location = new Point(184, 124);

                this.shareForm.Size = new Size(751, 452);
                this.shareForm.devicePanel.SetBounds(10, 12, 725, 177);
                this.shareForm.sharePanel.SetBounds(10, 195, 725, 245);
                this.shareForm.noCartLabel.Location = new Point(166, 51);
                this.shareForm.progressLabel.Location = new Point(260, 65);
                this.shareForm.deviceLabel.Location = new Point(291, 46);

                this.statsForm.panel1.Location = new Point(558, 0);
                this.statsForm.descriptionLabel.Size = new Size(537, 35);
                this.statsForm.summaryChart.Size = new Size(540, 314);
                this.statsForm.resetChartButton.Location = new Point(460, 65);
                this.statsForm.previousButton.Location = new Point(496, 65);
                this.statsForm.nxtButton.Location = new Point(527, 65);
                this.statsForm.monthComboBox.Location = new Point(393, 88);
                this.statsForm.yearComboBox.Location = new Point(502, 88);

                this.settingsForm.Size = new Size(751, 452);
                this.settingsForm.panel2.Size = new Size(727, 112);
                this.settingsForm.panel3.Size = new Size(727, 216);
                this.settingsForm.urlAddingInfo.TextAlign = ContentAlignment.TopCenter;
                this.settingsForm.urlAddingInfo.Size = new Size(364, 36);
            }
            else
            {
                this.sideMenuPanel.Size = new Size(235, 482);
                this.activeForm.SetBounds(0, 0, 567, 452);
                this.workPanel.SetBounds(235, 30, 567, 452);
                this.searchPanel.Location = new Point(184, -3);
                if (this.activationPanel.Visible)
                    this.activationTextBox.Visible = true;

                this.cartToolStrip.Location = new Point(238, 5);
                this.pictureBox1.Location = new Point(238, 27);
                
                this.homeForm.dashBoardPanel.Refresh();
                this.homeForm.Size = new Size(567, 452);
                this.homeForm.popularNowPanel.Width = 501;
                this.homeForm.goRightButton.Location = new Point(547, 267);
                this.homeForm.adsPanel.Size = new Size(338, 212);
                this.homeForm.taskPieChart.Location = new Point(360, 58);
                this.homeForm.tempPieChart.Location = new Point(360, 58);
                this.homeForm.volumeLabel.Location = new Point(424, 106);
                this.homeForm.mainGetLabel.Location = new Point(139, 20);
                this.homeForm.subGetLabel.Location = new Point(175, 55);
                this.homeForm.subGetLabel.Size = new Size(152, 52);
                this.homeForm.pictureBox2.Location = new Point(6, 55);
                this.homeForm.pictureBox2.Size = new Size(163, 100);

                if (this.libraryForm.infoPanel.Visible) this.libraryForm.infoPanel.Visible = false;
                this.libraryForm.Size = new Size(567, 452);
                this.libraryForm.libraryPanel.SetBounds(12, 12, 546, 431);
                this.libraryForm.infoPanel.SetBounds(0, 306, 567, 146);
                this.libraryForm.durationLabel.Location = new Point(144, 48);
                this.libraryForm.durationLabelExt.Location = new Point(203, 48);
                this.libraryForm.genreLabel.Location = new Point(144, 65);
                this.libraryForm.genreTextBox.Location = new Point(190, 65);
                this.libraryForm.yearLabel.Location = new Point(144, 82);
                this.libraryForm.yearTextBox.Location = new Point(190, 82);
                this.libraryForm.ratingLabel.Location = new Point(144, 99);
                this.libraryForm.ratingTextBox.Location = new Point(192, 99);
                this.libraryForm.moreInfoLinkLabel.Location = new Point(144, 124);

                this.shareForm.Size = new Size(567, 452);
                this.shareForm.devicePanel.SetBounds(10, 12, 545, 177);
                this.shareForm.sharePanel.SetBounds(10, 195, 545, 245);
                this.shareForm.noCartLabel.Location = new Point(66, 51);
                this.shareForm.progressLabel.Location = new Point(158, 65);
                this.shareForm.deviceLabel.Location = new Point(189, 46);

                this.statsForm.panel1.Location = new Point(374, 0);
                this.statsForm.descriptionLabel.Size = new Size(353, 35);
                this.statsForm.summaryChart.Size = new Size(356, 314);
                this.statsForm.resetChartButton.Location = new Point(276, 65);
                this.statsForm.previousButton.Location = new Point(312, 65);
                this.statsForm.nxtButton.Location = new Point(343, 65);
                this.statsForm.monthComboBox.Location = new Point(209, 88);
                this.statsForm.yearComboBox.Location = new Point(318, 88);

                this.settingsForm.Size = new Size(567, 452);
                this.settingsForm.panel2.Size = new Size(543, 112);
                this.settingsForm.panel3.Size = new Size(543, 216);
                this.settingsForm.urlAddingInfo.TextAlign = ContentAlignment.MiddleRight;
                this.settingsForm.urlAddingInfo.Size = new Size(211, 36);
            }

            this.workPanel.Focus();
        }

        private void searchTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            searchTextBox.ForeColor = Color.Black;
            searchTextBox.BackColor = SystemColors.Window;
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            searchTextBox.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar;
            if((!searchPanel.ContainsFocus && !searchButton.ContainsFocus) || searchTextBox.Text == "")
            {
                resultPanel.Controls.Clear();
                searchPanel.Visible = false;
                pictureBox2.Visible = false;
                searchTextBox.Clear();
            }
        }

        private void LoadHomeMedia(int count)
        {
            int initial1 = 3;

            foreach (LibraryManager media in SortPRS(count))
            {
                PictureBox coverArtPictureBox = new PictureBox
                {
                    Image = (media.CoverArtDirectory != null) ? Image.FromFile(media.CoverArtDirectory) :
                            Media_Distro.Properties.Resources.coverart_sample_2,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(116, 140),
                    Location = new Point(initial1, 10),
                    Tag = media,
                    BorderStyle = BorderStyle.FixedSingle
                };

                homeForm.titleToolTip.SetToolTip(coverArtPictureBox, media.Title);

                coverArtPictureBox.MouseEnter += new EventHandler(PRSItem_MouseEnter);

                initial1 += 121;

                homeForm.popularNowPanel.Invoke((MethodInvoker)delegate { homeForm.popularNowPanel.Controls.Add(coverArtPictureBox); });
            }
        }

        public void LoadLibraryMedia(LibraryManager media)
        {
            if(media.Type == MediaType.Movie)
            {
                if (media.CoverArtDirectory != null && File.Exists(media.CoverArtDirectory))
                {
                    libraryForm.movieList.Invoke((MethodInvoker)delegate { libraryForm.movieList.LargeImageList.Images.Add(Image.FromFile(media.CoverArtDirectory)); });

                    libraryForm.movieList.Invoke((MethodInvoker)delegate
                    {
                        libraryForm.movieList.Items.Add(new ListViewItem
                        {
                            Text = media.Title,
                            Tag = media,
                            ImageIndex = libraryForm.moiter++
                        });
                    });
                }
                else
                {
                    libraryForm.movieList.Invoke((MethodInvoker)delegate
                    {
                        libraryForm.movieList.Items.Add(new ListViewItem
                        {
                            Text = media.Title,
                            Tag = media,
                            ImageIndex = 0
                        });
                    });
                }
            }
            else if(media.Type == MediaType.Music)
            {
                if (media.CoverArtDirectory != null && File.Exists(media.CoverArtDirectory))
                {
                    libraryForm.musicList.Invoke((MethodInvoker)delegate { libraryForm.musicList.LargeImageList.Images.Add(Image.FromFile(media.CoverArtDirectory)); });

                    libraryForm.musicList.Invoke((MethodInvoker)delegate
                    {
                        libraryForm.musicList.Items.Add(new ListViewItem
                        {
                            Text = media.Title,
                            Tag = media,
                            ImageIndex = libraryForm.muiter++
                        });
                    });
                }
                else
                {
                    libraryForm.musicList.Invoke((MethodInvoker)delegate
                    {
                        libraryForm.musicList.Items.Add(new ListViewItem
                        {
                            Text = media.Title,
                            Tag = media,
                            ImageIndex = 0
                        });
                    });
                }
            }   
            else if(media.Type == MediaType.Series)
            {
                if (media.CoverArtDirectory != null && File.Exists(media.CoverArtDirectory))
                {
                    libraryForm.seriesList.Invoke((MethodInvoker)delegate { libraryForm.seriesList.LargeImageList.Images.Add(Image.FromFile(media.CoverArtDirectory)); });

                    libraryForm.seriesList.Invoke((MethodInvoker)delegate
                    {
                        libraryForm.seriesList.Items.Add(new ListViewItem
                        {
                            Text = media.Title,
                            Tag = media,
                            ImageIndex = libraryForm.siter++
                        });
                    });
                }
                else
                {
                    libraryForm.seriesList.Invoke((MethodInvoker)delegate
                    {
                        libraryForm.seriesList.Items.Add(new ListViewItem
                        {
                            Text = media.Title,
                            Tag = media,
                            ImageIndex = 0
                        });
                    });
                }
            }
        }

        public void ManageMedia()
        {
            int initial1 = 3, count = 1;
            List<string> nonExistentMovDirs = new List<string>();
            List<string> nonExistentMusDirs = new List<string>();
            List<string> nonExistentSerDirs = new List<string>();
            LibraryManager libraryManager = new LibraryManager();

            foreach (string dir in Media_Distro.Properties.Settings.Default.Movie_Media_Location)
            {
                if (Exists(dir))
                {
                    foreach (string file in GetFiles(dir))
                        if (GetExtension(file) == ".mp4" || GetExtension(file) == ".mkv" || GetExtension(file) == ".avi" ||
                                GetExtension(file) == ".flv" || GetExtension(file) == ".wmv" || GetExtension(file) == ".f4v" ||
                                GetExtension(file) == ".f4p" || GetExtension(file) == ".f4a" || GetExtension(file) == ".f4b" ||
                                GetExtension(file) == ".3gp" || GetExtension(file) == ".m4v" || GetExtension(file) == ".mpeg" ||
                                GetExtension(file) == ".mpg" || GetExtension(file) == ".mov" || GetExtension(file) == ".qt")
                            movieDir.Add(file);

                    RetrieveMediaDirectories(dir, movieDir, this, true);
                    settingsForm.urlPathListBox.Invoke((MethodInvoker)delegate { settingsForm.urlPathListBox.Items.Add(dir); });
                }
                else
                    nonExistentMovDirs.Add(dir);
            }

            foreach (string dir in Media_Distro.Properties.Settings.Default.Series_Media_Location)
            {
                if (Exists(dir))
                {
                    foreach (string subDir in GetDirectories(dir))
                        seriesDir.Add(subDir);
                }
                else
                    nonExistentSerDirs.Add(dir);
            }

            foreach (string dir in Media_Distro.Properties.Settings.Default.Music_Media_Location)
            {
                if (Exists(dir))
                {
                    foreach (string file in GetFiles(dir))
                        if (GetExtension(file) == ".mp3" || GetExtension(file) == ".m4a" || GetExtension(file) == ".webm" ||
                            GetExtension(file) == ".wv" || GetExtension(file) == ".wma" || GetExtension(file) == ".wav" ||
                            GetExtension(file) == ".m4b" || GetExtension(file) == ".m4p" || GetExtension(file) == ".aac")
                            musicDir.Add(file);

                    RetrieveMediaDirectories(dir, musicDir, this);
                }
                else
                    nonExistentMusDirs.Add(dir);
            }

            foreach (string dir in nonExistentMovDirs)
            {
                Media_Distro.Properties.Settings.Default.Movie_Media_Location.Remove(dir);
            }

            foreach (string dir in nonExistentMusDirs)
            {
                Media_Distro.Properties.Settings.Default.Music_Media_Location.Remove(dir);
            }

            foreach (string dir in nonExistentSerDirs)
            {
                Media_Distro.Properties.Settings.Default.Series_Media_Location.Remove(dir);
            }

            Media_Distro.Properties.Settings.Default.Save();

            libraryForm.loadingLabel.Invoke((MethodInvoker)delegate { libraryForm.loadingLabel.Visible = false; });
            homeForm.loadingLabel.Invoke((MethodInvoker)delegate { homeForm.loadingLabel.Visible = false; });
            foreach (string dir in movieDir) 
            {
                libraryManager = ManageMediaReference(dir, MediaType.Movie, GetFileNameWithoutExtension(dir));
                LoadLibraryMedia(libraryManager);
                homeForm.popularNowPanel.Invoke((MethodInvoker)delegate { homeForm.popularNowPanel.Controls.Clear(); });
                LoadHomeMedia((count < 11) ? count++ : 11);

                GC.Collect();
            }
            foreach (string dir in seriesDir) 
            { 
                libraryManager = ManageMediaReference(dir, MediaType.Series, GetFileName(dir));
                LoadLibraryMedia(libraryManager);
                homeForm.popularNowPanel.Invoke((MethodInvoker)delegate { homeForm.popularNowPanel.Controls.Clear(); });
                LoadHomeMedia((count < 11) ? count++ : 11);

                GC.Collect();
            }
            foreach (object dir in musicDir)
            {
                if (dir is string)
                    libraryManager = ManageMediaReference((string)dir, MediaType.Music, GetFileNameWithoutExtension((string)dir));
                else if (dir is ArrayList)
                    libraryManager = ManageMediaReference((ArrayList)dir);
                
                LoadLibraryMedia(libraryManager);
                homeForm.popularNowPanel.Invoke((MethodInvoker)delegate { homeForm.popularNowPanel.Controls.Clear(); });
                LoadHomeMedia((count < 11) ? count++ : 11);
                GC.Collect();
            }
            
            SortMedia(null, SortType.Name, Order.Ascending);

            movieGenreCatalogue.Sort();
            foreach (string genre in movieGenreCatalogue)
                libraryForm.arrangementToolStrip.BeginInvoke((MethodInvoker)delegate { libraryForm.genreToolStripDropDownButton.DropDownItems.Add(genre, null, new EventHandler(libraryForm.genreSelected_Click)); });

            libraryForm.movieList.Invoke((MethodInvoker)delegate { libraryForm.movieList.Clear(); });
            libraryForm.movieList.Invoke((MethodInvoker)delegate
            {
                for (int i = libraryForm.movieList.LargeImageList.Images.Count - 1; i > 0; i--)
                    libraryForm.movieList.LargeImageList.Images.RemoveAt(i);
            });
            libraryForm.musicList.Invoke((MethodInvoker)delegate { libraryForm.musicList.Clear(); });
            libraryForm.musicList.Invoke((MethodInvoker)delegate 
            {
                for (int i = libraryForm.musicList.LargeImageList.Images.Count - 1; i > 0; i--)
                    libraryForm.musicList.LargeImageList.Images.RemoveAt(i);
            });
            libraryForm.seriesList.Invoke((MethodInvoker)delegate { libraryForm.seriesList.Clear(); });
            libraryForm.seriesList.Invoke((MethodInvoker)delegate 
            {
                for (int i = libraryForm.seriesList.LargeImageList.Images.Count - 1; i > 0; i--)
                    libraryForm.seriesList.LargeImageList.Images.RemoveAt(i);
            });
            homeForm.popularNowPanel.Invoke((MethodInvoker)delegate { homeForm.popularNowPanel.Controls.Clear(); });

            foreach (LibraryManager movie in movieCatalogue)
            {
                if (movie.CoverArtDirectory != null && File.Exists(movie.CoverArtDirectory))
                {
                    libraryForm.movieList.Invoke((MethodInvoker)delegate { libraryForm.movieList.LargeImageList.Images.Add(Image.FromFile(movie.CoverArtDirectory)); });

                    libraryForm.movieList.Invoke((MethodInvoker)delegate
                    {
                        libraryForm.movieList.Items.Add(new ListViewItem
                        {
                            Text = movie.Title,
                            Tag = movie,
                            ImageIndex = libraryForm.moiter++
                        });
                    });
                }
                else
                {
                    libraryForm.movieList.Invoke((MethodInvoker)delegate
                    {
                        libraryForm.movieList.Items.Add(new ListViewItem
                        {
                            Text = movie.Title,
                            Tag = movie,
                            ImageIndex = 0
                        });
                    });
                }
            }
            foreach (LibraryManager music in musicCatalogue)
            {
                if (music.CoverArtDirectory != null && File.Exists(music.CoverArtDirectory))
                {
                    libraryForm.musicList.Invoke((MethodInvoker)delegate { libraryForm.musicList.LargeImageList.Images.Add(Image.FromFile(music.CoverArtDirectory)); });

                    libraryForm.musicList.Invoke((MethodInvoker)delegate
                    {
                        libraryForm.musicList.Items.Add(new ListViewItem
                        {
                            Text = music.Title,
                            Tag = music,
                            ImageIndex = libraryForm.muiter++
                        });
                    });
                }
                else
                {
                    libraryForm.musicList.Invoke((MethodInvoker)delegate
                    {
                        libraryForm.musicList.Items.Add(new ListViewItem
                        {
                            Text = music.Title,
                            Tag = music,
                            ImageIndex = 0
                        });
                    });
                }
            }
            foreach (LibraryManager series in seriesCatalogue)
            {
                if (series.CoverArtDirectory != null && File.Exists(series.CoverArtDirectory))
                {
                    libraryForm.seriesList.Invoke((MethodInvoker)delegate { libraryForm.seriesList.LargeImageList.Images.Add(Image.FromFile(series.CoverArtDirectory)); });

                    libraryForm.seriesList.Invoke((MethodInvoker)delegate
                    {
                        libraryForm.seriesList.Items.Add(new ListViewItem
                        {
                            Text = series.Title,
                            Tag = series,
                            ImageIndex = libraryForm.siter++
                        });
                    });
                }
                else
                {
                    libraryForm.seriesList.Invoke((MethodInvoker)delegate
                    {
                        libraryForm.seriesList.Items.Add(new ListViewItem
                        {
                            Text = series.Title,
                            Tag = series,
                            ImageIndex = 0
                        });
                    });
                }
            }

            foreach (LibraryManager media in SortPRS())
            {
                PictureBox coverArtPictureBox = new PictureBox
                {
                    Image = (media.CoverArtDirectory != null) ? Image.FromFile(media.CoverArtDirectory) :
                            Media_Distro.Properties.Resources.coverart_sample_2,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(116, 140),
                    Location = new Point(initial1, 10),
                    Tag = media,
                    BorderStyle = BorderStyle.FixedSingle
                };

                    homeForm.titleToolTip.SetToolTip(coverArtPictureBox, media.Title);

                    coverArtPictureBox.MouseEnter += new EventHandler(PRSItem_MouseEnter);

                    initial1 += 121;

                    homeForm.popularNowPanel.Invoke((MethodInvoker)delegate { homeForm.popularNowPanel.Controls.Add(coverArtPictureBox); });
            }

            statsForm.mediaAmountChart.Invoke((MethodInvoker)delegate
            {
                statsForm.mediaAmountChart.Series.Add(new ColumnSeries
                {
                    Title = "Movies",
                    Values = new ChartValues<int> { movieCatalogue.Count }
                });
            });

            statsForm.mediaAmountChart.Invoke((MethodInvoker)delegate
            {
                statsForm.mediaAmountChart.Series.Add(new ColumnSeries
                {
                    Title = "Music",
                    Values = new ChartValues<int> { musicCatalogue.Count }
                });
            });

            statsForm.mediaAmountChart.Invoke((MethodInvoker)delegate
            {
                statsForm.mediaAmountChart.Series.Add(new ColumnSeries
                {
                    Title = "Series",
                    Values = new ChartValues<int> { seriesCatalogue.Count }
                });
            });
        }

        private void PRSItem_MouseEnter(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;

            homeForm.addToCartButton.Visible = true;
            homeForm.addToCartButton.Location = new Point(box.Location.X, 148);
            homeForm.addToCartButton.Tag = box.Tag;
            homeForm.popularNowPanel.Controls.Add(homeForm.addToCartButton);
        }

        private void searchT()
        {
            PictureBox coverArt;
            Label searchQueryLabel;
            Label notFoundLabel = new Label 
            { 
                Text = "No items matches current entry", 
                Location = new Point(45, 10), 
                Visible = true, 
                Size = new Size(155, 15)   
            };
            Panel searchQueryPanel;
            ToolTip searchToolTip;
            Button addToCart;
            List<LibraryManager> searchResults = Search(searchTextBox.Text, catalogues);

            searchPanel.Invoke((MethodInvoker)delegate { searchPanel.Visible = true; });

            if (searchResults.Count > 0)
            {
                notFoundLabel.Visible = false;
                foreach (LibraryManager media in searchResults)
                {
                    coverArt = new PictureBox
                    {
                        Size = new Size(36, 48),
                        Location = new Point(3, 3),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Image = (media.CoverArtDirectory != null) ? Image.FromFile(media.CoverArtDirectory) : Media_Distro.Properties.Resources.coverart_sample_2,
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    searchQueryLabel = new Label
                    {
                        Text = (media.Title == media.Name) ? GetFileNameWithoutExtension(media.Name) : media.Title,
                        Location = new Point(45, 20),
                        Size = new Size(155, 20)
                    };
                    searchToolTip = new ToolTip();
                    searchToolTip.SetToolTip(searchQueryLabel, searchQueryLabel.Text);

                    addToCart = new Button
                    {
                        Size = new Size(25, 25),
                        Location = new Point(200, 15),
                        FlatStyle = FlatStyle.Flat,
                        Tag = media,
                        Image = Media_Distro.Properties.Resources.Add_Media_Icon
                    };
                    addToCart.FlatAppearance.BorderSize = 0;
                    addToCart.Click += addToCart_Click;

                    searchQueryPanel = new Panel
                    {
                        Size = new Size(resultPanel.Width - 20, coverArt.Height + 10),
                        Location = new Point(0, 58 * resultPanel.Controls.Count)
                    };

                    searchQueryPanel.Controls.Add(coverArt);
                    searchQueryPanel.Controls.Add(searchQueryLabel);
                    searchQueryPanel.Controls.Add(addToCart);

                    resultPanel.Invoke((MethodInvoker)delegate { resultPanel.Controls.Add(searchQueryPanel); });
                }
            }
            else
            {
                resultPanel.Invoke((MethodInvoker)delegate { resultPanel.Controls.Add(notFoundLabel); });
                notFoundLabel.Invoke((MethodInvoker)delegate { notFoundLabel.Visible = true; });
            }
        }

        private void addToCart_Click(object sender, EventArgs e)
        {
            Button add = (Button)sender;
            CartManager cart;

            try
            {
                if (customers == 0) throw new Exception();
                else
                {
                    cart = (CartManager)cartLabel.Tag;
                    cart.AddMedia((LibraryManager)add.Tag);
                }
            }
            catch (Exception)
            {
                DialogResult result = MessageBox.Show("There are currently no active carts available. Click OK to add to a cart.", "Empty Slot", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    newCartToolStripButton.PerformClick();
                    cart = (CartManager)cartLabel.Tag;
                    cart.AddMedia((LibraryManager)add.Tag);
                }
            }

            searchPanel.Focus();

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text != "")
            {
                resultPanel.Controls.Clear();
                searchTextBox.Focus();
                searchTextBox.BackColor = SystemColors.Control;
                pictureBox2.Visible = true;

                searchTask = new Task(() => searchT());
                searchTask.Start();

                searchTextBox.Focus();
            }
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && searchTextBox.Text == "//Activate_Bonus")
            {
                Media_Distro.Properties.Settings.Default.bonusAvailable = true;
                settingsForm.bonusButton.Visible = true;
                searchTextBox.Text = "Bonus Activated";
                Media_Distro.Properties.Settings.Default.Save();
            }
            else if (e.KeyChar == (char)Keys.Enter && searchTextBox.Text != "")
            {
                resultPanel.Controls.Clear();
                searchTextBox.Focus();
                searchTextBox.BackColor = SystemColors.Control;
                pictureBox2.Visible = true;

                searchTask = new Task(() => searchT());
                searchTask.Start();

                searchTextBox.Focus();
            }   
        }

        private void titleBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            this.startPoint = e.Location;
            this.drag = true;
        }

        private void titleBarPanel_MouseUp(object sender, MouseEventArgs e)
        {
            this.drag = false;

            workPanel.Focus();
        }

        private void titleBarPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.drag)
            {
                Point p1 = new Point(e.X, e.Y);
                Point p2 = this.PointToScreen(p1);
                Point p3 = new Point(p2.X - this.startPoint.X,
                                     p2.Y - this.startPoint.Y);

                this.Location = p3;
            }
        }
        
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Visible = false;

            workPanel.Controls.Remove(activeForm);
            activeForm = childForm;
            activeForm.TopLevel = false;
            workPanel.SuspendLayout();
            workPanel.Controls.Add(activeForm);
            activeForm.Visible = true;
        }
       
        private void librarysubMenu_Click(object sender, EventArgs e)
        {
            activeButton.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
            activeButton = librarySubMenu;
            activeButton.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            
            openChildForm(libraryForm);
            libraryForm.Focus();
        }

        private void sharesubMenu_Click(object sender, EventArgs e)
        {
            activeButton.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
            activeButton = sharesubMenu;
            activeButton.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;

            openChildForm(shareForm);
            shareForm.deviceList.Focus();
        }

        private void homesubMenu_Click(object sender, EventArgs e)
        {
            activeButton.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
            activeButton = homeSubMenu;
            activeButton.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;

            openChildForm(homeForm);
            homeForm.Focus();
        }

        private void statssubMenu_Click(object sender, EventArgs e)
        {
            activeButton.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
            activeButton = statssubMenu;
            activeButton.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;

            openChildForm(statsForm);
            statsForm.Focus();

        }

        private void settingsubMenu_Click(object sender, EventArgs e)
        {
            activeButton.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
            activeButton = settingsubMenu;
            activeButton.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;

            openChildForm(settingsForm);
            settingsForm.Focus();

        }

        private void newCartToolStripButton_Click(object sender, EventArgs e)
        {
            CartManager newCart;

            if (cartLabelEdit.Visible)
            {
                cartLabelEdit.Visible = false;
                cartLabel.Visible = true;
                cartLabel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            }

            if (cartsToolStripSplitButton.DropDownItems != null)
            {
                cartsToolStripSplitButton.ToolTipText = null;
                shareForm.noCartLabel.Visible = false ;
            }
                
            cartsToolStripSplitButton.DropDownItems.Add("Customer " + ++customers).Tag = newCart = new CartManager(customers);
            cartLabel.Text = $"Customer {customers}";
            cartLabel.Tag = newCart;

            cartsToolStripSplitButton.DropDown.ItemClicked += new ToolStripItemClickedEventHandler(cartsToolStripSplitButton_DropDownItemClicked);

            ListViewItem newItem = new ListViewItem
            {
                Text = cartLabel.Text,
                ImageIndex = 1,
                Tag = cartLabel.Tag
            };

            if(activeItem == null)
            {
                shareForm.cartsListView.Items.Add(newItem);
                activeItem = newItem;
            }
            else
            {
                activeItem.ImageIndex = 0;
                shareForm.cartsListView.Items.Add(newItem);
                activeItem = newItem;
            }
        }

        private void cartsToolStripSplitButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            activeItem.ImageIndex = 0;

            cartLabel.Text = e.ClickedItem.Text;
            cartLabel.Tag = e.ClickedItem.Tag;

            foreach (ListViewItem item in shareForm.cartsListView.Items)
                if (item.Tag == cartLabel.Tag)
                {
                    activeItem = item;
                    activeItem.ImageIndex = 1;
                }
        }

        private void cartLabel_Click(object sender, EventArgs e)
        {
            cartLabelEdit = new TextBox
            {
                Location = new Point(cartToolStrip.Location.X + 97, cartToolStrip.Location.Y + 2),
                Size = new Size(cartLabel.Width, cartLabel.Height),
                BorderStyle = BorderStyle.Fixed3D,
                BackColor = Color.FromArgb(200, 215, 255)
            };
            cartLabelEdit.KeyPress += cartLabelEdit_KeyPress;
            cartLabelEdit.Leave += cartLabelEdit_Leave;
            titleBarPanel.Controls.Add(cartLabelEdit);
            cartLabelEdit.Text = cartLabel.Text;
            cartLabelEdit.Tag = cartLabel.Tag;
            cartLabel.Visible = false;
            cartLabelEdit.Focus();
        }

        private void cartLabelEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                cartLabelEdit.Visible = false;
                cartLabel.Visible = true;
                cartLabel.Text = cartLabelEdit.Text;
                foreach(ToolStripItem item in cartsToolStripSplitButton.DropDownItems)
                    if (item.Tag == cartLabelEdit.Tag)
                        item.Text = cartLabel.Text;
                
                foreach (ListViewItem item in shareForm.cartsListView.Items)
                    if (item.Tag == cartLabelEdit.Tag)
                        item.Text = cartLabel.Text;

                foreach (ProgressListView.ProgressListViewItem item in shareForm.progressListView.Items)
                    if (item.Tag == cartLabelEdit.Tag)
                        item.customerLabel.Text = cartLabel.Text;

                cartLabel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            } 
        }

        private void cartLabel_MouseHover(object sender, EventArgs e)
        {
            cartLabel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
        }

        private void cartLabel_MouseLeave(object sender, EventArgs e)
        {
            cartLabel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
        }

        private void cartLabelEdit_Leave(object sender, EventArgs e)
        {
            cartLabelEdit.Visible = false;
            cartLabel.Visible = true;
            cartLabel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
        }

        private void sideMenuPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (cartLabelEdit.Visible)
            {
                cartLabelEdit.Visible = false;
                cartLabel.Visible = true;
                cartLabel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            }
        }

        private void mediaDistroFrame_Load(object sender, EventArgs e)
        {
            sideMenuPanel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
            titleBarPanel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            searchTextBox.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar;
            workPanel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
            cartToolStrip.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            pictureBox1.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;

            searchButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar;
            searchButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar;
            menushowButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            menushowButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            homeSubMenu.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            homeSubMenu.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            librarySubMenu.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            librarySubMenu.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            sharesubMenu.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            sharesubMenu.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            statssubMenu.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            statssubMenu.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            settingsubMenu.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            settingsubMenu.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;

            libraryForm.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
            libraryForm.moviesTabButton.ForeColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            libraryForm.moviesSelected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            libraryForm.genreListView.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
            libraryForm.movieList.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
            libraryForm.musicList.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
            libraryForm.seriesList.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
            libraryForm.infoPanel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            if (Media_Distro.Properties.Settings.Default.Active_Theme_Preference == Media_Distro.Properties.Settings.Default.Default_Theme_Preference)
            {
                minimizeButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Default_Theme_SearchBar;
                minimizeButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Default_Theme_SearchBar;

                homeForm.locateZipButton.FillColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;

                libraryForm.infoPanel.BackgroundImage = Media_Distro.Properties.Resources.infoPanel_Background;
                libraryForm.titleTextBox.BackColor = libraryForm.infoPanel.BackColor;
                libraryForm.genreTextBox.BackColor = Color.FromArgb(130, 200, 255);
                libraryForm.yearTextBox.BackColor = Color.FromArgb(130, 200, 255);
                libraryForm.ratingTextBox.BackColor = Color.FromArgb(130, 200, 255);
                libraryForm.cartButton.BackColor = Color.FromArgb(130, 200, 255);
                libraryForm.hideInfoButton.FillColor = Media_Distro.Properties.Settings.Default.Default_Theme_Preference;
                libraryForm.hideInfoButton.Image = Media_Distro.Properties.Resources.Hide_Info_Icon;
                libraryForm.addSTCart.BackColor = Color.FromArgb(130, 200, 255);
                libraryForm.albumTreeView.BackColor = Color.FromArgb(130, 200, 255);
                libraryForm.pictureBox1.BackColor = Color.FromArgb(130, 200, 255);
                libraryForm.addSTCart.FillColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                libraryForm.moreInfoLinkLabel.LinkColor = libraryForm.infoPanel.BackColor;
                libraryForm.moreInfoLinkLabel.ActiveLinkColor = Media_Distro.Properties.Settings.Default.Default_Theme_SearchBar;
                settingsForm.updateLinkLabel.LinkColor = libraryForm.infoPanel.BackColor;
                settingsForm.updateLinkLabel.ActiveLinkColor = Media_Distro.Properties.Settings.Default.Default_Theme_SearchBar;

                shareForm.detailPanel.BackgroundImage = Media_Distro.Properties.Resources.detailPanel_Default_BackGround;

                statsForm.pictureBox1.Image = Media_Distro.Properties.Resources.stats_background_default;
                statsForm.zoomInButton1.FillColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.zoomOutButton1.FillColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.resetChartButton.FillColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.previousButton.FillColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.nxtButton.FillColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.cartInfoLabel.BackColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.cartMovieLabel.BackColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.cartMoviesExt.BackColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.cartMusicLabel.BackColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.cartMusicExt.BackColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.cartSeriesLabel.BackColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.cartSeriesExt.BackColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.cartSentDateLabel.BackColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.cartDateExt.BackColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.cartPaidLabel.BackColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
                statsForm.cartPaidExt.BackColor = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;

                Media_Distro.Properties.Settings.Default.Active_Theme_InfoPanel = libraryForm.genreTextBox.BackColor;
            }
            else if (Media_Distro.Properties.Settings.Default.Active_Theme_Preference == Media_Distro.Properties.Settings.Default.Fire_Theme_Preference)
            {
                minimizeButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;
                minimizeButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;

                homeForm.locateZipButton.FillColor = Media_Distro.Properties.Settings.Default.Fire_Theme_TitleBar;

                libraryForm.infoPanel.BackgroundImage = Media_Distro.Properties.Resources.infoPanel_FireBackground;
                libraryForm.titleTextBox.BackColor = libraryForm.infoPanel.BackColor;
                libraryForm.genreTextBox.BackColor = Color.FromArgb(180, 80, 95);
                libraryForm.yearTextBox.BackColor = Color.FromArgb(180, 80, 95);
                libraryForm.ratingTextBox.BackColor = Color.FromArgb(180, 80, 95);
                libraryForm.cartButton.BackColor = Color.FromArgb(180, 80, 95);
                libraryForm.hideInfoButton.FillColor = Media_Distro.Properties.Settings.Default.Fire_Theme_Preference;
                libraryForm.hideInfoButton.Image = Media_Distro.Properties.Resources.Hide_Info_Fire_Icon;
                libraryForm.addSTCart.BackColor = Color.FromArgb(180, 80, 95);
                libraryForm.albumTreeView.BackColor = Color.FromArgb(180, 80, 95);
                libraryForm.pictureBox1.BackColor = Color.FromArgb(180, 80, 95);
                libraryForm.addSTCart.FillColor = Media_Distro.Properties.Settings.Default.Fire_Theme_TitleBar;
                libraryForm.moreInfoLinkLabel.LinkColor = libraryForm.titleTextBox.ForeColor;
                libraryForm.moreInfoLinkLabel.ActiveLinkColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;
                settingsForm.updateLinkLabel.LinkColor = libraryForm.infoPanel.BackColor;
                settingsForm.updateLinkLabel.ActiveLinkColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;

                shareForm.detailPanel.BackgroundImage = Media_Distro.Properties.Resources.detailPanel_Fire_BackGround;

                statsForm.pictureBox1.Image = Media_Distro.Properties.Resources.stats_background_fire;
                statsForm.zoomInButton1.FillColor = Media_Distro.Properties.Settings.Default.Fire_Theme_TitleBar;
                statsForm.zoomOutButton1.FillColor = Media_Distro.Properties.Settings.Default.Fire_Theme_TitleBar;
                statsForm.resetChartButton.FillColor = Media_Distro.Properties.Settings.Default.Fire_Theme_TitleBar;
                statsForm.previousButton.FillColor = Media_Distro.Properties.Settings.Default.Fire_Theme_TitleBar;
                statsForm.nxtButton.FillColor = Media_Distro.Properties.Settings.Default.Fire_Theme_TitleBar;
                statsForm.cartInfoLabel.BackColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;
                statsForm.cartMovieLabel.BackColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;
                statsForm.cartMoviesExt.BackColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;
                statsForm.cartMusicLabel.BackColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;
                statsForm.cartMusicExt.BackColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;
                statsForm.cartSeriesLabel.BackColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;
                statsForm.cartSeriesExt.BackColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;
                statsForm.cartSentDateLabel.BackColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;
                statsForm.cartDateExt.BackColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;
                statsForm.cartPaidLabel.BackColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;
                statsForm.cartPaidExt.BackColor = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;

                Media_Distro.Properties.Settings.Default.Active_Theme_InfoPanel = libraryForm.genreTextBox.BackColor;
            }
            else if (Media_Distro.Properties.Settings.Default.Active_Theme_Preference == Media_Distro.Properties.Settings.Default.Meadow_Theme_Preference)
            {
                minimizeButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_Selected;
                minimizeButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_Selected;

                homeForm.locateZipButton.FillColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_TitleBar;

                libraryForm.infoPanel.BackgroundImage = Media_Distro.Properties.Resources.infoPanel_MeadowBackground;
                libraryForm.titleTextBox.BackColor = libraryForm.infoPanel.BackColor;
                libraryForm.genreTextBox.BackColor = Color.FromArgb(155, 255, 165);
                libraryForm.yearTextBox.BackColor = Color.FromArgb(155, 255, 165);
                libraryForm.ratingTextBox.BackColor = Color.FromArgb(155, 255, 165);
                libraryForm.cartButton.BackColor = Color.FromArgb(155, 255, 165);
                libraryForm.hideInfoButton.FillColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_Preference;
                libraryForm.hideInfoButton.Image = Media_Distro.Properties.Resources.Hide_Info_Meadow_Icon;
                libraryForm.addSTCart.BackColor = Color.FromArgb(155, 255, 165);
                libraryForm.albumTreeView.BackColor = Color.FromArgb(155, 255, 165);
                libraryForm.pictureBox1.BackColor = Color.FromArgb(155, 255, 165);
                libraryForm.addSTCart.FillColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_Preference;
                libraryForm.moreInfoLinkLabel.LinkColor = libraryForm.infoPanel.BackColor;
                libraryForm.moreInfoLinkLabel.ActiveLinkColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_SearchBar;
                settingsForm.updateLinkLabel.LinkColor = libraryForm.infoPanel.BackColor;
                settingsForm.updateLinkLabel.ActiveLinkColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_SearchBar;

                shareForm.detailPanel.BackgroundImage = Media_Distro.Properties.Resources.detailPanel_Meadow_BackGround;

                statsForm.pictureBox1.Image = Media_Distro.Properties.Resources.stats_background_green;
                statsForm.zoomInButton1.FillColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_Preference;
                statsForm.zoomOutButton1.FillColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_Preference;
                statsForm.resetChartButton.FillColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_Preference;
                statsForm.previousButton.FillColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_Preference;
                statsForm.nxtButton.FillColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_Preference;
                statsForm.cartInfoLabel.BackColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_TitleBar;
                statsForm.cartMovieLabel.BackColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_TitleBar;
                statsForm.cartMoviesExt.BackColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_TitleBar;
                statsForm.cartMusicLabel.BackColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_TitleBar;
                statsForm.cartMusicExt.BackColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_TitleBar;
                statsForm.cartSeriesLabel.BackColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_TitleBar;
                statsForm.cartSeriesExt.BackColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_TitleBar;
                statsForm.cartSentDateLabel.BackColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_TitleBar;
                statsForm.cartDateExt.BackColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_TitleBar;
                statsForm.cartPaidLabel.BackColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_TitleBar;
                statsForm.cartPaidExt.BackColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_TitleBar;

                Media_Distro.Properties.Settings.Default.Active_Theme_InfoPanel = libraryForm.genreTextBox.BackColor;
            }
            else if (Media_Distro.Properties.Settings.Default.Active_Theme_Preference == Media_Distro.Properties.Settings.Default.Dark_Theme_Preference)
            {
                minimizeButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Dark_Theme_WorkPlace;
                minimizeButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Dark_Theme_WorkPlace;

                homeForm.locateZipButton.FillColor = Media_Distro.Properties.Settings.Default.Dark_Theme_SearchBar;

                libraryForm.infoPanel.BackgroundImage = Media_Distro.Properties.Resources.infoPanel_DarkBackground;
                libraryForm.titleTextBox.BackColor = libraryForm.infoPanel.BackColor;
                libraryForm.genreTextBox.BackColor = Color.FromArgb(105, 105, 115);
                libraryForm.yearTextBox.BackColor = Color.FromArgb(105, 105, 115);
                libraryForm.ratingTextBox.BackColor = Color.FromArgb(105, 105, 115);
                libraryForm.cartButton.BackColor = Color.FromArgb(105, 105, 115);
                libraryForm.hideInfoButton.FillColor = Media_Distro.Properties.Settings.Default.Dark_Theme_Preference;
                libraryForm.hideInfoButton.Image = Media_Distro.Properties.Resources.Hide_Info_Dark_Icon;
                libraryForm.addSTCart.BackColor = Color.FromArgb(105, 105, 115);
                libraryForm.albumTreeView.BackColor = Color.FromArgb(105, 105, 115);
                libraryForm.pictureBox1.BackColor = Color.FromArgb(105, 105, 115);
                libraryForm.addSTCart.FillColor = Media_Distro.Properties.Settings.Default.Default_Theme_SearchBar;
                libraryForm.moreInfoLinkLabel.LinkColor = libraryForm.infoPanel.BackColor;
                libraryForm.moreInfoLinkLabel.ActiveLinkColor = Media_Distro.Properties.Settings.Default.Dark_Theme_SearchBar;
                settingsForm.updateLinkLabel.LinkColor = libraryForm.infoPanel.BackColor;
                settingsForm.updateLinkLabel.ActiveLinkColor = Media_Distro.Properties.Settings.Default.Dark_Theme_SearchBar;

                shareForm.detailPanel.BackgroundImage = Media_Distro.Properties.Resources.detailPanel_Dark_BackGround;

                statsForm.pictureBox1.Image = Media_Distro.Properties.Resources.stats_background_4;
                statsForm.zoomInButton1.FillColor = Media_Distro.Properties.Settings.Default.Dark_Theme_SearchBar;
                statsForm.zoomOutButton1.FillColor = Media_Distro.Properties.Settings.Default.Dark_Theme_SearchBar;
                statsForm.resetChartButton.FillColor = Media_Distro.Properties.Settings.Default.Dark_Theme_SearchBar;
                statsForm.previousButton.FillColor = Media_Distro.Properties.Settings.Default.Dark_Theme_SearchBar;
                statsForm.nxtButton.FillColor = Media_Distro.Properties.Settings.Default.Dark_Theme_SearchBar;
                statsForm.cartInfoLabel.BackColor = Color.FromArgb(115, 120, 125);
                statsForm.cartMovieLabel.BackColor = Color.FromArgb(115, 120, 125);
                statsForm.cartMoviesExt.BackColor = Color.FromArgb(115, 120, 125);
                statsForm.cartMusicLabel.BackColor = Color.FromArgb(115, 120, 125);
                statsForm.cartMusicExt.BackColor = Color.FromArgb(115, 120, 125);
                statsForm.cartSeriesLabel.BackColor = Color.FromArgb(115, 120, 125);
                statsForm.cartSeriesExt.BackColor = Color.FromArgb(115, 120, 125);
                statsForm.cartSentDateLabel.BackColor = Color.FromArgb(115, 120, 125);
                statsForm.cartDateExt.BackColor = Color.FromArgb(115, 120, 125);
                statsForm.cartPaidLabel.BackColor = Color.FromArgb(115, 120, 125);
                statsForm.cartPaidExt.BackColor = Color.FromArgb(115, 120, 125);

                Media_Distro.Properties.Settings.Default.Active_Theme_InfoPanel = libraryForm.genreTextBox.BackColor;
            }
            else if (Media_Distro.Properties.Settings.Default.Active_Theme_Preference == Media_Distro.Properties.Settings.Default.Twilight_Theme_Preference)
            {
                minimizeButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Twilight_Theme_Selected;
                minimizeButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Twilight_Theme_Selected;

                homeForm.locateZipButton.FillColor = Media_Distro.Properties.Settings.Default.Twilight_Theme_TitleBar;

                libraryForm.infoPanel.BackgroundImage = Media_Distro.Properties.Resources.infoPanel_TwilightBackground;
                libraryForm.titleTextBox.BackColor = libraryForm.infoPanel.BackColor;
                libraryForm.genreTextBox.BackColor = Color.FromArgb(60, 70, 100);
                libraryForm.yearTextBox.BackColor = Color.FromArgb(60, 70, 100);
                libraryForm.ratingTextBox.BackColor = Color.FromArgb(60, 70, 100);
                libraryForm.cartButton.BackColor = Color.FromArgb(60, 70, 100);
                libraryForm.hideInfoButton.FillColor = Media_Distro.Properties.Settings.Default.Twilight_Theme_Preference;
                libraryForm.hideInfoButton.Image = Media_Distro.Properties.Resources.Hide_Info_Twilight_Icon;
                libraryForm.addSTCart.BackColor = Color.FromArgb(60, 70, 100);
                libraryForm.albumTreeView.BackColor = Color.FromArgb(60, 70, 100);
                libraryForm.pictureBox1.BackColor = Color.FromArgb(60, 70, 100);
                libraryForm.addSTCart.FillColor = Media_Distro.Properties.Settings.Default.Twilight_Theme_Preference;
                libraryForm.moreInfoLinkLabel.LinkColor = libraryForm.infoPanel.BackColor;
                libraryForm.moreInfoLinkLabel.ActiveLinkColor = Media_Distro.Properties.Settings.Default.Twilight_Theme_SearchBar;
                settingsForm.updateLinkLabel.LinkColor = libraryForm.infoPanel.BackColor;
                settingsForm.updateLinkLabel.ActiveLinkColor = Media_Distro.Properties.Settings.Default.Twilight_Theme_SearchBar;

                shareForm.detailPanel.BackgroundImage = Media_Distro.Properties.Resources.detailPanel_Twilight_BackGround;

                statsForm.pictureBox1.Image = Media_Distro.Properties.Resources.stats_background_twilight;
                statsForm.zoomInButton1.FillColor = Media_Distro.Properties.Settings.Default.Twilight_Theme_Preference;
                statsForm.zoomOutButton1.FillColor = Media_Distro.Properties.Settings.Default.Twilight_Theme_Preference;
                statsForm.resetChartButton.FillColor = Media_Distro.Properties.Settings.Default.Twilight_Theme_Preference;
                statsForm.previousButton.FillColor = Media_Distro.Properties.Settings.Default.Twilight_Theme_Preference;
                statsForm.nxtButton.FillColor = Media_Distro.Properties.Settings.Default.Twilight_Theme_Preference;
                statsForm.cartInfoLabel.BackColor = Color.FromArgb(60, 95, 155);
                statsForm.cartMovieLabel.BackColor = Color.FromArgb(60, 95, 155);
                statsForm.cartMoviesExt.BackColor = Color.FromArgb(60, 95, 155);
                statsForm.cartMusicLabel.BackColor = Color.FromArgb(60, 95, 155);
                statsForm.cartMusicExt.BackColor = Color.FromArgb(60, 95, 155);
                statsForm.cartSeriesLabel.BackColor = Color.FromArgb(60, 95, 155);
                statsForm.cartSeriesExt.BackColor = Color.FromArgb(60, 95, 155);
                statsForm.cartSentDateLabel.BackColor = Color.FromArgb(60, 95, 155);
                statsForm.cartDateExt.BackColor = Color.FromArgb(60, 95, 155);
                statsForm.cartPaidLabel.BackColor = Color.FromArgb(60, 95, 155);
                statsForm.cartPaidExt.BackColor = Color.FromArgb(60, 95, 155);

                Media_Distro.Properties.Settings.Default.Active_Theme_InfoPanel = libraryForm.genreTextBox.BackColor;
            }
                
            shareForm.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
            shareForm.cartsSelected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            shareForm.cartsButton.ForeColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            shareForm.progressSelected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            shareForm.panel1.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
            shareForm.detailPanel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
            shareForm.detailListView.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
            shareForm.deviceList.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;

            settingsForm.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
            settingsForm.priceSetting.UpDownButtonFillColor = Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar;
            settingsForm.movieURLCollectionButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            settingsForm.musicURLCollectionButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            settingsForm.seriesURLCollectionButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;

            homeForm.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
            homeForm.goLeftButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            homeForm.goRightButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            homeForm.goLeftButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            homeForm.goRightButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;

            statsForm.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
        }

        private void searchPanel_Leave(object sender, EventArgs e)
        {
            searchTextBox.Clear();
            resultPanel.Controls.Clear();
            if (!searchTextBox.Focused)
            {
                searchPanel.Visible = false;
                pictureBox2.Visible = false;
            }
            
        }

        private void sharesubMenu_Paint(object sender, PaintEventArgs e)
        {
            if (completedTasks > 0)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(Brushes.Gray, 33, 25, 15, 15);
                e.Graphics.DrawString(completedTasks.ToString(), new Font("Microsoft JhengHei", 8), Brushes.Black, new PointF(36, 26));
            }
        }

        private void submitActiButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog keyCodeZip = new OpenFileDialog();
            DialogResult result =  keyCodeZip.ShowDialog();
            string keyFilePath = Combine(adFolder, "LK");
            string key;

            keyCodeZip.Filter = "All Files (*.*)| *.*";
            keyCodeZip.Title = "Setting Activation Code";

            if(result == DialogResult.OK)
            {
                ZipFile.ExtractToDirectory(keyCodeZip.FileName, adFolder);
                activationTextBox.Text = keyCodeZip.FileName;
                key = File.ReadAllLines(keyFilePath)[0];

                if (key == GenerateKeyAlgorithm(key[0]) && key != Media_Distro.Properties.Settings.Default.activationKey)
                {
                    Media_Distro.Properties.Settings.Default.activationKey = key;
                    Media_Distro.Properties.Settings.Default.expirationDate = DateTime.Now.AddDays(7d);
                    StreamWriter dateCheckFile = File.CreateText(Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "akf"));
                    dateCheckFile.WriteLine(Media_Distro.Properties.Settings.Default.expirationDate.ToString());
                    dateCheckFile.Close();

                    newCartToolStripButton.Enabled = true;
                    cartsToolStripSplitButton.Enabled = true;
                    activationPanel.Visible = false;
                    sharesubMenu.Enabled = true;

                    Media_Distro.Properties.Settings.Default.Save();
                }
                else
                    MessageBox.Show("The activation code is invalid. Retrieve the code from the bot and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                File.Delete(keyFilePath);
                File.Delete(keyCodeZip.FileName);
            }
        }

        public static string GenerateKeyAlgorithm(char arbitChar = ' ')
        {
            List<char> letters = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            List<char> numbers = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            List<char> generatedKey = new List<char>() { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            string key = "";

            char firstChar;
            int emptySpaces = 9;
            Random randNum = new Random();

            while(key == "")
            {
                try
                {
                    if (arbitChar == ' ')
                        generatedKey[0] = firstChar = letters[randNum.Next(letters.Count)];
                    else
                        generatedKey[0] = firstChar = (letters.Contains(arbitChar)) ? arbitChar : ' ';

                    if (firstChar == ' ')
                        return "";

                    generatedKey[3] = letters[((letters.IndexOf(firstChar) + 4) * 8 % 26) - 1];
                    generatedKey[6] = letters[((letters.IndexOf(firstChar) + 7) * 7 % 26) - 1];
                    emptySpaces -= 3;

                    for (int i = 0; i < generatedKey.Count; i++)
                    {
                        char character;
                        int index;

                        if (generatedKey[i] != ' ')
                        {
                            index = (((letters.IndexOf(generatedKey[i]) + 1) * emptySpaces) % 26);
                            character = (index > 0) ? letters[index - 1] : letters[index];
                            generatedKey[i + 1] = (!generatedKey.Contains(character)) ? character : char.ToLower(character);
                            i++;
                        }
                        else
                        {
                            index = (((letters.IndexOf(generatedKey[i - 1]) + 1) * emptySpaces) % 9);
                            generatedKey[i] = (index > 0) ? numbers[index - 1] : numbers[index];
                        }

                        emptySpaces--;
                    }

                    foreach (char c in generatedKey)
                        key += c;
                }
                catch (Exception)
                {  }
            }

            return key;
        }

        private void movieCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (movieCheckBox.Checked)
                catalogues.Add(movieCatalogue);
            else
                catalogues.Remove(movieCatalogue);

            resultPanel.Controls.Clear();

            searchTask = new Task(() => searchT());
            searchTask.Start();
        }

        private void musicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (musicCheckBox.Checked)
                catalogues.Add(musicCatalogue);
            else
                catalogues.Remove(musicCatalogue);

            resultPanel.Controls.Clear();

            searchTask = new Task(() => searchT());
            searchTask.Start();
        }

        private void seriesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (seriesCheckBox.Checked)
                catalogues.Add(seriesCatalogue);
            else
                catalogues.Remove(seriesCatalogue);

            resultPanel.Controls.Clear();

            searchTask = new Task(() => searchT());
            searchTask.Start();
        }

        private void shareToolStripSplitButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DriveInfo usbStorage = new DriveInfo(e.ClickedItem.Tag.ToString());
            CartManager cart = (CartManager)cartLabel.Tag;

            try
            {
                if (cart != null && !cart.IsEmpty() && usbStorage.AvailableFreeSpace > cart.cartSize)
                {
                    shareForm.progressListView.Add(cart, cartLabel.Text, usbStorage);
                    shareForm.tasks++;
                    shareForm.sharePanel.Refresh();
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                if (cart == null)
                    MessageBox.Show("There are currenlty no carts. Go ahead and create a new cart.", "No Carts Exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (cart.IsEmpty())
                    MessageBox.Show("Cart is currently empty. Go to the library and pick some stuff up.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (usbStorage.AvailableFreeSpace < cart.cartSize)
                    MessageBox.Show("There is no available space in the storage device.", "Low Available Storage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void mediaDistroFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsUpdating)
            {
                ProcessStartInfo info = new ProcessStartInfo(Combine(GetCurrentDirectory(), "Updater.exe"));
                info.UseShellExecute = true;
                info.Verb = "runas";
                Process.Start(info);
            }
        }
    }
}
 