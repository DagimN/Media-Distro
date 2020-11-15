using System;
using System.IO;
using static System.IO.Path;
using static System.IO.Directory;
using static System.Environment;
using static Mobile_Service_Distribution.LibraryManager;
using Mobile_Service_Distribution.Managers;
using Media_Distro;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Mobile_Service_Distribution.Forms;


namespace Mobile_Service_Distribution
{
    public partial class mediaDistroFrame : Form
    {
        private readonly FormWindowState state = FormWindowState.Normal;
        private Point startPoint = new Point(0, 0);
        private Task searchTask;
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
        private static FileStream statsFile;

        public ArrayList movieDir;
        public ArrayList musicDir;
        public ArrayList seriesDir;
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

                using (Form introForm = new Form())
                {
                    Label logoLabel = new Label();
                    Label descriptionLabel = new Label();
                    Label movieLabel = new Label();
                    Label musicLabel = new Label();
                    Label seriesLabel = new Label();

                    TextBox movieURL = new TextBox();
                    TextBox musicURL = new TextBox();
                    TextBox seriesURL = new TextBox();

                    Button movieBrowseButton = new Button();
                    Button musicBrowseButton = new Button();
                    Button seriesBrowseButton = new Button();
                    Button continueButton = new Button();
                    Button closeButton = new Button();
                    introForm.SuspendLayout();

                    //Labels

                    logoLabel.Location = new Point(9, 3);
                    logoLabel.Size = new Size(395, 60);
                    logoLabel.Text = "Media Distro";
                    logoLabel.Font = new Font("Microsoft JhengHei", 36);
                    logoLabel.ForeColor = Color.FromArgb(112, 112, 112);

                    descriptionLabel.Location = new Point(9, 83);
                    descriptionLabel.Text = "Fill in the following media's URL location.";
                    descriptionLabel.Font = new Font("Segoe UI", 9);
                    descriptionLabel.Size = new Size(300, 15);

                    movieLabel.Location = new Point(30, 115);
                    movieLabel.Size = new Size(56, 21);
                    movieLabel.Text = "Movies";
                    movieLabel.Font = new Font("Segoe UI", 9);

                    musicLabel.Location = new Point(30, 152);
                    musicLabel.Size = new Size(56, 21);
                    musicLabel.Text = "Music";
                    musicLabel.Font = new Font("Segoe UI", 9);

                    seriesLabel.Location = new Point(30, 189);
                    seriesLabel.Size = new Size(56, 21);
                    seriesLabel.Text = "Series";
                    seriesLabel.Font = new Font("Segoe UI", 9);

                    //TextBoxs

                    movieURL.Location = new Point(95, 115);
                    movieURL.Size = new Size(303, 100);
                    movieURL.Font = new Font("Segoe UI", 10);
                    movieURL.ReadOnly = true;

                    musicURL.Location = new Point(95, 152);
                    musicURL.Size = new Size(303, 100);
                    musicURL.Font = new Font("Segoe UI", 10);
                    musicURL.ReadOnly = true;

                    seriesURL.Location = new Point(95, 189);
                    seriesURL.Size = new Size(303, 100);
                    seriesURL.Font = new Font("Segoe UI", 10);
                    seriesURL.ReadOnly = true;

                    //Buttons

                    closeButton.Location = new Point(594, 0);
                    closeButton.Size = new Size(36, 34);
                    closeButton.Click += new EventHandler(closeButton_Click);

                    movieBrowseButton.Location = new Point(400, 115);
                    movieBrowseButton.Size = new Size(50, 20);
                    movieBrowseButton.Text = "Browse";
                    movieBrowseButton.Click += browseButton_Click;

                    musicBrowseButton.Location = new Point(400, 152);
                    musicBrowseButton.Size = new Size(50, 20);
                    musicBrowseButton.Text = "Browse";
                    musicBrowseButton.Click += browseButton_Click;

                    seriesBrowseButton.Location = new Point(400, 189);
                    seriesBrowseButton.Size = new Size(50, 20);
                    seriesBrowseButton.Text = "Browse";
                    seriesBrowseButton.Click += browseButton_Click;

                    continueButton.Location = new Point(541, 294);
                    continueButton.Size = new Size(78, 23);
                    continueButton.Text = "Continue";
                    continueButton.Enabled = false;
                    continueButton.Click += continueButton_Click;

                    //Form

                    introForm.Size = new Size(630, 330);
                    introForm.FormBorderStyle = FormBorderStyle.None;

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
                        introForm.Close();
                    }
                }
            } 
            
            InitializeComponent();

            if (!Exists(mediaFolder)) CreateDirectory(mediaFolder);
            if (!Exists(movieFolder)) CreateDirectory(movieFolder);
            if (!Exists(seriesFolder)) CreateDirectory(seriesFolder);
            if (!Exists(musicFolder)) CreateDirectory(musicFolder);
            if(!File.Exists(statsFileURL))
            {
                statsFile = new FileStream(statsFileURL, FileMode.Create, FileAccess.ReadWrite);
                statsFile.Close();
            }
                

            movieDir = new ArrayList();
            musicDir = new ArrayList();
            seriesDir = new ArrayList();

            foreach(string dir in Media_Distro.Properties.Settings.Default.Movie_Media_Location)
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

            foreach(string dir in Media_Distro.Properties.Settings.Default.Series_Media_Location)
                foreach (string subDir in GetDirectories(dir)) 
                    seriesDir.Add(subDir);

            foreach(string dir in Media_Distro.Properties.Settings.Default.Music_Media_Location)
            {
                foreach (string file in GetFiles(dir))
                    if (GetExtension(file) == ".mp3" || GetExtension(file) == ".m4a" || GetExtension(file) == ".webm" || 
                        GetExtension(file) == ".wv" || GetExtension(file) == ".wma" || GetExtension(file) == ".wav" || 
                        GetExtension(file) == ".m4b" || GetExtension(file) == ".m4p")
                            musicDir.Add(file);

                RetrieveMediaDirectories(dir, musicDir, this);
            }

            foreach(string dir in movieDir) { ManageMediaReference(dir, MediaType.Movie, GetFileNameWithoutExtension(dir)); }
            foreach (object dir in musicDir)
            {
                if (dir is string)
                    ManageMediaReference((string)dir, MediaType.Music, GetFileNameWithoutExtension((string)dir));
                else if (dir is ArrayList)
                    ManageMediaReference((ArrayList)dir);
            }
            foreach (string dir in seriesDir) { ManageMediaReference(dir, MediaType.Series, GetFileName(dir)); }


            libraryForm = new LibraryForm(this);
            homeForm = new HomeForm(this);
            statsForm = new StatsForm();
            shareForm = new ShareForm(this, homeForm, statsForm);
            settingsForm = new SettingsForm(shareForm.progressListView);

            openChildForm(statsForm);
            openChildForm(homeForm);
            activeButton = homeSubMenu;
            activeButton.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
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
                                    ListViewItem usbDrive = new ListViewItem 
                                    {
                                        Text = usbStorage.VolumeLabel + " " + usbStorage.Name,
                                        Tag = usbStorage.Name,
                                        ImageIndex = 2
                                    };

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

                            break;
                    }

                    break;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
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
                this.sideMenuPanel.SetBounds(0, 0, 52, 482);
                this.workPanel.SetBounds(52, 30, 750, 452);
                this.activeForm.SetBounds(0, 0, 750, 452);
                this.cartToolStrip.Location = new Point(58, 5);
                this.pictureBox1.Location = new Point(58, 27);

                this.homeForm.panel1.Refresh();
                this.homeForm.popularNowPanel.Width = 531;
                this.homeForm.goRightButton.Location = new Point(577, 274);
                this.homeForm.adsPanel.Location = new Point(611, 230);
                this.homeForm.taskPieChart.Location = new Point(544, 3);
                this.homeForm.tempPieChart.Location = new Point(544, 3);
                this.homeForm.volumeLabel.Location = new Point(608, 106);

                if (this.libraryForm.infoPanel.Visible) this.libraryForm.infoPanel.Visible = false;
                this.libraryForm.libraryPanel.SetBounds(12, 12, 725, 431);
                this.libraryForm.infoPanel.SetBounds(0, 306, 750, 146);

                this.shareForm.devicePanel.SetBounds(10, 12, 725, 177);
                this.shareForm.sharePanel.SetBounds(10, 195, 725, 245);
                this.shareForm.noCartLabel.Location = new Point(166, 51);

                this.statsForm.panel1.Location = new Point(558, 0);
                this.statsForm.descriptionLabel.Size = new Size(537, 35);
                this.statsForm.summaryChart.Size = new Size(540, 314);

                this.settingsForm.splitContainer1.SetBounds(0, 0, 750, 452);

            }
            else
            {
                this.sideMenuPanel.SetBounds(0, 0, 235, 482);
                this.workPanel.SetBounds(235, 30, 567, 452);
                this.activeForm.SetBounds(0, 0, 567, 452);
                this.cartToolStrip.Location = new Point(238, 5);
                this.pictureBox1.Location = new Point(238, 27);

                this.homeForm.panel1.Refresh();
                this.homeForm.popularNowPanel.Width = 347;
                this.homeForm.goRightButton.Location = new Point(393, 274);
                this.homeForm.adsPanel.Location = new Point(427, 230);
                this.homeForm.taskPieChart.Location = new Point(360, 3);
                this.homeForm.tempPieChart.Location = new Point(360, 3);
                this.homeForm.volumeLabel.Location = new Point(424, 106);

                if (this.libraryForm.infoPanel.Visible) this.libraryForm.infoPanel.Visible = false;
                this.libraryForm.libraryPanel.SetBounds(12, 12, 546, 431);
                this.libraryForm.infoPanel.SetBounds(0, 306, 567, 146);

                this.shareForm.devicePanel.SetBounds(10, 12, 545, 177);
                this.shareForm.sharePanel.SetBounds(10, 195, 545, 245);
                this.shareForm.noCartLabel.Location = new Point(66, 51);

                this.statsForm.panel1.Location = new Point(374, 0);
                this.statsForm.descriptionLabel.Size = new Size(353, 35);
                this.statsForm.summaryChart.Size = new Size(356, 314);

                this.settingsForm.splitContainer1.SetBounds(0, 0, 567, 452);
            }
        }

        private void searchTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            if(searchTextBox.Text == "Search")
                searchTextBox.Clear();
    
            searchTextBox.ForeColor = Color.Black;
            searchTextBox.BackColor = SystemColors.Window;
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            searchTextBox.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar;
            searchTextBox.ForeColor = Color.FromArgb(180, 180, 180);
            if((!searchPanel.ContainsFocus && !searchButton.ContainsFocus) || searchTextBox.Text == "")
            {
                searchTextBox.Text = "Search";
                resultPanel.Controls.Clear();
                searchPanel.Visible = false;
                pictureBox2.Visible = false;
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
                        Image = Image.FromFile(Combine(GetFolderPath(SpecialFolder.MyDocuments), "Euphoria Games", "Add Media Icon.png"))
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
            if (searchTextBox.Text != "" && searchTextBox.Text != "Search")
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
            if (e.KeyChar == (char)Keys.Enter && searchTextBox.Text != "Search" && searchTextBox.Text != "")
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
            
            activeForm = childForm;
            activeForm.TopLevel = false;
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
            shareForm.Focus();
            
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
                cartLabel.BackColor = Color.FromArgb(18, 32, 86);
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
            cartLabelEdit.SetBounds(cartToolStrip.Location.X + 60, cartToolStrip.Location.Y + 2, cartLabel.Width, cartLabel.Height);
            cartLabelEdit.Visible = true;
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

                cartLabel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
            } 
        }

        private void cartLabel_MouseHover(object sender, EventArgs e)
        {
            cartLabel.BackColor = Color.FromArgb(18, 32, 70);
        }

        private void cartLabel_MouseLeave(object sender, EventArgs e)
        {
            cartLabel.BackColor = Color.FromArgb(18, 32, 86);
        }

        private void cartLabelEdit_Leave(object sender, EventArgs e)
        {
            cartLabelEdit.Visible = false;
            cartLabel.Visible = true;
            cartLabel.BackColor = Color.FromArgb(18, 32, 86);
        }

        private void sideMenuPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (cartLabelEdit.Visible)
            {
                cartLabelEdit.Visible = false;
                cartLabel.Visible = true;
                cartLabel.BackColor = Color.FromArgb(18, 32, 86);
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

            libraryForm.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
            libraryForm.moviesTabButton.ForeColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
            libraryForm.moviesSelected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;

            shareForm.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
            shareForm.cartsSelected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            shareForm.cartsButton.ForeColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            shareForm.progressSelected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            shareForm.panel1.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;

            settingsForm.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;

            homeForm.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
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
    }
}
 