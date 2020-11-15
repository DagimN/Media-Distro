using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mobile_Service_Distribution.LibraryManager;
using System.Windows.Forms;

namespace Mobile_Service_Distribution.Forms
{
    public partial class SettingsForm : Form
    {
        private bool OnMovie = true, OnMusic = false, OnSeries = false;
        private Media_Distro.ProgressListView reference;

        public SettingsForm(Media_Distro.ProgressListView reference)
        {
            InitializeComponent();

            this.reference = reference;

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

            priceSettingLabel.Text = "Price per Movie:";
            priceOption.Value = Media_Distro.Properties.Settings.Default.moviePrice;
        }

        private void musicURLCollectionButton_Click(object sender, EventArgs e)
        {
            OnMovie = false;
            OnMusic = true;
            OnSeries = false;
            urlPathListBox.Items.Clear();

            foreach (string url in Media_Distro.Properties.Settings.Default.Music_Media_Location)
                urlPathListBox.Items.Add(url);

            priceSettingLabel.Text = "Price per Music:";
            priceOption.Value = Media_Distro.Properties.Settings.Default.musicPrice;
        }

        private void seriesURLCollectionButton_Click(object sender, EventArgs e)
        {
            OnMovie = false;
            OnMusic = false;
            OnSeries = true;
            urlPathListBox.Items.Clear();

            foreach (string url in Media_Distro.Properties.Settings.Default.Series_Media_Location)
                urlPathListBox.Items.Add(url);

            priceSettingLabel.Text = "Price per Series:";
            priceOption.Value = Media_Distro.Properties.Settings.Default.seriesPrice;
        }

        private void defaultColor_Click(object sender, EventArgs e)
        {
            selected.Location = new Point(defaultColor.Location.X, defaultColor.Location.Y - 1);
            Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;
            selected.BackColor = Media_Distro.Properties.Settings.Default.Default_Theme_Preference;

            Media_Distro.Properties.Settings.Default.Active_Theme_Preference = Media_Distro.Properties.Settings.Default.Default_Theme_Preference;
            Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
            Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = Media_Distro.Properties.Settings.Default.Default_Theme_SearchBar;
            Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = Media_Distro.Properties.Settings.Default.Default_Theme_WorkPlace;
            Media_Distro.Properties.Settings.Default.Active_Theme_Selected = Media_Distro.Properties.Settings.Default.Default_Theme_Selected;

            Media_Distro.Properties.Settings.Default.Save();

            
        }

        private void greenColor_Click(object sender, EventArgs e)
        {
            selected.Location = new Point(greenColor.Location.X, greenColor.Location.Y - 1);
            Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;
            selected.BackColor = Media_Distro.Properties.Settings.Default.Meadow_Theme_Preference;

            Media_Distro.Properties.Settings.Default.Active_Theme_Preference = Media_Distro.Properties.Settings.Default.Meadow_Theme_Preference;
            Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = Media_Distro.Properties.Settings.Default.Meadow_Theme_TitleBar;
            Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = Media_Distro.Properties.Settings.Default.Meadow_Theme_SearchBar;
            Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = Media_Distro.Properties.Settings.Default.Meadow_Theme_WorkPlace;
            Media_Distro.Properties.Settings.Default.Active_Theme_Selected = Media_Distro.Properties.Settings.Default.Meadow_Theme_Selected;

            Media_Distro.Properties.Settings.Default.Save();
        }

        private void redColor_Click(object sender, EventArgs e)
        {
            selected.Location = new Point(redColor.Location.X, redColor.Location.Y - 1);
            Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;
            selected.BackColor = Media_Distro.Properties.Settings.Default.Fire_Theme_Preference;

            Media_Distro.Properties.Settings.Default.Active_Theme_Preference = Media_Distro.Properties.Settings.Default.Fire_Theme_Preference;
            Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = Media_Distro.Properties.Settings.Default.Fire_Theme_TitleBar;
            Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = Media_Distro.Properties.Settings.Default.Fire_Theme_SearchBar;
            Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = Media_Distro.Properties.Settings.Default.Fire_Theme_WorkPlace;
            Media_Distro.Properties.Settings.Default.Active_Theme_Selected = Media_Distro.Properties.Settings.Default.Fire_Theme_Selected;

            Media_Distro.Properties.Settings.Default.Save();
        }

        private void darkBlueColor_Click(object sender, EventArgs e)
        {
            selected.Location = new Point(darkBlueColor.Location.X, darkBlueColor.Location.Y - 1);
            Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;
            selected.BackColor = Media_Distro.Properties.Settings.Default.Twiligth_Theme_WorkPlace;

            Media_Distro.Properties.Settings.Default.Active_Theme_Preference = Media_Distro.Properties.Settings.Default.Default_Theme_Preference;
            Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = Media_Distro.Properties.Settings.Default.Default_Theme_TitleBar;
            Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = Media_Distro.Properties.Settings.Default.Default_Theme_SearchBar;
            Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = Media_Distro.Properties.Settings.Default.Twiligth_Theme_WorkPlace;
            Media_Distro.Properties.Settings.Default.Active_Theme_Selected = Media_Distro.Properties.Settings.Default.Default_Theme_Selected;

            Media_Distro.Properties.Settings.Default.Save();
        }

        private void blackColor_Click(object sender, EventArgs e)
        {
            selected.Location = new Point(blackColor.Location.X, blackColor.Location.Y - 1);
            Media_Distro.Properties.Settings.Default.selectedLocation = selected.Location.X;
            selected.BackColor = Media_Distro.Properties.Settings.Default.Dark_Theme_Preference;

            Media_Distro.Properties.Settings.Default.Active_Theme_Preference = Media_Distro.Properties.Settings.Default.Dark_Theme_Preference;
            Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar = Media_Distro.Properties.Settings.Default.Dark_Theme_TitleBar;
            Media_Distro.Properties.Settings.Default.Active_Theme_SearchBar = Media_Distro.Properties.Settings.Default.Dark_Theme_SearchBar;
            Media_Distro.Properties.Settings.Default.Active_Theme_WorkPlace = Media_Distro.Properties.Settings.Default.Dark_Theme_WorkPlace;
            Media_Distro.Properties.Settings.Default.Active_Theme_Selected = Media_Distro.Properties.Settings.Default.Dark_Theme_Selected;

            Media_Distro.Properties.Settings.Default.Save();
        }

        private void generalSettingsButton_Click(object sender, EventArgs e)
        {
            generalSettingsPanel.Visible = true;
            aboutPanel.Visible = false;
            helpPanel.Visible = false;
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            generalSettingsPanel.Visible = false;
            aboutPanel.Visible = false;
            helpPanel.Visible = true;
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            generalSettingsPanel.Visible = false;
            aboutPanel.Visible = true;
            helpPanel.Visible = false;
        }

        private void priceOption_ValueChanged(object sender, EventArgs e)
        {
            if (priceSettingLabel.Text.Contains("Movie"))
            {
                Media_Distro.Properties.Settings.Default.moviePrice = priceOption.Value;

                foreach (LibraryManager priceChange in movieCatalogue)
                    priceChange.Price = priceOption.Value;
            }
            else if (priceSettingLabel.Text.Contains("Music"))
            {
                Media_Distro.Properties.Settings.Default.musicPrice = priceOption.Value;

                foreach (LibraryManager priceChange in musicCatalogue)
                    priceChange.Price = priceOption.Value;
            }
            else if (priceSettingLabel.Text.Contains("Series"))
            {
                Media_Distro.Properties.Settings.Default.seriesPrice = priceOption.Value;

                foreach (LibraryManager priceChange in seriesCatalogue)
                    priceChange.Price = priceOption.Value;
            }

            Media_Distro.Properties.Settings.Default.Save();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            selected.Location = new Point(Media_Distro.Properties.Settings.Default.selectedLocation, selected.Location.Y);
            selected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_Preference;
            notificationSettingCheckBox.Checked = Media_Distro.Properties.Settings.Default.showNotification;
            priceOption.Value = Media_Distro.Properties.Settings.Default.moviePrice;
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
    }
}
