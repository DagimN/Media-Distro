using System;
using System.Drawing;
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

            foreach (string url in Media_Distro.Properties.Settings.Default.Movie_Media_Location)
                urlPathListBox.Items.Add(url);
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
            }
                
            folderBrowser.Dispose();
            Media_Distro.Properties.Settings.Default.Save();
        }

        private void movieURLCollectionButton_Click(object sender, EventArgs e)
        {
            OnMovie = true;
            OnMusic = false;
            OnSeries = false;
            urlPathListBox.Items.Clear();

            foreach (string url in Media_Distro.Properties.Settings.Default.Movie_Media_Location)
                urlPathListBox.Items.Add(url);

            priceSettingLabel.Text = "Price per Movie";
            priceSetting.Value = Media_Distro.Properties.Settings.Default.moviePrice;
        }

        private void musicURLCollectionButton_Click(object sender, EventArgs e)
        {
            OnMovie = false;
            OnMusic = true;
            OnSeries = false;
            urlPathListBox.Items.Clear();

            foreach (string url in Media_Distro.Properties.Settings.Default.Music_Media_Location)
                urlPathListBox.Items.Add(url);

            priceSettingLabel.Text = "Price per Music";
            priceSetting.Value = Media_Distro.Properties.Settings.Default.musicPrice;
        }

        private void seriesURLCollectionButton_Click(object sender, EventArgs e)
        {
            OnMovie = false;
            OnMusic = false;
            OnSeries = true;
            urlPathListBox.Items.Clear();

            foreach (string url in Media_Distro.Properties.Settings.Default.Series_Media_Location)
                urlPathListBox.Items.Add(url);

            priceSettingLabel.Text = "Price per Episode";
            priceSetting.Value = Media_Distro.Properties.Settings.Default.seriesPrice;
        }

        private void defaultColor_Click(object sender, EventArgs e)
        {
            Color[] themePreferencePackage = new Color[] { Media_Distro.Properties.Settings.Default.Default_Theme_Preference,
                                                           Media_Distro.Properties.Settings.Default.Default_Theme_SearchBar,
                                                           Media_Distro.Properties.Settings.Default.Default_Theme_Selected,
                                                           Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar,
                                                           Media_Distro.Properties.Settings.Default.Default_Theme_WorkPlace};


            selected.Location = new Point(defaultColor.Location.X, defaultColor.Location.Y - 1);
            Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;
            
            if(PreviewPreference(themePreferencePackage) == 1)
            {
                Media_Distro.Properties.Settings.Default.Active_Theme_Preference = themePreferencePackage[0];
                Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = themePreferencePackage[3];
                Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = themePreferencePackage[1];
                Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = themePreferencePackage[4];
                Media_Distro.Properties.Settings.Default.Active_Theme_Selected = themePreferencePackage[2];

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
            Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;
            

            if(PreviewPreference(themePreferencePackage) == 1)
            {
                Media_Distro.Properties.Settings.Default.Active_Theme_Preference = themePreferencePackage[0];
                Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = themePreferencePackage[3];
                Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = themePreferencePackage[1];
                Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = themePreferencePackage[4];
                Media_Distro.Properties.Settings.Default.Active_Theme_Selected = themePreferencePackage[2];

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
            Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;
            
            if(PreviewPreference(themePreferencePackage) == 1)
            {
                Media_Distro.Properties.Settings.Default.Active_Theme_Preference = themePreferencePackage[0];
                Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = themePreferencePackage[3];
                Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = themePreferencePackage[1];
                Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = themePreferencePackage[4];
                Media_Distro.Properties.Settings.Default.Active_Theme_Selected = themePreferencePackage[2];

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
            Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;
            
            if(PreviewPreference(themePreferencePackage) == 1)
            {
                Media_Distro.Properties.Settings.Default.Active_Theme_Preference = themePreferencePackage[0];
                Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = themePreferencePackage[3];
                Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = themePreferencePackage[1];
                Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = themePreferencePackage[4];
                Media_Distro.Properties.Settings.Default.Active_Theme_Selected = themePreferencePackage[2];

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
            Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;

            if(PreviewPreference(themePreferencePackage) == 1)
            {
                Media_Distro.Properties.Settings.Default.Active_Theme_Preference = themePreferencePackage[0];
                Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = themePreferencePackage[3];
                Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = themePreferencePackage[1];
                Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = themePreferencePackage[4];
                Media_Distro.Properties.Settings.Default.Active_Theme_Selected = themePreferencePackage[2];

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
                    priceChange.Price = priceSetting.Value;
            }
            else if (priceSettingLabel.Text.Contains("Series"))
            {
                Media_Distro.Properties.Settings.Default.seriesPrice = priceSetting.Value;

                foreach (LibraryManager priceChange in seriesCatalogue)
                    priceChange.Price = priceSetting.Value;
            }

            Media_Distro.Properties.Settings.Default.Save();
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
            mainRef.searchButton.FlatAppearance.MouseOverBackColor = themePreference[2];
            mainRef.searchButton.FlatAppearance.MouseDownBackColor = themePreference[2];
            mainRef.minimizeButton.FlatAppearance.MouseOverBackColor = themePreference[4];
            mainRef.minimizeButton.FlatAppearance.MouseDownBackColor = themePreference[4];
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

            //LibraryForm Color Change

            libRef.BackColor = themePreference[4];
            libRef.moviesTabButton.ForeColor = themePreference[0];
            libRef.moviesSelected.BackColor = themePreference[0];
            libRef.genreListView.BackColor = themePreference[4];
            libRef.movieList.BackColor = themePreference[4];
            libRef.musicList.BackColor = themePreference[4];
            libRef.seriesList.BackColor = themePreference[4];

            //Share Form Color Change

            shRef.BackColor = themePreference[4];
            shRef.cartsSelected.BackColor = themePreference[3];
            shRef.cartsButton.ForeColor = themePreference[3];
            shRef.progressSelected.BackColor = themePreference[3];
            shRef.panel1.BackColor = themePreference[0];
            shRef.detailPanel.BackColor = themePreference[0];

            //Stats Form color Change

            stRef.BackColor = themePreference[4];

            //Settings Form Color Change

            selected.BackColor = themePreference[2];
            this.BackColor = themePreference[4];
            accountSettingsButton.FillColor = themePreference[4];
            helpButton.FillColor = themePreference[4];

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
                mainRef.searchButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                mainRef.searchButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                mainRef.minimizeButton.FlatAppearance.MouseOverBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
                mainRef.minimizeButton.FlatAppearance.MouseDownBackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Selected;
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

                //LibraryForm return active color

                libRef.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                libRef.moviesTabButton.ForeColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
                libRef.moviesSelected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
                libRef.genreListView.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                libRef.movieList.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                libRef.musicList.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                libRef.seriesList.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;

                //Share Form return active color

                shRef.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                shRef.cartsSelected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                shRef.cartsButton.ForeColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                shRef.progressSelected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
                shRef.panel1.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
                shRef.detailPanel.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;

                //Stats Form return active color

                stRef.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;

                //Settings Form return active color

                selected.Location = new Point(Media_Distro.Properties.Settings.Default.selectedLocation, selected.Location.Y);
                selected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
                this.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                accountSettingsButton.FillColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;
                helpButton.FillColor = Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace;

                return 0;
            }
        }
    }
}
