﻿using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using static System.IO.Path;
using static System.Environment;
using static System.IO.Directory;
using System.IO.Compression;
using System.IO;
using static Mobile_Service_Distribution.LibraryManager;
using System.Windows.Forms;


namespace Mobile_Service_Distribution.Forms
{
    public partial class SettingsForm : Form
    {
        private bool OnMovie = true, OnMusic = false, OnSeries = false;
        private Media_Distro.ProgressListView reference;
        private mediaDistroFrame mainRef;
        private HomeForm hRef;
        private LibraryForm libRef;
        private ShareForm shRef;
        private StatsForm stRef;

        public SettingsForm(Media_Distro.ProgressListView reference, mediaDistroFrame mainRef, HomeForm hRef ,LibraryForm libRef, ShareForm shRef, StatsForm stRef)
        {
            InitializeComponent();
          
            this.reference = reference;
            this.mainRef = mainRef;
            this.libRef = libRef;
            this.shRef = shRef;
            this.stRef = stRef;
            this.hRef = hRef;

            assemblyLabel.Text = typeof(mediaDistroFrame).Assembly.GetName().Version.ToString();

            if (Media_Distro.Properties.Settings.Default.bonusAvailable)
                bonusButton.Visible = true;
            else
                bonusButton.Visible = false;
        }

        private void addURLButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                urlPathListBox.Items.Add(folderBrowser.SelectedPath);

                if (OnMovie) Media_Distro.Properties.Settings.Default.Movie_Media_Location.Add(folderBrowser.SelectedPath);
                else if (OnMusic) Media_Distro.Properties.Settings.Default.Music_Media_Location.Add(folderBrowser.SelectedPath);
                else if (OnSeries) Media_Distro.Properties.Settings.Default.Series_Media_Location.Add(folderBrowser.SelectedPath);

                Media_Distro.Properties.Settings.Default.Save();
                fileLoadLabel.Visible = true;
            }
                
            folderBrowser.Dispose();
            urlPathListBox.Focus();
        }

        private void movieURLCollectionButton_Click(object sender, EventArgs e)
        {
            OnMovie = true;
            OnMusic = false;
            OnSeries = false;
            urlPathListBox.Items.Clear();

            foreach (string url in Media_Distro.Properties.Settings.Default.Movie_Media_Location)
                urlPathListBox.Items.Add(url);

            priceSettingLabel.Text = "Price Per Movie";
            priceSetting.Value = Media_Distro.Properties.Settings.Default.moviePrice;
            urlPathListBox.Focus();
        }

        private void musicURLCollectionButton_Click(object sender, EventArgs e)
        {
            OnMovie = false;
            OnMusic = true;
            OnSeries = false;
            urlPathListBox.Items.Clear();

            foreach (string url in Media_Distro.Properties.Settings.Default.Music_Media_Location)
                urlPathListBox.Items.Add(url);

            priceSettingLabel.Text = "Price Per Music";
            priceSetting.Value = Media_Distro.Properties.Settings.Default.musicPrice;
            urlPathListBox.Focus();
        }

        private void seriesURLCollectionButton_Click(object sender, EventArgs e)
        {
            OnMovie = false;
            OnMusic = false;
            OnSeries = true;
            urlPathListBox.Items.Clear();

            foreach (string url in Media_Distro.Properties.Settings.Default.Series_Media_Location)
                urlPathListBox.Items.Add(url);

            priceSettingLabel.Text = "Price Per Episode";
            priceSetting.Value = Media_Distro.Properties.Settings.Default.seriesPrice;
            urlPathListBox.Focus();
        }

        private void defaultColor_Click(object sender, EventArgs e)
        {
            Color[] themePreferencePackage = new Color[] { Media_Distro.Properties.Settings.Default.Default_Theme_Preference,
                                                           Media_Distro.Properties.Settings.Default.Default_Theme_SearchBar,
                                                           Media_Distro.Properties.Settings.Default.Default_Theme_Selected,
                                                           Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar,
                                                           Media_Distro.Properties.Settings.Default.Default_Theme_WorkPlace};


            selected.Location = new Point(defaultColor.Location.X, defaultColor.Location.Y - 1);
            
            if(PreviewPreference(themePreferencePackage) == 1)
            {
                Media_Distro.Properties.Settings.Default.Active_Theme_Preference = themePreferencePackage[0];
                Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = themePreferencePackage[3];
                Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = themePreferencePackage[1];
                Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = themePreferencePackage[4];
                Media_Distro.Properties.Settings.Default.Active_Theme_Selected = themePreferencePackage[2];
                Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;

                Media_Distro.Properties.Settings.Default.Save();
            }
        }

        private void greenColor_Click(object sender, EventArgs e)
        {
            Color[] themePreferencePackage = new Color[] { Media_Distro.Properties.Settings.Default.Meadow_Theme_Preference,
                                                           Media_Distro.Properties.Settings.Default.Meadow_Theme_SearchBar,
                                                           Media_Distro.Properties.Settings.Default.Meadow_Theme_Selected,
                                                           Media_Distro.Properties.Settings.Default.Meadow_Theme_TitleBar,
                                                           Media_Distro.Properties.Settings.Default.Meadow_Theme_WorkPlace};


            selected.Location = new Point(greenColor.Location.X, greenColor.Location.Y - 1);
            
            if(PreviewPreference(themePreferencePackage) == 1)
            {
                Media_Distro.Properties.Settings.Default.Active_Theme_Preference = themePreferencePackage[0];
                Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = themePreferencePackage[3];
                Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = themePreferencePackage[1];
                Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = themePreferencePackage[4];
                Media_Distro.Properties.Settings.Default.Active_Theme_Selected = themePreferencePackage[2];
                Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;

                Media_Distro.Properties.Settings.Default.Save();
            }
        }

        private void redColor_Click(object sender, EventArgs e)
        {
            Color[] themePreferencePackage = new Color[] { Media_Distro.Properties.Settings.Default.Fire_Theme_Preference,
                                                           Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar,
                                                           Media_Distro.Properties.Settings.Default.Fire_Theme_Selected,
                                                           Media_Distro.Properties.Settings.Default.Fire_Theme_TitleBar,
                                                           Media_Distro.Properties.Settings.Default.Fire_Theme_WorkPlace};


            selected.Location = new Point(redColor.Location.X, redColor.Location.Y - 1);
            
            if(PreviewPreference(themePreferencePackage) == 1)
            {
                Media_Distro.Properties.Settings.Default.Active_Theme_Preference = themePreferencePackage[0];
                Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = themePreferencePackage[3];
                Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = themePreferencePackage[1];
                Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = themePreferencePackage[4];
                Media_Distro.Properties.Settings.Default.Active_Theme_Selected = themePreferencePackage[2];
                Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;

                Media_Distro.Properties.Settings.Default.Save();
            }
        }

        private void darkBlueColor_Click(object sender, EventArgs e)
        {
            Color[] themePreferencePackage = new Color[] { Media_Distro.Properties.Settings.Default.Twilight_Theme_Preference,
                                                           Media_Distro.Properties.Settings.Default.Twilight_Theme_SearchBar,
                                                           Media_Distro.Properties.Settings.Default.Twilight_Theme_Selected,
                                                           Media_Distro.Properties.Settings.Default.Twilight_Theme_TitleBar,
                                                           Media_Distro.Properties.Settings.Default.Twilight_Theme_WorkPlace};

            selected.Location = new Point(darkBlueColor.Location.X, darkBlueColor.Location.Y - 1);
            
            if(PreviewPreference(themePreferencePackage) == 1)
            {
                Media_Distro.Properties.Settings.Default.Active_Theme_Preference = themePreferencePackage[0];
                Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = themePreferencePackage[3];
                Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = themePreferencePackage[1];
                Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = themePreferencePackage[4];
                Media_Distro.Properties.Settings.Default.Active_Theme_Selected = themePreferencePackage[2];
                Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;

                Media_Distro.Properties.Settings.Default.Save();
            }
        }

        private void blackColor_Click(object sender, EventArgs e)
        {
            Color[] themePreferencePackage = new Color[] { Media_Distro.Properties.Settings.Default.Dark_Theme_Preference,
                                                           Media_Distro.Properties.Settings.Default.Dark_Theme_SearchBar,
                                                           Media_Distro.Properties.Settings.Default.Dark_Theme_Selected,
                                                           Media_Distro.Properties.Settings.Default.Dark_Theme_TitleBar,
                                                           Media_Distro.Properties.Settings.Default.Dark_Theme_WorkPlace};

            selected.Location = new Point(blackColor.Location.X, blackColor.Location.Y - 1);
            
            if(PreviewPreference(themePreferencePackage) == 1)
            {
                Media_Distro.Properties.Settings.Default.Active_Theme_Preference = themePreferencePackage[0];
                Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = themePreferencePackage[3];
                Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = themePreferencePackage[1];
                Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = themePreferencePackage[4];
                Media_Distro.Properties.Settings.Default.Active_Theme_Selected = themePreferencePackage[2];
                Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;

                Media_Distro.Properties.Settings.Default.Save();
            } 
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            selected.Location = new Point(Media_Distro.Properties.Settings.Default.selectedLocation, selected.Location.Y);
            selected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
            notificationSettingCheckBox.Checked = Media_Distro.Properties.Settings.Default.showNotification;
            priceSetting.Value = Media_Distro.Properties.Settings.Default.moviePrice;
        }

        private void priceSetting_ValueChanged(object sender, EventArgs e)
        {
            if (priceSettingLabel.Text.Contains("Movie"))
            {
                Media_Distro.Properties.Settings.Default.moviePrice = priceSetting.Value;

                foreach (LibraryManager priceChange in movieCatalogue)
                    priceChange.Price = priceSetting.Value;
            }
            else if (priceSettingLabel.Text.Contains("Music"))
            {
                Media_Distro.Properties.Settings.Default.musicPrice = priceSetting.Value;

                foreach (LibraryManager priceChange in musicCatalogue)
                {
                    if(priceChange.AlbumList != null)
                    {
                        priceChange.Price = 0;

                        foreach (object track in priceChange.AlbumList)
                            priceChange.Price += Media_Distro.Properties.Settings.Default.musicPrice;
                    }
                    else
                        priceChange.Price = Media_Distro.Properties.Settings.Default.musicPrice;
                }
                    
            }
            else if (priceSettingLabel.Text.Contains("Episode"))
            {
                Media_Distro.Properties.Settings.Default.seriesPrice = priceSetting.Value;

                foreach (LibraryManager priceChange in seriesCatalogue)
                {
                    priceChange.Price = 0;
                    
                    foreach (ArrayList file in priceChange.SeriesList)
                        for (int i = 1; i < file.Count; i++)
                            priceChange.Price += Media_Distro.Properties.Settings.Default.seriesPrice;
                }
            }

            Media_Distro.Properties.Settings.Default.Save();
        }

        private void bonusButton_Click(object sender, EventArgs e)
        {
            if(GetDirectories(Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Ads")).Length > 0)
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                DialogResult result = folderBrowser.ShowDialog();
                string bonusFolder = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Bonus");
                CreateDirectory(bonusFolder);

                string statsRecord = Combine(bonusFolder, GetBonusKey() + ".txt");
                StreamWriter writer = File.CreateText(statsRecord);
                string bonusFile;
                DateTime date = new DateTime();

                for (int i = 0; i < stRef.statsFile.Length - 1; i += 7)
                {
                    date = DateTime.Parse(stRef.statsFile[i].Substring(11));

                    if (date > Media_Distro.Properties.Settings.Default.latestBonusDate || 
                        Media_Distro.Properties.Settings.Default.latestBonusDate == new DateTime())
                    {
                        writer.WriteLine(stRef.statsFile[i]);
                        writer.WriteLine(stRef.statsFile[i + 1]);
                        writer.WriteLine(stRef.statsFile[i + 2]);
                        writer.WriteLine(stRef.statsFile[i + 3]);
                        writer.WriteLine(stRef.statsFile[i + 4]);
                        writer.WriteLine(stRef.statsFile[i + 5]);
                        writer.WriteLine();
                    }
                }

                writer.Close();

                if (date != new DateTime() && date != Media_Distro.Properties.Settings.Default.latestBonusDate)
                {
                    Media_Distro.Properties.Settings.Default.latestBonusDate = date;
                    Media_Distro.Properties.Settings.Default.Save();

                    if (result == DialogResult.OK)
                    {
                        bonusFile = Combine(folderBrowser.SelectedPath, "Bonus");

                        try
                        {
                            ZipFile.CreateFromDirectory(bonusFolder, bonusFile);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show(ex.Message, "File Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Latest bonuses have already been collected.", "Bonus Collected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                Delete(bonusFolder, true);
            }
            else
            {
                MessageBox.Show("No Distro Package has ever been loaded, therefore you cannot recieve bonuses for now. Get the packages via telegram bot " +
                    "and integrate it with the interface.", "Package Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void notificationSettingCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (notificationSettingCheckBox.Checked)
            {
                reference.showNotification = true;
                
                Media_Distro.Properties.Settings.Default.showNotification = true;
                Media_Distro.Properties.Settings.Default.Save();
            }
            else
            {
                reference.showNotification = false;

                Media_Distro.Properties.Settings.Default.showNotification = false;
                Media_Distro.Properties.Settings.Default.Save();
            }
                
        }

        private void SettingsForm_Leave(object sender, EventArgs e)
        {
            fileLoadLabel.Visible = false;
        }

        private void removeURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> removedURL = new List<string>();

            if(urlPathListBox.SelectedItems.Count != 0)
            {
                foreach(string dir in urlPathListBox.SelectedItems)
                {
                    removedURL.Add(dir);
                    if (OnMovie) Media_Distro.Properties.Settings.Default.Movie_Media_Location.Remove(dir);
                    else if (OnMusic) Media_Distro.Properties.Settings.Default.Music_Media_Location.Remove(dir);
                    else if (OnSeries) Media_Distro.Properties.Settings.Default.Series_Media_Location.Remove(dir);
                }

                Media_Distro.Properties.Settings.Default.Save();

                foreach (string dir in removedURL)
                    urlPathListBox.Items.Remove(dir);
            }
        }

        private void updateLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog updateFile = new OpenFileDialog();
            Version currentVersion = new Version(typeof(mediaDistroFrame).Assembly.GetName().Version.ToString());
            Version latestVersion = new Version(1, 0, 0, 0);
            string versionInfo = null;
            updateFile.Title = "Locating Update";
            updateFile.Filter = "Zip Files (*.zip)|*.zip |All files (*.*)|*.*";

            if(updateFile.ShowDialog() == DialogResult.OK)
            {
                string newUpdateDir = CreateDirectory(Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "temp")).FullName;
                try
                {
                    ZipFile.ExtractToDirectory(updateFile.FileName, newUpdateDir);
                }
                catch (Exception)
                {
                    if (Exists(newUpdateDir))
                        Delete(newUpdateDir, true);

                    newUpdateDir = CreateDirectory(Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "temp")).FullName;
                    ZipFile.ExtractToDirectory(updateFile.FileName, newUpdateDir);
                }
                
                foreach(string dir in GetFiles(newUpdateDir))
                {
                    if(GetFileName(dir) == "Version Number.txt" || GetFileName(dir) == "Version Number.TXT")
                    {
                        latestVersion = new Version(File.ReadAllLines(dir)[0]);
                        versionInfo = dir;
                        break;
                    }
                }

                if (currentVersion < latestVersion)
                {
                    DialogResult result = MessageBox.Show("Update is available. Click YES to start the update and the app will need a restart after completion.", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    
                    if(result == DialogResult.Yes)
                    {
                        mainRef.IsUpdating = true;
                        if (versionInfo != null)
                            File.Delete(versionInfo);

                        Application.Exit();
                    }
                }
                else
                    MessageBox.Show("The latest update has been installed in the interface.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int PreviewPreference(Color[] themePreference)
        {
            //Main Form Color Change

            mainRef.sideMenuPanel.BackColor = themePreference[0];
            mainRef.homeSubMenu.BackColor = themePreference[0];
            mainRef.librarySubMenu.BackColor = themePreference[0];
            mainRef.sharesubMenu.BackColor = themePreference[0];
            mainRef.statssubMenu.BackColor = themePreference[0];
            mainRef.settingsubMenu.BackColor = themePreference[2];
            mainRef.titleBarPanel.BackColor = themePreference[3];
            mainRef.searchTextBox.BackColor = themePreference[1];
            mainRef.workPanel.BackColor = themePreference[4];
            mainRef.cartToolStrip.BackColor = themePreference[3];
            mainRef.pictureBox1.BackColor = themePreference[3];

            mainRef.cartLabel.BackColor = themePreference[3];
            mainRef.searchButton.FlatAppearance.MouseOverBackColor = themePreference[1];
            mainRef.searchButton.FlatAppearance.MouseDownBackColor = themePreference[1];
            mainRef.menushowButton.FlatAppearance.MouseOverBackColor = themePreference[2];
            mainRef.menushowButton.FlatAppearance.MouseDownBackColor = themePreference[2];
            mainRef.homeSubMenu.FlatAppearance.MouseOverBackColor = themePreference[2];
            mainRef.homeSubMenu.FlatAppearance.MouseDownBackColor = themePreference[2];
            mainRef.librarySubMenu.FlatAppearance.MouseOverBackColor = themePreference[2];
            mainRef.librarySubMenu.FlatAppearance.MouseDownBackColor = themePreference[2];
            mainRef.sharesubMenu.FlatAppearance.MouseOverBackColor = themePreference[2]; 
            mainRef.sharesubMenu.FlatAppearance.MouseDownBackColor = themePreference[2];
            mainRef.statssubMenu.FlatAppearance.MouseOverBackColor = themePreference[2];
            mainRef.statssubMenu.FlatAppearance.MouseDownBackColor = themePreference[2];
            mainRef.settingsubMenu.FlatAppearance.MouseOverBackColor = themePreference[2];
            mainRef.settingsubMenu.FlatAppearance.MouseDownBackColor = themePreference[2];

            //Home Form Color Change

            hRef.BackColor = themePreference[4];
            hRef.goLeftButton.FlatAppearance.MouseOverBackColor = themePreference[2];
            hRef.goRightButton.FlatAppearance.MouseOverBackColor = themePreference[2];
            hRef.goLeftButton.FlatAppearance.MouseDownBackColor = themePreference[2];
            hRef.goRightButton.FlatAppearance.MouseDownBackColor = themePreference[2];
            hRef.locateZipButton.FillColor = themePreference[3];
            hRef.addToCartButton.BackColor = themePreference[3];

            //LibraryForm Color Change

            libRef.BackColor = themePreference[4];
            libRef.genreListView.BackColor = themePreference[4];
            libRef.movieList.BackColor = themePreference[4];
            libRef.musicList.BackColor = themePreference[4];
            libRef.seriesList.BackColor = themePreference[4];
            libRef.activeListButton.ForeColor = themePreference[3];
            libRef.selected.BackColor = themePreference[3];
            libRef.infoPanel.BackColor = themePreference[3];
            libRef.hideInfoButton.FillColor = themePreference[0];

            Image temp1Image = libRef.infoPanel.BackgroundImage;
            Image temp2Image = libRef.hideInfoButton.Image;
            Image temp3Image = shRef.detailPanel.BackgroundImage;
            Image temp4Image = stRef.pictureBox1.Image;
            Color temp1Color = libRef.infoPanel.BackColor;
            Color temp2Color = libRef.genreTextBox.BackColor;
            Color temp3Color = mainRef.minimizeButton.FlatAppearance.MouseOverBackColor;
            Color temp4Color = stRef.zoomInButton1.FillColor;
            Color temp5Color = stRef.cartInfoLabel.BackColor;

            if (themePreference[0] == Media_Distro.Properties.Settings.Default.Default_Theme_Preference)
            {
                mainRef.minimizeButton.FlatAppearance.MouseOverBackColor = themePreference[1];
                mainRef.minimizeButton.FlatAppearance.MouseDownBackColor = themePreference[1];

                libRef.infoPanel.BackgroundImage = Media_Distro.Properties.Resources.infoPanel_Background;
                libRef.titleTextBox.BackColor = libRef.infoPanel.BackColor;
                libRef.genreTextBox.BackColor = Color.FromArgb(130, 200, 255);
                libRef.yearTextBox.BackColor = Color.FromArgb(130, 200, 255);
                libRef.ratingTextBox.BackColor = Color.FromArgb(130, 200, 255);
                libRef.cartButton.BackColor = Color.FromArgb(130, 200, 255);
                libRef.hideInfoButton.Image = Media_Distro.Properties.Resources.Hide_Info_Icon;
                libRef.addSTCart.BackColor = Color.FromArgb(130, 200, 255);
                libRef.albumTreeView.BackColor = Color.FromArgb(130, 200, 255);
                libRef.pictureBox1.BackColor = Color.FromArgb(130, 200, 255);
                libRef.addSTCart.FillColor = themePreference[3];
                libRef.moreInfoLinkLabel.LinkColor = libRef.infoPanel.BackColor;
                libRef.moreInfoLinkLabel.ActiveLinkColor = themePreference[1];
                updateLinkLabel.LinkColor = libRef.infoPanel.BackColor;
                updateLinkLabel.ActiveLinkColor = themePreference[1];

                shRef.detailPanel.BackgroundImage = Media_Distro.Properties.Resources.detailPanel_Default_BackGround;

                stRef.pictureBox1.Image = Media_Distro.Properties.Resources.stats_background_default;
                stRef.zoomInButton1.FillColor = themePreference[3];
                stRef.zoomOutButton1.FillColor = themePreference[3];
                stRef.resetChartButton.FillColor = themePreference[3];
                stRef.previousButton.FillColor = themePreference[3];
                stRef.nxtButton.FillColor = themePreference[3];
                stRef.cartInfoLabel.BackColor = themePreference[3];
                stRef.cartMovieLabel.BackColor = themePreference[3];
                stRef.cartMoviesExt.BackColor = themePreference[3];
                stRef.cartMusicLabel.BackColor = themePreference[3];
                stRef.cartMusicExt.BackColor = themePreference[3];
                stRef.cartSeriesLabel.BackColor = themePreference[3];
                stRef.cartSeriesExt.BackColor = themePreference[3];
                stRef.cartSentDateLabel.BackColor = themePreference[3];
                stRef.cartDateExt.BackColor = themePreference[3];
                stRef.cartPaidLabel.BackColor = themePreference[3];
                stRef.cartPaidExt.BackColor = themePreference[3];

                Media_Distro.Properties.Settings.Default.Active_Theme_InfoPanel = libRef.genreTextBox.BackColor;
            }
            else if (themePreference[0] == Media_Distro.Properties.Settings.Default.Fire_Theme_Preference)
            {
                mainRef.minimizeButton.FlatAppearance.MouseOverBackColor = themePreference[1];
                mainRef.minimizeButton.FlatAppearance.MouseDownBackColor = themePreference[1];

                libRef.infoPanel.BackgroundImage = Media_Distro.Properties.Resources.infoPanel_FireBackground;
                libRef.titleTextBox.BackColor = libRef.infoPanel.BackColor;
                libRef.genreTextBox.BackColor = Color.FromArgb(180, 80, 95);
                libRef.yearTextBox.BackColor = Color.FromArgb(180, 80, 95);
                libRef.ratingTextBox.BackColor = Color.FromArgb(180, 80, 95);
                libRef.cartButton.BackColor = Color.FromArgb(180, 80, 95);
                libRef.hideInfoButton.Image = Media_Distro.Properties.Resources.Hide_Info_Fire_Icon;
                libRef.addSTCart.BackColor = Color.FromArgb(180, 80, 95);
                libRef.albumTreeView.BackColor = Color.FromArgb(180, 80, 95);
                libRef.pictureBox1.BackColor = Color.FromArgb(180, 80, 95);
                libRef.addSTCart.FillColor = themePreference[3];
                libRef.moreInfoLinkLabel.LinkColor = libRef.titleTextBox.ForeColor;
                libRef.moreInfoLinkLabel.ActiveLinkColor = themePreference[1];
                updateLinkLabel.LinkColor = libRef.infoPanel.BackColor;
                updateLinkLabel.ActiveLinkColor = themePreference[1];

                shRef.detailPanel.BackgroundImage = Media_Distro.Properties.Resources.detailPanel_Fire_BackGround;

                stRef.pictureBox1.Image = Media_Distro.Properties.Resources.stats_background_fire;
                stRef.zoomInButton1.FillColor = themePreference[3];
                stRef.zoomOutButton1.FillColor = themePreference[3];
                stRef.resetChartButton.FillColor = themePreference[3];
                stRef.previousButton.FillColor = themePreference[3];
                stRef.nxtButton.FillColor = themePreference[3];
                stRef.cartInfoLabel.BackColor = themePreference[1];
                stRef.cartMovieLabel.BackColor = themePreference[1];
                stRef.cartMoviesExt.BackColor = themePreference[1];
                stRef.cartMusicLabel.BackColor = themePreference[1];
                stRef.cartMusicExt.BackColor = themePreference[1];
                stRef.cartSeriesLabel.BackColor = themePreference[1];
                stRef.cartSeriesExt.BackColor = themePreference[1];
                stRef.cartSentDateLabel.BackColor = themePreference[1];
                stRef.cartDateExt.BackColor = themePreference[1];
                stRef.cartPaidLabel.BackColor = themePreference[1];
                stRef.cartPaidExt.BackColor = themePreference[1];

                Media_Distro.Properties.Settings.Default.Active_Theme_InfoPanel = libRef.genreTextBox.BackColor;
            }
            else if (themePreference[0] == Media_Distro.Properties.Settings.Default.Meadow_Theme_Preference)
            {
                mainRef.minimizeButton.FlatAppearance.MouseOverBackColor = themePreference[2];
                mainRef.minimizeButton.FlatAppearance.MouseDownBackColor = themePreference[2];

                libRef.infoPanel.BackgroundImage = Media_Distro.Properties.Resources.infoPanel_MeadowBackground;
                libRef.titleTextBox.BackColor = libRef.infoPanel.BackColor;
                libRef.genreTextBox.BackColor = Color.FromArgb(155, 255, 165);
                libRef.yearTextBox.BackColor = Color.FromArgb(155, 255, 165);
                libRef.ratingTextBox.BackColor = Color.FromArgb(155, 255, 165);
                libRef.cartButton.BackColor = Color.FromArgb(155, 255, 165);
                libRef.hideInfoButton.Image = Media_Distro.Properties.Resources.Hide_Info_Meadow_Icon;
                libRef.addSTCart.BackColor = Color.FromArgb(155, 255, 165);
                libRef.albumTreeView.BackColor = Color.FromArgb(155, 255, 165);
                libRef.pictureBox1.BackColor = Color.FromArgb(155, 255, 165);
                libRef.addSTCart.FillColor = themePreference[0];
                libRef.moreInfoLinkLabel.LinkColor = libRef.infoPanel.BackColor;
                libRef.moreInfoLinkLabel.ActiveLinkColor = themePreference[1];
                updateLinkLabel.LinkColor = libRef.infoPanel.BackColor;
                updateLinkLabel.ActiveLinkColor = themePreference[1];

                shRef.detailPanel.BackgroundImage = Media_Distro.Properties.Resources.detailPanel_Meadow_BackGround;

                stRef.pictureBox1.Image = Media_Distro.Properties.Resources.stats_background_green;
                stRef.zoomInButton1.FillColor = themePreference[0];
                stRef.zoomOutButton1.FillColor = themePreference[0];
                stRef.resetChartButton.FillColor = themePreference[0];
                stRef.previousButton.FillColor = themePreference[0];
                stRef.nxtButton.FillColor = themePreference[0];
                stRef.cartInfoLabel.BackColor = themePreference[3];
                stRef.cartMovieLabel.BackColor = themePreference[3];
                stRef.cartMoviesExt.BackColor = themePreference[3];
                stRef.cartMusicLabel.BackColor = themePreference[3];
                stRef.cartMusicExt.BackColor = themePreference[3];
                stRef.cartSeriesLabel.BackColor = themePreference[3];
                stRef.cartSeriesExt.BackColor = themePreference[3];
                stRef.cartSentDateLabel.BackColor = themePreference[3];
                stRef.cartDateExt.BackColor = themePreference[3];
                stRef.cartPaidLabel.BackColor = themePreference[3];
                stRef.cartPaidExt.BackColor = themePreference[3];

                Media_Distro.Properties.Settings.Default.Active_Theme_InfoPanel = libRef.genreTextBox.BackColor;
            }
            else if (themePreference[0] == Media_Distro.Properties.Settings.Default.Dark_Theme_Preference)
            {
                mainRef.minimizeButton.FlatAppearance.MouseOverBackColor = themePreference[4];
                mainRef.minimizeButton.FlatAppearance.MouseDownBackColor = themePreference[4];

                hRef.locateZipButton.FillColor = themePreference[1];
                hRef.addToCartButton.BackColor = themePreference[1];

                libRef.infoPanel.BackgroundImage = Media_Distro.Properties.Resources.infoPanel_DarkBackground;
                libRef.titleTextBox.BackColor = libRef.infoPanel.BackColor;
                libRef.genreTextBox.BackColor = Color.FromArgb(105, 105, 115);
                libRef.yearTextBox.BackColor = Color.FromArgb(105, 105, 115);
                libRef.ratingTextBox.BackColor = Color.FromArgb(105, 105, 115);
                libRef.cartButton.BackColor = Color.FromArgb(105, 105, 115);
                libRef.hideInfoButton.Image = Media_Distro.Properties.Resources.Hide_Info_Dark_Icon;
                libRef.addSTCart.BackColor = Color.FromArgb(105, 105, 115);
                libRef.albumTreeView.BackColor = Color.FromArgb(105, 105, 115);
                libRef.pictureBox1.BackColor = Color.FromArgb(105, 105, 115);
                libRef.addSTCart.FillColor = themePreference[1];
                libRef.moreInfoLinkLabel.LinkColor = libRef.infoPanel.BackColor;
                libRef.moreInfoLinkLabel.ActiveLinkColor = themePreference[1];
                updateLinkLabel.LinkColor = libRef.infoPanel.BackColor;
                updateLinkLabel.ActiveLinkColor = themePreference[1];

                shRef.detailPanel.BackgroundImage = Media_Distro.Properties.Resources.detailPanel_Dark_BackGround;

                stRef.pictureBox1.Image = Media_Distro.Properties.Resources.stats_background_4;
                stRef.zoomInButton1.FillColor = themePreference[1];
                stRef.zoomOutButton1.FillColor = themePreference[1];
                stRef.resetChartButton.FillColor = themePreference[1];
                stRef.previousButton.FillColor = themePreference[1];
                stRef.nxtButton.FillColor = themePreference[1];
                stRef.cartInfoLabel.BackColor = Color.FromArgb(115, 120, 125);
                stRef.cartMovieLabel.BackColor = Color.FromArgb(115, 120, 125);
                stRef.cartMoviesExt.BackColor = Color.FromArgb(115, 120, 125);
                stRef.cartMusicLabel.BackColor = Color.FromArgb(115, 120, 125);
                stRef.cartMusicExt.BackColor = Color.FromArgb(115, 120, 125);
                stRef.cartSeriesLabel.BackColor = Color.FromArgb(115, 120, 125);
                stRef.cartSeriesExt.BackColor = Color.FromArgb(115, 120, 125);
                stRef.cartSentDateLabel.BackColor = Color.FromArgb(115, 120, 125);
                stRef.cartDateExt.BackColor = Color.FromArgb(115, 120, 125);
                stRef.cartPaidLabel.BackColor = Color.FromArgb(115, 120, 125);
                stRef.cartPaidExt.BackColor = Color.FromArgb(115, 120, 125);

                Media_Distro.Properties.Settings.Default.Active_Theme_InfoPanel = libRef.genreTextBox.BackColor;
            }
            else if (themePreference[0] == Media_Distro.Properties.Settings.Default.Twilight_Theme_Preference)
            {
                mainRef.minimizeButton.FlatAppearance.MouseOverBackColor = themePreference[2];
                mainRef.minimizeButton.FlatAppearance.MouseDownBackColor = themePreference[2];

                libRef.infoPanel.BackgroundImage = Media_Distro.Properties.Resources.infoPanel_TwilightBackground;
                libRef.titleTextBox.BackColor = libRef.infoPanel.BackColor;
                libRef.genreTextBox.BackColor = Color.FromArgb(60, 70, 100);
                libRef.yearTextBox.BackColor = Color.FromArgb(60, 70, 100);
                libRef.ratingTextBox.BackColor = Color.FromArgb(60, 70, 100);
                libRef.cartButton.BackColor = Color.FromArgb(60, 70, 100);
                libRef.hideInfoButton.Image = Media_Distro.Properties.Resources.Hide_Info_Twilight_Icon;
                libRef.addSTCart.BackColor = Color.FromArgb(60, 70, 100);
                libRef.albumTreeView.BackColor = Color.FromArgb(60, 70, 100);
                libRef.pictureBox1.BackColor = Color.FromArgb(60, 70, 100);
                libRef.addSTCart.FillColor = themePreference[0];
                libRef.moreInfoLinkLabel.LinkColor = libRef.infoPanel.BackColor;
                libRef.moreInfoLinkLabel.ActiveLinkColor = themePreference[1];
                updateLinkLabel.LinkColor = libRef.infoPanel.BackColor;
                updateLinkLabel.ActiveLinkColor = themePreference[1];

                shRef.detailPanel.BackgroundImage = Media_Distro.Properties.Resources.detailPanel_Twilight_BackGround;

                stRef.pictureBox1.Image = Media_Distro.Properties.Resources.stats_background_twilight;
                stRef.zoomInButton1.FillColor = themePreference[0];
                stRef.zoomOutButton1.FillColor = themePreference[0];
                stRef.resetChartButton.FillColor = themePreference[0];
                stRef.previousButton.FillColor = themePreference[0];
                stRef.nxtButton.FillColor = themePreference[0];
                stRef.cartInfoLabel.BackColor = Color.FromArgb(60, 95, 155);
                stRef.cartMovieLabel.BackColor = Color.FromArgb(60, 95, 155);
                stRef.cartMoviesExt.BackColor = Color.FromArgb(60, 95, 155);
                stRef.cartMusicLabel.BackColor = Color.FromArgb(60, 95, 155);
                stRef.cartMusicExt.BackColor = Color.FromArgb(60, 95, 155);
                stRef.cartSeriesLabel.BackColor = Color.FromArgb(60, 95, 155);
                stRef.cartSeriesExt.BackColor = Color.FromArgb(60, 95, 155);
                stRef.cartSentDateLabel.BackColor = Color.FromArgb(60, 95, 155);
                stRef.cartDateExt.BackColor = Color.FromArgb(60, 95, 155);
                stRef.cartPaidLabel.BackColor = Color.FromArgb(60, 95, 155);
                stRef.cartPaidExt.BackColor = Color.FromArgb(60, 95, 155);

                Media_Distro.Properties.Settings.Default.Active_Theme_InfoPanel = libRef.genreTextBox.BackColor;
            }
                
            //Share Form Color Change

            shRef.BackColor = themePreference[4];
            shRef.cartsSelected.BackColor = themePreference[3];
            shRef.cartsButton.ForeColor = themePreference[3];
            shRef.progressButton.ForeColor = themePreference[3];
            shRef.progressSelected.BackColor = themePreference[3];
            shRef.panel1.BackColor = themePreference[0];
            shRef.detailPanel.BackColor = themePreference[0];
            shRef.deviceList.BackColor = themePreference[4];
            shRef.detailListView.BackColor = themePreference[0];

            //Stats Form color Change

            stRef.BackColor = themePreference[4];

            //Settings Form Color Change

            priceSetting.UpDownButtonFillColor = themePreference[1];
            selected.BackColor = themePreference[2];
            this.BackColor = themePreference[4];
            movieURLCollectionButton.FlatAppearance.MouseOverBackColor = themePreference[2];
            musicURLCollectionButton.FlatAppearance.MouseOverBackColor = themePreference[2];
            seriesURLCollectionButton.FlatAppearance.MouseOverBackColor = themePreference[2];

            DialogResult result = MessageBox.Show("Are you sure you want the theme you chose applied on the interface?", "Change Theme Preference", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == DialogResult.OK)
            {
                return 1;
            }
            else
            {
                //Main Form return active color

                mainRef.sideMenuPanel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
                mainRef.titleBarPanel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                mainRef.searchTextBox.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar;
                mainRef.workPanel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                mainRef.cartToolStrip.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                mainRef.pictureBox1.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                mainRef.homeSubMenu.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
                mainRef.librarySubMenu.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
                mainRef.sharesubMenu.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
                mainRef.statssubMenu.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
                mainRef.settingsubMenu.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;

                mainRef.cartLabel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                mainRef.searchButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar;
                mainRef.searchButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar;
                mainRef.minimizeButton.FlatAppearance.MouseOverBackColor = temp3Color;
                mainRef.minimizeButton.FlatAppearance.MouseDownBackColor = temp3Color;
                mainRef.menushowButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                mainRef.menushowButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                mainRef.homeSubMenu.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                mainRef.homeSubMenu.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                mainRef.librarySubMenu.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                mainRef.librarySubMenu.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                mainRef.sharesubMenu.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                mainRef.sharesubMenu.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                mainRef.statssubMenu.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                mainRef.statssubMenu.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                mainRef.settingsubMenu.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                mainRef.settingsubMenu.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;

                //Home Form return active color

                hRef.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                hRef.goLeftButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                hRef.goRightButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                hRef.goLeftButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                hRef.goRightButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                hRef.locateZipButton.FillColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;


                //LibraryForm return active color

                libRef.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                libRef.genreListView.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                libRef.movieList.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                libRef.musicList.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                libRef.seriesList.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                libRef.activeListButton.ForeColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                libRef.selected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                libRef.infoPanel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                libRef.infoPanel.BackgroundImage = temp1Image;
                libRef.hideInfoButton.Image = temp2Image;
                libRef.genreTextBox.BackColor = temp2Color;
                libRef.yearTextBox.BackColor = temp2Color;
                libRef.ratingTextBox.BackColor = temp2Color;
                libRef.cartButton.BackColor = temp2Color;
                libRef.hideInfoButton.FillColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
                libRef.addSTCart.BackColor = temp2Color;
                libRef.albumTreeView.BackColor = temp2Color;
                libRef.pictureBox1.BackColor = temp2Color;
                libRef.addSTCart.FillColor = temp4Color;
                libRef.moreInfoLinkLabel.LinkColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                libRef.moreInfoLinkLabel.ActiveLinkColor = Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar;
                updateLinkLabel.LinkColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                updateLinkLabel.ActiveLinkColor = Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar;
                if (Media_Distro.Properties.Settings.Default.Active_Theme_Preference == Media_Distro.Properties.Settings.Default.Fire_Theme_Preference)
                    libRef.moreInfoLinkLabel.LinkColor = libRef.titleTextBox.ForeColor;
                    
                Media_Distro.Properties.Settings.Default.Active_Theme_InfoPanel = temp2Color;

                //Share Form return active color

                shRef.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                shRef.cartsSelected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                shRef.cartsButton.ForeColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                shRef.progressButton.ForeColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                shRef.progressSelected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                shRef.panel1.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
                shRef.detailPanel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
                shRef.deviceList.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                shRef.detailPanel.BackgroundImage = temp3Image;
                shRef.detailListView.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;

                //Stats Form return active color

                stRef.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                stRef.pictureBox1.Image = temp4Image;
                stRef.zoomInButton1.FillColor = temp4Color;
                stRef.zoomOutButton1.FillColor = temp4Color;
                stRef.resetChartButton.FillColor = temp4Color;
                stRef.previousButton.FillColor = temp4Color;
                stRef.nxtButton.FillColor = temp4Color;
                stRef.cartInfoLabel.BackColor = temp5Color;
                stRef.cartMovieLabel.BackColor = temp5Color;
                stRef.cartMoviesExt.BackColor = temp5Color;
                stRef.cartMusicLabel.BackColor = temp5Color;
                stRef.cartMusicExt.BackColor = temp5Color;
                stRef.cartSeriesLabel.BackColor = temp5Color;
                stRef.cartSeriesExt.BackColor = temp5Color;
                stRef.cartSentDateLabel.BackColor = temp5Color;
                stRef.cartDateExt.BackColor = temp5Color;
                stRef.cartPaidLabel.BackColor = temp5Color;
                stRef.cartPaidExt.BackColor = temp5Color;

                //Settings Form return active color

                priceSetting.UpDownButtonFillColor = Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar;
                selected.Location = new Point(Media_Distro.Properties.Settings.Default.selectedLocation, selected.Location.Y);
                selected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
                this.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                movieURLCollectionButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                musicURLCollectionButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                seriesURLCollectionButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;

                return 0;
            }
        }

        private static string GetBonusKey()
        {
            string[] statsFile = File.ReadAllLines(Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Stats Record.txt"));
            List<char> letters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            double bonus = 0;
            string bonusKey = "";
            Random random = new Random();
            DateTime now = DateTime.Now;
            string day = now.Day.ToString();
            string month = now.Month.ToString();
            string year = now.Year.ToString();

            for (int i = 0; i < statsFile.Length - 1; i += 7)
                bonus += double.Parse(statsFile[i + 5].Substring(15)) * 0.05;

            bonusKey += letters[random.Next(26)];

            for (int i = 0; i < 2; i++)
                bonusKey += letters[letters.IndexOf(bonusKey[i]) * 9 % 26];

            if (day.Length == 1)
            {
                bonusKey += letters[0];
                bonusKey += letters[int.Parse(day)];
            }
            else
            {
                bonusKey += letters[int.Parse(day[1].ToString())];
                bonusKey += letters[int.Parse(day[0].ToString())];
            }

            if (month.Length == 1)
            {
                bonusKey += letters[0];
                bonusKey += letters[int.Parse(month)];
            }
            else
            {
                bonusKey += letters[int.Parse(month[1].ToString())];
                bonusKey += letters[int.Parse(month[0].ToString())];
            }

            bonusKey += letters[int.Parse(year[2].ToString())];
            bonusKey += letters[int.Parse(year[3].ToString())];

            foreach (char c in String.Format("{0:F}", bonus))
            {
                if (c == '.')
                    bonusKey += 'P';
                else
                    bonusKey += letters[int.Parse(c.ToString()) % 26];
            }

            return bonusKey;
        }
    }
}
