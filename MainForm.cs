﻿using System;
using System.IO;
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

namespace Mobile_Service_Distribution
{
    public partial class mediaDistroFrame : Form
    {
        private readonly FormWindowState state = FormWindowState.Normal;
        private Point startPoint = new Point(0, 0);
        private Task searchTask;
        private Task manageMediaTask;
        private Button activeButton;
        public ListViewItem activeItem = null;

        private bool drag = false;
        private bool movieBool = false;
        private bool musicBool = false;
        private bool seriesBool = false;

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
            if(Media_Distro.Properties.Settings.Default.Movie_Media_Location == null &
                Media_Distro.Properties.Settings.Default.Music_Media_Location == null &
                Media_Distro.Properties.Settings.Default.Series_Media_Location == null)
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

                    Label logoLabel = new Label
                    {
                        Location = new Point(9, 3),
                        Size = new Size(395, 60),
                        Text = "Media Distro",
                        Font = new Font("Microsoft JhengHei", 36),
                        ForeColor = Color.FromArgb(112, 112, 112) 
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

                    Label getLabel = new Label
                    {
                        Location = new Point(231, 267),
                        AutoSize = true,
                        Text = "Gathering all media in selected folders. This will take a few minutes...",
                        Font = new Font("Microsoft JhengHei", 9),
                        Visible = false
                    };

                    //TextBoxes

                    TextBox movieURL = new TextBox
                    {
                        Location = new Point(95, 115),
                        Size = new Size(303, 100),
                        Font = new Font("Microsoft JhengHei", 10),
                        ReadOnly = true
                    };

                    TextBox musicURL = new TextBox
                    {
                        Location = new Point(95, 152),
                        Size = new Size(303, 100),
                        Font = new Font("Microsoft JhengHei", 10),
                        ReadOnly = true
                    };

                    TextBox seriesURL = new TextBox
                    {
                        Location = new Point(95, 189),
                        Size = new Size(303, 100),
                        Font = new Font("Microsoft JhengHei", 10),
                        ReadOnly = true
                    };

                    //Buttons

                    Button movieBrowseButton = new Button
                    {
                        Location = new Point(400, 115),
                        Size = new Size(50, 20),
                        Text = "Browse"
                    };
                    
                    Button musicBrowseButton = new Button
                    {
                        Location = new Point(400, 152),
                        Size = new Size(50, 20),
                        Text = "Browse"
                    };
                    
                    Button seriesBrowseButton = new Button
                    {
                        Location = new Point(400, 189),
                        Size = new Size(50, 20),
                        Text = "Browse"
                    };
                    
                    Button continueButton = new Button
                    {
                        Location = new Point(541, 294),
                        Size = new Size(78, 23),
                        Text = "Continue",
                        Enabled = false
                    };
                    
                    Button closeButton = new Button
                    {
                        Location = new Point(594, 0),
                        Size = new Size(36, 34)
                    };

                    movieBrowseButton.Click += browseButton_Click;
                    musicBrowseButton.Click += browseButton_Click;
                    seriesBrowseButton.Click += browseButton_Click;
                    continueButton.Click += continueButton_Click;
                    closeButton.Click += closeButton_Click;

                    //Form

                    introForm.Size = new Size(630, 330);
                    introForm.FormBorderStyle = FormBorderStyle.None;

                    introForm.Controls.Add(logoLabel);
                    introForm.Controls.Add(descriptionLabel);
                    introForm.Controls.Add(movieLabel);
                    introForm.Controls.Add(musicLabel);
                    introForm.Controls.Add(seriesLabel);
                    introForm.Controls.Add(getLabel);
                    introForm.Controls.Add(movieURL);
                    introForm.Controls.Add(musicURL);
                    introForm.Controls.Add(seriesURL);
                    introForm.Controls.Add(closeButton);
                    introForm.Controls.Add(movieBrowseButton);
                    introForm.Controls.Add(musicBrowseButton);
                    introForm.Controls.Add(seriesBrowseButton);
                    introForm.Controls.Add(continueButton);

                    introForm.ResumeLayout();
                    Application.Run(introForm);

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

                        Media_Distro.Properties.Settings.Default.Save();

                        folderBrowser.Dispose();

                        if (movieURL.Lines.Length > 0 && musicURL.Lines.Length > 0 && seriesURL.Lines.Length > 0)
                        {
                            continueButton.Enabled = true;
                        }   
                    }

                    void continueButton_Click(object sender, EventArgs e)
                    {
                        manageMediaTask = new Task(() => ManageMedia());
                        manageMediaTask.Start();

                        continueButton.Enabled = false;
                        getLabel.Visible = true;

                        manageMediaTask.Wait();
                        introForm.Close();
                    }
                }
            } 
            
            InitializeComponent();

            if (!Exists(mediaFolder)) CreateDirectory(mediaFolder).Attributes = FileAttributes.Hidden;
            if (!Exists(movieFolder)) CreateDirectory(movieFolder);
            if (!Exists(seriesFolder)) CreateDirectory(seriesFolder);
            if (!Exists(musicFolder)) CreateDirectory(musicFolder);

            if(!File.Exists(statsFileURL))
            {
                statsFile = new FileStream(statsFileURL, FileMode.Create, FileAccess.ReadWrite);
                statsFile.Close();
            }

            manageMediaTask = new Task(() => ManageMedia());
            manageMediaTask.Start();

            libraryForm = new LibraryForm(this);
            statsForm = new StatsForm();
            homeForm = new HomeForm(this);
            shareForm = new ShareForm(this, homeForm, statsForm);
            settingsForm = new SettingsForm(shareForm.progressListView, this, homeForm, libraryForm, shareForm, statsForm);

            PropertyInfo workPanelType = workPanel.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            workPanelType.SetValue(workPanel, true, null);
            PropertyInfo sidePanelType = sideMenuPanel.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            sidePanelType.SetValue(sideMenuPanel, true, null);

            openChildForm(statsForm);
            openChildForm(homeForm);
            activeButton = homeSubMenu;
            activeButton.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;

            if(Media_Distro.Properties.Settings.Default.activationKey.Length < 1 || 
                Media_Distro.Properties.Settings.Default.expirationDate.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                newCartToolStripButton.Enabled = false;
                cartsToolStripSplitButton.Enabled = false;
                activationPanel.Visible = true;
                sharesubMenu.Enabled = false;
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
                                        }
                                    }
                                    
                                }
                            }

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
                            }
                            else
                            {
                                foreach (DriveInfo usbStorage in DriveInfo.GetDrives())
                                {
                                    if (usbStorage.IsReady && usbStorage.DriveType == DriveType.Removable)
                                    {
                                        foreach (ListViewItem usbName in shareForm.deviceList.Items)
                                        {
                                            if (usbName.Text == usbStorage.Name) continue;
                                            else
                                            {
                                                shareForm.deviceList.Items.Remove(usbName);
                                                break;
                                            } 
                                                

                                        }

                                        foreach (ToolStripItem usbName in shareForm.sendToToolStripMenuItem.DropDownItems)
                                        {
                                            if (usbName.Text == usbStorage.Name) continue;
                                            else
                                            {
                                                shareForm.sendToToolStripMenuItem.DropDownItems.Remove(usbName);
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
                this.searchPanel.Location = new Point(358, -1);
                
                this.cartToolStrip.Location = new Point(58, 5);
                this.pictureBox1.Location = new Point(58, 27);

                this.homeForm.dashBoardPanel.Refresh();
                this.homeForm.Size = new Size(751, 452);
                this.homeForm.popularNowPanel.Width = 531;
                this.homeForm.goRightButton.Location = new Point(577, 267);
                this.homeForm.adsPanel.Location = new Point(611, 230);
                this.homeForm.taskPieChart.Location = new Point(544, 3);
                this.homeForm.tempPieChart.Location = new Point(544, 3);
                this.homeForm.volumeLabel.Location = new Point(608, 106);

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
            }
            else
            {
                this.sideMenuPanel.Size = new Size(235, 482);
                this.activeForm.SetBounds(0, 0, 567, 452);
                this.workPanel.SetBounds(235, 30, 567, 452);
                this.searchPanel.Location = new Point(175, -1);

                this.cartToolStrip.Location = new Point(238, 5);
                this.pictureBox1.Location = new Point(238, 27);

                this.homeForm.dashBoardPanel.Refresh();
                this.homeForm.Size = new Size(567, 452);
                this.homeForm.popularNowPanel.Width = 347;
                this.homeForm.goRightButton.Location = new Point(393, 267);
                this.homeForm.adsPanel.Location = new Point(427, 230);
                this.homeForm.taskPieChart.Location = new Point(360, 3);
                this.homeForm.tempPieChart.Location = new Point(360, 3);
                this.homeForm.volumeLabel.Location = new Point(424, 106);

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
            }
        }

        private void ManageMedia()
        {
            foreach (string dir in Media_Distro.Properties.Settings.Default.Movie_Media_Location)
            {
                foreach (string file in GetFiles(dir))
                    if (GetExtension(file) == ".mp4" || GetExtension(file) == ".mkv" || GetExtension(file) == ".avi" ||
                            GetExtension(file) == ".flv" || GetExtension(file) == ".wmv" || GetExtension(file) == ".f4v" ||
                            GetExtension(file) == ".f4p" || GetExtension(file) == ".f4a" || GetExtension(file) == ".f4b" ||
                            GetExtension(file) == ".3gp" || GetExtension(file) == ".m4v" || GetExtension(file) == ".mpeg" ||
                            GetExtension(file) == ".mpg" || GetExtension(file) == ".mov" || GetExtension(file) == ".qt")
                        movieDir.Add(file);

                RetrieveMediaDirectories(dir, movieDir, this);
            }

            foreach (string dir in Media_Distro.Properties.Settings.Default.Series_Media_Location)
                foreach (string subDir in GetDirectories(dir))
                    seriesDir.Add(subDir);

            foreach (string dir in Media_Distro.Properties.Settings.Default.Music_Media_Location)
            {
                foreach (string file in GetFiles(dir))
                    if (GetExtension(file) == ".mp3" || GetExtension(file) == ".m4a" || GetExtension(file) == ".webm" ||
                        GetExtension(file) == ".wv" || GetExtension(file) == ".wma" || GetExtension(file) == ".wav" ||
                        GetExtension(file) == ".m4b" || GetExtension(file) == ".m4p" || GetExtension(file) == ".aac")
                        musicDir.Add(file);

                RetrieveMediaDirectories(dir, musicDir, this);
            }

            foreach (string dir in movieDir) { ManageMediaReference(dir, MediaType.Movie, GetFileNameWithoutExtension(dir)); }
            foreach (string dir in seriesDir) { ManageMediaReference(dir, MediaType.Series, GetFileName(dir)); }
            foreach (object dir in musicDir)
            {
                if (dir is string)
                    ManageMediaReference((string)dir, MediaType.Music, GetFileNameWithoutExtension((string)dir));
                else if (dir is ArrayList)
                    ManageMediaReference((ArrayList)dir);
            }
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
                        Image = (media.CoverArtDirectory != "") ? Image.FromFile(media.CoverArtDirectory) : null,
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
                        Image = Image.FromFile(Combine(GetFolderPath(SpecialFolder.MyDocuments), "Euphoria Games", "Software", "Form Designs","Add Media Icon.png"))
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
            if (e.KeyChar == (char)Keys.Enter && searchTextBox.Text != "")
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
                Location = new Point(cartToolStrip.Location.X + 64, cartToolStrip.Location.Y + 2),
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

            homeForm.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
            homeForm.goLeftButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            homeForm.goRightButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            homeForm.goLeftButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
            homeForm.goRightButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;

            statsForm.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
        }

        private void searchPanel_Leave(object sender, EventArgs e)
        {
            searchTextBox.Text = "Search";
            resultPanel.Controls.Clear();
            if (!searchTextBox.Focused)
            {
                searchPanel.Visible = false;
                pictureBox2.Visible = false;
            }
            
        }

        private void seriesFilter_Click(object sender, EventArgs e)
        {
            seriesBool = !seriesBool;
            if (seriesBool)
            {
                catalogues.Add(seriesCatalogue);
                seriesFilter.BackColor = SystemColors.WindowFrame;
            }
            else
            {
                catalogues.Remove(seriesCatalogue);
                seriesFilter.BackColor = SystemColors.Control;
            }
                
            resultPanel.Controls.Clear();

            searchTask = new Task(() => searchT());
            searchTask.Start();
        }

        private void musicFilter_Click(object sender, EventArgs e)
        {
            musicBool = !musicBool;
            if (musicBool)
            {
                catalogues.Add(musicCatalogue);
                musicFilter.BackColor = SystemColors.WindowFrame;
            }
            else
            {
                catalogues.Remove(musicCatalogue);
                musicFilter.BackColor = SystemColors.Control;
            }
                
            resultPanel.Controls.Clear();

            searchTask = new Task(() => searchT());
            searchTask.Start();
        }

        private void movieFilter_Click(object sender, EventArgs e)
        {
            movieBool = !movieBool;
            if (movieBool)
            {
                catalogues.Add(movieCatalogue);
                movieFilter.BackColor = SystemColors.WindowFrame;
            }
            else
            {
                catalogues.Remove(movieCatalogue);
                movieFilter.BackColor = SystemColors.Control;
            }
                
            resultPanel.Controls.Clear();

            searchTask = new Task(() => searchT());
            searchTask.Start();
        }

        private void sharesubMenu_Paint(object sender, PaintEventArgs e)
        {
            if (completedTasks != 0)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillEllipse(Brushes.Gray, 33, 25, 15, 15);
                e.Graphics.DrawString(completedTasks.ToString(), new Font("Microsoft JhengHei", 8), Brushes.Black, new PointF(36, 26));
            }
        }

        private void submitActiButton_Click(object sender, EventArgs e)
        {

        }
    }
}
 